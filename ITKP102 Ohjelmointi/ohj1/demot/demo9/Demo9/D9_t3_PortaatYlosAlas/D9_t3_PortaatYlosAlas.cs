using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

public class D9_t3_PortaatYlosAlas : PhysicsGame
{
    const double LAATIKON_KOKO = 80;

    public override void Begin()
    {
        // Kirjoita ohjelmakoodisi tähän

        //Level.Background.Color = Color.Black;
        //Vector piste = new Vector(0, 0);
        //piste = PiirraLaatikko(this, piste);
        //piste = PiirraLaatikko(this, piste);
        //piste = PiirraLaatikko(this, piste);
        //piste -= new Vector(0, LAATIKON_KOKO);
        //piste = PiirraLaatikkoAlas(this, piste);
        //piste = PiirraLaatikkoAlas(this, piste);
        //PhysicsObject pallo = new PhysicsObject(5, 5, Shape.Circle);
        //Add(pallo, 1);
        //pallo.Color = Color.Red;
        //Camera.ZoomToAllObjects(100);


        Level.BackgroundColor = Color.Black;
        Vector piste = new Vector(0, 0);
        PiirraPortaat(this, piste, 3, 2);
        Camera.ZoomToAllObjects(100);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    public static Vector PiirraLaatikko(Game peli, Vector piste)
    {
        double s = LAATIKON_KOKO;
        GameObject nelio = new GameObject(s, s, Shape.Rectangle);
        nelio.Position = piste;
        peli.Add(nelio);
        return piste + new Vector(s, s);
    }

    public static Vector PiirraLaatikkoAlas(Game peli, Vector piste)
    {
        double s = LAATIKON_KOKO;
        GameObject nelio = new GameObject(s, s, Shape.Rectangle);
        nelio.Position = piste + new Vector(0, -s);
        peli.Add(nelio);
        return piste + new Vector(s, -s);
    }

    public static void PiirraPortaat (Game peli, Vector piste, int y, int a)
    {
        Vector piirtoPiste = piste;
        double s = LAATIKON_KOKO;

        for (int i = 0; i < y; i++)
        {
            GameObject nelio = new GameObject(s, s, Shape.Rectangle);
            nelio.Position = piirtoPiste;
            peli.Add(nelio);
            piirtoPiste = piirtoPiste + new Vector(s, s);
        }

        piirtoPiste += new Vector(0, -s*2);

        for (int i = 0; i < a; i++)
        {
            GameObject nelio = new GameObject(s, s, Shape.Rectangle);
            nelio.Position = piirtoPiste;
            peli.Add(nelio);
            piirtoPiste = piirtoPiste + new Vector(s, -s);
        }
    }
}
