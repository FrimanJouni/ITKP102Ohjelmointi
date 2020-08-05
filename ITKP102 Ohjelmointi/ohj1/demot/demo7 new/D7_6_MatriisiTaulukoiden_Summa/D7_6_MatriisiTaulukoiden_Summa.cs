using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 28102018
/// <summary>
/// 
/// </summary>
public class D7_6_MatriisiTaulukoiden_Summa
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        double[,] mat1 = { { 1, 2, 3 }, { 2, 2, 2 }, { 4, 2, 3 } };
        double[,] mat2 = { { 9, 2, 8 }, { 1, 2, 5 }, { 3, 19, -3 } };
        double[,] mat3 = Summa(mat1, mat2);
        Console.WriteLine(mat3[0, 0] + " " + mat3[0, 1] + " " + mat3[0, 2]);
        Console.WriteLine(mat3[1, 0] + " " + mat3[1, 1] + " " + mat3[1, 2]);
        Console.WriteLine(mat3[2, 0] + " " + mat3[2, 1] + " " + mat3[2, 2]);
    }

    public static double[,] Summa(double[,] t1, double[,] t2)
    {
        int rivi = t1.GetLength(0);
        int sara = t1.GetLength(1);
        double[,] tulos = new double[rivi, sara];

        for(int iRivi = 0; iRivi < rivi; iRivi++)
        {
            for(int iSara = 0; iSara < sara; iSara++)
            {
                tulos[iRivi, iSara] = t1[iRivi, iSara] + t2[iRivi, iSara];
            }
        }

        return tulos;
    }

}
