using Calculus;
using Classes;
using FileTools;
using UI;
using System;
using System.Collections.Generic;

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
                    case 4:
                        new Client().CreateAndRecord();
                        break;
                    case 5:
                        var clients = new Client().Read();
                        foreach(Base client in clients) { Console.WriteLine(client.ToString()); }
                        break;
                    case 6:
                        new User().CreateAndRecord();
                        break;
                    case 7:
                        var users = new User().Read();
                        foreach (Base user in users) { Console.WriteLine(user.ToString()); }
                        break;
                    default:
                        Console.WriteLine("Invalid option... Please try again!");
                        break;
                }

                Console.WriteLine("\nPress ENTER to exit...");
                Console.ReadLine();
            }
        }
    }
}
