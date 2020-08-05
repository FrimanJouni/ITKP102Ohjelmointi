using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
// using Jypeli.Effects;
using Jypeli.Widgets;
// using Jypeli.WP7;

namespace Demo7
{
    /// @author  Vesa Lappalainen
    /// @version 14.10.2011
    /// <summary>
    /// Piirretään pistejoukon kuvaajaa
    /// </summary>
    public class Kuvaaja : PhysicsGame
    {
        /// <summary>Koordinaatistoakselit</summary>
        private Axis akselit;

        /// <summary>Koordinaatit piirretyille pisteille</summary>
        private Vector[] pisteet;

        /// <summary>Merkki paikalle jota viimeksi klikattu</summary>
        private PhysicsObject klikattuPiste;

        /// <summary>Merkki pisteelle joka on lähinnä klikattua paikkaa</summary>
        private PhysicsObject merkkipiste;


        private const double x1 = -5;
        private const double x2 = 20;
        private const double y1 = -5;
        private const double y2 = 20;
        private const double pallonKoko = (y2 - y1) / 300;

        /// <summary>
        /// Alustetaan rajat ja luodaan pisteet ja 
        /// niiden paikat pisteet-taulukkoon.
        /// </summary>
        public override void Begin()
        {
            SetWindowSize(1000, 700); // muuta tässä arvoja jos ikkuna ei mahdu kokokaan ruutuun
            Level.Background.Color = Color.White;
            // IsFullScreen = true;
            Level.Width = x2 - x1;
            Level.Height = y2 - y1;

            akselit = new Axis(x1, y1, x2, y2);

            pisteet = ArvoPisteet(1000, x1, y1, x2, y2);

            LuoPisteet(this, pisteet, pallonKoko);

            klikattuPiste = LuoPallo(this, Vector.Zero, 1.5 * pallonKoko, Color.Blue);
            merkkipiste = LuoPallo(this, Vector.Zero, 1.5 * pallonKoko, Color.Red);

            Camera.ZoomTo(x1, y1, x2, y2);
            AsetaOhjaimet();
        }


        /// <summary>
        /// Asetetaan ohjaimet peliä varten. F1 ja ESC.
        /// Kuunnellaan hiiren paikkaa ja siirretään merkkipisteen sen mukaan mihin klikattu
        /// Samoin kuunnellaan puhelimelta sormella tökkäisyä.
        /// </summary>
        private void AsetaOhjaimet()
        {
            Keyboard.Listen(Key.F1, ButtonState.Pressed, ShowControlHelp, "Näytä ohjeet");
            Keyboard.Listen(Key.Escape, ButtonState.Pressed, Exit, "Poistu");

            Mouse.IsCursorVisible = true;
			Mouse.Listen(MouseButton.Left, ButtonState.Pressed, delegate() { SiirraMerkkipisteet(Mouse.PositionOnWorld); }, "Laita piste");
            Mouse.Listen(MouseButton.Right, ButtonState.Pressed, KysyKoordinaatti, "Kysy");

//            TouchPanel.Listen(ButtonState.Pressed, delegate(Touch kosketus) { SiirraMerkkipisteet(kosketus.PositionOnWorld); }, null);
//            TouchPanel.ListenGesture(GestureType.VerticalDrag, delegate(Touch touch) { KysyKoordinaatti(); }, "Kysy");
            PhoneBackButton.Listen(Exit, "Lopeta peli");
        }


        /// <summary>Suojataan ettei kysymys voi olla käynnissä montaa kertaa</summary>
        private bool kysymassa = false;

        /// <summary>
        /// Kysytään koordinaatti ja luodaan vihreä  piste tähän paikkaan
        /// </summary>
        private void KysyKoordinaatti()
        {
            if (kysymassa) return;
            kysymassa = true;
            InputWindow kysymysIkkuna = new InputWindow("Anna uuden pisteen koordinaatti");
            kysymysIkkuna.TextEntered += KoordinaattiAnnettu;
            kysymysIkkuna.Color = Color.Gray;
            kysymysIkkuna.InputBox.Text = "5 5";
            // kysymysIkkuna.ShowWindowOnPhone = true;
            Add(kysymysIkkuna);
        }


        /// <summary>
        /// Laitetaan syöttöikkunasta saatuun koordinaattiin uusi vihreä piste
        /// </summary>
        /// <param name="ikkuna"></param>
        private void KoordinaattiAnnettu(InputWindow ikkuna)
        {
            string vastaus = ikkuna.InputBox.Text;
            Vector p = new Vector();
            double[] d = Taulukot.ErotaLuvut(vastaus + " 0 0");
            p.X = d[0];
            p.Y = d[1];
            LuoPallo(this, p, 1.5 * pallonKoko, Color.Green);
            kysymassa = false;
        }


        /// <summary>
        /// Siirretään sininen piste paikan p kohdalle 
        /// ja siirretään punainen piste lähimmän alueen pisteen päälle
        /// </summary>
        /// <param name="p">paikka johon sininen piste tulee</param>
        public void SiirraMerkkipisteet(Vector p)
        {
            klikattuPiste.Position = p;

            int i = LahimmanIndeksi(pisteet, p);
            if (i < 0) return;

            merkkipiste.Position = pisteet[i];
        }


        /// <summary>
        /// Luodaan peliin taulukossa olevien koordinaattien kohdalle pienet pallot
        /// </summary>
        /// <param name="pisteet">piirrettävien pisteiden koordinaatit</param>
        /// <param name="r">säde kullekin pisteelle</param>
        /// <param name="game">peli, johon pisteet lisätään</param>
        public static void LuoPisteet(PhysicsGame game, IEnumerable<Vector> pisteet, double r)
        {
            foreach (Vector p in pisteet)
                LuoPallo(game, p, r, Color.Black);
        }


