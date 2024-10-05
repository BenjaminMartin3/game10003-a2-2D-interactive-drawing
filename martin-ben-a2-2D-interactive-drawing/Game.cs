// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        // Colours
        Color navyBlue = new Color(0, 2, 58);
        Color brickRed = new Color(130, 23, 0);
        Color concreateGrey = new Color(142, 144, 118);
        Color darkGreenBack = new Color(38, 115, 50);
        Color darkGreenFront = new Color(45, 124, 64);
        int moonLocation = Random.Integer(40, 340);
        int moonPhase = Random.Integer(0, 30);


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(400, 400);
            Window.SetTitle("Interactive Drawing");
            
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {

            // -------- Background --------

            // Background Buildings
            Draw.FillColor = Color.Black;
            Draw.Rectangle(0, 260, 20, 140);
            Draw.Rectangle(20, 180, 20, 220);
            Draw.Rectangle(360, 260, 20, 140);
            Draw.Rectangle(380, 240, 20, 160);

            // Background Bushes
            DrawBush(0, 390, 25);
            DrawBush(360, 390, 25);

            // Background Moon
            DrawMoon();

            // -------- Building --------

            // Main Building 
            Draw.FillColor = brickRed;
            Draw.Rectangle(40, 100, 320, 300);

            // Roof 
            Draw.FillColor = concreateGrey;
            Draw.Rectangle(20, 80, 360, 30);

            // Dark Windows 
            Draw.FillColor = Color.Black;
            for (int index = 0; index < 3; index++)
            {
                int xOffset = index * 100;
                Draw.Square(60 + xOffset, 120, 80);
            }
            for (int index = 0; index < 3; index++)
            {
                int xOffset = index * 100;
                Draw.Square(60 + xOffset, 220, 80);
            }
            for (int index = 0; index < 3; index++)
            {
                int xOffset = index * 100;
                Draw.Square(60 + xOffset, 320, 80);
            }


            Window.ClearBackground(navyBlue);
        }

        void DrawBush(float x, float y, float radius)
        {
            Draw.LineSize = 0;
            Draw.FillColor = darkGreenBack;
            Draw.Circle(x + 20, y - 20, radius - 5);
            Draw.FillColor = darkGreenFront;
            Draw.Circle(x, y, radius);
            Draw.Circle(x + 40, y, radius);

        }

        void DrawMoon()
        {
            Draw.FillColor = Color.White;
            Draw.Circle(moonLocation, 30, 30);
            Draw.FillColor = navyBlue;
            Draw.Circle(moonLocation - moonPhase, 30, 30);
            

        }
    }
}
