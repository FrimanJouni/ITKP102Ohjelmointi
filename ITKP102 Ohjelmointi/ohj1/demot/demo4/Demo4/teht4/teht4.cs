using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Omanimi
/// @version Päivämäärä
/// <summary>
/// 
/// </summary>
public class teht4
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        string merkkijono = "Kissa istuu.";
        string vertailtu = IsoVaiPieni(merkkijono);
        Console.WriteLine("Ensimmäinen merkki on " + vertailtu);
    }

    public static string IsoVaiPieni(string lause)
    {
        if (String.IsNullOrEmpty(lause)) return "pieni";
        if (Char.IsNumber(lause[0])) return "pieni";
        if (Char.IsLower(lause[0])) return "pieni";
        else return "iso";
    }
}
