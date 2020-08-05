using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 11.11.2018
/// <summary>
/// 
/// </summary>
public class D9_Tauno_keskiarvoRajojensisällä
{
    /// <summary>
    /// Taulukoiden alkioista keskiarvo annettujen rajojen sisäpuolella.
    /// </summary>
    public static void Main()
    {
        int[] maarat = new int[] { 3, 0, 7, 6, 5, 99, 5 };
        double ka = Keskiarvo(maarat, 0, 10);
        System.Console.WriteLine(ka);
    }

    public static double Keskiarvo(int[] taulukko, int ala, int yla)
    {
        double keskiarvo = 0;
        int laskuri = 0;

        foreach (int luku in taulukko)
        {
            if(luku <= yla && luku >= ala)  // Ei ota huomioon jos rajat ovat "väärillä" puolilla esimerkiksi alaraja on ylärajaa isompi.
            {
                keskiarvo += luku;
                laskuri++;
            }
        }

        if (laskuri == 0) return -1;
        keskiarvo = keskiarvo / laskuri;
        return keskiarvo;
    }

}
