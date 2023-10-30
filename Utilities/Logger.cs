using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e.Utilities
{
    internal class Logger
    {
        public static void Log(object message)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("[");
            System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("] [");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("e");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("] ");
            System.Console.WriteLine(message);
        }

        public static void LogError(object message)
        {
            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write("[");
            System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("] [");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("e");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("] ");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogWarning(object message)
        {
            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write("[");
            System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("] [");
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("e");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("] ");
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(message);
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
