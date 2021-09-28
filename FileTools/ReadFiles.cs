using System;
using System.IO;

namespace FileTools
{
    class ReadFiles
    {
        public static void ShowReadFiles(int fileNumber)
        {
            string filePath = @Environment.CurrentDirectory + "\\..\\..\\file" + fileNumber + ".txt";

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

            string filePath2 = @Environment.CurrentDirectory + "\\..\\..\\file" + (fileNumber++) + ".txt";

            if (File.Exists(filePath2))
            {
                ShowReadFiles(fileNumber);
            }
        }
    }
}
