using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VisaForm.ComPort;

namespace VisaForm.Devices.Libraries
{
    public abstract class Device
    {
        protected MySerialPort Serial;
        public event EventHandler<string> Received;
        protected string Identifier;


        private CancellationTokenSource repeatToken;

        protected Device(string identifier)
        {
            Identifier = identifier;
        }

        public void SetConfig(ConfigDevice cfg)
        {
            Serial = new MySerialPort(cfg.ChannelNumber, cfg.BaudRate, cfg.ParityBit);
        }

        public void RepeatCommands(params string[] commands)
        {
            repeatToken = new CancellationTokenSource();
            Task.Run(async () =>
            {
                while (!repeatToken.IsCancellationRequested)
                {
                    await SendCommands(commands);
                }
            }, repeatToken.Token);

        }
        public async Task<string> StartSendCommands(params string[] commands)
        {
            return await Task.Run(() => SendCommands(commands));
        }

        public async Task<string> SendCommands(string[] commands, CancellationTokenSource token = null)
        {
            token?.Cancel();
            await Task.Delay(500);

            string result = null;
            foreach (var command in commands)
            {
                if (command.Contains(Identifier))
                {
                    Serial.Write(command);
                    await Task.Delay(500);
                    result = Serial.Read();
                }
                else
                {
                    Serial.Write(command);

                }

                await Task.Delay(500);
            }

            return result;
        }

        public abstract void Check();
    }
}