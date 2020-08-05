using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

namespace Demo7
{
    /// @author  Vesa Lappalainen
    /// @version 16.10.2011
    /// <summary>
    /// Aliohjelmia taulukoille 
    /// </summary>
    public class Taulukot
    {
        /// <summary>
        /// Lasketaan yhteen kaksi matriisia vastinalkioittain.
        /// Mikäli matriisit eivät ole yhtäsuuria, tehdään tulosmatriisin
        /// kooksi matriisien yhteinen pienin koko.
        /// </summary>
        /// <param name="mat1">ensimmäinen summattava</param>
        /// <param name="mat2">toinen summattava</param>
        /// <returns>taulukkojen summataulukko</returns>
        /// <example>
        /// <pre name="test">
        /// // System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("fi-FI");
        ///   CultureInfo ci = new CultureInfo("fi-FI");
        ///   ci.NumberFormat.NumberDecimalSeparator = ".";
        ///   // CultureInfo.CurrentCulture = ci;
        ///   System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        ///   // System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
        ///   // CultureInfo.DefaultThreadCurrentCulture = ci;
        /// double[,] mat1 = { { 1, 2, 3 }, { 2, 2, 2 }, { 4, 2, 3 } };
        /// double[,] mat2 = { { 9, 2, 8 }, { 1, 2, 5 }, { 3, 19, -3 } };
        /// double[,] mat23 = { { 1, 2, 3 }, { 2, 2, 2 } };
        /// double[,] mat32 = { { 9, 2 }, { 1.1, 2 }, { 3, 19 } };
        /// double[,] mat = Summa(mat1, mat2);
        /// Demo6.Matriisit.Jonoksi(mat," ","{0}",",") === "10 4 11,3 4 7,7 21 0"; // tai:
        /// String.Join(" ",mat.Cast<double>()) === "10 4 11 3 4 7 7 21 0";
        /// mat = Summa(mat23, mat32);
        /// Demo6.Matriisit.Jonoksi(mat," ","{0}",",") === "10 4,3.1 4"; // tai:
        /// String.Join(" ",mat.Cast<double>()) === "10 4 3.1 4";
        /// </pre>
        /// </example>
        public static double[,] Summa(double[,] mat1, double[,] mat2)
        {
            int ny = Math.Min(mat1.GetLength(0), mat2.GetLength(0));
            int nx = Math.Min(mat1.GetLength(1), mat2.GetLength(1));
            double[,] tulos = new double[ny, nx];
            for (int iy = 0; iy < ny; iy++)
                for (int ix = 0; ix < nx; ix++)
                    tulos[iy, ix] = mat1[iy, ix] + mat2[iy, ix];
            return tulos;
        }


        /// <summary>
        /// Erotetaan merkkijonossa olevat luvut reaalilukutaulukoksi.
        /// Luvut voivat olla erotettuna toisistaan välilyönnein,
        /// pilkuin, puolipistein yms.  Huonot luvut palautetaan 0:na.
        /// </summary>
        /// <param name="jono">jono josta lukuja otetaan</param>
        /// <returns>taulukollinen lukuja</returns>
        /// <example>
        /// <pre name="test">
        ///   double[] luvut = ErotaLuvut("2 3 4 5 k      9 ;5");
        ///   String.Join(" ",luvut) === "2 3 4 5 0 9 5";  
        /// </pre>
        /// </example>
        public static double[] ErotaLuvut(string jono)
        {
            string[] osat = jono.Split(new char[] { ' ', ',', ';', '/', ':' }, StringSplitOptions.RemoveEmptyEntries);
            double[] tulos = new double[osat.Length];
            for (int i = 0; i < osat.Length; i++)
            {
                tulos[i] = ErotaDouble(osat[i], 0.0);
            }
            return tulos;
        }


        /// <summary>
        /// Lasketaan monestikko etsittävä kirjain esiintyy jonossa
        /// </summary>
        /// <param name="jono">tutkittava jono</param>
        /// <param name="kirjain">etsittävä kirjain</param>
        /// <returns>kirjaimen esiintymien lukumäärä</returns>
        /// <example>
        /// <pre name="test">
        ///   LaskeKirjaimet("kissa",'s') === 2;
        ///   LaskeKirjaimet("kissa",'k') === 1;
        ///   LaskeKirjaimet("kissa",'K') === 1;
        /// </pre>
        /// </example>
        public static int LaskeKirjaimet(string jono, char kirjain)
        {
            int maara = 0;
            char pkirjain = Char.ToLower(kirjain);
            foreach (char merkki in jono)
                if (Char.ToLower(merkki) == pkirjain) maara++;
            return maara;
        }



        /// <summary>
        /// Otetaan jonossa oleva reaaliluku.  Jos luku ei ole
        /// mielekäs luku, niin palautetaan oletus. Desimaalina on aina .
        /// </summary>
        /// <param name="jono">jono josta reaaliluku otetaan</param>
        /// <param name="oletus">mikä arvo annetaan jos jonosta ei saada lukua</param>
        /// <returns>otettu reaaliluku</returns>
        /// <example>
        /// <pre name="test">
        ///   ErotaDouble("") ~~~ 0.0;
        ///   ErotaDouble(" 2.3 ") ~~~ 2.3;
        ///   ErotaDouble("5 3") ~~~ 5;
        ///   ErotaDouble("5k3") ~~~ 5;
        ///   ErotaDouble("5e3") ~~~ 5000;
        ///   ErotaDouble("5E-3") ~~~ 0.005;
        ///   ErotaDouble("k") ~~~ 0.0;
        ///   ErotaDouble("k",1.0) ~~~ 1.0;
        ///   ErotaDouble("2..3") ~~~ 0.0;
        /// </pre>
        /// </example>
        public static double ErotaDouble(string jono, double oletus = 0.0)
        {
            string reg = @"^([-0-9\.eE]+)(.*)$";
            Match m = Regex.Match(jono.Trim(), reg);
            string tjono = m.Groups[1].Value;
            double tulos = oletus;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            if (double.TryParse(tjono,NumberStyles.Any,nfi, out tulos)) return tulos;
            return oletus;
        }


        /// <summary>
        /// Otetaan jonossa oleva reaaliluku.  Jos luku ei ole
        /// mielekäs luku, niin palautetaan oletus.
        /// </summary>
        /// <param name="jono">jono josta reaaliluku otetaan</param>
        /// <param name="oletus">mikä arvo annetaan jos jonosta ei saada lukua</param>
        /// <returns>otettu reaaliluku</returns>
        /// <example>
        /// <pre name="test">
        ///   Erota("",0.0) ~~~ 0.0;
        ///   Erota(" 2.3 ",0.0) ~~~ 2.3;
        ///   Erota("5 3",0.0) ~~~ 5;
        ///   Erota("k",0.0) ~~~ 0.0;
        ///   Erota("k",1.0) ~~~ 1.0;
        ///   Erota("2..3",0.0) ~~~ 0.0;
        /// </pre>
        /// </example>
        public static double Erota(string jono, double oletus)
        {
            return ErotaDouble(jono, oletus);
        }
    }
}
