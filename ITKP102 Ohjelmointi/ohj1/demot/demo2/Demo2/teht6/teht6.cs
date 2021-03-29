using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

public class teht6 : PhysicsGame
{
    public override void Begin()
    {
        Camera.ZoomToLevel();

        int r = 50; //Muunnettava säde, skaala pysyy samana

        double c = Math.Sqrt((2 * r) * (2 * r) - r * r); //Korkeuden laskeminen pythagoraan lauseella
        

        Piirrapallo(this, 0, 0, r); //Alarivin pallot, tässä pelissä, x-koordi, y-koordi ja säde annetaan aliohjelmalle.
        Piirrapallo(this, 2 * r, 0, r);
        Piirrapallo(this, 4 * r, 0, r);

        Piirrapallo(this, r, c, r); //Keskirivin pallot
        Piirrapallo(this, 3 * r, c, r);

        Piirrapallo(this, 2*r, 2*c, r); //Ylin pallo

        Camera.ZoomToAllObjects(50);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    public static void Piirrapallo(PhysicsGame peli, double x, double y, double r) //Aliohjelma pallojen piirtämiseen.
    {
        PhysicsObject p = new PhysicsObject(2*r, 2*r, Shape.Circle); //PhysicsObject ottaa mitat ja muodon, r = säde joten 2*r on halkaisija
        p.Y = y;
        p.X = x;
        peli.Add(p);
            

    }
}

