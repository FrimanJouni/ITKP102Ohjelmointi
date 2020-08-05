using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 22102018
/// <summary>
/// Antaa skaalaimen väliltä 0-1 (esim 0.2) ja kaksi muuta lukua joiden välille funktio löytää arvon samalla skaalalla kuin annettu skaalain.
/// Tarvitaan esimerkiksi satunnaislukugeneraattoreissa joissa ne tuottavat lukuja välille 0-1, joten tätä tarvitaan tuottamaan satunnaisia lukuja muille väleille.
/// </summary>
public class D6_6_SkaalainValille_0_1
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        Console.WriteLine(Skaalaa(0.2, -3, 3));
        Console.WriteLine(Skaalaa(0.2, 1, 6));
        Console.WriteLine(Skaalaa(0.0, 1, 6));
        Console.WriteLine(Skaalaa(1.0, 1, 6));
    }

    public static double Skaalaa(double luku, double min, double max)
    {
        //double skaalain = min + (max - min) * luku;
        //return skaalain;

        return min + (max - min) * luku;
    }

}
