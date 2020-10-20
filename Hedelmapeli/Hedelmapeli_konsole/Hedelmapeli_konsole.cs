using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

/// @author Jouni Friman
/// @version Konsoliversio beta 20.09.2020
/// <summary>
/// Proof of Concept - Konsoliversiona tehty logiikan testaus hedelmäpelistä joka toteutetaan graafisena myöhemmin.
/// </summary>
public class Hedelmapeli_konsole
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        bool exit = false;
        int[] arvotutNumerot = new int[9];                  //TODO: Muuta vakiot fiksuiksi
        int rahat = 20;
        int panos = 1;

        while (exit == false)                                //Mainloop, toistaa itseään kunnes suljetaan TODO:lopetus pelille ilman vakiota
        {
            int komento = PelaajaKomento(panos);                      //Ottaa pelaajan komennon vastaan ja iffeillä päätetään mitä tapahtuu. TODO: Pohdi olisko joku fiksumpi systeemi (?)

            if (komento == 1) Kaynnista(arvotutNumerot);              //Komennon perusteella käynnistää pelin
            if (komento == 2) panos = Panosta(rahat);                         //Komennon perusteella nostaa tai laskee panosta. TODO: TÄMÄ
            if (komento == 3) exit = Lopeta();                  //Lopettaa silmukan, ei välttämättä tarvitsisi aliohjelmaa, mutta "moduläärisempi" näin :-)

            //TODO : jos väärä komento
        }
    }

    public static int PelaajaKomento(int panos)
    {
        int komento = 0;

        Console.WriteLine("Anna numerona komento mitä haluat tehdä :"); //Tulostetaan komennot näytille
        Console.WriteLine("1) Käynnistä Hedelmäpeli");
        Console.WriteLine("2) Muuta panosta, panos nyt > {0}. kolikkoa", panos);
        Console.WriteLine("3) Lopeta peli");
        Console.Write(">");

        return komento = Convert.ToInt32(Console.ReadLine()); //Palauttaa int arvona pelaajan valitseman komennon
    }

    public static void Kaynnista(int [] arvotutNumerot)
    {
        Random rnd = new Random();              //Määritetään random jota käytetään arpomaan hedelmäpelin tulokset

        for (int i=0; i<arvotutNumerot.Length; i++)
        {
            arvotutNumerot[i] = rnd.Next(1,5);      //Arvotaan tulokset taulukkoon
        }

        Grafiikka(arvotutNumerot);                //Arvonnan jälkeen kutsutaan grafiikka aliohjelmaa joka tulostaa pelin näytölle
    }

    public static int Panosta(int rahat)
    {
        int panos = 1;
        Console.WriteLine("Aseta panos:");
        panos = Convert.ToInt32(Console.ReadLine());
        if (rahat > panos) return panos;
        else
        {
            Console.Write("Kolikkosi eivät riitä, panos on nyt 1 kolikko");
            return 1;
        }
    }

    public static void Grafiikka(int [] arvotutNumerot)
    {
        int laskuri = 0;
        Console.WriteLine("*********************");
        for (int i = 0; i < arvotutNumerot.Length; i++)
        {
            Console.Write("** " + arvotutNumerot[i] + " **");
            laskuri++;
            if (laskuri == 3)
            {
                Console.WriteLine("");                      //Maailman surkein spagettikoodiviritys halp TODO: Paranna miten tämä toimii
                laskuri = 0;                                //Yritetään siis tulostaa koodi nätisti kolmelle eri riville
            }
        }
        Console.WriteLine("*********************");
    }

    public static bool Lopeta()
    {
        return true;
    }

}





//TODO: Voitontarkistus, rahamäärät/seuranta
