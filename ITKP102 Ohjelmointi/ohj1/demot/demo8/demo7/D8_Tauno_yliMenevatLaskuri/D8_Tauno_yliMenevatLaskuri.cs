using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author vesal
/// @version 26.10.2013
/// <summary>
/// Lasketaan tietynlaisen osajonon pituus
/// </summary>
public class Tauno8
{
    /// <summary>
    ///
    /// </summary>
    public static void Main()
    {
        int[] t = { 96, 73, 23, 46, 93, 72 };
        int pituus = PisinYliRajan(t, 50);
        Console.WriteLine(pituus);
    }


    /**
     * Tutkitaan mikä on pisimmän osajonon pituus, jossa kaikki
     * alkiot ovat suurempia kuin raja.
     * Alla esim 1. esimerkissä jono 3,5,4 on tällainen osajono
     * (="jonosta" otettu peräkkäisten numeroiden osa).
     * @param taulu Tutkittava taulukko jonka luvut tulkitaan jonoksi
     * @return pisimmän yli rajan sisältävän osajonon pituus
     * @example
     * <pre name="test">
     *    Tauno8.PisinYliRajan(new int[]{2,3,4,1,2,0,1,3,5,4,1},2) === 3;
     *    Tauno8.PisinYliRajan(new int[]{2,3,4,1,2,0,1,3,5,2,1},2) === 2;
     *    Tauno8.PisinYliRajan(new int[]{5,3,4,5,5,5,1,3,5,3,1},2) === 6;
     *    Tauno8.PisinYliRajan(new int[]{2,3,4,1,2},2) === 2;
     *    Tauno8.PisinYliRajan(new int[]{2,3,2,1,2},2) === 1;
     *    Tauno8.PisinYliRajan(new int[]{3,3,2,1,2},2) === 2;
     *    Tauno8.PisinYliRajan(new int[]{2,1,2,1,2},2) === 0;
     *    Tauno8.PisinYliRajan(new int[]{3,3},2) === 2; // Kaikki yli
     *    Tauno8.PisinYliRajan(new int[]{3},2) === 1; // Vain yksi alkio
     *    Tauno8.PisinYliRajan(new int[]{},2) === 0; // ei yhtään alkiota
     * </pre>
     */
    public static int PisinYliRajan(int[] t, int raja)
    {
        int laskuri = 0;
        int pisinJono = 0;

        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] > raja) laskuri++;
            if (laskuri > pisinJono) pisinJono = laskuri;
            if (t[i] < raja) laskuri = 0;
        }
        return pisinJono;
    }
}
