using Calculus;
using FileTools;
using System;
using UI;

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
                switch (MainMenu.showMainMenu())
                {
                    case 0:
                        loop = !loop;
                        break;
                    case 1:
                        ReadFiles.ShowReadFiles(1);
                        break;
                    case 2:
                        TimesTable.ShowTimesTable();
                        break;
                    case 3:
                        Average.ShowAverageCalculator();
                        break;
                }

                Console.WriteLine("\nPress ENTER to exit...");
                Console.ReadLine();
            }

        }

    }
}
