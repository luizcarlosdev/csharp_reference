using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculus
{
    class TimesTable
    {
        public static void ShowTimesTable()
        {
            Console.Write("Please enter the number to show its times table: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(num + " x " + i + " = " + num * i);
            }
        }
    }
}
