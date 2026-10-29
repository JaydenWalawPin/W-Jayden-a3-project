// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {

        Brushes Brush = new Brushes();
        Interface Screen = new Interface();


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Drawing Program");
            Window.ClearBackground(255);
            Window.TargetFPS = 60;
            Draw.SetLineColor(0);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Brush.Update();
            Screen.Update();

            if (Input.IsKeyboardKeyPressed(KeyboardKey.Q) == true)
                Window.ClearBackground(255);
        }
    }

}
