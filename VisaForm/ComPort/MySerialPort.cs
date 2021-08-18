﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodSharp.SerialPort;
using VisaForm.Devices;

namespace VisaForm.ComPort
{
    public class MySerialPort
    {
        private readonly int Number;
        private readonly int BaudRate;
        private readonly int Parity;
        private GodSerialPort Serial;

        public event Action<Exception> ReceiveErrorMessage;//вывод исключений
        public event Action<string> ReceiveMessage;//вывод стандартных ответов
        public event Action<string, CommandImplicits> ReceiveSpecMessage;//вывод ответов вида => ответ от прибора[20], команда прибору[:chan1:meas:volt ?] 

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
                    throw exception;
                }
            }
        }

        public void Write(CommandImplicits message)
        {
            Open();
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

        /// <summary>
        /// чтение из компорта
        /// </summary>
        /// <param name="cmd">передача команды в ответе для идентификации</param>
        /// <param name="loop">необходимость в передаче команды в ответе</param>
        public void Read(CommandImplicits cmd = null, bool loop = false)
        {
            try
            {
                var dataBytes = Encoding.UTF8.GetString(Serial.Read());
                var returnSting = RemoveUnnecessary(dataBytes);
                if (loop)
                {
                    ReceiveSpecMessage?.Invoke(returnSting, cmd);//передача ответа от прибора и команды в инвет
                }
                else
                {
                    ReceiveMessage?.Invoke(returnSting);//передача только ответа от прибора
                }
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

        static string RemoveUnnecessary(string message)//удаление мусора для строки ответа
        {
            var unnecessary = new[] { '?', '\n', '\r' };
            return String.Join("", message.Where((ch) => !unnecessary.Contains(ch)));
        }

    }
}
