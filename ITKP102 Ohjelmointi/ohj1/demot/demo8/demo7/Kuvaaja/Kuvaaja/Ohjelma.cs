using System;


static class Ohjelma
{
#if WINDOWS || XBOX
    static void Main(string[] args)
    {
        using (Demo7.Kuvaaja game = new Demo7.Kuvaaja())
        {
#if !DEBUG
            game.IsFullScreen = true;
#endif
            game.Run();
        }
    }
#endif
}
