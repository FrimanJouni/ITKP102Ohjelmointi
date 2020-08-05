using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 1710018
/// <summary>
/// 
/// </summary>
public class D6_TaunoKayTaulukkoaLapi
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[,] alkuSukupolvi = {
               { 1,0,1,1 },
               { 0,1,1,0 },
               { 1,0,0,0 },
               { 1,0,0,1 }
             };
        int naapureita = LaskeNaapurit(alkuSukupolvi, 1, 1);
        Console.WriteLine(naapureita);
        naapureita = LaskeNaapurit(alkuSukupolvi, 1, 2);
        Console.WriteLine(naapureita);
        naapureita = LaskeNaapurit(alkuSukupolvi, 2, 1);
        Console.WriteLine(naapureita);
        naapureita = LaskeNaapurit(alkuSukupolvi, 2, 2);
        Console.WriteLine(naapureita);
    }

    public static int LaskeNaapurit(int[,] sukupolvi, int iy, int ix)
    {
        int n = 0;

        for (int i = -1; i < 2; i++)    //Toistolauseilla ei ole mitään tekemistä taulukossa sijainnin kanssa, vaan ne ovat suoraan suhteessa koordinaatin sijaintiin.
        {
            for (int j = -1; j < 2; j++)    //Eli sijainnista on otettu paikka -1 ja sen ympäriltä käydään toisessa ulottuvuudessa sen ympäröivät -1, 0, +1 sijainnit
            {                                           // Tätä toistetaan jokaisen ensimmäisessä ulottuvuudessa olevan -1, 0, +1 sijainneissa koordinaatin ympärillä.
                n += sukupolvi[iy + i, ix + j];
            }                              //Tulokseen lisätään alkuperäisestä koordinaatista [alkp-1, alkp-1], [alkp+0, alkp+0]... jne toistolauseiden indeksiä käyttäen
        }

        if (sukupolvi[iy, ix] == 1) n = n - 1; //Lopputuloksesta poistetaan alkuperäinen luku

        return n;
    }

}
