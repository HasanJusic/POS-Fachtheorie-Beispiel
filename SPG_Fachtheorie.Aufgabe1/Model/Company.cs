using Microsoft.EntityFrameworkCore.Sqlite.Query.Internal;
using System;
using System.Runtime.CompilerServices;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Company
    {
        public Guid Guidkey { get; set; }
        public string? Firmenname { get; set; }
        public string? Anschrift { get; set; }
        public int? Postleitzahl { get; set; }
        public string? Ort { get; set; }
        public string? Email { get; set; }
        public int? Telefonnummer { get; set; }

        public Company() { }

        public Company(Guid guid, string name, string anschrift, int plz, string ort,  string email, int telefonnummer)
        {
            Guidkey = guid;
            Firmenname = name;
            Anschrift = anschrift;
            Postleitzahl = plz;
            Ort = ort;
            Email = email;
            Telefonnummer = telefonnummer;

        }
    }
}
