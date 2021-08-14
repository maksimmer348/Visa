using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodSharp.SerialPort;

namespace VisaForm.ComPort
{
    public class MySerialPort
    {
        private int Number;
        private int BaudRate;
        private int Parity;
        private GodSerialPort Serial;
        public event Action<Exception> ReceiveErrorMessage;
        public event Action<string> ReceiveMessage;

        public MySerialPort(int number, int baudRate, int parity)
        {
            Number = number;
            BaudRate = baudRate;
            Parity = parity;
        }

        public void Open()
        {
            if (Serial == null || !Serial.IsOpen)
            {
                try
                {
                    Serial = new GodSerialPort($"COM{Number}", BaudRate, Parity);
                    Serial.Open();
                }
                catch (Exception exception)
                {
                    ReceiveErrorMessage?.Invoke(exception);
                }
            }

        }

        public void Write(string message)
        {
            const string END_OF_LINE = "\r\n";
            try
            {
                var dataBytes = Encoding.UTF8.GetBytes(message + END_OF_LINE);
                Serial.Write(dataBytes);

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string Read()
        {
            try
            {
                var dataBytes = Encoding.UTF8.GetString(Serial.Read());
                return dataBytes;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Close()
        {
            if (Serial != null && Serial.IsOpen)
            {
                try
                {
                    Serial.Close();

                }
                catch (Exception exception)
                {
                    ReceiveErrorMessage?.Invoke(exception);
                }
            }
        }

        static string RemoveUnnecessary(string message)
        {
            var unnecessary = new[] { '?', '\n', '\r' };
            return String.Join("", message.Where((ch) => !unnecessary.Contains(ch)));
        }
    }
}
