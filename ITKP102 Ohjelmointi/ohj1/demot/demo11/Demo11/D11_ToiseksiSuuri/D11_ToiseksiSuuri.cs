using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frima
/// @version ..2018
/// <summary>
/// 
/// </summary>
public class D11_ToiseksiSuuri
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[] t = { 3, 1, -7, 9, 15, 8 };
        int toiseksiSuurin = EtsiToiseksiSuurin(t);
        TulostaTaulukko(t, toiseksiSuurin);
        t = new int[] { 1, 2, 3, 4 };
        toiseksiSuurin = EtsiToiseksiSuurin(t);
        TulostaTaulukko(t, toiseksiSuurin);
        t = new int[] { 7, 10, 8, 2 };
        toiseksiSuurin = EtsiToiseksiSuurin(t);
        TulostaTaulukko(t, toiseksiSuurin);
        t = new int[] { 1, 223 };
        toiseksiSuurin = EtsiToiseksiSuurin(t);
        TulostaTaulukko(t, toiseksiSuurin);
        t = new int[] { -1, -223 };
        toiseksiSuurin = EtsiToiseksiSuurin(t);
        TulostaTaulukko(t, toiseksiSuurin);
    }

    public static int EtsiToiseksiSuurin(int[] t)
    {
        int suurin = t[0];
        int toiseksiSuurin = int.MinValue;

        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] >= suurin)
            {
                toiseksiSuurin = suurin;
                suurin = t[i];
            }
            if (t[i] > toiseksiSuurin && t[i] != suurin) toiseksiSuurin = t[i];
        }

        if (t.Length < 2) return int.MinValue;
        return toiseksiSuurin;

    }

    public static void TulostaTaulukko(int[] t, int tS)
    {
        Console.Write("Taulukon ");
        foreach (int luku in t)
        {
            Console.Write(luku + " ");
        }
        Console.Write("toiseksi suurin alkio on " + tS + "\n");
    }

}
