using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;
using Jypeli.Effects;

namespace Demo7
{
    /// @author  Vesa Lappalainen
    /// @version 16.10.2011
    /// @version 22.10.2011
    /// <summary>
    /// Peli, jossa vihaisia Legoja tiputellaan toisten päälle
    /// </summary>
    /// <remarks>
    /// Todo:
    ///  - värinä vain kun äänitaso 2 tai enemmän
    ///  
    ///  Muutokset:
    ///  - varmistetaan pelin lopetus
    ///  - savua kun pallo poistuu
    ///  - gradientti vaihtuu tason mukaan
    ///  - pallot rikkovat tiiliä kerralla kun viholliset tuhottu
    ///  - pesismaila lyömävälineeksi
    ///  - labelit yhtä leveiksi
    /// </remarks>
    /// 
    public class AngryLego : PhysicsGame
    {

        private static String[] taso0 = {
            "                        ",
            "     oos                ",
            "     ----------         ",
            "                        ",
            "                        ",
            "/                       ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "       =====            ",
            "       X   X            ",
            "       X   X            ",
            "       X   X            ",
            "       X * X            ",
            "     * X  *X            ",
        };

        private static String[] taso1 = {
            "                        ",
            "     ooosooso           ",
            "     ----------         ",
            "                        ",
            "                        ",
            "/                       ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "        =======         ",
            "        X* X  X         ",
            "        X  X  X         ",
            "   *    X  X  X     *   ",
            "        X  X  X         ",
            "        X *X *X         ",
        };

        private static String[] taso2 = {
            "                        ",
            "                        ",
            "                       o",
            "                      --",
            "                       o",
            "/                     --",
            "                       o",
            "                      --",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "    X  X *X X  X        ",
            "    X* X  X*X *X        ",
        };
        private static String[] taso3 = {
            "                        ",
            "     ooooooso           ",
            "     ----------         ",
            "                        ",
            "                        ",
            "/                       ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "        =======         ",
            "        X* X  X         ",
            "        X  X  X         ",
            "   *    X  X  XX     X  ",
            "        X  X  XX  *  X  ",
            "        X *X *XX    *X  ",
        };

        private static String[] taso4 = {
            "                        ",
            "     ooooooso           ",
            "     ----------         ",
            "                        ",
            "                        ",
            "/                       ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "                        ",
            "        =======         ",
            "        X* X  X         ",
            "        X  X  X=======  ",
            "   *    X  X  XX     X  ",
            "        X  X  XX  *  X  ",
            "        X *X *XX    *X  ",
        };

        private static string[][] tasolista = { taso0, taso1, taso2, taso3 };
        //        private static string[][] tasolista = { taso0 };
        private static Color[] ylaVarit = { Color.White, Color.LightYellow, Color.LightPink, Color.LightGreen };
        private static Color[] alaVarit = { Color.Blue, Color.Blue, Color.Blue, Color.Blue };

        private int tileWidth;
        private int tileHeight;

        const int SeinanTormaysIgnoreRyhma = 10;
        private KaantyvaMaila maila;
        private TileMap tiles;

        private Image pallonKuva = LoadImage("Igor");
        private Image pallonKuva2 = LoadImage("symbian");
        private Image vihunKuva = LoadImage("Baby");
        private Image seinanKuva = LoadImage("tiili");
        private Image mailanKuva = LoadImage("maila3");

        private SoundEffect savunAani = null; //= Jypeli.Game.LoadSoundEffectFromResources("laser");
        private SoundEffect liekinAani = null;// = Jypeli.Game.LoadSoundEffectFromResources("implosionSound");

        private static Image[] tiilenKuvat = Game.LoadImages("tiili", "tiili2", "tiili3");
        private static Image[] katonKuvat = Game.LoadImages("tiili", "tiili1", "tiili2", "tiili3");

        private List<PhysicsObject> pallot = new List<PhysicsObject>();

        private IntMeter pisteet = new IntMeter(0);
        private IntMeter vihollisia = new IntMeter(0);
        private IntMeter tasoNr = new IntMeter(0, 0, 10);

        private Label pisteNaytto;

