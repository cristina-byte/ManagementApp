using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Admin : User
    {
        public Admin(string name, string password, string email, BigInteger phone, BigInteger cnp, DateTime birthDay) : base(name, password, email, phone, cnp, birthDay)
        {

        }

        public Admin(string email,string password) : base(email, password)
        {

        }

        public override string ToString(){
            return $"\nName: _name \nEmail: _email \nPhone: _phone \nBorned at: _birthDay \nCnp:_cnp";
        }
    }
}
