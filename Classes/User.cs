namespace Classes
{
    public class User : Base
    {
        public User() { }

        public User(string name, string phone, string cpf)
        {
            this.setName(name);
            this.setPhone(phone);
            this.setCpf(cpf);
        }
    }
}