        private ScoreList topLista = new ScoreList(10, false, 0);


        /// <summary>
        /// Aloitus 1. kerralla
        /// </summary>
        public override void Begin()
        {
#if WINDOWS
            savunAani = LoadSoundEffectFromResources("Laser");
            liekinAani = LoadSoundEffectFromResources("ImplosionSound");
#endif
            //Phone.DisplayResolution = DisplayResolution.Large;
            topLista = DataStorage.TryLoad<ScoreList>(topLista, "pisteet.xml");
            AloitaUusiPeli();
        }


        /// <summary>
        /// Aloitetaan peli. Aluksi siivotaan kaikki, jotta voidaan aloittaa uusi peli.
        /// Tätä pitää kutsua uuden pelin aloittamiseksi.
        /// </summary>
        public void AloitaUusiPeli()
        {
            pisteet.Value = 0;
            tasoNr.Value = 0;
            UusiTaso();
        }


        /// <summary>
        /// Aloitetaan pelissä uusi taso
        /// </summary>
        public void UusiTaso()
        {
            ClearGameObjects();
            ClearControls();
            pallot.Clear();

            System.GC.Collect();
            vihollisia.Value = 0;

            tasoNr.Value++;
            if (tasoNr.Value > tasolista.Length)
            {
                NaytaIlmoitus("All levels completed!", Color.Yellow);
                return;
            }
            //  ClearAll();
            int index = tasoNr.Value - 1;
            string[] tasonKuva = tasolista[index];
            if (index >= alaVarit.Length) index = alaVarit.Length - 1;

            Level.Background.CreateGradient(alaVarit[index], ylaVarit[index]);

            tileWidth = 800 / tasonKuva[0].Length;
            tileHeight = 480 / tasonKuva.Length;
            tiles = TileMap.FromStringArray(tasonKuva);

            Gravity = new Vector(0, -500);
            // IsFullScreen = true;


            tiles['X'] = LuoSeina;
            tiles['='] = LuoKatto;
            tiles['_'] = LuoLattia;
            tiles['/'] = LuoMaila;
            tiles['-'] = LuoPalloTaso;
            tiles['*'] = LuoVihollinen;
            tiles['o'] = LuoPallo;
            tiles['s'] = LuoPallo2;

            tiles.Insert(tileWidth, tileHeight);

            LuoNaytot();

            LisaaReuna(Surface.CreateBottom(Level));
            LisaaReuna(Surface.CreateTop(Level));
            LisaaReuna(Surface.CreateLeft(Level));
            LisaaReuna(Surface.CreateRight(Level));
            Camera.ZoomToLevel();

            AsetaOhjaimet();
        }


        /// <summary>
        /// Lisää reunaelementin peliin ja laittaa sille törmäysryhmän jotta maila voidaan suojata
        /// törmäykseltä.
        /// </summary>
        /// <param name="reuna">Lisättävä reunaelementti</param>
        private void LisaaReuna(Surface reuna)
        {
            reuna.CollisionIgnoreGroup = SeinanTormaysIgnoreRyhma;
            Add(reuna);
        }


        /// <summary>
        /// Luodaan näyttö pisteille, tasoille ja vihollisille
        /// </summary>
        private void LuoNaytot()
        {
            pisteet.MinValue = -500;
            pisteNaytto = LuoNaytto("Points: {0:00000}", pisteet, 0);
            LuoNaytto("Level: {0:0}", tasoNr, 1);
            LuoNaytto("Enemy: {0:00}", vihollisia, 2);
        }


        /// <summary>
        /// Luo yksittäisen labelin näyttämään laskurin arvoa n:n ilmoittamaan paikkaan
        /// </summary>
        /// <param name="format">missä muodossa laskurin arvo näytetään</param>
        /// <param name="mittari">mihin laskuriin kiinitetään</param>
        /// <param name="n">monenteenko paikkaan kokrkeussuunnassa</param>
        /// <returns></returns>
        private Label LuoNaytto(string format, IntMeter mittari, int n)
        {
            Label naytto = new Label(format);
            naytto.Width = 150;
            naytto.SizeMode = TextSizeMode.None;

            naytto.IntFormatString = format;
            naytto.BindTo(mittari);
            naytto.Position = new Vector(Screen.Right - naytto.Width / 2 - 20, Screen.Top - naytto.Height / 2 - n * naytto.Height);
            naytto.Color = Color.Yellow;
            naytto.BorderColor = Color.Black;
            naytto.PreferredSize = new Vector(150, naytto.Height);
            Add(naytto);
            return naytto;
        }


