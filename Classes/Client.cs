using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace Classes
{
    public class Client
    {
        private string name;
        private string phone;
        private string cpf;

        public static Client CreateClient()
        {
            Client client = new Client();

            Console.Write("Type your name: ");
            client.name = Console.ReadLine();
            Console.Write("Type your phone (numbers only): ");
            client.phone =Console.ReadLine();
            Console.Write("Type your CPF (numbers only): ");
            client.cpf = Console.ReadLine();

            return client;
        }

        public static void RecordClient(Client client)
        {
            //DONE: write client into a file - HIGH MEMORY USAGE
            List<Client> clients = GetClients();

            clients.Add(client);

            string filePath = getFilePath() + "clients.txt";

            if (File.Exists(filePath))
            {
                string content = "name;phone;cpf;";
                
                foreach(Client c in clients)
                {
                    content += "\n" + c.name + ";" + c.phone + ";" + c.cpf + ";";
                }

                File.WriteAllText(filePath, content);
            }
        }

        public static void RecordClient()
        {
            RecordClient(CreateClient());
        }

        private static string getFilePath()
        {
            return ConfigurationManager.AppSettings["ClientsDatabasePath"];
        }

        public static List<Client> GetClients()
        {
            var clients = new List<Client>();
            string filePath = getFilePath() + "clients.txt";

            if (File.Exists(filePath))
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    Console.WriteLine("\nFile: " + filePath);
                    string row;
                    int i = 0;
                    while ((row = file.ReadLine()) != null)
                    {
                        if (i == 0)
                        {
                            i++;
                            continue;
                        }

                        var actualClient = row.Split(';');
                        
                        // Instantiate a new Client WITHOUT CONSTRUCTOR, using named args
                        Client client = new Client
                        {
                            name = actualClient[0],
                            phone = actualClient[1],
                            cpf = actualClient[2]
                        };

                        clients.Add(client);
                    }
                }
            }

            return clients;
        }

        public static void ShowClients()
        {
            foreach (Client client in GetClients())
            {
                Console.WriteLine(client.ToString());
            }
        }

        public override string ToString()
        {
            return ("Name:: " + name +
                "\nPhone: " + phone +
                "\nCPF::: " + cpf);
        }
    }
}
