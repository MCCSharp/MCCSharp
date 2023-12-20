using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WarenKorb
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Kunde[] kunden = Kunde.GetKundenListe();
            Produkt[] produkte = Produkt.GetProduktListe();
            //Aufgabe A
            Console.WriteLine("**** Aufgabe A ****");
            var produktname = produkte.Select(p => new {p.Name}) ;
            // Query Expression
            var warenkorb = from k in kunden
                            select new { k.Name, k.Ort };
            // Extension-Method:
            var warenkorb2 = kunden.Where(k => k.Land == Länder.Germany)
                                   .Select(kunden => kunden.Bestellungen);
            // Query Expression
            var AufgabeB = from k in kunden
                           where k.Land == Länder.Germany
                           select k.Bestellungen;
            foreach(var item in AufgabeB)
            {
                foreach(var bestellung in item)
                {
                    Console.WriteLine(bestellung);
                }
            }
            Console.WriteLine("**** AUSGABE *****");
            var AufgabeB2 = from k in kunden
                            where k.Land == Länder.Germany
                            from b in k.Bestellungen
                            select b;
            foreach(var item in AufgabeB2)
            {
                Console.WriteLine(item);
            }

            //Aufgabe C          
            Console.WriteLine("**** Aufgabe C ****");
            // Expression :
            var AufgabeCEx = kunden
                           .Where((k, i)=> i % 2 != 0);
            foreach (Kunde kunde in AufgabeCEx)
            {
                Console.WriteLine(kunde.ToString());
            }
            // query Expression
            int zaehler = 0;
            var AufgabeCQ = from k in kunden
                            where zaehler++ % 2 == 0
                            select k.Name;
            foreach (var kunde in AufgabeCQ)
            {
                Console.WriteLine(kunde);
            }
            Console.WriteLine("*** QE-2 ***");
            var AufgabeC2 = from k in kunden.Select((wert, i) => new { wert, i })
                            where k.i % 2 == 0
                            select k.wert.Name;
            foreach (var kunde in AufgabeC2)
            {
                Console.WriteLine(kunde);
            }
            // Aufgabe D
            Console.WriteLine("**** Aufgabe D ****");
            //Extension:
            var AufgabeD = produkte
                       .Where(p => p.Preis <= 20)
                       .Select(p=> (p.Name, p.Preis ))
                       .OrderByDescending(produkte => produkte.Preis);

            foreach(var produkt in AufgabeD)
            {
                Console.WriteLine(produkt);
            }
            // Hybride lösung:
            var namepreis = (from p in produkte
                            where p.Preis <= 20
                            select new { Name = p.Name, Preis = p.Preis }).OrderByDescending(item => item.Preis);
            //var sortiertnamepreis = namepreis.OrderByDescending(item => item.Preis);
            foreach (var produkt in namepreis)
            {
                Console.WriteLine(produkt);
            }

            //Query Expression:
            Console.WriteLine("**** QE ****");
            var AufgabeDQ = from p in produkte
                            where p.Preis <= 20
                            orderby p.Preis descending
                            select new { p.Name, p.Preis };
            foreach (var produkt in AufgabeDQ)
            {
                Console.WriteLine(produkt);
            }
            // Aufgabe E
            Console.WriteLine("**** Aufgabe E ****");
            //Hybride Methode:
            var hybridE = from k in kunden
                          select new {Name =k.Name, Land = k.Land};
            var hybridSortiert = hybridE.OrderBy(item => item.Land).ThenBy(item => item.Name);

            foreach (var kunde in hybridSortiert)
            {
                Console.WriteLine(kunde);
            }
            //Extension Method:
            var emaufgabeE = kunden.OrderBy(k => k.Land).Where(k => k.Land == k.Land)
                                   .OrderBy(k => k.Land).Select(k => new {k.Name, k.Land});
            foreach(var kunde in emaufgabeE)
            {
                Console.WriteLine(kunde);
            }
            //Extension
            Console.WriteLine("**** MICHELE ****");
            var emichele = kunden.Select(k => new {k.Name, k.Land})
                                 .OrderByDescending(k => k.Land)
                                 .ThenBy(k => k.Name);
            foreach (var kunde in emichele)
            {
                Console.WriteLine(kunde);
            }
            var AufgabeE = kunden
                           .Select((k => new { k.Land, k.Name }))
                           .GroupBy(p => p.Land);
            foreach(var kunde  in AufgabeE)
            {
                Console.WriteLine(kunde);
            }
            // Aufgabe F
            Console.WriteLine("**** Aufgabe F ****");
            //Extension
            var emgruppiert = kunden.GroupBy(k => k.Land);
            GroupByAusgabe(emgruppiert);
            // Query Expression
            var qegruppiert = from k in kunden 
                              group k by k.Land
                              into Landgruppe
                              select new {Land = Landgruppe.Key, kunden = Landgruppe.ToList()};
            //GroupByAusgabe(qegruppiert);
            //
            var qegruppiert2 = from k in kunden
                               group k by k.Land;
            GroupByAusgabe(qegruppiert2);

            Console.WriteLine("**** Aufgabe 1G ****");
            //Extension
            var emaufgabeG = produkte.GroupBy(produkte => produkte.Name.First())
                                     .Select(gruppe => new { Buchstabe = gruppe.Key, Name = gruppe.ToList() });
            foreach(var item in emaufgabeG)
            {
                Console.WriteLine(item.Buchstabe);
                foreach (var Name in item.Name)
                {
                    Console.WriteLine(Name.Name);
                }
            }

            var emaufgabeG2 = produkte.Select(p => p.Name)
                                      .GroupBy(produkte => produkte.First());
            GroupByAusgabe(emaufgabeG2);
            //Query Expression:

            var qeaufgabeG = from p in produkte
                             group p by p.Name.First()
                             into SortedFirstLetter
                             select new {Buchstabe =SortedFirstLetter.Key,
                             Name = SortedFirstLetter.ToList() };
            Console.WriteLine("**** QE *****");
            foreach (var item in qeaufgabeG)
            {
                Console.WriteLine(item.Buchstabe);
                foreach (var Name in item.Name)
                {
                    Console.WriteLine(Name.Name);
                }
            }

            var qeaufgabeG2 = from p in produkte
                              group p.Name by p.Name.First();
            GroupByAusgabe(qeaufgabeG2);
            Console.WriteLine("**** H ****");
            // Query expression
            var bestelleungenkunden = from k in kunden
                                      from b in k.Bestellungen
                                      join p in produkte on b.ProduktNr equals p.ProduktNr
                                      orderby p.Preis
                                      select new { p.Preis, b.Monat, b.ProduktNr, p.Name, b.Versendet };
            Ausgabe(bestelleungenkunden);
            //Hybrid
            var qeaufgabeH = from b in kunden.SelectMany(kunden => kunden.Bestellungen)
                             join p in produkte on b.ProduktNr equals p.ProduktNr
                             orderby p.Preis
                             select (p.Preis, b.Monat, b.ProduktNr, p.Name, b.Versendet);
            Ausgabe(qeaufgabeH);
            //Extenssion
            var emaufgabeH = produkte.Join(kunden.SelectMany(kunden => kunden.Bestellungen),
                a => a.ProduktNr,
                b => b.ProduktNr,
                (a, b) => new { b.Monat, b.ProduktNr, a.Name, a.Preis, b.Versendet }).OrderBy(p => p.Preis);
            Ausgabe(emaufgabeH);
            Console.WriteLine("**** I ****");
            //Query Expression 
            var qeaufgabeI = from k in kunden
                             select new { k.Name, k.Ort, AnzahlBestellungn = k.Bestellungen.Length };
            Ausgabe(qeaufgabeI);
            //Extension 
            Console.WriteLine("**** Entension ****");
            var eaugfgabeI = kunden.Select(k => new { k.Name, k.Ort, k.Land, Anzahl = k.Bestellungen.Length });
            Ausgabe(eaugfgabeI);
            //Query Expresion
            var qesumme = (from p in produkte select p.Preis).Sum();
            Console.WriteLine(qesumme);
            Console.WriteLine("**** Aufgabe 1K ****");
            var kundenmitgesamtbetrag = from k in kunden
                                        select new
                                        {
                                            Name = k.Name,
                                            Gesamtbetrag = k.Bestellungen.Sum(b =>
                                            {
                                                var produkt = produkte.FirstOrDefault
                                                (p => p.ProduktNr == b.ProduktNr); 
                                                return (produkt != null ? produkt.Preis : 0) * b.Anzahl;
                                            })
                                        };
            Ausgabe(kundenmitgesamtbetrag);

            //LÖSUNG ANDREAS
            var kundenlist = from k in kunden
                             group k by k.Name into g
                             select new
                             {
                                 Name = g.Key,
                                 Gesamtbetrag = (from k in g
                                                 from b in k.Bestellungen
                                                 join p in produkte on b.ProduktNr equals
                                                 p.ProduktNr
                                                 select b.Anzahl * p.Preis).Sum()
                             };
            Console.WriteLine("**** LÖSUNG ANDREAS ****");
            foreach(var item in kundenlist)
            {
                Console.WriteLine($"Kunde : {item.Name}");
                Console.WriteLine(item.Gesamtbetrag);
            }
            //Alternative:
            var gesamtsumme =
                from k in kunden
                select new
                {
                    k.Name,
                    Gesamtbetrag = (from p in produkte
                                    join b in k.Bestellungen on p.ProduktNr equals
                                    b.ProduktNr
                                    select (p.Preis * b.Anzahl)).Sum()
                };
           Ausgabe(gesamtsumme);
            // Extension:
            var emgesamtsumme = kunden.Select(k => new
            {
                k.Name,
                Gesamtbetrag = (produkte.Join(k.Bestellungen,
                                         p => p.ProduktNr,
                                         b => b.ProduktNr,
                                         (p, b) => p.Preis * b.Anzahl
                                         )).Sum()
            });
            Ausgabe(gesamtsumme); 
        }
        static void Ausgabe(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
        static void GroupByAusgabe<TKey, TElement>(IEnumerable<IGrouping<TKey,TElement>> collection)
        {
            foreach(var itemGroup in collection)
            {
                Console.WriteLine(itemGroup.Key);
                foreach(var wert in itemGroup)
                {
                    Console.WriteLine(" * " + wert );
                }
            }
        }
        
    }
}