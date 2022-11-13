using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Member
    {
        private string name;
        private int age;
        private BigInteger cnp;


        public Member(string _name, int _age, BigInteger _cnp)
        {
            name = _name;
            age = _age;
            cnp = _cnp;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public BigInteger Cnp
        {
            get { return cnp; }
            set { cnp = value; }

        }

       override public string ToString()
        {
            return "Name: " + name + " Age: " + age + " CNP: " + cnp;
        }

    }
}
