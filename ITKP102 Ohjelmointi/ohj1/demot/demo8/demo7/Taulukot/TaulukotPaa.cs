using System;
using Demo6;
using Demo7;

/// @author  Vesa Lappalainen
/// @version 16.10.2011
/// <summary>
/// Testataan taulukkoaliohjelmia
/// </summary>
public class TaulukotPaa
{
    /// <summary>
    /// Testataan taulukkoaliohjelmia
    /// </summary>
    public static void Main()
    {
        Taulukot.ErotaDouble("k", 1);
        double[,] mat1 = { { 1, 2, 3 }, { 2, 2, 2 }, { 4, 2, 3 } };
        double[,] mat2 = { { 9, 2, 8 }, { 1, 2, 5 }, { 3, 19, -3 } };
        double[,] mat3 = Taulukot.Summa(mat1, mat2);
        Console.WriteLine(Matriisit.Jonoksi(mat3, " ", "{0,5:0.00}"));

        double[] luvut = Taulukot.ErotaLuvut("2.23 3 4 5 k      9 ;5");
        Console.WriteLine(Matriisit.Jonoksi(luvut, " ", "{0,5:0.00}"));
        double[] l2 = luvut;
        Array.Resize(ref l2, 10);
        Console.WriteLine(Matriisit.Jonoksi(luvut, " ", "{0,5:0.00}"));
        Console.WriteLine(Matriisit.Jonoksi(l2, " ", "{0,5:0.00}"));
        l2 = luvut;
        Array.Resize(ref l2, 4);
        Console.WriteLine(Matriisit.Jonoksi(luvut, " ", "{0,5:0.00}"));
        Console.WriteLine(Matriisit.Jonoksi(l2, " ", "{0,5:0.00}"));
    }
}
