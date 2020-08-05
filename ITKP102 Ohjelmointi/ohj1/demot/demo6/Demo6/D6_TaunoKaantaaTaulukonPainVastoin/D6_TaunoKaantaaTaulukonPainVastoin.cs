using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 17102018
/// <summary>
/// 
/// </summary>
public class D6_TaunoKaantaaTaulukonPainVastoin
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

    public static void KasitteleTaulukko(int[] t)
    {
        int i = 0;
        int j = t.Length -1;
        int pankki = 0;

        while (i < j)
        {
            pankki = t[i];
            t[i] = t[j];
            t[j] = pankki;
            i++;
            j--;
        }
    }

}
