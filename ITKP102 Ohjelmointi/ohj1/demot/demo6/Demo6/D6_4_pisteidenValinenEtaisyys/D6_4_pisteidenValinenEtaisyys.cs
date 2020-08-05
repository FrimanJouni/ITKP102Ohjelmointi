using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 22102018
/// <summary>
/// Mittaa etäisyyden kahden pisteen välillä 2-ulotteisessa taulukossa.
/// </summary>
public class D6_4_pisteidenValinenEtaisyys
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        string muoto = "{0:F5}";
        Console.WriteLine(muoto, Etaisyys(0, 0, 1, 1));
        Console.WriteLine(muoto, Etaisyys(0, 0, 0, 1));
        Console.WriteLine(muoto, Etaisyys(3, 0, 0, 4));
        Console.WriteLine(muoto, Etaisyys(-1.5, 1.1, 2.7, -9.2));

        Console.WriteLine(Etaisyys(3, 0, 0, 4));
        Console.WriteLine(Etaisyys(-1.5, 1.1, 2.7, -9.2));
    }

    public static double Etaisyys(double x1, double y1, double x2, double y2)   
    {

        double etaisyys = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));     //Pythagoran lause z^2 = x^2 + y^2
        return etaisyys;
    }

}
