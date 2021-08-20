using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        protected string Identifier = "?";//индентифиактор запросов в будущем убрать отсюда инициализацию!

        protected Device(ConfigDevice config, string identifier)
        {
            Serial = new MySerialPort(config.ChannelNumber, config.BaudRate, config.ParityBit);//конфиг компорта 
            Serial.ReceiveSpecMessage += ResponseSpec;//получение ответа вида => ответ от прибора[20], команда прибору[:chan1:meas:volt ?] 
        }

        public void GetSetValue(CommandImplicits cmd)//отправка запроса и получение ответа от прибора
        {
            Run = Task.Run(async () => Work(cmd));
        }
        public void GetSetSpecValue(CommandImplicits cmd, RequestAndResponse requestAndResponse, Button btn)//отправка запроса и получение ответа от прибора
        {
            Run = Task.Run(async () => WorkSpec(cmd, requestAndResponse,btn));

        }
        public void RepeatGetSetValue(params CommandImplicits[] cmd)//отправка запроса и получение ответа от прибора в петле
        {
            Run = Task.Run(async () => WorkRepeat(cmd));
        }
        CancellationTokenSource repeatToken;
        private void WorkRepeat(CommandImplicits[] commands)
        {
            while (true)
            {
                foreach (var command in commands)
                {

                    Serial.Write(command);
                    Thread.Sleep(200);
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
                Thread.Sleep(200);
                Serial.Read(command);

                Suspense.Set();//продолить петлю измерений значений
            }
        }

        private void WorkSpec(CommandImplicits command,RequestAndResponse requestAndResponse, Button button)
        {
            //repeatToken.Cancel();
            Suspense.Reset();// приостановка петли измерений значений, для отправки команды в прибор
            
            Thread.Sleep(200);
            Serial.Write(command);
            Thread.Sleep(200);
            Serial.Read(command,true);
            if (Serial.CommandResponse.Command == requestAndResponse.ResponseCommandTrue)//если комнада от прибора 1 то мы отправаляем прибору команду1
            {
                Serial.Write(requestAndResponse.CommandApply1);
            }
            else if(Serial.CommandResponse.Command == requestAndResponse.ResponseCommandFalse)//если комнада от прибора 0 то мы отправаляем прибору команду2
            {
                Serial.Write(requestAndResponse.CommandApply2);
            }
            Suspense.Set();//продолить петлю измерений значений
            
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

    }
}