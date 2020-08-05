using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 28102018
/// <summary>
/// Laskee halutusta stringistä halutun charrien määrän.
/// </summary>
public class D7_5_KirjaintenLaskeminen
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int sMaara = LaskeKirjaimet("kissa", 's');
        int kMaara = LaskeKirjaimet("kissa", 'k');
        int vMaara = LaskeKirjaimet("vesa on vekkuli veikkonen", 'v');
        Console.WriteLine(sMaara); // 2
        Console.WriteLine(kMaara); // 1
        Console.WriteLine(vMaara); // 3
    }

    public static int LaskeKirjaimet(string sana, char kirjain)
    {
        int maara = 0;
        for (int i = 0; i < sana.Length; i++)
        {
            if (sana[i] == kirjain) maara++;
        }
        return maara;
    }
}
