using System;

namespace UI
{
    class MainMenu
    {
        public static int showMainMenu()
        {
            Console.Clear();
            Console.WriteLine("################################################################################");
            Console.WriteLine("#                                  C# Reference                                #");
            Console.WriteLine("################################################################################");
            Console.WriteLine("# 0 - Exit program                        1 - Read Files                       #");
            Console.WriteLine("# 2 - Times table                         3 - Average calculator               #");
            Console.WriteLine("# 4 - Create and Record Client            5 - List Clients                     #");
            Console.WriteLine("################################################################################");
            Console.Write("Please type the desired program number: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
