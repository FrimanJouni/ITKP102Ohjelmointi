using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frima
/// @version ..2018
/// <summary>
/// 
/// </summary>
public class D5_SummaaYliMenevat
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[] luvut = { 12, 3, 5, 9, 7, 1, 4, 9 };
        int summa = SummaYli(luvut, 4);
        Console.WriteLine("Yli 4 olevien lukujen summa on: " + summa);
    }

    public static int SummaYli(int[] t, int raja)
    {
        int i = 0;
        int palautus = 0;
        while (i < t.Length)            //Silmukka käy läpi koko tauluko
        {
            if (t[i] > raja)        //Jonka sisällä tulostetaan vain sopivat taulukon alkiot
            {
                palautus += t[i];
            }

            i++;
        }

        return palautus;
    }

}
