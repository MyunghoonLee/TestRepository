using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Program
    {
        class Calendar
        {
            public static void Print(int y, int m, int d, int dow, bool flag)
            {
                int day = 1;
                int cnt = 0;
                if (flag == false && m == 2) { d = 29; }
                Console.WriteLine("\n\t\t\t   " + y + "년 " + m + "월");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\t일");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t월\t화\t수\t목\t금\t토\n");
                ///////////////////////////
                for (int i = 0; i < 7; i++)
                {
                    if (i == dow)
                    {
                        if (i == 0) { Console.ForegroundColor = ConsoleColor.Red; }
                        Console.Write("\t" + day);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (i > dow)
                    {
                        day++;
                        Console.Write("\t" + day);
                    }
                    else { Console.Write("\t"); }
                }
                Console.WriteLine("\n");
                while (true)
                {
                    if (day >= d) { break; }
                    else if (cnt == 7) { cnt = 0; Console.WriteLine("\n"); }
                    else
                    {
                        day++;
                        if (cnt == 0) { Console.ForegroundColor = ConsoleColor.Red; }
                        Console.Write("\t" + day);
                        Console.ForegroundColor = ConsoleColor.White;
                        cnt++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            int totalDay = 0;

            while (true)
            {
                bool flag = true;
                int[] monthArray = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                totalDay = (year - 1) * 365 + ((year - 1) / 4 - (year - 1) / 100 + (year - 1) / 400);
                for (int i = 0; i < month - 1; i++)
                {
                    totalDay = totalDay + monthArray[i];
                }
                if (month >= 3 && ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0))
                {
                    totalDay++;
                }
                totalDay++;
                int dayOfWeek = totalDay % 7;
                if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                {
                    flag = false;
                }

                Calendar.Print(year, month, monthArray[month - 1], dayOfWeek, flag);
                ConsoleKeyInfo info = Console.ReadKey();
                Console.Clear();
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (month == 12) { }
                    else { month++; }
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    if (month == 1) { }
                    else { month--; }
                }
                else if (info.Key == ConsoleKey.LeftArrow)
                {
                    if (year == 1) { }
                    year--;
                }
                else if (info.Key == ConsoleKey.RightArrow)
                {
                    year++;
                }
            }
        }
    }
}