        /// <summary>
        /// Asetetaan ohjaimet varsinaista peliä varten
        /// </summary>
        private void AsetaOhjaimet()
        {
            Keyboard.Listen(Key.F1, ButtonState.Pressed, ShowControlHelp, "Show help");
            Keyboard.Listen(Key.F5, ButtonState.Pressed, Begin, "New game");
            // Keyboard.Listen(Key.Escape, ButtonState.Pressed, KysyLopetus, "Exit game");
            Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Exit game");
            Keyboard.Listen(Key.Up, ButtonState.Down, KaannaMailaa, "Move up", 5.0);
            Keyboard.Listen(Key.Down, ButtonState.Down, KaannaMailaa, "Move down", -5.0);
            Keyboard.Listen(Key.Space, ButtonState.Pressed, PudotaPallo, "Drop ball");

            Mouse.IsCursorVisible = true;
            Mouse.ListenOn(pisteNaytto, MouseButton.Left, ButtonState.Pressed, delegate () { AloitaUusiPeli(); }, null);
            Mouse.Listen(MouseButton.Left, ButtonState.Pressed, delegate () { PudotaPallo(); }, "Drop ball");
            //  Mouse.ListenMovement(0.1, delegate (AnalogState analogState) { Tahtaa(Mouse.PositionOnWorld); }, "Aim");
            Mouse.ListenMovement(0.1, () => { Tahtaa(Mouse.PositionOnWorld); }, "Aim");

            TouchPanel.ListenOn(pisteNaytto, ButtonState.Pressed, delegate (Touch kosketus) { AloitaUusiPeli(); }, null);
            TouchPanel.Listen(ButtonState.Pressed, delegate (Touch kosketus) { PudotaPallo(); }, "Drop ball");
            TouchPanel.Listen(ButtonState.Down, delegate (Touch kosketus) { Tahtaa(kosketus.PositionOnWorld); }, "Aim");
            // PhoneBackButton.Listen(KysyLopetus, "Lopeta peli");
            PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");

#if ANDROID // lisää tähän ehtoa jos muitakin kallistelun tukevia
            Accelerometer.Calibration = AccelerometerCalibration.ZeroAngle;
            Accelerometer.ListenAnalog(AccelerometerSensitivity.Realtime, TahtaaAccel, "Aim");
            Accelerometer.Listen(AccelerometerDirection.Shake, delegate { PudotaPallo(); }, "Drop ball");
#endif
        }


        /// <summary>
        /// Tähdätään puhelimen kallistuksen mukaan.  30 asteen kallistuksella taso on vaakassa.
        /// </summary>
        /// <param name="s"></param>
        private void TahtaaAccel(AnalogState s)
        {
            double kulma = s.StateVector.Y * 120 + 30;
            maila.Tavoite = Angle.FromDegrees(kulma);
        }


        /// <summary>
        /// Kun Windows Phonessa palataan takaisin, jatketaan peliä
        /// </summary>
        // public override void Continue()
        // {
        //  // Begin();
        // }


        /// <summary>
        /// Tähdätään mailalla kohti annettua pistettä
        /// </summary>
        /// <param name="p">mihin kohti tähdätään</param>
        private void Tahtaa(Vector p)
        {
            Vector suunta = (p - maila.Position).Normalize();
            Angle a = (maila.Angle - suunta.Angle);
            maila.Tavoite = suunta.Angle;
        }


        /// <summary>
        /// Luodaan seinäelementti
        /// </summary>
        /// <returns>luotu elementti</returns>
        private PhysicsObject LuoSeina()
        {
            SarkyvaRakenne seina = new SarkyvaRakenne(tileWidth, tileHeight);
            seina.Tag = "rakenne";
            seina.Kuvat = tiilenKuvat;
            return seina;
        }


