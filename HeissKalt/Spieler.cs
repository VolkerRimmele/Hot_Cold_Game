using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeissKalt
{
    public class Spieler
    {
        string name;
        int versuche;
        int randomZahl;

                    
        public static List<Spieler> spielerListe = new List<Spieler>();

        public Spieler(string name, int versuche, int randomZahl)
        {
            Name = name;
            Versuche = versuche;
            RandomZahl = randomZahl;
        }
        
        public string Name { get => name; set => name = value; }
        public int Versuche { get => versuche; set => versuche = value; }
        public int RandomZahl { get => randomZahl; set => randomZahl = value; }

        public static List<Spieler> SpielerListe { get => spielerListe; set => spielerListe = value; }


        internal static void AusgabeUnsortiert()
        {
            //Ausgabe unsortiert d.h. wer zuerst gespielt hat kommt zuerst.
            foreach (var spieler in SpielerListe)
            {
                Console.WriteLine($"SpielerListe: Name: {spieler.Name}, HighScore: {spieler.Versuche}, RandomZahl: {spieler.RandomZahl}");

                Thread.Sleep(500);
            }

        }


        //Query Syntax
        internal static void AusgabeSortiert()
        {
            //Sortierung erst nach Anzahl Versuche, dann nach Name dann nach Random Zahl
            var spielerListeSortiert = SpielerListe.OrderBy(s => s.Versuche).ThenBy(s => s.Name).ThenBy(s=>s.randomZahl);

            foreach (var s in spielerListeSortiert)
            {
                Console.WriteLine($"SpielerListe: Name: {s.Name}, HighScore: {s.Versuche}, RandomZahl: {s.RandomZahl}");
            }
        }

    }
}
