using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculus
{
    class Average
    {
        public static void ShowAverageCalculator()
        {
            int num = 1;
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter desired numbers and press ENTER for each one (0 to finish): ");

            do
            {
                num = int.Parse(Console.ReadLine());
                if (num == 0)
                {
                    break;
                }
                numbers.Add(num);
            } while (num != 0);

            Console.WriteLine("The average between given numbers is: " + numbers.Sum() / numbers.Count);
        }
    }
}
