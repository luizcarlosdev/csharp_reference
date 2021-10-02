using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Classes
{
    public class Base : IPerson
    {
        
        public Base() { }

        public Base(string name, string phone, string cpf)
        {
            this.name = name;
            this.phone = phone;
            this.cpf = cpf;
        }
        
        private string name;
        private string phone;
        private string cpf;

        private string getFilePath()
        {
            return ConfigurationManager.AppSettings["BaseDirPath"] + this.GetType().Name.ToLower() + "s.csv";
        }

        public Base Create()
        {
            var b = Activator.CreateInstance(this.GetType());

            Console.Write("Name: ");
            this.setName(Console.ReadLine());
            Console.Write("Phone: ");
            this.setPhone(Console.ReadLine());
            Console.Write("CPF: ");
            this.setCpf(Console.ReadLine());

            return this;
        }

        public List<IPerson> Read()
        {
            var data = new List<IPerson>();
            Console.WriteLine("READING FROM " + getFilePath());
            if (File.Exists(getFilePath()))
            {
                using (StreamReader file = File.OpenText(getFilePath()))
                {
                    string row;
                    int i = 0;
                    while((row = file.ReadLine()) != null)
                    {
                        i++;
                        if (i == 1) continue;

                        var baseFile = row.Split(';');
                        var b = new Base(baseFile[0], baseFile[1], baseFile[2]);
                        data.Add(b);
                    }
                }
            }
            return data;
        }
        
        public void Record()
        {
            var data = Read();
            data.Add(this);
            if (File.Exists(getFilePath()))
            {
                StreamWriter sw = new StreamWriter(getFilePath());
                sw.WriteLine("name;phone;cpf;");
                foreach(Base b in data)
                {
                    var row = b.name + ";" + b.phone + ";" + b.cpf + ";";
                    sw.WriteLine(row);
                }
                sw.Close();
            }
        }

        public void CreateAndRecord()
        {
            this.Create();
            this.Record();
        }

        public string getName()
        {
            return this.name;
        }
        
        public void setName(string name)
        {
            this.name = name;
        }

        public string getPhone()
        {
            return this.phone;
        }

        public void setPhone(string phone)
        {
            this.phone = phone;
        }

        public string getCpf()
        {
            return this.cpf;
        }

        public void setCpf(string cpf)
        {
            this.cpf = cpf;
        }

        public override string ToString()
        {
            return ("Name:: " + name +
                "\nPhone: " + phone +
                "\nCPF::: " + cpf +
                "\n==============================");
        }
    }
}
