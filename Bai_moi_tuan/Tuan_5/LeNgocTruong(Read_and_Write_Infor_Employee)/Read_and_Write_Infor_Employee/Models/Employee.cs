using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Read_and_Write_Infor_Employee.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }
        public decimal Salary { get; set; }
        public string Image { get; set; }
    }
}