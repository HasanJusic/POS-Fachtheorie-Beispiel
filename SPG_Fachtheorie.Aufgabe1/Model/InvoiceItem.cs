using System;
using System.Collections.Generic;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class InvoiceItem
    {
        public Guid Guid { get; set; }
        public int Invoicenumberkey { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();


        public InvoiceItem() { }

        public InvoiceItem(Guid guid, int invoicenumberkey, List<Article> articles, List<Invoice> invoices)
        {
            Guid = guid;
            Invoicenumberkey = invoicenumberkey;
            Articles = articles;
            Invoices = invoices;

        }

        public decimal Summe()
        {
            decimal GesamtPreis = Articles.Sum(a => a.Einzelpreis);
            decimal RabatPreis = GesamtPreis * Invoices[0].Rabatt / 100;
            return GesamtPreis - RabatPreis;
        }
    }

}
