using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_reference
{
    class Program
    {
        enum MENU_OPTIONS { EXIT, READ_FILES, TIMES_TABLE, AVERAGE_CALC };

        static void Main(string[] args)
        {
            bool loop = true;

            while (loop)
            {
                switch (showMenu())
                {
                    case 0:
                        loop = !loop;
                        break;
                    case 1:
                        ReadFiles(1);
                        break;
                    case 2:
                        ShowTimesTable();
                        break;
                    case 3:
                        ShowAverageCalculator();
                        break;
                }

                Console.WriteLine("\nPress ENTER to exit...");
                Console.ReadLine();
            }

        }

        private static int showMenu()
        {
            Console.Clear();
            Console.WriteLine("################################################################################");
            Console.WriteLine("#                                  C# Reference                                #");
            Console.WriteLine("################################################################################");
            Console.WriteLine("# 0 - Exit program                        1 - Read Files                       #");
            Console.WriteLine("# 2 - Times table                         3 - Average calculator               #");
            Console.WriteLine("################################################################################");
            Console.Write("Please type the desired program number: ");
            return int.Parse(Console.ReadLine());
        }

        private static void ReadFiles(int fileNumber)
        {
            string filePath = @Environment.CurrentDirectory + "\\file" + fileNumber+ ".txt";

            if (File.Exists(filePath))
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    Console.WriteLine("\nFile: " + filePath);
                    string row;
                    while ((row = file.ReadLine()) != null)
                    {
                        Console.WriteLine(row);
                    }
                }
            }

            string filePath2 = @Environment.CurrentDirectory + "\\file" + (fileNumber++) + ".txt";

            if (File.Exists(filePath2))
            {
                ReadFiles(fileNumber);
            }
        }

        private static void ShowTimesTable()
        {
            Console.Write("Please enter the number to show its times table: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(num + " x " + i + " = " + num * i);
            }
        }

        private static void ShowAverageCalculator()
        {
            int num = 1;
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter desired numbers and press ENTER for each one (0 to finish): ");

            do
            {
                num = int.Parse(Console.ReadLine());
                if(num == 0)
                {
                    break;
                }
                numbers.Add(num);
            } while (num != 0);

            Console.WriteLine("The average between given numbers is: " + numbers.Sum() / numbers.Count);
        }
    }
}
