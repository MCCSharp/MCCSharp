using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WarenKorb
{
    public enum Länder { USA, GB, Germany }
    internal class Kunde
    {
        //public int KundeId { get; set; }
        //string KundeName { get; set; }
        //string KundeAdress { get; set; }
        //private static List<Kunde> kundes = new List<Kunde>() { new Kunde() { KundeId = 1, KundeName = "Bob", KundeAdress = "Adlerstr 10, Berlin" },
        //                                                       new Kunde() { KundeId = 2,KundeName = "Bill", KundeAdress = "Theodorst 15, Düsseldorf" },
        //                                                       new Kunde() { KundeId = 3,KundeName = "John", KundeAdress = "Toulousestr 8, Köln"},
        //                                                       new Kunde() { KundeId = 4,KundeName = "Jack", KundeAdress = "Wallstr 20, Freiburg" },
        //                                                       new Kunde() { KundeId = 5,KundeName = "Robert", KundeAdress = "Diana RossStr 25, Emmendigen" },
        //                                                       new Kunde() { KundeId = 5,KundeName = "Tibault", KundeAdress = "Gustavstr 7, Stuttgart" },
        //                                                       new Kunde() { KundeId = 6,KundeName = "Henri", KundeAdress = "MariaHospitalstr 46, Hilden " },
        //                                                       new Kunde() { KundeId = 7,KundeName = "Dominique", KundeAdress = "RotFeuerwerkstr 10, Mannheim" } };

        //public static Kunde[] GetKundeListe()
        //{
        //    return kundes.ToArray();
        //}

        // string GetKunde()
        //{
        //   return $"{KundeName} {KundeAdress}";
        //}
     

        public string Name { get; private set; }
        public string Ort { get; private set; }
        public Länder Land { get; private set; }
        public Bestellung[] Bestellungen { get; private set; }
        public Kunde(string name, string ort, Länder land, Bestellung[] bestellungen)
        {
            Name = name;
            Ort = ort;
            Land = land;
            Bestellungen = bestellungen;
        }
        public override string ToString()
        {
            return $"{Name} - {Ort} - {Land}";
        }
        public static Kunde[] GetKundenListe()
        {
            return new Kunde[] {
                new Kunde("Walter", "Altenburg", Länder.Germany, new Bestellung[] {
                    new Bestellung(2, 4, "März", false)
                }),
                new Kunde("Thomas", "Berlin", Länder.Germany, new Bestellung[] {
                    new Bestellung(1, 11, "Juni", false),
                    new Bestellung(3, 19, "November", true)
                }),
                new Kunde("Holger", "Washington", Länder.USA, new Bestellung[] {
                    new Bestellung(5, 17, "November", true)
                }),
                new Kunde("Fernando", "New York", Länder.USA, new Bestellung[] {
                    new Bestellung(6, 12, "Juni", false)
                }),
                new Kunde("Alice", "London", Länder.GB, new Bestellung[] {
                    new Bestellung(4, 3, "Februar", true),
                    new Bestellung(2, 1, "Februar", false),
                    new Bestellung(3, 19, "Juni", true)
                })
            };
        }

    }
}
