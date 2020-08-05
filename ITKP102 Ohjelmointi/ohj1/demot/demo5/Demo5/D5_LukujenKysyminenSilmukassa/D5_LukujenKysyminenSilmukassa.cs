using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frima
/// @version ..2018
/// <summary>
/// 
/// </summary>
public class D5_LukujenKysyminenSilmukassa
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[] luvut = new int[3];
        int i = 0;
        while (i < 3)
        {
            int tulosteNumero = i + 1;
            Console.Write("Anna {0}. kokonaisluku >", tulosteNumero);
            luvut[i] = int.Parse(Console.ReadLine());
            i++;
        }

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