        /// <summary>
        /// Luodaan kattoelementti.  Luodaan hieman ylisuureksi, jolloin liimautuu
        /// naapuriin kiinni.
        /// </summary>
        /// <returns>luotu elementti</returns>
        private PhysicsObject LuoKatto()
        {
            SarkyvaRakenne katto = new SarkyvaRakenne(tileWidth * 1.5, tileHeight);
            katto.Tag = "rakenne";
            katto.Kuvat = katonKuvat;
            return katto;
        }


        /// <summary>
        /// Luodaan lattiaelementti. 
        /// </summary>
        /// <returns>luotu elementti</returns>
        private PhysicsObject LuoLattia()
        {
            PhysicsObject lattia = PhysicsObject.CreateStaticObject(tileWidth, tileHeight);
            lattia.Color = Color.Green;
            lattia.Tag = "lattia";
            return lattia;
        }


        /// <summary>
        /// Luodaan maila, jolla palloja lyödään
        /// </summary>
        /// <returns>luotu maila</returns>
        private PhysicsObject LuoMaila()
        {
            double w = tileWidth * 6;
            double h = w / mailanKuva.Width * mailanKuva.Height;
            maila = new KaantyvaMaila(w, h);
            maila.CollisionIgnoreGroup = SeinanTormaysIgnoreRyhma;
            maila.Color = Color.Black;
            maila.IgnoresGravity = true;
            maila.Image = mailanKuva;
            return maila;
        }


        /// <summary>
        /// Luodaan taso, jolla palloja säilytetään
        /// </summary>
        /// <returns>luotu taso</returns>
        private PhysicsObject LuoPalloTaso()
        {
            PhysicsObject pallotaso = PhysicsObject.CreateStaticObject(tileWidth, tileHeight / 3);
            pallotaso.Color = Color.Black;
            return pallotaso;
        }


        /// <summary>
        /// Luodaan vihollinen, joka hajoaa osuessaan rakenteeseen
        /// </summary>
        /// <returns>luotu vihollinen</returns>
        private PhysicsObject LuoVihollinen()
        {
            PhysicsObject vihu = new PhysicsObject(tileWidth / 2, tileWidth / 2, Shape.Circle);
            vihu.Color = Color.Pink;
            Add(vihu);
            AddCollisionHandler(vihu, "rakenne", delegate (IPhysicsObject vihollinen, IPhysicsObject rakenne) { Possauta(vihollinen); pisteet.Value += 50; });
            AddCollisionHandler(vihu, "pallo", delegate (IPhysicsObject vihollinen, IPhysicsObject pallo) { Possauta(vihollinen); pisteet.Value += 100; });
            AddCollisionHandler(vihu, "pallo2", delegate (IPhysicsObject vihollinen, IPhysicsObject pallo) { Possauta(vihollinen, true); pisteet.Value += 200; });
            vihu.Tag = "vihu";
            vihu.Image = vihunKuva;
            vihu.Destroyed += delegate { vihollisia.Value--; };
            vihollisia.Value++;
            return vihu;
        }


        /// <summary>
        /// Apualiohjelma vihollisen räjäyttämiseksi ja poistamiseksi
        /// </summary>
        /// <param name="olio">olio joka possautetaan</param>
        /// <param name="useShock">Käyteäänkö shokkiaaltoa</param>
        /// <param name="kerroin">minkä kokoinen verrattuna olioon</param>
        private void Possauta(IPhysicsObject olio, bool useShock = false, double kerroin = 10)
        {
            Tarise(200);
            Explosion rajahdys = new Explosion(olio.Width * kerroin);
            rajahdys.Position = olio.Position;
            rajahdys.UseShockWave = useShock;
            Add(rajahdys);
            olio.Destroy();
            Remove(olio);
        }


        /// <summary>
        /// Tärisee jos äänitaso on 2 tai enemmän
        /// </summary>
        /// <param name="kestoms">tärinän kesto millisekunteina</param>
        private void Tarise(int kestoms)
        {
            //SoundEffect.MasterVolume = 0.1;
            // if (SoundEffect.MasterVolume < 0.2) return; // ei toimi tässä, sillä ei ole sama kuin puhelimen ääni
            // Device.Vibrate(kestoms);
        }


