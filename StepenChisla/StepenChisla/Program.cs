using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepenChisla
{
    public class Color
    {
        public static void Mess(string message, ConsoleColor c)//для цветных сообщений
        {
            Console.ForegroundColor = c;
            Console.Write(message);
            Console.ResetColor();
        }       
    }

    class Program
    {
        private static List<int> chisla = new List<int>();
        public static int Check(int min, int max)//проверка входных данных
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out n) && n >= min && n <= max;//число относится к целому типу, больше минимума и меньше максимума
                if (ok == false)
                    Color.Mess("\nОшибка! Повторите ввод: ", ConsoleColor.Red);
            } while (!ok);
            return n;
        }
        private static void ChisloStepen(int number)//поиск числа 
        {
            bool ok = false;
            for(int i = 2; i<=Math.Sqrt(number); i++)//перебор чисел от двух до корня исходного числа
            {
                if(number % i == 0)//если исходное число делится без остатка на перебирающее число
                {
                    double x = Math.Log10(number) / Math.Log10(i);//определяется потенциальная степень исходного числа по минимальному
                                                                  //с помощью отношения логарифма исходного числа и логарифма перебирающего числа
                    int xx = Convert.ToInt32(x);//приведение потенциальной степени к целому типу
                    if (Math.Pow(i, xx) == number)               //если при возведении перебирающего числа в потенциальную 
                    {                                            //степень целого типа получится исходное число
                        Color.Mess("\n YES", ConsoleColor.Green);//печатается сообщение 
                        ok = true;                               //флажок о том, что степень верно определена
                        break;                                   //программа останавливает перебор
                    }
                }
            }
            if(!ok)//если не определена степень, то выводит сообщение, что число не степенное
                Color.Mess("\n NO", ConsoleColor.Red);
        }
        static void Main()
        {
            Color.Mess("\n Введите колличество элементов (от 1 до 10): ", ConsoleColor.Yellow);
            int x = Check(1, 10);//запрос на ввод числа в промежутке от 1 до 10 включитально
            for(int i = 0; i<x; i++)
            {
                Color.Mess("\n Введите " + (i+1) + " число (допусимый диапазон от 1 до 1000000000): ", ConsoleColor.Yellow);
                int n = Check(1, 1000000000);//запрос на ввод числа в промежутке от 1 до 10^9 включительно
                chisla.Add(n);//добавление числа в список
            }
            for (int i = 0; i < x; i++)//перебор чисел, занесенных в список
                ChisloStepen(chisla[i]);//проверка относится ли число из списка к степенному или нет, печать сообщений
            Color.Mess("\n Нажмите любую клавишу чтобы выйти из программы...", ConsoleColor.Yellow);
            Console.ReadKey();
        }
    }
}
