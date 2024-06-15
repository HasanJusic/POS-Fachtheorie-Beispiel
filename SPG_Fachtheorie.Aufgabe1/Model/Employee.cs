using System;
using System.ComponentModel.DataAnnotations;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Employee
    {
        [Key]
        public Guid Guidkey { get; set; }
        public string Name { get; set; }

        public Employee() { }

        public Employee(Guid guidkey, string name)
        {
            Guidkey = guidkey;
            Name = name;
        }
    }
}
