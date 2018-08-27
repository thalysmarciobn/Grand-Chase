﻿using System;

namespace Common.Log
{
    public class Logging
    {
        private static readonly object Lock = new object();
        
        public static void Info(string message)
        {
            lock (Lock)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" [INFO] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(message);
                Console.WriteLine();
            }
        }
    }
}