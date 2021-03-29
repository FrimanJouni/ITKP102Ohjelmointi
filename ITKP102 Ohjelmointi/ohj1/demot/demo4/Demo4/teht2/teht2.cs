using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Omanimi
/// @version Päivämäärä
/// <summary>
/// 
/// </summary>
public class teht2
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        Console.Write("Anna 1. sana >");
        string sana1 = Console.ReadLine();
        Console.Write("Anna 2. sana >");
        string sana2 = Console.ReadLine();
        string pidempi = PidempiMerkkijono(sana1, sana2);
        Console.WriteLine("\"" + pidempi + "\" on pidempi sana");
    }

    public static string PidempiMerkkijono(string x, string y)
    {
        if (x.Length >= y.Length) return x;
        else return y;
    }

}
