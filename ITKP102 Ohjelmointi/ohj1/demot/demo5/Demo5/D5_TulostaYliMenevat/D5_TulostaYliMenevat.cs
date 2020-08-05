using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frima
/// @version ..2018
/// <summary>
/// 
/// </summary>
public class D5_TulostaYliMenevat
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main()
    {
        int[] luvut = { 12, 3, 5, 9, 7, 1, 4, 9 };
        TulostaYli(luvut, 4);
    }

    public static void TulostaYli(int[] t, int raja)
    {
        int i = 0;
        while (i < t.Length)
        {
            if (t[i] > raja)
            {
                Console.Write("{0} ", t[i]);            //Muista tuo perkeleen järjestys tuossa writessä kun ei ole sama kuin c++
            }

            i++;
        }
    }

}
