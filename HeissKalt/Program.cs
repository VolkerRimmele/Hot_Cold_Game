using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeissKalt
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //Spiel Heiskalt.
        //Der Computer wählt eine Zahl von 1-100 zufällig aus. 
        //Der Spieler muss sie mit möglichst wenig Versuchen erraten.
        //Dazu wird die der Absolutwert der Differenz AusgedachteZahl
        //(=akutelle Eingabe es Users) - RandomZahl genommen.
        //und mit der Differenz VorherigeZahl (=Eingabe des User eine Runde vorher) - RandomZahl verglichen.
        //Es wird dann entweder heiß oder kalt ausgeben.

        //Per Menue kann man entscheiden ob man 
        //1. ein neues Spiel machen will
        //2. bzw. 3 die bisherigen Daten anschauen will (2=unsortiert, 3=Sortiert nach Anzahl Versuche, dann Name, dann RandomZahl) 
        //4. Die Daten speichern will. Neu eingegebene Daten kann man erst anschauen wenn sie vorher gespeichert wurden
        //5. Ob man das Spiel beenden will 
        
        //Die Daten werden in einer json Datei gespeichert    

           Menue.Start();
        }
    }
}