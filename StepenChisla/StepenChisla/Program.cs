using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepenChisla
{
    class Program
    {
        private static void MessAsk(string message)//для сообщений на белом фоне черными буквами
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ResetColor();
        }
        private static void MessGreen(string message)//для зеленых сообщений
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }
        private static void MessYellow (string message)//для желтых сообщений
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ResetColor();
        }
        private static void MessRed(string message)//для красных сообщений (сообщений об ошибках)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
        }
        public static int Check(int min, int max)//проверка входных данных
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out n) && n >= min && n <= max;//число относится к целому типу, больше минимума и меньше максимума
                if (ok == false)
                    MessRed("\nОшибка! Повторите ввод: ");
            } while (!ok);
            return n;
        }
        private static void ChisloStepen(int number)//поиск числа 
        {
            bool ok = false;
            for(int i = 2; i<Math.Sqrt(number); i++)//перебор чисел от двух до корня исходного числа
            {
                if(number % i == 0)//если исходное число делится без остатка на перебирающее число
                {
                    double x = Math.Log10(number) / Math.Log10(i);//определяется потенциальная степень исходного числа по минимальному
                                                                  //с помощью отношения логарифма исходного числа и логарифма перебирающего числа
                    int xx = Convert.ToInt32(x);//приведение потенциальной степени к целому типу
                    if (Math.Pow(i, xx) == number)//если при возведении перебирающего числа в потенциальную 
                    {                             //степень целого типа получится исходное число
                        MessGreen("\n YES");//печатается сообщение 
                        ok = true;//флажок о том, что степень верно определена
                        break;//программа останавливает перебор
                    }
                }
            }
            if(!ok)//если не определена степень, то выводит сообщение, что число не степенное
                MessRed("\n NO");
        }
        private static List<int> chisla = new List<int>();
        static void Main()
        {
            MessYellow("\n Введите колличество элементов (от 1 до 10): ");
            int x = Check(1, 10);//запрос на ввод числа в промежутке от 1 до 10 включитально
            for(int i = 0; i<x; i++)
            {
                MessYellow("\n Введите " + (i+1) + " число (допусимый диапазон от 1 до 1000000000): ");
                int n = Check(1, 1000000000);//запрос на ввод числа в промежутке от 1 до 10^9 включительно
                chisla.Add(n);//добавление числа в список
            }
            for (int i = 0; i < x; i++)//перебор чисел, занесенных в список
                ChisloStepen(chisla[i]);//проверка относится ли число из списка к степенному или нет, печать сообщений
            MessYellow("\n Нажмите любую клавишу чтобы выйти из программы...");
            Console.ReadKey();
        }
    }
}
