﻿namespace Classes
{
    public class Client : Base
    {
        public Client(){ }

        public Client(string name, string phone, string cpf)
        {
            this.setName(name);
            this.setPhone(phone);
            this.setCpf(cpf);
        }
    }
}
