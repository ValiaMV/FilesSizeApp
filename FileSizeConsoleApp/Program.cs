﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileSizeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"C:\Users\mager43\Downloads");

            Parallel.ForEach(files, (currentFile) =>
            {
                Console.WriteLine($"{new FileInfo(currentFile).Length}");
            });
            Console.ReadKey();
        }
    }
}