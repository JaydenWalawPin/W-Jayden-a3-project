using System;
using System.Numerics;

namespace MohawkGame2D;

public class Brushes
{

    // Controls size of Brushes 
    float GlobalRadius = 10;
    // Controls colour of brush
    Color GlobalColour = Color.Black;
    // Controls what brush
    int WhichOne = 0;

    // Honestly this is still a magic trick in my head
    // USES TO DRAW THE DEFAULT BRUSH
    float Defaultx1 = 0;
    float Defaulty1 = 0;
    float Defaultx2 = 0;
    float Defaulty2 = 0;
    // ---------------IGNORE---------------------------

    // Line Tool Brush Variables

    //Specifies the X-coordinate for the line tool brush.
    float LineInX = 0;
    float LineInY = 0;
    // Used for let go
    float LineOutX = 0;
    float LineOutY = 0;
    // Checks if positions are determined
    Boolean LinePlaced = false;

    // Line Tool Brush Variable end

    // --------------------------------------------------
    //                              Circle Tool Variables
    // detects if mouse was realeased after click
    Boolean CirclePlaced = false;
    // Mouse Press
    float CircleInputX1 = 0;
    float CircleInputY1 = 0;
    // Mouse Release
    float CircleInputX2 = 0;
    float CircleInputY2 = 0;
    // Average
    float CircleX = 0;
    float CircleY = 0;
    // Circle Tool Variables end
    // ---------------------------------------------------

    

    public void Setup()
    {
    }

    public void Update()
    {
        // Temporary code that lets the user cycle through both brushes
        if (Input.IsKeyboardKeyPressed(KeyboardKey.W) == true)
        {
            WhichOne = 1;
        }

        if (Input.IsKeyboardKeyPressed(KeyboardKey.E) == true)
        {
            WhichOne = 0;
        }

        if (Input.IsKeyboardKeyPressed(KeyboardKey.R) == true)
        {
            WhichOne = 2;
        }

        if (WhichOne == 0)
        {
            DefaultBrush(GlobalRadius);
        }

        if (WhichOne == 1)
        {
            LineToolBrush(GlobalRadius);
        }

        if (WhichOne == 2)
        {
            CircleToolBrush();
        }

    }

    void DefaultBrush(float radius) //Function that does the default brush
    {
        //sets colour
        Draw.SetLineColor(GlobalColour);
        Draw.SetFillColor(GlobalColour);

        // Mouse shadow effect used to get the previous frame pos
        // This makes the brush have zero gaps
        Defaultx2 = Defaultx1;
        Defaulty2 = Defaulty1;

        Defaultx1 = Input.GetMouseX();
        Defaulty1 = Input.GetMouseY();

        if (Input.IsMouseButtonDown(MouseButton.Left) == true)
        {
            Draw.Capsule(Defaultx1, Defaulty1, Defaultx2, Defaulty2, 10);
        }
    }

    void LineToolBrush(float radius) // Function that does the line tool brush 
    {
        //sets colour
        Draw.SetLineColor(GlobalColour);
        Draw.SetFillColor(GlobalColour);

        //Sets the X1 and Y1
        if (Input.IsMouseButtonPressed(MouseButton.Left) == true)
        {
            LineInX = Input.GetMouseX();
            LineInY = Input.GetMouseY();
            LinePlaced = true;
        }

        //Sets the X2 and Y2
        //Draws line
        if ((Input.IsMouseButtonReleased(MouseButton.Left) == true) && (LinePlaced == true))
        {
            LineOutX = Input.GetMouseX();
            LineOutY = Input.GetMouseY();
            Draw.Capsule(LineInX, LineInY, LineOutX, LineOutY, radius);
            LinePlaced = false;
        }
    }

    void CircleToolBrush() // function that does the cricle too brush yeah
    {
        //sets colour
        Draw.SetLineColor(GlobalColour);
        Draw.SetFillColor(GlobalColour);

        // Sets X1 and Y1
        if (Input.IsMouseButtonPressed(MouseButton.Left) == true)
        {
            CircleInputX1 = Input.GetMouseX();
            CircleInputY1 = Input.GetMouseY();
            CirclePlaced = true;
        }

        // Sets X2 and Y2
        if ((Input.IsMouseButtonReleased(MouseButton.Left) == true) && (CirclePlaced == true))
        {
            CircleInputX2 = Input.GetMouseX();
            CircleInputY2 = Input.GetMouseY();

            // I hate to admit that that math class was actually important
            // Calculates the median or something like that
            CircleX = (CircleInputX1 + CircleInputX2) / 2;
            CircleY = (CircleInputY1 + CircleInputY2) / 2;

            // draws the circle
            Draw.SetLineSize(1);
            Draw.Circle(CircleX, CircleY, CircleInputX2 - CircleInputX1);
            CirclePlaced = false;
            //this could have been so much easier if I just had to use X1 Y1 X2 Y2 to draw a circle instead of doing radius 
        }
    }
}
