using System;

public class Vuodet
{
    public static void Main()
    {
        bool olikoKarkausvuosi = Karkausvuosi(2015);
        Console.WriteLine(olikoKarkausvuosi);
        Console.WriteLine(Karkausvuosi(1900));
        Console.WriteLine(Karkausvuosi(2000));
        Console.WriteLine(Karkausvuosi(2001));
        Console.WriteLine(Karkausvuosi(2004));
        Console.WriteLine(Karkausvuosi(1200));
        Console.WriteLine(Karkausvuosi(1800));
        Console.WriteLine(Karkausvuosi(0));
    }

    public static bool Karkausvuosi(int vuosi)
    {
        if (vuosi % 100 == 0 && vuosi != 0) //tarkistaa onko kyseessä täysi vuosisata
        {
            if ((vuosi / 100) % 4 == 0) return true; //jos vuosisata on jaollinen palauttaa true
            return false;   //muuten false
        }

        if (vuosi % 4 == 0 && vuosi != 0) return true; // vuosisadattomissa tilanteissa vaan suoraan tarkistaa onko 4 jaollinen
        return false;   // muuten false
    }
}