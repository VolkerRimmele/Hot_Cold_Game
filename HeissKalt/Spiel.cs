using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeissKalt
{
    internal class Spiel
    {
        public static void NeuesSpiel()
        {
            //Heiß Kalt

            Random rand = new Random();//Definition rand - Zur Erzeugung einer Zufallszahl
            int randomZahl = rand.Next(1, 101);//Computer erzeugt ein Zahl zwischen 1 und 100

            bool check;//check wird true wenn konvertierung der Eingabe mit TryParse erfolgreich wenn nicht dann false
            int versuche = 0;
            int vorherigeZahl = 0;
            int ausgedachteZahl;
            string name;

            Console.WriteLine("Bitte geben Sie Ihren Namen ein");
            name = Console.ReadLine();
                      
            do
            {

                Console.WriteLine("Bitte Zahl zwischen 1-100 eingeben?");

                check = int.TryParse(Console.ReadLine(), out ausgedachteZahl);
                versuche = versuche + 1;

                

                if (versuche > 1)
                {
                    if (Math.Abs(ausgedachteZahl - randomZahl) < Math.Abs(vorherigeZahl - randomZahl)) // Die Differenze der Absolwerte werden vergichen - wenn Diff kleiner als bei vorheriger Zahl dann heiß 
                    {
                        Console.WriteLine("Heiß");
                    }
                    else
                    {
                        Console.WriteLine("Kalt");
                    }

                }
                vorherigeZahl = ausgedachteZahl;
            } while (check == false || ausgedachteZahl < 1 || ausgedachteZahl > 100 || ausgedachteZahl != randomZahl);
            Console.WriteLine($"Sie haben {versuche} Versuche benötigt, die RandomZahl war {randomZahl}");
            

            //Aufruf Konstruktor
            Spieler spieler = new Spieler(name, versuche, randomZahl);
            

            //Liste wird gefüllt
            Spieler.SpielerListe.Add(spieler);
            

        }
    }
}
