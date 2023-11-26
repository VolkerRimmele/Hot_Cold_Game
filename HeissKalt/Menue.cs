using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HeissKalt
{
    internal class Menue
    {
        public static void Start()
        {

            int eingabeZahl;//Die vom User eingegebene Zahl
            bool check;
            do
            {
                Console.WriteLine("Was möchten Sie Tun, 1=neues Spiel, 2 =High Scores Anzeigen, 3=High Scores sortiert anzeigen, 4=Speichern, 5=Programm beenden");
                check = int.TryParse(Console.ReadLine(), out eingabeZahl);//Check wird true wenn Konvertierung zu int erfolgreich

                switch (eingabeZahl)
                {
                    case 1:
                        Spiel.NeuesSpiel();
                        break;
                    case 2:
                        Laden();
                        Spieler.AusgabeUnsortiert();
                        break;
                    case 3:
                        Laden();
                        Spieler.AusgabeSortiert();
                        break;
                    case 4:
                        Speichern();
                        break;
                    case 5:
                        return;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte 1-5 eingeben, 1=neues Spiel, 2=High Scores unsortiert anzeigen, 3=High Scores sortiert anzeigen, 4=Speichern, 5=Programm beenden");
                        break;
                        Console.Clear();
                }


            } while (check = false || eingabeZahl < 5 || eingabeZahl > 5);//Schleife wird nur verlassen wenn 5 eingegeben wird

        }

        public static void Speichern()
        {
            string json = JsonSerializer.Serialize(Spieler.SpielerListe);//Die Spieler.Spielerliste wird in eine Json sting ungewandelt // Objekt wird in string ungewandelt Serialize

            using (StreamWriter sw = new StreamWriter("spielerListe.json"))//Initialisierung der StreamWriter Objekts (sw) - ist die Datei "spielerListe.json" noch nicht vorhanden,
                                                                           //wird sie bei der Initialisierung des Objekts (sw) erstellt.
            {
                sw.WriteLine(json);//Der json String wird in die Datei "SpielerListe.json" geschrieben
            }
            Console.WriteLine("\nDaten gespeichert. Drücke Enter um ins Menü zurück zu kehren.");
            Console.ReadLine();
        }

        public static void Laden() 
        {
            string json;
            try
            {
                if (File.Exists("spielerListe.json"))
                {
                    using (StreamReader sr = new StreamReader("spielerListe.json")) // Object der Klasse Streamreader wird erstellt
                    {
                        json = sr.ReadToEnd();//die Datei "spielerListe.json" wird bis zum Ende gelesen und als json string gespeichert
                    }

                    Spieler.SpielerListe = JsonSerializer.Deserialize<List<Spieler>>(json);//der Json string wird wieder in ein Objekt verwandelt (Deserialize)
                    Console.WriteLine("\nDaten geladen. Drücke Enter zum weitermachen.");
                    Console.ReadLine();
                }
                else throw new FileNotFoundException("Datei nicht gefunden.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }

}



