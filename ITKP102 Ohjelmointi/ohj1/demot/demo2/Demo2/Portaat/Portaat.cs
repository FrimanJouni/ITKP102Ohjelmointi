using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

public class Portaat : PhysicsGame
{
    public override void Begin()
    {

        Camera.ZoomToLevel();     // Seuraavia voi kutsua myös
        PiirraNelio(this, 0, 0);  // PiirraNelio(peli:this,x:0,y:0);
        PiirraNelio(this, 80, 80);// PiirraNelio(peli:this,x:80,y:80);
        PiirraNelio(this, 160, 160);
        PiirraNelio(this, 240, 240);
        PiirraNelio(this, 320, 320);

        Camera.ZoomToAllObjects(50);


        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }


    public static void PiirraNelio(PhysicsGame peli,
                               double x, double y)
    {
        PhysicsObject p = new PhysicsObject(80, 80, Shape.Rectangle, 80);
        {
            p.X = x + 40;
            p.Y = y + 40;
            peli.Add(p);
        }
    }
}