        /// <summary>
        /// Soitetaan ääni jos se eiole null.
        /// Tämä vain siksi, että Mäcissä ei saada ladattua resurssiääniä
        /// </summary>
        /// <param name="aani"></param>
        private void SoitaAani(SoundEffect aani)
        {
            if (aani == null) return;
            aani.Play();
        }


        /// <summary>
        /// Apualiohjelma hävittämiseksi ja savun luomiseksi samaan paikaan
        /// </summary>
        /// <param name="olio">olio savutetaan</param>
        /// <param name="useShock">Käytetäänkö shokkiaaltoa</param>
        /// <param name="kerroin">minkä kokoinen verrattuna olioon</param>
        private void Savuta(IPhysicsObject olio, bool useShock = false, double kerroin = 10)
        {
            Smoke savu = new Smoke();
            savu.MaximumLifetime = TimeSpan.FromSeconds(3);
            savu.Position = olio.Position;
            Add(savu); olio.Destroy();
            // savu.FadeOut(5); // ei tuhoa oliota efektin jälkeen
            Timer timer = new Timer();
            timer.Interval = 3;
            timer.Start();
            timer.Timeout += delegate ()
            {
                savu.Destroy();
                timer.Stop();
            };
            SoitaAani(savunAani);
        }


        /// <summary>
        /// Apualiohjelma hävittämiseksi ja savun luomiseksi samaan paikaan
        /// </summary>
        /// <param name="olio">olio savutetaan</param>
        /// <param name="useShock">Käytetäänkö shokkiaaltoa</param>
        /// <param name="kerroin">minkä kokoinen verrattuna olioon</param>
        private void Liekita(IPhysicsObject olio, bool useShock = false, double kerroin = 10)
        {
            Flame liekki = new Flame(pallonKuva2);
            liekki.MaximumLifetime = TimeSpan.FromSeconds(3);
            liekki.Position = olio.Position;
            liekki.MinVelocity = 5;
            liekki.MaxVelocity = 30;
            Add(liekki); olio.Destroy();
            // liekki.FadeOut(5);
            Timer timer = new Timer();
            timer.Interval = 3;
            timer.Start();
            timer.Timeout += delegate ()
            {
                liekki.Destroy();
                timer.Stop();
            };
            SoitaAani(liekinAani);
        }


        /// <summary>
        /// Käännetään pudotustasoa
        /// </summary>
        /// <param name="kulma">millä kulmalla käännetään</param>
        private void KaannaMailaa(double kulma)
        {
            maila.Tavoite = maila.Angle + Angle.FromDegrees(kulma);
        }


        /// <summary>
        /// Luodaan uusi pallo, joka voi rikkoa vihollisen
        /// </summary>
        private PhysicsObject LuoPallo()
        {
            PhysicsObject pallo = new PhysicsObject(tileWidth, tileWidth, Shape.Circle);
            pallo.Image = pallonKuva;
            Add(pallo);
            pallo.Tag = "pallo";
            pallo.Destroyed += delegate { Savuta(pallo, false, 1); };
            pallot.Add(pallo);
            AddCollisionHandler<PhysicsObject, SarkyvaRakenne>(pallo, "rakenne", PalloOsuiRakenteeseen);
            return pallo;
        }


        /// <summary>
        /// Luodaan uusi pallo, joka voi rikkoa vihollisen
        /// </summary>
        private PhysicsObject LuoPallo2()
        {
            PhysicsObject pallo = new PhysicsObject(tileWidth * 0.6, tileWidth, Shape.Circle);
            pallo.Image = pallonKuva2;
            Add(pallo);
            pallo.Tag = "pallo2";
            pallo.Destroyed += delegate { Liekita(pallo, false, 2); };
            pallot.Add(pallo);
            AddCollisionHandler<PhysicsObject, SarkyvaRakenne>(pallo, "rakenne", Pallo2OsuiRakenteeseen);
            return pallo;
        }


