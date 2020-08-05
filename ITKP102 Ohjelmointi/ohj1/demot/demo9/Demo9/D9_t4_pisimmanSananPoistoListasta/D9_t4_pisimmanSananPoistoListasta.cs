using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frimanJ
/// @version 11.11.2018
/// <summary>
/// 
/// </summary>
public class D9_t4_pisimmanSananPoistoListasta
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        List<string> sanat = new List<string> { "susi", "kissa", "kissa", "kana", "koira", "mato", "täi", "kissa" };
        Console.WriteLine(string.Join(" ", sanat));

        string pisin = EtsiPisin(sanat);
        Console.WriteLine(pisin);
        PoistaSanat(sanat, pisin);
        Console.WriteLine(string.Join(" ", sanat));
    }

    public static string EtsiPisin(List<string> sanat)
    {
        int pisinSana = 0;
        int index = -1;

        for (int i = 0; i < sanat.Count; i++)
        {
            if (sanat[i].Length > pisinSana)
            {
                pisinSana = sanat[i].Length;
                index = i;

            }
        }
        return sanat[index];
    }

    public static void PoistaSanat(List<string> sanat, string pisin)
    {
        for (int i = 0; i < sanat.Count; i++)
        {
            sanat.Remove(pisin);
        }
    }

}
