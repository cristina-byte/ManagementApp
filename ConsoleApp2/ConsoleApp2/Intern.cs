using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Intern : Member
    {
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public Intern(string _name, int _age, BigInteger _cnp, DateTime _startDate) : base(_name, _age, _cnp)
        {
            startDate = _startDate;

        }



        public override string ToString()
        {
            return base.ToString()+" Started internship at: "+startDate;
        }


    }
}
