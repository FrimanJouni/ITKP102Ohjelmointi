using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Omanimi
/// @version Päivämäärä
/// <summary>
/// 
/// </summary>
public class teht3
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("Toistan mitä sanot, mutta en osaa sanoa l:ää!");
        // string lause = "ralliauto ajaa superkovaa.";
        Console.Write("Anna teksti  >");
        string lause = Console.ReadLine();
        Console.WriteLine();
        string muutettulause = MuutaKirjaimet(lause);
        Console.WriteLine("Sanoit siis : " + muutettulause);
    }

    public static string MuutaKirjaimet(string lause)
    {
        return lause.Replace("r","l").Replace("R","L");
    }

}