        /// <summary>
        /// Kun pallo osuu rakenteeseen, tullaan tänne.
        /// Lisätään rakenteen osumia ja poistetaan rakenne jos osumia tuli tarpeeksi.
        /// Jos viholliset on loppu, räjäytetään rakenne saman tien
        /// </summary>
        /// <param name="pallo">pallo joka osui</param>
        /// <param name="rakenne">rakenne johon osuttiin</param>
        private void PalloOsuiRakenteeseen(PhysicsObject pallo, SarkyvaRakenne rakenne)
        {
            int kerroin = 1;
            pisteet.Value += 1;
            if (!rakenne.Osuma() && vihollisia.Value > 0) return;
            if (vihollisia.Value <= 0) kerroin = 2;
            Possauta(rakenne);
            pisteet.Value += 10 * kerroin;
        }


        /// <summary>
        /// Toisenlaisen pallon osuma rakenteeseen.
        /// Räjäytetään rakenne kertaosumasta.
        /// </summary>
        /// <param name="pallo">pallo joka osui</param>
        /// <param name="rakenne">rakenne johon osuttiin</param>
        private void Pallo2OsuiRakenteeseen(PhysicsObject pallo, SarkyvaRakenne rakenne)
        {
            int kerroin = 1;
            Possauta(rakenne, false);
            if (vihollisia.Value <= 0) kerroin = 2;
            pisteet.Value += 20 * kerroin;
        }


        /// <summary>
        /// Pudotetaan uusi pallo, joka voi rikkoa vihollisen.  
        /// Pallo otetaan pallojen listasta pois.
        /// </summary>
        private void PudotaPallo()
        {
            if (pallot.Count <= 0) return;
            PhysicsObject pallo = pallot[0];
            pallot.Remove(pallo);
            if (pallot.Count == 0) pallo.Destroyed += delegate { TasoPelattu(); };
            pallo.MoveTo(maila.Position + new Vector(tileWidth * 0.6, maila.Height + tileWidth), tileWidth * 10);
            //    pallo.Hit(new Vector(-300, 0));
            pallo.LifetimeLeft = TimeSpan.FromSeconds(8);
        }



        /// <summary>
        /// Taso on valmis, kaikki pallot on käytetty.
        /// </summary>
        private void TasoPelattu()
        {
            // int vihuja = GetObjects(olio => (string)(olio.Tag) == "vihu").Count;
            if (vihollisia.Value <= 0)
            {
                UusiTaso();
                return;
            }

            NaytaIlmoitus("Game over!", Color.Pink);
        }


        /// <summary>
        /// Näytetään teksti valitulla värillä
        /// </summary>
        /// <param name="teksti">näytettävä teksti</param>
        /// <param name="vari">pohjaväri, jolla näytetään</param>
        private void NaytaIlmoitus(string teksti, Color vari)
        {
#if WINDOWS
            Label label = new Label(teksti);
            label.Font = Font.DefaultLargeBold;
            label.Width = 400;
            label.Height = 200;
            label.Color = vari;
            label.BorderColor = Color.Black;
            Add(label);
            ClearControls();
            HighScoreWindow topIkkuna = new HighScoreWindow("Top 10",
                "Congratulations! You got %p points! Give you name:",
                topLista, pisteet);
            topIkkuna.Closed += delegate { DataStorage.TrySave<ScoreList>(topLista, "pisteet.xml"); AloitaUusiPeli(); };
            Add(topIkkuna);
#endif
        }

        /*
        /// <summary>
        /// Kysytään haluaako lopettaa pelin
        /// </summary>
        private void KysyLopetus()
        {
            MultiSelectWindow valintaIkkuna = new MultiSelectWindow("Do you want to quit?", "Yes", "No");
            valintaIkkuna.ItemSelected += new Action<int>(ValintaIkkunastaValittu);
            // valintaIkkuna.Buttons = new PushButton[] { Key.Enter, Key.Escape };
            Add(valintaIkkuna);
        }


        /// <summary>
        /// Tähän tullaan kun valintaikkunasta on valittu jokin nappi
        /// </summary>
        /// <param name="arvo"></param>
        void ValintaIkkunastaValittu(int arvo)
        {
            if (arvo == 0) Exit();
        }
        */
    }


