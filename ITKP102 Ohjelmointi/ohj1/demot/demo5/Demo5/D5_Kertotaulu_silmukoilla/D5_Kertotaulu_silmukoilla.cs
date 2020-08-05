using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 14102018
/// <summary>
/// Kertotaulua annetuilla numeroilla silmukoiden kautta aliohjelmassa
/// </summary>
public class D5_Kertotaulu_silmukoilla
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        TulostaKertotaulu(3);
        Console.WriteLine("-------------------");
        TulostaKertotauluWhile(3, 5);
        Console.WriteLine("-------------------");
        TulostaKertotauluDoWhile(6, 0);
    }

    public static void TulostaKertotaulu(int luku)  //Kertotaulu for silmukalla
    {
        for (int i = 1; i <= 10; i++)
        {
            int tulos = i * luku;
            Console.WriteLine("{0,2} * {1,2} = {2,2}", i, luku, tulos);   //Ensimmäinen luku {}-sisällä tarkoittaa mitä siihen halutaan tulostaa perässä tulevista muuttujista tai muista
        }                                                                 //Toinen luku tarkoittaa kuinka monta "palaa" tilaa kyseiselle merkkijonolle varataan. Esim. {0,5}, 123 tulostaisi
    }                                                                     // "  123" eli tyhjää tilaa jäisi kaksi "palaa" numeroiden edelle.

    public static void TulostaKertotauluWhile(int kerroin, int rivi)
    {
        int i = 1;
        while (i <= rivi)
        {
            int tulos = i * kerroin;                                            //Tulos täytyy olla loopin sisällä, muuten tulee loputon.
            Console.WriteLine("{0,2} * {1,2} = {2,2}", i, kerroin, tulos);
            i++;
        }
    }

    public static void TulostaKertotauluDoWhile(int kerroin, int rivi)
    {
        int i = 1;
        do
        {
            int tulos = i * kerroin;                                            //Nolla huono tässä sillä do-while tulostaa kuitenkan aina kerran.
            Console.WriteLine("{0,2} * {1,2} = {2,2}", i, kerroin, tulos);
            i++;

        } while (i <= rivi);
    }

}
