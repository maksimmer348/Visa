using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Ivi.Visa;
using NationalInstruments.Visa;
using GodSharp.SerialPort;

namespace visa
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
    interface ICmd
    {
        void Run(string message);
        void Send(string message);
    }

    class PingCmd : ICmd
    {
        SerialPort gsp = new SerialPort(4, 9600, 0);
        public PingCmd()
        {
            gsp.ResieveMessage += Send;
            gsp.ResieveErrorMessage += Send;
            gsp.Open();
        }
        public void Run(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (message.Contains('?'))
                {
                    gsp.Write(message);
                    Thread.Sleep(500);
                    gsp.Read();
                    Thread.Sleep(500);
                }
                else
                {
                    gsp.Write(message);
                }
            }
        }
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        static PingCmd p = new PingCmd();
        static void Main(string[] args)
        {

            while (true)
            {

                var message = Console.ReadLine();
                Thread thr = new Thread(delegate () { SendToSupply1(message); });
                thr.Name = "1";
                thr.Start();

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"i = {i}");
                    Thread.Sleep(1000);
                }

                
                //p.RunAnsw(":chan1:meas:curr ?");
                //p.RunAnsw(":chan1:meas:volt ?");
                //p.RunAnsw(":outp:stat 0");
                //p.RunAnsw(":outp:stat?");

                //Thread thr = new Thread(delegate () { SendToSupply1(message); });
                //thr.Name = $"MyDevice 1";
                //thr.Start();
            }
        }

        static void SendToSupply1(string message)
        {
            p.Run(message);
        }

    }
}
