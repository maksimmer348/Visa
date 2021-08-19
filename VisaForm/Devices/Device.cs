using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VisaForm.ComPort;

namespace VisaForm.Devices.Libraries
{
    //TODO:индентифиактор запросов в будущем убрать отсюда инициализацию!
    //TODO:вернуть если понадобится public event Action<string> ResponseMessage;//прием обычных сообщений с прибора

    public abstract class Device
    {
        protected ManualResetEvent Suspense = new ManualResetEvent(true);//для приостановки петли измерений значений
        private Task Run;//рабочий поток

        private static MySerialPort Serial;//компорт
        public event Action<string, CommandImplicits> ResponseSpecMessage;//ивент для приема сообщений с прибора вида => ответ от прибора[20], команда прибору[:chan1:meas:volt ?] 
        public event Action<string, CommandImplicits> ResponseButtonMessage;//ивент для приема сообщений с прибора вида =>ответ от прибора[20, StartTheSupplyPSH], команда прибору[:chan1:meas:volt ?] 

        protected string Identifier = "?";//индентифиактор запросов в будущем убрать отсюда инициализацию!

        protected Device(ConfigDevice config, string identifier)
        {
            Serial = new MySerialPort(config.ChannelNumber, config.BaudRate, config.ParityBit);//конфиг компорта 
            Serial.ReceiveSpecMessage += ResponseSpec;//получение ответа вида => ответ от прибора[20], команда прибору[:chan1:meas:volt ?] 
            Serial.ReceiveButtonMessage += ResponseSpecButton;//получение ответов вида => ответ от прибора[20, StartTheSupplyPSH], команда прибору[:chan1:meas:volt ?] 
        }

        public void GetSetValue(CommandImplicits cmd)//отправка запроса и получение ответа от прибора
        {
            Run = Task.Run(async () => Work(cmd));
        }

        public void RepeatGetSetValue(params CommandImplicits[] cmd)//отправка запроса и получение ответа от прибора в петле
        {
            Run = Task.Run(async () => WorkRepeat(cmd));
        }

        private void WorkRepeat(CommandImplicits[] commands)
        {
            while (true)
            {
                foreach (var command in commands)
                {
                    Serial.Write(command);
                    Thread.Sleep(300);
                    Serial.Read(command);//отправляем команду и запрос на ее возврат через ивент
                    Suspense.WaitOne();//ожидание в сучае отправки команды упарвления в прибор
                }
            }
        }

        private void Work(CommandImplicits command)
        {
            if (!command.Command.Contains(Identifier))//если это приказ то ответ нам не нужен
                //пр вызове метода inplictis рабоат не буде  потом унужно явно указать сслку на строку
                //command.Command.Contains а не command.Contains
            {
                Suspense.Reset();// приостановка петли измерений значений, для отправки команды в прибор

                Serial.Write(command);//в случае с ипликтис тут как раз можно указывать напряму те
                //command а не command.Command, но тк ипликт раскрывается в метода Write не нужно

                Suspense.Set();//продолить петлю измерений значений
            }
            else//если запрос требуем ответа
            {
                Suspense.Reset();// приостановка петли измерений значений, для отправки команды в прибор

                Serial.Write(command);
                Thread.Sleep(300);
                Serial.Read(command);

                Suspense.Set();//продолить петлю измерений значений
            }
        }

        /// <summary>
        /// ответ от прибора 
        /// </summary>
        /// <param name="response">ответ[команда прибору]</param>
        /// <param name="cmd">ответ от прибора</param>
        void ResponseSpec(string response, CommandImplicits cmd)
        {
            ResponseSpecMessage?.Invoke(response, cmd);
        }

        /// <summary>
        /// ответ от прибора 
        /// </summary>
        /// <param name="response">ответ[команда прибору, имя кнопки]</param>
        /// <param name="cmd">ответ от прибора</param>
        void ResponseSpecButton(string response, CommandImplicits cmd)
        {
            ResponseSpecMessage?.Invoke(response, cmd);
        }
    }
}