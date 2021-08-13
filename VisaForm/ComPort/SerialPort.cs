using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodSharp.SerialPort;

namespace VisaForm.ComPort
{
    class SerialPort
    {
        private int Number;
        private int BaudRate;
        private int Parity;
        private GodSerialPort serial;
        public event Action<string> ResieveErrorMessage;
        public event Action<string> ResieveMessage;

        public SerialPort(int number, int baudRate, int parity)
        {
            Number = number;
            BaudRate = baudRate;
            Parity = parity;
        }

        public void Open()
        {
            if (serial == null || !serial.IsOpen)
            {
                try
                {
                    serial = new GodSerialPort($"COM{Number}", BaudRate, Parity);
                    serial.Open();
                }
                catch (Exception exception)
                {
                    ResieveErrorMessage?.Invoke(exception.Message);
                }
            }

        }

        public void Write(string message)
        {
            const string END_OF_LINE = "\r\n";
            try
            {
                var dataBytes = Encoding.UTF8.GetBytes(message + END_OF_LINE);
                serial.Write(dataBytes);

            }
            catch (Exception exception)
            {
                ResieveErrorMessage?.Invoke(exception.Message);
            }
        }

        public void Read()
        {
            try
            {
                var dataBytes = Encoding.UTF8.GetString(serial.Read());
                ResieveMessage?.Invoke(RemoveUnnecessary(dataBytes));
            }
            catch (Exception exception)
            {
                ResieveErrorMessage?.Invoke(exception.Message);
            }
        }

        public void Close()
        {
            if (serial != null && serial.IsOpen)
            {
                try
                {

                    serial.Close();

                }
                catch (Exception exception)
                {
                    ResieveErrorMessage?.Invoke(exception.Message);
                }
            }
        }
        string RemoveUnnecessary(string message)
        {
            var unnecessary = new[] { '?', '\n', '\r' };
            return String.Join("", message.Where((ch) => !unnecessary.Contains(ch)));
        }

    }
}
