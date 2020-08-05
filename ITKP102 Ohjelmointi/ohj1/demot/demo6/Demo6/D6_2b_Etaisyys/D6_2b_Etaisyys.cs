using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frima
/// @version ..2018
/// <summary>
/// 
/// </summary>
public class D6_2b_Etaisyys
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        double etaisyys = Etaisyys(9.0, 6.0);
        Console.WriteLine(etaisyys);
        double etaisyys1 = Etaisyys(-6.0, 9.0);
        Console.WriteLine(etaisyys1);
        double etaisyys4 = Etaisyys(-9.0, 6.0);
        Console.WriteLine(etaisyys4);
        double etaisyys2 = Etaisyys(0.0, 0.0);
        Console.WriteLine(etaisyys2);
        double etaisyys3 = Etaisyys(-6.0, -9.0);
        Console.WriteLine(etaisyys3);

    }

    public static double Etaisyys(double matka1, double matka2)
    {
        if (matka1 - matka2 < 0) return -(matka1 - matka2);
        return matka1 - matka2;
    }

}
