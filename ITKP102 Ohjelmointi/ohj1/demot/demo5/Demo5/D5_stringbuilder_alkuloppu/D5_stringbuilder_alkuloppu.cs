using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 14102018
/// <summary>
/// Käyttää StringBuilder metodia lisäämään mnerkkijonon alkuun ja loppuun haluttua tavaraa
/// </summary>
public class D5_stringbuilder_alkuloppu
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        StringBuilder jono;
        jono = new StringBuilder("kissa istuu");
        LisaaAlkuunJaLoppuun(jono, "***"); // jono muuttuu
        Console.WriteLine("Jono on nyt " + jono);
        // tulostaa: Jono on nyt *** kissa istuu ***
    }

    public static StringBuilder LisaaAlkuunJaLoppuun (StringBuilder alkp, string lisays)
    {
        StringBuilder palautus = alkp.Append(" ");
        palautus.Append(lisays);
        palautus = palautus.Insert(0, " ");
        palautus = palautus.Insert(0, lisays);
        return palautus;
    }

}
