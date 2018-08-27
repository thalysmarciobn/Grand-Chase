using System;

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
                Console.Write(" [ INFO ] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(message);
                Console.WriteLine();
            }
        }
        
        public static void Server(string message)
        {
            lock (Lock)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" [ SERVER ] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(message);
                Console.WriteLine();
            }
        }
        
        public static void Alert(string message)
        {
            lock (Lock)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" [ ALERT ] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(message);
                Console.WriteLine();
            }
        }
    }
}