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
        Color lightyellow = new Color(226, 255, 54);
        Color darkGray = new Color(25, 25, 25);

        // Integers to randomize the moon's placement and phase
        int moonLocation = Random.Integer(40, 340);
        int moonPhase = Random.Integer(0, 30);

        // Array for Window Coordinates
        float[] xWindowCoord = [60, 160, 260];
        float[] yWindowCoord = [120, 220, 320];

        // Array for Star Coordinates
        float[] xStarCoordinates = []; 
        float[] yStarCoordinates = []; 

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(400, 400);
            Window.SetTitle("Interactive Drawing");

            int starCount = Random.Integer(25, 75);
            xStarCoordinates = new float[starCount];
            yStarCoordinates = new float[starCount];
            for (int i = 0; i < starCount; i++) 
            {
                xStarCoordinates[i] = Random.Integer(10, 390);
                yStarCoordinates[i] = Random.Integer(10, 260);
            }

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // Getting Mouse X and Y Coordinates
            float mouseX = Input.GetMouseX();
            float mouseY = Input.GetMouseY();

            // -------- Background --------

            // Set Background Colour 
            Window.ClearBackground(navyBlue);

            // Background Stars
            Draw.FillColor = Color.White;
            Draw.LineSize = 0; 
            for (int i = 0; i < xStarCoordinates.Length; i++)
            {
                Draw.Circle(xStarCoordinates[i], yStarCoordinates[i], 2); 
            }

            // Background Buildings
            Draw.FillColor = Color.Black;
            Draw.Rectangle(0, 260, 20, 140);
            Draw.Rectangle(20, 180, 20, 220);
            Draw.Rectangle(360, 260, 20, 140);
            Draw.Rectangle(380, 240, 20, 160);

            // Background Treetops
            DrawTreetop(0, 390, 25);
            DrawTreetop(360, 390, 25);

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
            Draw.FillColor = darkGray;
            for (int index = 0; index < 3; index++)
            {
                int xOffset = index * 100;
                Draw.Square(60 + xOffset, 120, 80);
                Draw.Square(60 + xOffset, 220, 80);
                Draw.Square(60 + xOffset, 320, 80);
            }

            // Click each window to make it light up 
            if (Input.IsMouseButtonDown(0))
            {
                // Window Light Colour
                Draw.FillColor = lightyellow;

                // Left Column Windows
                if (mouseX >= xWindowCoord[0] && mouseX <= 140)
                {
                    // Top Left Window
                    if (mouseY >= yWindowCoord[0] && mouseY <= 200)
                    {
                        Draw.Square(xWindowCoord[0], yWindowCoord[0], 80);
                    }
                    // Middle Left Window
                    else if (mouseY >= yWindowCoord[1] && mouseY <= 300)
                    {
                        Draw.Square(xWindowCoord[0], yWindowCoord[1], 80);
                    }
                    // Bottom Left Window
                    else if (mouseY >= yWindowCoord[2] && mouseY <= 400)
                    {
                        Draw.Square(xWindowCoord[0], yWindowCoord[2], 80);
                    }
                }
                // Middle Column 
                else if (mouseX >= xWindowCoord[1] && mouseX <= 240)
                {
                    // Top Middle Window
                    if (mouseY >= yWindowCoord[0] && mouseY <= 200)
                    {
                        Draw.Square(xWindowCoord[1], yWindowCoord[0], 80);
                    }
                    // Middle Window
                    else if (mouseY >= yWindowCoord[1] && mouseY <= 300)
                    {
                        Draw.Square(xWindowCoord[1], yWindowCoord[1], 80);
                    }
                    // Bottom Middle Window 
                    else if (mouseY >= yWindowCoord[2] && mouseY <= 400)
                    {
                        Draw.Square(xWindowCoord[1], yWindowCoord[2], 80);
                    }
                }
                else if ((mouseX >= xWindowCoord[2] && mouseX <= 340))
                {
                    // Top Right Window
                    if (mouseY >= yWindowCoord[0] && mouseY <= 200)
                    {
                        Draw.Square(xWindowCoord[2], yWindowCoord[0], 80);
                    }
                    // Middle Right Window
                    else if (mouseY >= yWindowCoord[1] && mouseY <= 300)
                    {
                        Draw.Square(xWindowCoord[2], yWindowCoord[1], 80);
                    }
                    // Bottom Right Window 
                    else if (mouseY >= yWindowCoord[2] && mouseY <= 400)
                    {
                        Draw.Square(xWindowCoord[2], yWindowCoord[2], 80);
                    }
                }
            }


            // Spacebar Input to light up all windows 
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                Draw.FillColor = lightyellow;
                for (int index = 0; index < 3; index++)
                {
                    int xOffset = index * 100;
                    Draw.Square(60 + xOffset, 120, 80);
                    Draw.Square(60 + xOffset, 220, 80);
                    Draw.Square(60 + xOffset, 320, 80);
                }
            }

            // Window Lines 
            Draw.FillColor = Color.Black;
            Draw.LineSize = 3;
            for (int index = 0; index <= 3; index++)
            {
                int xOffset = index * 100;
                int yOffset = index * 100 + 60;
                // Vertical Lines
                Draw.Line(100 + xOffset, 120, 100 + xOffset, 200);
                Draw.Line(100 + xOffset, 220, 100 + xOffset, 300);
                Draw.Line(100 + xOffset, 320, 100 + xOffset, 400);
                // Horizontal Lines 
                Draw.Line(60, 100 + yOffset, 140, 100 + yOffset);
                Draw.Line(160, 100 + yOffset, 240, 100 + yOffset);
                Draw.Line(260, 100 + yOffset, 340, 100 + yOffset);
            }
        }

        void DrawTreetop(float x, float y, float radius)
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
