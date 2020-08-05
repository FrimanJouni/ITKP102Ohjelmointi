using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 14102018
/// <summary>
/// Taulukon suurin ja pienin arvo palautetaan metodilla
/// </summary>
public class D5_array_suurinpienin
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[] luvut = { 7, 9, 2 };

        int suurin = Suurin(luvut);
        int pienin = Pienin(luvut);

        Console.WriteLine("Suurin luku on " + suurin);
        Console.WriteLine("Pienin luku on " + pienin);
    }

    public static int Suurin(int[] luvut)
    {
        if (luvut[0] >= luvut[1])
        {
            if (luvut[0] >= luvut[2]) return luvut[0];
        }
        if (luvut[1] >= luvut[0])
        {
            if (luvut[1] >= luvut[2]) return luvut[1];
        }
        return luvut[2];
    }

    public static int Pienin(int[] luvut)
    {
        if (luvut[0] <= luvut[1])
        {
            if (luvut[0] <= luvut[2]) return luvut[0];
        }
        if (luvut[1] <= luvut[0])
        {
            if (luvut[1] <= luvut[2]) return luvut[1];
        }
        return luvut[2];
    }

}
