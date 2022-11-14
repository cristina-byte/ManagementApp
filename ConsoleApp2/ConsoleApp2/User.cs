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
        public string _name;
        public string _password;
        public string _email;
        public BigInteger _phone;
        public BigInteger _cnp;
        public DateTime _birthDay;

        public User(string name,string password,string email, BigInteger phone,BigInteger cnp, DateTime birthDay)
        {
           _name= name;
           _password= password;
           _email= email;
           _phone= phone;
           _cnp= cnp;  
           _birthDay= birthDay;
        }
        public DateTime BirthDay { get; set; }
        
        public string Email { get; set; }   
        
        public BigInteger Phone { get; set; }
       
        public BigInteger Cnp { get; set; }
       
        public string Name { get; set; }
       
        public string Password { get; set; }

        public override string ToString()
        {
            return "This is a simple user" + "\n" + "Name:" + _name + "\nEmail:" + _email + "\nPhone:" + _phone + "\nBorned at:" + _birthDay + "\nCnp:" + _cnp;
        }

        public void Authentificate(string password,string email)
        {
            Console.WriteLine("Authentification using password and email");
        }

        public void Authentificate(string email)
        {
            Console.WriteLine("Authentification using a google account");

        }
    }
}
