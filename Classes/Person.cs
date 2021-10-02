using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IPerson
    {
        void Record();
        void setName(string name);
        void setPhone(string phone);
        void setCpf(string cpf);
    }
}
