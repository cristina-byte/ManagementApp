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
        public Admin(string _name, string _password, string _email, BigInteger _phone, BigInteger _cnp, DateTime _birthDay) : base(_name, _password, _email, _phone, _cnp, _birthDay)
        {
        }

        public override string ToString()
        {
            return "This is an admin. He has special rights" + "\n" + "Name:" + name + "\nEmail:" + email + "\nPhone:" + phone + "\nBorned at:" + birthDay + "\nCnp:" + cnp;
        }


    }
}
