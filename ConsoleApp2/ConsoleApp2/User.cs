using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class User
    {
        public string name;
        public string password;
        public string email;
        public BigInteger phone;
        public BigInteger cnp;
        public DateTime birthDay;

        public User(string _name,string _password,string _email, BigInteger _phone,BigInteger _cnp, DateTime _birthDay)
        {
            name= _name;
            password= _password;
            email= _email;
            phone= _phone;
            cnp= _cnp;  
            birthDay= _birthDay;
        }



        public DateTime BirthDay { get; set; }
        public string Email { get; set; }   
        public BigInteger Phone { get; set; }
        public BigInteger Cnp { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return "This is a simple user" + "\n" + "Name:" + name + "\nEmail:" + email + "\nPhone:" + phone + "\nBorned at:" + birthDay + "\nCnp:" + cnp;
        }
        
        public void authentificate(string password,string email)
        {
            Console.WriteLine("Authentification using password and email");

        }

        public void authentificate(string email)
        {
            Console.WriteLine("Authentification using a google account");

        }
       

    }
}
