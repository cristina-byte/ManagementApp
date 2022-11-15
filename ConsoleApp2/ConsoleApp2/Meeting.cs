using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Meeting
    {
        public string Title { get; set; }

        public string Address { get; set; }

        public DateTime Date { get; set; }

        public Meeting(string title, string address,DateTime date)
        {
            Title = title;
            Address = address;
            Date = date;
        }

        public override string ToString()=> "Title:" + Title + "\nAddress:" + Address + "\nDate:" + Date;
       
    }
}
