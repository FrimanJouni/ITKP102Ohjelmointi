using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 11.11.2018
/// <summary>
/// 
/// </summary>
public class D9_t1_nousevatArvotTaulukossa
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[] taulukko = new int[] { 2, 3, 4, 1, 2, 0, 1, 2, 5, 5, 7 };
        int jononPituus = PisinNouseva(taulukko);
        Console.WriteLine("Pisimmän aidosti nousevan osajonon pituus on " + jononPituus);
    }

    public static int PisinNouseva(int[] taulukko)
    {
        int pienin = int.MinValue;
        int jono = 0;
        int pisinJono = 0;

        foreach (int luku in taulukko)
        {
            if (luku > pienin)
            {
                jono++;
                pienin = luku;
            }
            else
            {
                pienin = int.MinValue;
                if (pisinJono < jono) pisinJono = jono;
                jono = 0;
            }
        }

        if (jono > pisinJono) return jono;
        return pisinJono;
    }



}
