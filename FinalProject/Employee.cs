using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    public class Employee
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string position { get; set; }
        public string address { get; set; }
        public DateTime startDate { get; set; }

        public Employee()
        {

        }

        public Employee(string name, string email, string phoneNumber,
                        string positon, string address, DateTime startDate)
        {
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.position = positon;
            this.address = address;
            this.startDate = startDate;
        }
    }
}
