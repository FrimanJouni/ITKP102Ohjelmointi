using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;
using Jypeli.WP7;
using Demo5;

namespace Demo7
{
    /// @author  Vesa Lappalainen
    /// @version 01.10.2011
    /// @version 15.10.2011
    ///
    /// <summary>
    /// Game of life, jossa luodaan uusia populaatioita edellisestä kuvasta.
    /// Ks esim: http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
    /// </summary>
    public class GameOfLife : PhysicsGame
    {
#if WINDOWS || XBOX
        private const int NY = 60;
#else
    private const int NY = 30;
#endif
        private int[,] sukupolvi;
        private int[,] seuraavaSukupolvi;
        private GameObject[,] oliot;
        private Timer timer = new Timer();
        private Color[] varit = { Color.Black, Color.White };

        /// <summary>
        /// Alustetaan peli
        /// </summary>
        public override void Begin()
        {
            Level.Background.Color = Color.Black;

            double dy = Screen.Height / NY; // Lasketaan ruudun korkeus pikseleinä
            int nx = (int)(Screen.Width / dy);  // ja montako mahtuu X-suuntaan
            int ny = NY;

            sukupolvi = new int[ny, nx];           //  Luodaan taulukot
            seuraavaSukupolvi = new int[ny, nx];
            oliot = new GameObject[ny, nx];
            // seuraavaSukupolvi = sukupolvi;          // jos tämä on mukana, käyttäytyy eri tavalla

            LuoOliot(this, oliot);

            // IsFullScreen = true;

            timer.Interval = 0.1; // timeri antamaan tapahtuma 0.1 sek välein
            timer.Timeout += LaskeJaPiirraSeuraavaSukupolvi;
            timer.Start();

            ArvoSukupolvi();  // jos halutaan käynnistää automaattisesti

            Camera.ZoomToAllObjects();
            // Camera.Zoom(20);
            // Camera.Move(new Vector(Screen.Width/2, Screen.Height/2));

            // Kuuntelijat:
            Keyboard.Listen(Key.Escape, ButtonState.Pressed, Exit, "Poistu");
            Keyboard.Listen(Key.F1, ButtonState.Pressed, ShowControlHelp, "Näytä ohjeet");
            Keyboard.Listen(Key.Enter, ButtonState.Pressed, Jatka, "Jatka");
            Keyboard.Listen(Key.Space, ButtonState.Pressed, ArvoSukupolvi, "Arvo sukupolvi");
            Keyboard.Listen(Key.Delete, ButtonState.Pressed, TyhjennaSukupolvi, "Tyhjennä sukupolvi");
            Keyboard.Listen(Key.Right, ButtonState.Pressed, LaskeJaPiirraSeuraavaSukupolvi, "Seuraava sukupolvi");
            Keyboard.Listen(Key.Left, ButtonState.Pressed, PiirraEdellinenSukupolvi, "Edellinen sukupolvi");
            Mouse.IsCursorVisible = true;
            Mouse.Listen(MouseButton.Left, ButtonState.Pressed, HiiriPainettu, null);
            Mouse.Listen(MouseButton.Right, ButtonState.Pressed, delegate { Jatka(); }, "Jatka");

            TouchPanel.Listen(ButtonState.Pressed, NayttoaPainettu, null);
            TouchPanel.ListenGesture(GestureType.DoubleTap, delegate { Jatka(); }, "Jatka");
            TouchPanel.ListenGesture(GestureType.VerticalDrag, delegate { TyhjennaSukupolvi(); }, "Tyhjennä taulukko");
            TouchPanel.ListenGesture(GestureType.HorizontalDrag, delegate { ArvoSukupolvi(); }, "Arvo sukupolvi");
            Accelerometer.Listen(AccelerometerDirection.Shake, delegate { ArvoSukupolvi(); }, "Arvo sukupolvi");
            PhoneBackButton.Listen(Exit, "Lopeta peli");
        }


        /// <summary>
        /// Lisätään peliin ruudukollinen suorakaiteita.
        /// </summary>
        /// <param name="game">peli johon lisätään</param>
        /// <param name="oliot">taulukko johon oliviitteet laitetaan</param>
        private static void LuoOliot(PhysicsGame game, GameObject[,] oliot)
        {
            int ny = oliot.GetLength(0);
            int nx = oliot.GetLength(1);

            for (int iy = 0; iy < ny; iy++)    // luodaan ruutuoliot
                for (int ix = 0; ix < nx; ix++)
                {
                    GameObject obj = new GameObject(1, 1, Shape.Rectangle);
                    oliot[iy, ix] = obj; // jemmataan taulukkoon
                    obj.X = ix;
                    obj.Y = iy;
                    obj.Color = Color.Black;
                    game.Add(obj);
                    // Mouse.ListenOn(obj, MouseButton.Left, ButtonState.Pressed, VaihdaVari, null, iy,ix);
                }
        }


