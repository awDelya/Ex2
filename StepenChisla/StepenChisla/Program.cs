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
        private static void ChisloStepen(int number)
        {
            bool ok = false;
            for(int i = 2; i<number; i++)
            {
                if(number % i == 0)
                {
                    double x = Math.Log10(number) / Math.Log10(i);
                    if (Math.Pow(i, x) == number)
                    {
                        MessGreen("\n YES");
                        ok = true;
                        break;
                    }
                }
            }
            if(!ok)
                MessRed("\n NO");
        }
        private static List<int> chisla = new List<int>();
        static void Main()
        {
            MessYellow("\n Введите колличество элементов (от 1 до 10): ");
            int x = Check(1, 10);
            for(int i = 0; i<x; i++)
            {
                MessYellow("\n Введите " + (i+1) + " число (допусимый диапазон от 1 до 1000000000): ");
                int n = Check(1, 1000000000);
                chisla.Add(n);
            }
            for (int i = 0; i < x; i++)
                ChisloStepen(chisla[i]);
            MessYellow("\n Нажмите любую клавишу чтобы выйти из программы...");
            Console.ReadKey();
        }
    }
}
