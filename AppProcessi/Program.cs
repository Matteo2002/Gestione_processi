﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProcessi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Esercitazione sulla gestione dei processi");
            Process.Start("Notepad.exe");

            Process.Start("Notepad.exe", @"\\dc01srv\_Condivisa\INF\4 A\Matteo Uras\Gestione_processi\AppProcessi\Hello_World.txt");

            Process.Start(@"Chrome.exe", @"https://www.youtube.it");

            //Con questo sistema creo un processo
            var app = new Process();

            app.StartInfo.FileName = @"Notepad.exe";
            app.StartInfo.Arguments = @"\\dc01srv\_Condivisa\INF\4 A\Matteo Uras\Gestione_processi\AppProcessi\Hello_World.txt";
            app.Start();
            app.PriorityClass = ProcessPriorityClass.RealTime;

            //app.WaitForExit();
            var Processes = Process.GetProcesses();
            foreach (var p in Processes)
            {
                if(p.ProcessName=="notepad")
                {
                    //Prendo il processo e lo ammazzo
                    p.Kill();
                }
            }

            Console.WriteLine("Programma terminato!");
            Console.ReadLine();

        }
    }
}
