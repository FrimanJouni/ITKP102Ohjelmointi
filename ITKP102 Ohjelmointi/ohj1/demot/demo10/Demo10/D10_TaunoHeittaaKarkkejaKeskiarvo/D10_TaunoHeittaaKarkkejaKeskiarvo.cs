using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frima
/// @version ..2018
/// <summary>
/// 
/// </summary>
public class D10_TaunoHeittaaKarkkejaKeskiarvo
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[] karkkimaarat = new int[] { 3, 0, 7, 6, 5, 99, 5 };
        double ka = Keskiarvo(karkkimaarat, 0, 99);
        System.Console.WriteLine(ka);
    }

    public static double Keskiarvo(int[] taulukko, int vialliset, int lopetus)
    {
        double keskiarvo = 0;
        int i = 0;
        foreach (int luku in taulukko)
        {
            if (luku >= lopetus) break;
            if(luku > vialliset)
            {
                i++;
                keskiarvo += luku;
            }
        }
        if (i == 0) return vialliset;

        keskiarvo = keskiarvo / i;
        return keskiarvo;
    }

}
