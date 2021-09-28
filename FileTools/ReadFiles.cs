using System;
using System.Configuration;
using System.IO;

namespace FileTools
{
    class ReadFiles
    {
        private static string getFilePath()
        {
            return ConfigurationManager.AppSettings["filePath"];
        }

        public static void ShowReadFiles(int fileNumber)
        {
            string filePath = getFilePath() + "file" + fileNumber + ".txt";

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

            string filePath2 = getFilePath() + "file" + (fileNumber++) + ".txt";

            if (File.Exists(filePath2))
            {
                ShowReadFiles(fileNumber);
            }
        }
    }
}
