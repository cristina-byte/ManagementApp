﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin : User
    {
        public Admin(int id,string name, string password, string email, BigInteger phone, 
            BigInteger cnp, DateTime birthDay) : base(id,name, password, email, phone, cnp, birthDay)
        {

        }

        public override string ToString()
        {
            return $"\nName: _name \nEmail: _email \nPhone: _phone \nBorned at: _birthDay \nCnp:_cnp";
        }
    }
}