        /// <summary>
        /// Lisätään peliin pallo
        /// </summary>
        /// <param name="game">peli johon pallo lisätään</param>
        /// <param name="p">pallon keskipiste</param>
        /// <param name="r">pallon säde</param>
        /// <param name="color">pallon väri</param>
        /// <returns>lisätyn pallon viite</returns>
        public static PhysicsObject LuoPallo(PhysicsGame game, Vector p, double r, Color color)
        {
            PhysicsObject pallo = new PhysicsObject(r * 2, r * 2, Shape.Circle);
            pallo.Position = p;
            pallo.Color = color;
            game.Add(pallo);
            return pallo;
        }


        /// <summary>
        /// Arvotaan joukko 2D-pisteitä halutulle alueelle
        /// </summary>
        /// <param name="n">montako pistettä arvotaan</param>
        /// <param name="x1">alueen vasemman alakulman x</param>
        /// <param name="y1">alueen vasemman alakulman y</param>
        /// <param name="x2">alueen oikean yläkulman x</param>
        /// <param name="y2">alueen oikean yläkulman y</param>
        /// <returns></returns>
        public static Vector[] ArvoPisteet(int n, double x1, double y1, double x2, double y2)
        {
            Vector[] pisteet = new Vector[n];
            for (int i = 0; i < n; i++)
            {
                //double x = RandomGen.NextDouble(x1, x2);
                //double y = RandomGen.NextDouble(y1, y2);
                //pisteet[i] = new Vector(x, y);
                pisteet[i] = RandomGen.NextVector(x1, y1, x2, y2);
            }
            return pisteet;
        }


        /// <summary>
        /// Etsitään pistettä lähimmän taulukon alkion indeksi.
        /// </summary>
        /// <param name="pisteet">taulukko jossa pisteet, joista lähintä etsitään</param>
        /// <param name="piste">piste johon muita verrataan</param>
        /// <returns>lähimmän pisteen indeksi, -1 jos taulukko tyhjä</returns>
        /// <example>
        /// <pre name="test">
        ///   Vector[] luvut = { new Vector(1,2),new Vector(3,4),new Vector(5,2),new Vector(5,5) };
        ///   LahimmanIndeksi(luvut,new Vector(3,5)) === 1;
        ///   LahimmanIndeksi(luvut,new Vector(0,0)) === 0;
        ///   LahimmanIndeksi(luvut,new Vector(5,3)) === 2;
        ///   LahimmanIndeksi(luvut,new Vector(15,5)) === 3;
        /// </pre>
        /// </example>
        public static int LahimmanIndeksi(Vector[] pisteet, Vector piste)
        {
            int paikka = -1;
            double pieninEtaisyys = double.MaxValue;
            for (int i = 0; i < pisteet.Length; i++)
            {
                Vector p = pisteet[i];
                double d = Vector.Distance(piste, p);
                if (d < pieninEtaisyys)
                {
                    paikka = i;
                    pieninEtaisyys = d;
                }
            }
            return paikka;
        }


        /// <summary>
        /// Tämä tehdään aina kun ruutua pitää päivittää
        /// </summary>
        /// <param name="canvas">Piirtoalue, johon voi piirtää</param>
        protected override void Paint(Canvas canvas)
        {
            akselit.Draw(canvas);
        }


        /// <summary>
        /// Kun Windows Phonessa palataan takaisin, aloitetaan uusi peli
        /// </summary>
//        public override void Continue()
//        {
//           // Begin();
//        }

    }


    /// <summary>
    /// Luokka koordinaatiston piirtämistä varten
    /// </summary>
    public class Axis
    {
        private double x1, x2, y1, y2;
        public Color Color { set; get; }

        /// <summary>
        /// Alustetaan koordinaatisto haluttuihin rajoihin
        /// </summary>
        /// <param name="x1">alueen vasemman alakulman x</param>
        /// <param name="y1">alueen vasemman alakulman y</param>
        /// <param name="x2">alueen vasemman yläkulman x</param>
        /// <param name="y2">alueen vasemman yläkulman y</param>
        public Axis(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
            Color = Color.Black;
        }


        /// <summary>
        /// Piirretään koordinaatisto niin, että tulee x ja y akselit ja niihin
        /// yhden välein pikkutikkuja.
        /// </summary>
        /// <param name="canvas">Canvas-olio, johon piirto tehdään</param>
        public void Draw(Canvas canvas)
        {
            canvas.BrushColor = Color;
            double t = (y2 - y1) / 200; // tikkujen koko

            // X-akseli
            canvas.DrawLine(new Vector(x1, 0), new Vector(x2, 0));
            // Tikut X-akselille 0:sta lähtien kumpaankin suuntaan
            for (double x = 0; x >= x1; x -= 1.0) canvas.DrawLine(new Vector(x, -t), new Vector(x, t));
            for (double x = 0; x <= x2; x += 1.0) canvas.DrawLine(new Vector(x, -t), new Vector(x, t));

            // Y-akseli
            canvas.DrawLine(new Vector(0, y1), new Vector(0, y2));
            // Tikut Y-akselille 0:sta lähtien kumpaankin suuntaan
            for (double y = 0; y >= y1; y -= 1.0) canvas.DrawLine(new Vector(-t, y), new Vector(t, y));
            for (double y = 0; y <= y2; y += 1.0) canvas.DrawLine(new Vector(-t, y), new Vector(t, y));
        }
    }

}