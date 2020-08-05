using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// @author: Vesa Lappalainen
/// @version: 01.10.2011
/// @version: 15.10.2011
///
/// <summary>
/// Tutkitaan elämäpeliä. 
/// </summary>
/// <remarks>
/// Säännöt ovat oletuksena b3s23 (born 3/stay 2,3), mutta 
/// saaannot-taulukolla voidaan
/// viedä peliin muitakin sääntöjä.
/// </remarks>
public class Sopulit2
{
    private static int[,] b3s23 = 
                               {//  0 1 2 3 4 5 6 7 8
                                   {0,0,0,1,0,0,0,0,0}, // born
                                   {0,0,1,1,0,0,0,0,0}  // stay
                               };

    /// <summary>
    /// Muodostaa seuraavan vaiheen menemällä taulukkoa 
    /// rivi kerrallaan ylhäältä alas ja vasemmalta oikealle.
    /// Tulos tulee samaan taulukkoon jos seuraava = null.
    /// </summary>
    /// <param name="sukupolvi">Nykyinen vaihe, josta tilanne lasketaan</param>
    /// <param name="seuraava">Vaihe, johon uusi vaihe lasketaan.  Jos == null,
    /// niin vaihe lasketaan vaihe-taulukkoon.  Jos taulukoiden koot eivät
    /// ole samat, käyteään pienemmän kokoa</param>
    /// <param name="saannot">2x8 taulukko siitä, millä naapurimäärillä herää
    /// ja millä naapurimäärillä säilyy hengissä.</param>
    /// <example>
    /// <pre name="test">
    ///   int[,] vaihe = {
    ///                { 1,0,1,1 },
    ///                { 0,1,1,0 },
    ///                { 1,0,0,0 },
    ///                { 1,0,0,1 }
    ///              };
    ///    SeuraavaSukupolvi(vaihe);
    ///    Demo5.Sopulit.Jonoksi(vaihe," ",",") === "0 1 0 0,1 0 0 0,1 1 0 0,1 1 1 0";
    ///    SeuraavaSukupolvi(vaihe);
    ///    Demo5.Sopulit.Jonoksi(vaihe," ",",") === "0 0 0 0,1 1 0 0,0 0 1 0,0 1 1 0";
    ///    SeuraavaSukupolvi(vaihe);
    ///    Demo5.Sopulit.Jonoksi(vaihe," ",",") === "0 0 0 0,0 0 0 0,0 1 1 0,0 1 1 0";
    /// </pre>
    /// </example>
    public static void SeuraavaSukupolvi(int[,] sukupolvi, int[,] seuraava = null,
                      int[,] saannot = null)
    {
        if (seuraava == null) seuraava = sukupolvi;
        if (saannot == null) saannot = b3s23;
        int maxy = Math.Min(sukupolvi.GetLength(0), seuraava.GetLength(0));
        int maxx = Math.Min(sukupolvi.GetLength(1), seuraava.GetLength(1));
        for (int iy = 0; iy < maxy; iy++)
        {
            for (int ix = 0; ix < maxx; ix++)
            {
                int arvo = sukupolvi[iy, ix];
                int naapureita = LaskeNaapurit(sukupolvi, iy, ix);
                seuraava[iy, ix] = saannot[arvo, naapureita];
            }
        }
    }


    /// <summary>
    /// Muodostaa seuraavan vaiheen menemällä taulukkoa 
    /// rivi kerrallaan ylhäältä alas ja vasemmalta oikealle.
    /// Tulos tulee samaan taulukkoon jos seuraava = null.
    /// Käyteään naapureita kuten toruksen pintaa.
    /// </summary>
    /// <param name="sukupolvi">Nykyinen vaihe, josta tilanne lasketaan</param>
    /// <param name="seuraava">Vaihe, johon uusi vaihe lasketaan.  Jos == null,
    /// niin vaihe lasketaan vaihe-taulukkoon.  Jos taulukoiden koot eivät
    /// ole samat, käyteään pienemmän kokoa</param>
    /// <param name="saannot">2x8 taulukko siitä, millä naapurimäärillä herää
    /// ja millä naapurimäärillä säilyy hengissä.</param>
    /// <example>
    /// <pre name="test">
    ///   int[,] s1 = {
    ///                { 1,0,1,1 },
    ///                { 0,0,0,0 },
    ///                { 1,0,0,0 },
    ///                { 1,0,0,1 }
    ///              };
    ///    int[,] s2 = new int[4,4];  
    ///                  //  0 1 2 3 4 5 6 7 8
    ///    int[,] b02s1 = { {1,0,1,0,0,0,0,0,0}, // born
    ///                     {0,1,0,0,0,0,0,0,0}  // stay
    ///                   };
    ///    SeuraavaSukupolviTorus(s1,s2,b02s1); 
    ///    Demo5.Sopulit.Jonoksi(s2," ",",") === "0 0 0 0,0 0 1 0,0 1 0 0,0 0 0 0";
    ///    SeuraavaSukupolviTorus(s2,s1,b02s1);
    ///    Demo5.Sopulit.Jonoksi(s1," ",",") === "1 0 0 0,0 1 1 0,0 1 1 0,0 0 0 1";
    ///    SeuraavaSukupolviTorus(s1,s2,b02s1); 
    ///    Demo5.Sopulit.Jonoksi(s2," ",",") === "0 0 0 0,0 0 0 0,0 0 0 0,0 0 0 0";
    ///    SeuraavaSukupolviTorus(s2,s1,b02s1);
    ///    Demo5.Sopulit.Jonoksi(s1," ",",") === "1 1 1 1,1 1 1 1,1 1 1 1,1 1 1 1";
    /// </pre>
    /// </example>
    public static void SeuraavaSukupolviTorus(int[,] sukupolvi, int[,] seuraava = null,
                      int[,] saannot = null)
    {
        if (seuraava == null) seuraava = sukupolvi;
        if (saannot == null) saannot = b3s23;
        int maxy = Math.Min(sukupolvi.GetLength(0), seuraava.GetLength(0));
        int maxx = Math.Min(sukupolvi.GetLength(1), seuraava.GetLength(1));
        for (int iy = 0; iy < maxy; iy++)
        {
            for (int ix = 0; ix < maxx; ix++)
            {
                int arvo = sukupolvi[iy, ix];
                int naapureita = LaskeNaapuritTorus(sukupolvi, iy, ix);
                seuraava[iy, ix] = saannot[arvo, naapureita];
            }
        }
    }


