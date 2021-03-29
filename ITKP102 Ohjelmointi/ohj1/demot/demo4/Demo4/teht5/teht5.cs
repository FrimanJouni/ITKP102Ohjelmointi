using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author Omanimi
/// @version Päivämäärä
/// <summary>
/// 
/// </summary>
public class teht5
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        Console.Write("Anna 1. kokonaisluku >");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Anna 2. kokonaisluku >");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Anna 3. kokonaisluku >");
        int c = int.Parse(Console.ReadLine());
        Console.WriteLine();

        int suurin = Suurin(a, b, c);
        int pienin = Pienin(a, b, c);
        Console.WriteLine("Suurin luku on " + suurin);
        Console.WriteLine("Pienin luku on " + pienin);
    }

    public static int Suurin(int eka, int toka, int kolkki)
    {
        int suurin = eka;

        if (suurin < toka)suurin = toka;
        if (suurin < kolkki) suurin = kolkki;
        return suurin;
    }

    public static int Pienin(int eka, int toka, int kolkki)
    {
        int pienin = eka;

        if (pienin > toka) pienin = toka;
        if (pienin > kolkki) pienin = kolkki;
        return pienin;
    }



}
