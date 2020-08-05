using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/// @author vesal
/// @version 20.10.2013
/// <summary>
/// Kahden taulukon sisätulo
/// </summary>
public class Tauno72
{
    /// <summary>
    /// Lasketaan kahden taulukon sisätulo
    /// </summary>
    public static void Main()
    {
        int[,] maski = { 
            {1,1,1},
            {1,1,0},
            {0,1,1} 
        };
        int[,] luvut = { 
           {255,34,120,222},
           {35,50,60,70},
           {50,90,102,10},
           {20,34,44,55} 
        };
        int st = Sisatulo(luvut, maski, 2, 1);  // 273
        Console.WriteLine(st);
    }


    /// <summary>
    /// Lasketaan matriin osan ja maskin välinen sisätulo (eli kerrotaan vastinalkiot ja summataan).
    /// Aloituspisteen iy,ix tulee olla sisäpiste (se ei saa olla reunassa)
    /// Maskin tulee olla 3x3 kokoinen.
    /// </summary>
    /// <param name="luvut">matriisi, jonka osa otetaan</param>
    /// <param name="maski">maski, jonka kanssa sisätulo lasketaan</param>
    /// <param name="iy">miltä riviltä luvut-taulukkoa aloitetaan</param>
    /// <param name="ix">miltä sarakkeelta luvut-taulukkoa aloitetaan</param>
    /// <returns>sisätulo</returns>
    /// <example>
    /// <pre name="test">
    ///    int[,] maski = { {1,1,1},{1,1,0},{0,1,1} };
    ///    int[,] luvut = { {255,34,120,222},{35,50,60,70},{50,90,102,10},{20,34,44,55} };
    ///    Sisatulo(luvut,maski,2,1) === 363;
    ///    Sisatulo(luvut,maski,1,1) === 686;
    ///    Sisatulo(luvut,maski,1,2) === 598;
    ///    Sisatulo(luvut,maski,2,2) === 471;
    /// </pre>
    /// </example>
    /// <example>
    /// <pre name="test">
    ///  int[,] naapurit = { {1,1,1},{1,0,1},{1,1,1} };
    ///  int[,] alkuSukupolvi = {
    ///    { 1,0,1,1 },
    ///    { 0,1,1,0 },
    ///    { 1,0,0,0 },
    ///    { 1,0,0,1 }
    ///  };
    ///  Sisatulo(alkuSukupolvi,naapurit,2,1) === 4;
    ///  Sisatulo(alkuSukupolvi,naapurit,1,1) === 4;
    ///  Sisatulo(alkuSukupolvi,naapurit,1,2) === 3;
    ///  Sisatulo(alkuSukupolvi,naapurit,2,2) === 3;
    /// </pre>
    /// </example>
    public static int Sisatulo(int[,] luvut, int[,] maski, int iy, int ix)
    {
        int summa = 0;
        /*
        // vain paikan 2,1 summa
        summa += luvut[1, 0] * maski[0, 0];
        summa += luvut[1, 1] * maski[0, 1];
        summa += luvut[1, 2] * maski[0, 2];
        summa += luvut[2, 0] * maski[1, 0];
        summa += luvut[2, 1] * maski[1, 1];
        summa += luvut[2, 2] * maski[1, 2];
        summa += luvut[3, 0] * maski[2, 0];
        summa += luvut[3, 1] * maski[2, 1];
        summa += luvut[3, 2] * maski[2, 2];
        */
        /*
        summa += luvut[iy - 1, ix - 1] * maski[0, 0];
        summa += luvut[iy - 1, ix + 0] * maski[0, 1];
        summa += luvut[iy - 1, ix + 1] * maski[0, 2];
        summa += luvut[iy + 0, ix - 1] * maski[1, 0];
        summa += luvut[iy + 0, ix + 0] * maski[1, 1];
        summa += luvut[iy + 0, ix + 1] * maski[1, 2];
        summa += luvut[iy + 1, ix - 1] * maski[2, 0];
        summa += luvut[iy + 1, ix + 0] * maski[2, 1];
        summa += luvut[iy + 1, ix + 1] * maski[2, 2];
         */
        /*
        int y = -1;

        int x = -1;
        summa += luvut[iy + y, ix + x] * maski[y+1, x+1]; x++;
        summa += luvut[iy + y, ix + x] * maski[y+1, x+1]; x++;
        summa += luvut[iy + y, ix + x] * maski[y+1, x+1]; x++;
        y++;

        x = -1;
        summa += luvut[iy + y, ix + x] * maski[y+1, x+1]; x++;
        summa += luvut[iy + y, ix + x] * maski[y+1, x+1]; x++;
        summa += luvut[iy + y, ix + x] * maski[y+1, x+1]; x++;
        y++;

        x = -1;
        summa += luvut[iy + y, ix + x] * maski[y+1, x+1]; x++;
        summa += luvut[iy + y, ix + x] * maski[y+1, x+1]; x++;
        summa += luvut[iy + y, ix + x] * maski[y+1, x+1]; x++;
        y++;
        */

        for (int my = 0; my <= 2; my++)
            for (int mx = 0; mx <= 2; mx++)
                summa += luvut[iy + my - 1, ix + mx - 1] * maski[my, mx];
        return summa;
    }


}
