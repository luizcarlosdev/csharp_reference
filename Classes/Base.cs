using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Base : Person
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
            return @ConfigurationManager.AppSettings["BaseDirPath"] + this.GetType().Name.ToLower() + "s.csv";
        }

        public Base Create()
        {
            Base b = new Base();

            Console.Write("Name: ");
            b.setName(Console.ReadLine());
            Console.Write("Phone: ");
            b.setPhone(Console.ReadLine());
            Console.Write("CPF: ");
            b.setCpf(Console.ReadLine());

            return b;
        }

        public List<Base> Read()
        {
            var data = new List<Base>();
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
        
        //FIX
        public void Record()
        {
            var data = new Base().Read();
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
            Base b = Create();
            b.Record();
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
