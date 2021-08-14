using System;
using System.Linq;
using System.Threading;
using VisaForm.ComPort;

namespace VisaForm.Devices.Libraries
{
    public abstract class Device : IDevice
    {
        protected MySerialPort Serial;
        public event EventHandler<string> Received;
        protected string Identifier;
        
        private Thread thread;

        protected Device(string identifier)
        {
            Identifier = identifier;
        }

        public void SetConfig(ConfigDevice cfg)
        {
            Serial = new MySerialPort(cfg.ChannelNumber, cfg.BaudRate, cfg.ParityBit);
        }

        public string StartSendCommands(params string[] commands)
        {
            Start(() => SendCommands(commands));
        }

        public string SendCommands(params string[] commands)
        {
            string result = null;
            foreach (var command in commands)
            {
                if (command.Contains(Identifier))
                {
                    Serial.Write(command);
                    Thread.Sleep(500);
                    result = Serial.Read();
                }
                else
                {
                    Serial.Write(command);

                }
                Thread.Sleep(500);
            }

            return result;
        }

        public void Start(Action action)
        {
            thread = new Thread(new ThreadStart(action));
            thread.Start();
        }
        public abstract void Check();
    }
}