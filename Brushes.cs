using System;
using System.Numerics;

namespace MohawkGame2D;

public class Brushes
{

    // Controls size of Brushes 
    float GlobalRadius = 10;

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

    int WhichOne = 0;

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

        if (WhichOne == 0)
        {
            DefaultBrush(GlobalRadius);
        }

        if (WhichOne == 1)
        {
            LineToolBrush(GlobalRadius);
        }

    }

    void DefaultBrush(float radius) //Function that does the default brush
    {
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
        if (Input.IsMouseButtonPressed(MouseButton.Left) == true)
        {
            LineInX = Input.GetMouseX();
            LineInY = Input.GetMouseY();
            LinePlaced = true;
        }

        if ((Input.IsMouseButtonReleased(MouseButton.Left) == true) && (LinePlaced == true))
        {
            LineOutX = Input.GetMouseX();
            LineOutY = Input.GetMouseY();
            Draw.Capsule(LineInX, LineInY, LineOutX, LineOutY, radius);
            LinePlaced = false;
        }
    }
}
