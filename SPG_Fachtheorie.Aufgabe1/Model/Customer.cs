using System;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Customer
    {
        public Guid Guid { get; set; }
        public int? Kundennummerkey { get; set; }
        public Salutation Anrede { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public string? Adresse { get; set; }
        public int? Postleitzahl { get; set; }
        public string? Ort { get; set; }
        public string? Land { get; set; }

        public Customer() { }

        public Customer(Guid guid, int nummer, Salutation anrede, string vorname, string nachname, string addresse, int plz, string ort, string land)
        {
            Guid = guid;
            Kundennummerkey = nummer;
            Anrede = anrede;
            Vorname = vorname;
            Nachname = nachname;
            Adresse = addresse;
            Postleitzahl = plz;
            Ort = ort;
            Land = land;

        }
        public enum Salutation
        {
            Mr,
            Ms
        }

    }
}



public enum Salutation
{
    Mr,
    Ms
}