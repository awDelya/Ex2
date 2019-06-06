using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepenChisla
{
    class Program
    {
        private static void MessAsk(string message)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
        }
        private static void MessGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }
        private static void MessYellow (string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ResetColor();
        }
        private static void MessRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
        }
        public static int Check(int min, int max)
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out n) && n >= min && n <= max;
                if (ok == false)
                    MessRed("\nОшибка! Повторите ввод: ");
            } while (!ok);
            return n;
        }
        static void Main()
        {
            MessYellow("\n Введите колличество элементов: ");
            int x = Check(1, 10);
        }
    }
}
