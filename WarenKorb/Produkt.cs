using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenKorb
{
    internal class Produkt
    //{

    //    public int ProduktId { get; set; }
    //    string ProduktName { get; set; }
    //    public int Anzahl { get; set; } = 0;
    //    public static List<Produkt> produkts = new List<Produkt>() { new Produkt() { ProduktId = 1, ProduktName = "Nutella" },
    //                                                          new Produkt() { ProduktId = 2, ProduktName = "Pommes Frites" },
    //                                                          new Produkt() { ProduktId = 3, ProduktName = "Ketchup" },
    //                                                          new Produkt() { ProduktId = 5, ProduktName = "Brötchen" },
    //                                                          new Produkt() { ProduktId = 6, ProduktName = "Spagetti" },
    //                                                          new Produkt() { ProduktId = 7, ProduktName = "Rice" },
    //                                                          new Produkt() { ProduktId = 8, ProduktName = "Cola" },
    //                                                          new Produkt() { ProduktId = 9, ProduktName = "Waseer" },
    //                                                          new Produkt() { ProduktId = 10, ProduktName = "Bier" },
    //                                                          new Produkt() { ProduktId = 11, ProduktName = "Fleisch" },
    //                                                          new Produkt() { ProduktId = 12, ProduktName = "Gemüse" }};

    //    internal static Produkt[] GetProduktListe()
    //    {
    //        return produkts.ToArray();
    //    }

    //    public string GetProdukt()
    //    {
    //        return $"{ProduktName}, {Anzahl}";
    //    }
    //}
    {
        public int ProduktNr { get; private set; }
        public string Name { get; private set; }
        public decimal Preis { get; private set; }
        public Produkt(int produktNr, string name, decimal preis)
        {
            ProduktNr = produktNr;
            Name = name;
            Preis = preis;
        }
        public override string ToString()
        {
            return $"{ProduktNr} - {Name} - {Preis}";
        }
        public static Produkt[] GetProduktListe()
        {
            return new Produkt[] {
                new Produkt(1, "Marmelade", 5),
                new Produkt(2, "Quark", 10),
                new Produkt(3, "Mohrrüben", 15),
                new Produkt(4, "Käse", 20),
                new Produkt(5, "Honig", 25),
                new Produkt(6, "Mehl", 30),
                new Produkt(7, "RAM", 90),
                new Produkt(8, "SSD", 50),
                new Produkt(9, "CPU", 190)
            };
        }
    }
}
