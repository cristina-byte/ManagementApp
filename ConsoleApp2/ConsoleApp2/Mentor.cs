using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Mentor : User
    {
        private Intern intern;
        public Intern Intern
        {
            get { return intern; }
            set { intern = value; }
        }
        public Mentor(string _name, int _age, BigInteger _cnp, Intern _intern) : base(_name, _age, _cnp)
        {
            intern = _intern;
        }

        public override string ToString()
        {
            return base.ToString()+" Mentor for: "+intern.ToString();
        }

    }
}
