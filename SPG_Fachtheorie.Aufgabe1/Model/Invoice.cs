using System;
using System.Collections.Generic;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Invoice
    {
        public Guid Guid { get; set; }
        public int Rechnungsnummerkey { get; set; }
        public DateOnly Rechnungsdatum { get; set; }
        public int Rabatt { get; set; }
        public List<Customer> Customer { get; set; } = new List<Customer>();
        public List<Employee> Employee { get; set; } = new List<Employee>();

        public Invoice() { }

        public Invoice(Guid guid, int rechnungsnummerkey, DateOnly rechnungsdatum, int rabatt, List<Employee> employee, List<Customer> customers)
        {
            Guid = guid;
            Rechnungsnummerkey = rechnungsnummerkey;
            Rechnungsdatum = rechnungsdatum;
            Rabatt = rabatt;
            Employee = employee;
            Customer = customers;
        }
    }
}