    /// <summary>
    /// Laskee montako nollasta poikkeavaa naapuria on valitulla alkiolla
    /// </summary>
    /// <param name="sukupolvi">taulukko josta naapureita etsitään</param>
    /// <param name="rivi">minkä rivin naapureita etsitään</param>
    /// <param name="sarake">minkä sarakkeen naapureita etsitään</param>
    /// <returns></returns>
    /// <example>
    /// <pre name="test">
    ///   int[,] alku = {
    ///                { 1,0,1,1,0 },
    ///                { 0,1,1,0,0 },
    ///                { 1,0,0,0,0 },
    ///                { 1,0,0,0,0 }
    ///              };
    ///   LaskeNaapurit(alku,0,0) === 1;
    ///   LaskeNaapurit(alku,3,0) === 1;
    ///   LaskeNaapurit(alku,0,1) === 4;
    ///   LaskeNaapurit(alku,2,2) === 2;
    ///   LaskeNaapurit(alku,3,2) === 0;
    /// </pre>
    /// </example>
    public static int LaskeNaapurit(int[,] sukupolvi, int rivi, int sarake)
    {
        int summa = 0;
        int alkuy = rivi - 1;
        int loppuy = rivi + 1;
        int alkux = sarake - 1;
        int loppux = sarake + 1;

        if (alkuy < 0) alkuy = 0;
        if (loppuy >= sukupolvi.GetLength(0)) loppuy = sukupolvi.GetLength(0) - 1;
        if (alkux < 0) alkux = 0;
        if (loppux >= sukupolvi.GetLength(1)) loppux = sukupolvi.GetLength(1) - 1;

        for (int iy = alkuy; iy <= loppuy; iy++)
            for (int ix = alkux; ix <= loppux; ix++)
                summa += sukupolvi[iy, ix];
        summa -= sukupolvi[rivi, sarake];
        return summa;
    }


    /// <summary>
    /// Laskee montako nollasta poikkeavaa naapuria on valitulla alkiolla.
    /// Naapuri otetaan reunojen tapauksessa "kiertämällä toiselle laidalle" (=Torus).
    /// </summary>
    /// <param name="sukupolvi">taulukko josta naapureita etsitään</param>
    /// <param name="rivi">minkä rivin naapureita etsitään</param>
    /// <param name="sarake">minkä sarakkeen naapureita etsitään</param>
    /// <returns></returns>
    /// <example>
    /// <pre name="test">
    ///   int[,] alku = {
    ///                { 1,0,1,1 },
    ///                { 0,1,1,0 },
    ///                { 1,0,0,0 },
    ///                { 1,0,0,0 }
    ///              };
    ///   LaskeNaapuritTorus(alku,0,0) === 3;
    ///   LaskeNaapuritTorus(alku,3,0) === 3;
    ///   LaskeNaapuritTorus(alku,0,1) === 5;
    ///   LaskeNaapuritTorus(alku,2,2) === 2;
    ///   LaskeNaapuritTorus(alku,3,2) === 2;
    /// </pre>
    /// </example>
    public static int LaskeNaapuritTorus(int[,] sukupolvi, int rivi, int sarake)
    {
        int summa = 0;
        int ny = sukupolvi.GetLength(0);
        int nx = sukupolvi.GetLength(1);

        for (int iy = rivi - 1; iy <= rivi + 1; iy++)
        {
            int ity = (iy + ny) % ny; // iy toruksen pinnalla
            for (int ix = sarake - 1; ix <= sarake + 1; ix++)
            {
                int itx = (ix + nx) % nx; // ix toruksen pinnalla // 0-5  5 % 6 = 5  7 % 6 = 1 
                summa += sukupolvi[ity, itx];
            }
        }
        summa -= sukupolvi[rivi, sarake];
        return summa;
    }

}
