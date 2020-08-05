using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author frima
/// @version ..2018
/// <summary>
/// 
/// </summary>
public class D10_3_LottoPallojenArpominen
{
    /// <summary>
    /// 
    /// </summary>
    public static void Main(String[] args)
    {
        List<int> pallot = new List<int>();

        for (int i = 1; i < 40; i++)
        {
            pallot.Add(i);
        }

        Jypeli.RandomGen.Shuffle(pallot);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(pallot[i]);
        }

    }

}
