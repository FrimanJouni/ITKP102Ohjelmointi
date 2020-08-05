using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 17102018
/// <summary>
/// 
/// </summary>
public class D6_TaunoVaihtaaTaulukonPareittain
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[] t = { 23, 45, 12, 9, 3, 7 };
        Console.WriteLine("Aluksi : " + string.Join(", ", t));
        KasitteleTaulukko(t);
        Console.WriteLine("Lopuksi: " + string.Join(", ", t));
    }

    public static void KasitteleTaulukko(int [] t)
    {
        int i = 0;
        int j = 1;
        int pankki = 0;

        while (j < t.Length)
        {
            pankki = t[i];      //apumuuttujan avulla saadaan taulukon paikoissa i ja j olevat vaihdettua keskenään.
            t[i] = t[j];
            t[j] = pankki;
            i += 2;             // Pareittain vaihdettaessa molempia lisätään kahdella. Hypätään aina "toisen yli".
            j += 2;
        }
    }

}
