using System;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Article
    {
        public Guid Guid { get; set; }
        public int Artikelnummerkey { get; set; }
        public string? Artikelbezeichnung { get; set; }
        public decimal Einzelpreis { get; set; }

        public Article()
        {

        }

        public Article(Guid guid, int artikelnummer, string artikelbezeichnung, decimal einzelpreis)
        {
            Guid = guid;
            Artikelnummerkey = artikelnummer;
            Artikelbezeichnung = artikelbezeichnung;
            Einzelpreis = einzelpreis;


        }




    }






}
