using System;

namespace Demo8
{
    /// @author  Jouni Friman
    /// @version 4.11.2018
    /// <summary>
    /// Aliohjelmia karkauspäiviin ja vuodenaikoihin
    /// </summary>
    public class Vuodet
    {
        /// <summary> Talvea tarkoittava merkkijono           </summary>
        public const String TALVI = "talvi";
        /// <summary> Kevättä tarkoittava merkkijono          </summary>
        public const String KEVAT = "kevät";
        /// <summary> Kesää tarkoittava merkkijono            </summary>
        public const String KESA = "kesä";
        /// <summary> Syksyä tarkoittava merkkiono            </summary>
        public const String SYKSY = "syksy";
        /// <summary> Virheellinen vuodenaika                 </summary>
        public const String VIRHE = "";


        /// <summary>
        /// Tutkkitaan luokan aliohjelmien toimintaa
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Vuodenajat:");
            for (int i = 0; i <= 13; i++)
            {
                Console.WriteLine("{0,2} {1}", i, VuodenaikaIf(i));
            }
        }

        public static string VuodenaikaIf(int kuukausi)
        {
            if (kuukausi == 3 || kuukausi == 4 || kuukausi == 5) return "kevät";
            if (kuukausi == 6 || kuukausi == 7 || kuukausi == 8) return "kesä";
            if (kuukausi == 9 || kuukausi == 10 || kuukausi == 11) return "syksy";
            if (kuukausi == 12 || kuukausi == 1 || kuukausi == 2) return "talvi";
            return "";
        }
    }
}