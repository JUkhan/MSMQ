﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public static void Message(string str)
         {
            string path = @"C:\Jasim Khan\test_project\log.txt";
            System.IO.File.AppendAllText(path, DateTime.Now.ToShortDateString() + " : " + str + Environment.NewLine + "-------------------" + Environment.NewLine);
        }
        static void Main(string[] args)
        {
            Message("Hellow world!");

            ServiceRef.Service1Client client = new ServiceRef.Service1Client();
            client.GetData(100);
            Console.WriteLine("end...");
            client.Close();                 
            Console.ReadKey();
        }
    }
}
