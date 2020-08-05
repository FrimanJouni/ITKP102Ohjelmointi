using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

public class D9_t2_PortaatYlos : PhysicsGame
{
    public override void Begin()
    {
        // Kirjoita ohjelmakoodisi tähän

        Level.Background.Color = Color.Black;
        Vector piste = new Vector(0, 0);
        piste = PiirraLaatikko(this, piste);
        piste = PiirraLaatikko(this, piste);
        piste = PiirraLaatikko(this, piste);
        PhysicsObject pallo = new PhysicsObject(5, 5, Shape.Circle);
        Add(pallo, 1);
        pallo.X = -40;
        pallo.Y = -40;
        pallo.Color = Color.Red;
        Camera.ZoomToAllObjects(100);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    public static Vector PiirraLaatikko(Game peli, Vector piste)
    {
        double s = 80;
        GameObject nelio = new GameObject(s, s, Shape.Rectangle);
        nelio.Position = piste;
        peli.Add(nelio);
        return piste + new Vector(s, s);
    }

}
