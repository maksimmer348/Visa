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
        private GodSerialPort Serial;
        public event Action<Exception> ReceiveErrorMessage;
        public event Action<string> ReceiveMessage;

        public SerialPort(int number, int baudRate, int parity)
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
                ReceiveErrorMessage?.Invoke(exception);
            }
        }

        public void Read()
        {
            try
            {
                var dataBytes = Encoding.UTF8.GetString(Serial.Read());
                ReceiveMessage?.Invoke(RemoveUnnecessary(dataBytes));
            }
            catch (Exception exception)
            {
                ReceiveErrorMessage?.Invoke(exception);
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
            var unnecessary = new[] {'?', '\n', '\r'};
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
        SerialPort Gsp = new SerialPort(4, 9600, 0);

        public PingCmd()
        {
            Gsp.ReceiveMessage += Send;
            Gsp.Open();
        }

        public void Run(string message)
        {

            if (!string.IsNullOrWhiteSpace(message))
            {
                if (message.Contains('?'))
                {
                    Gsp.Write(message);
                    Thread.Sleep(500);
                    Gsp.Read();
                    Thread.Sleep(500);
                }
                else
                {
                    Gsp.Write(message);
                }
            }
        }

        public void AOAOA()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"i = {i}");
                Thread.Sleep(1000);
            }
        }

        public void Send(string message)
        {
            Console.WriteLine(message);
        }
        public void SendErrors(Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    class Program
    {
        static PingCmd p = new PingCmd();

        static void Main(string[] args)
        {
            p.Run(":outp:stat 1");
            p.Run(":outp:stat?");
            p.Run(":chan1:meas:curr ?");
            p.Run(":chan1:meas:volt ?");
            p.Run(":outp:stat 0");
            p.Run(":outp:stat?");
            Console.ReadLine();
            //Thread thr = new Thread(delegate () { SendToSupply1(message); });
            //thr.Name = $"MyDevice 1";
            //thr.Start();
        }

//static void SendToSupply1(string message)
        //{
        //    p.Run(message);
        //}
        //static void SendToSupply1()
        //{
        //    p.AOAOA();
        //}

    }

}
