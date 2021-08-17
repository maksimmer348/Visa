using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VisaForm.ComPort;

namespace VisaForm.Devices.Libraries
{
    public abstract class Device
    {
        private ManualResetEvent Suspense = new ManualResetEvent(true);//для приостановки петли измерений значений
        private Task Run;//рабочий поток
        private static MySerialPort Serial;//компорт
        public event Action<string> ResponseMessage;//прием обычных сообщений с прибора
        public event Action<string, string> ResponseSpecMessage;//прием сообщений с прибора вида => ответ от прибора[20], команда прибору[:chan1:meas:volt ?] 
        protected string Identifier = "?";//индентифиактор запросов 

        protected Device(ConfigDevice config, string identifier)
        {
            Serial = new MySerialPort(config.ChannelNumber, config.BaudRate, config.ParityBit);
            Serial.ReceiveMessage += Response;
            Serial.ReceiveSpecMessage += ResponseSpec;
        }

        public void GetValue(params string[] cmd)
        {
            Run = Task.Run(async () => WorkRepeat(cmd));
        }

        public void SetValue(string cmd)
        {
            Run = Task.Run(async () => Work(cmd));
        }

        private void WorkRepeat(string[] commands)
        {
            while (true)
            {
                foreach (var command in commands)
                {
                    Serial.Write(command);
                    Thread.Sleep(300);
                    Serial.Read(command, true);//отправляем команду и запрос на ее возврат через ивент
                    Suspense.WaitOne();
                }
            }
        }
        private void Work(string command)
        {
            if (!command.Contains(Identifier))//если это запрос то ответ нам не нужен
            {
                Suspense.Reset();// приостановка петли измерений значений
                Serial.Write(command);
                Suspense.Set();//продолить петлю измерений значений
            }
            else//если не запрос требуем ответа
            {
                Suspense.Reset();
                Serial.Write(command);
                Thread.Sleep(300);
                Serial.Read(command, true);//полуаем ответ
                Suspense.Set();
            }
        }


        void Response(string res)
        {
            ResponseMessage?.Invoke(res);
        }

        /// <summary>
        /// ответ от прибора 
        /// </summary>
        /// <param name="response">ответ</param>
        /// <param name="cmd"></param>
        void ResponseSpec(string response, string cmd)
        {
            ResponseSpecMessage?.Invoke(response, cmd);
        }
    }
}