    /// @author  Vesa Lappalainen
    /// @version 19.10.2011
    /// <summary>
    /// Rakenne, jolla on kesto ja kuva vaihtuu sen mukaan paljonko kestoa on jäljellä.
    /// </summary>
    public class SarkyvaRakenne : PhysicsObject
    {
        /// <summary>
        /// Rakenteen kesto.  Kun menee alle nolla, saa hajottaa
        /// </summary>
        public int Kesto { get { return kesto; } set { SetKesto(value); } }
        private int kesto = 0;

        /// <summary>
        /// Kuvataulukko, jossa kuvat eri keston vaiheissa.  indeksissä 0 vahvimman keston kuva.
        /// </summary>
        public Image[] Kuvat { get { return kuvat; } set { kuvat = value; if (kuvat != null) Kesto = kuvat.Length - 1; } }
        private Image[] kuvat;

        /// <summary>
        /// Paljonko vähintään on olevat peräkkäisten osumien väli sekunteina
        /// jotta kestoa heikennetään.
        /// </summary>
        public double OsumienMinVali { get; set; }

        private TimeSpan edellinenOsuma;


        /// <summary>
        /// Alustetaan rakenne
        /// </summary>
        /// <param name="width">olion leveys</param>
        /// <param name="height">olion korkeus</param>
        public SarkyvaRakenne(double width, double height)
            : base(width, height)
        {
            OsumienMinVali = 2.0;
        }


        /// <summary>
        /// Asetetaan kesto 
        /// </summary>
        /// <param name="value"></param>
        protected virtual void SetKesto(int value)
        {
            kesto = value;
            if (Kuvat == null) return;
            Image = Kuvat[Math.Max(0, Math.Min(Kuvat.Length - 1, Kuvat.Length - 1 - Kesto))];
        }


        /// <summary>
        /// Kutsu tätä aina kun olio saa osuman.  Jos kutsutaan liian nopeasti
        /// edellisen jälkeen, ei tapahtu mitään. Olio vaihtaa kuvaansa tarvittaessa.
        /// </summary>
        /// <returns>true jos on aika tuhoa olio</returns>
        public bool Osuma(int maara = 1)
        {
            TimeSpan aika = Jypeli.Game.Time.SinceStartOfGame;
            TimeSpan dt = aika - edellinenOsuma;
            if (dt.TotalSeconds < OsumienMinVali) return false;
            edellinenOsuma = aika;
            Kesto -= maara;
            Size *= 0.95;
            return (Kesto < 0);
        }
    }


    /// @author  Vesa Lappalainen
    /// @version 16.10.2011
    /// <summary>
    /// Maila, jolle voidaan asettaa suunta , johon se pyrkii.
    /// Kääntyminen tehdään sitä mukaa kuin ehditään.
    /// </summary>
    public class KaantyvaMaila : PhysicsObject
    {
        /// <summary>
        /// Tavoitekulma, johon maila pyrkii osoittamaan
        /// </summary>
        public Angle Tavoite { get { return tavoite; } set {
                tavoite = value;
                saavutettu = false;
            } }
        private Angle tavoite;
        private bool saavutettu = true;

        public KaantyvaMaila(double width, double height)
            : base(width, height)
        {
            // MakeStatic();
            Mass = 10000;
            IgnoresGravity = true;
            IsUpdated = true;
        }


        /// <summary>
        /// Uusi versio Update-metodista, jossa nyt käännetään mailaa kohti tavoitekulmaa.
        /// </summary>
        /// <param name="time">Peliaika</param>
        public override void Update(Time time)
        {
            if (saavutettu) { base.Update(time); return; }
            Angle diff = Tavoite - Angle;
            double suunta = diff.Degrees;
            double d = 2;
            if (Math.Abs(suunta) > d)
            {
                this.StopAngular();
                this.ApplyTorque(10000000 * 35.0 * suunta); // kokeiltu hihavakio
            }
            else
            {
                Stop();
                saavutettu = true;
            }
            base.Update(time);
        }

    }

}