        /// <summary>
        /// Jatketaan peliä.
        /// </summary>
        private void Jatka()
        {
            timer.Start();
        }


        /// <summary>
        /// Arvotaan uusi sukupolvi
        /// </summary>
        private void ArvoSukupolvi()
        {
            Sopulit.Arvo(sukupolvi, 0, 1);
            timer.Start();
        }


        /// <summary>
        /// Nollataan sukupolvi
        /// </summary>
        private void TyhjennaSukupolvi()
        {
            Sopulit.Tayta(sukupolvi, 0);
            LaskeJaPiirraSeuraavaSukupolvi(); // jotta näyttö muuttuu
        }


        /// <summary>
        /// Puhelinta varten.  Mitä tehdään kun peliin palataan.
        /// Tässä pelissä aloitetaan aina alusta.
        /// </summary>
        public override void Continue()
        {
            Begin();
        }


        /// <summary>
        /// Käsitellään paikassa iy,ox oleva panallus
        /// </summary>
        /// <param name="paikkaMaailmassa">koordinaatti missä painettiin</param>
        private void Painettu(Vector paikkaMaailmassa)
        {
            int ix = (int)(paikkaMaailmassa.X + 0.5);
            int iy = (int)(paikkaMaailmassa.Y + 0.5);
            if (ix < 0 || iy < 0) return;
            if (ix >= oliot.GetLength(1) || iy >= oliot.GetLength(0)) return;
            VaihdaVari(iy, ix);
        }


        /// <summary>
        /// Käsitellään hiiren painallus
        /// </summary>
        private void HiiriPainettu()
        {
            Painettu(Mouse.PositionOnWorld);
        }


        /// <summary>
        /// Käsitellään puhelimen näytön koskettaminen
        /// </summary>
        /// <param name="touch"></param>
        private void NayttoaPainettu(Touch touch)
        {
            Painettu(touch.PositionOnWorld);
        }


        /// <summary>
        /// Vaihdetaan paikassa iy,ix oleva arvo päinvastaikseksi.
        /// Sammutetaan samalla kello.
        /// </summary>
        /// <param name="iy">y-indeksi paikalle</param>
        /// <param name="ix">x-indeksi paikalle</param>
        private void VaihdaVari(int iy, int ix)
        {
            timer.Stop();
            sukupolvi[iy, ix] ^= 1;
            oliot[iy, ix].Color = varit[sukupolvi[iy, ix]];
        }


        /// <summary>
        /// Lasketaan seuraava vaihe ja vaihdetaan kuvioiden värit vastaavaksi.
        /// </summary>
        private void LaskeJaPiirraSeuraavaSukupolvi()
        {   //                0 1 2 3 4 5 6 7 8
            int[,] b03s1 = { {1,0,0,1,0,0,0,0,0}, // born
                             {0,1,0,0,0,0,0,0,0}  // survive
                           };
            Sopulit2.SeuraavaSukupolviTorus(sukupolvi, seuraavaSukupolvi); // ,b03s1);
            int[,] tmp = sukupolvi;     // vaihdetaan taulukot seuraavaa
            sukupolvi = seuraavaSukupolvi;  // kierrosta varten
            seuraavaSukupolvi = tmp;

            int ny = sukupolvi.GetLength(0);
            int nx = sukupolvi.GetLength(1);

            for (int iy = 0; iy < ny; iy++)
                for (int ix = 0; ix < nx; ix++)
                    oliot[iy, ix].Color = varit[sukupolvi[iy, ix]];
        }


        /// <summary>
        /// Lasketaan seuraava vaihe ja vaihdetaan kuvioiden värit vastaavaksi.
        /// </summary>
        private void PiirraEdellinenSukupolvi()
        {   //                0 1 2 3 4 5 6 7 8
            int[,] tmp = sukupolvi;     // vaihdetaan taulukot 
            sukupolvi = seuraavaSukupolvi;  // kierrosta varten
            seuraavaSukupolvi = tmp;

            int ny = sukupolvi.GetLength(0);
            int nx = sukupolvi.GetLength(1);

            for (int iy = 0; iy < ny; iy++)
                for (int ix = 0; ix < nx; ix++)
                    oliot[iy, ix].Color = varit[sukupolvi[iy, ix]];
        }
    }
}