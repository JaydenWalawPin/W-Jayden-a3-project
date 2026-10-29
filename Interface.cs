using System;
using System.Numerics;

namespace MohawkGame2D;

public class Interface
{
    public void Setup()
    {
    }

    public void Update()
    {
        DrawScreen();
    }

    void DrawScreen() //This functions draws the Interface screen (as expected)
    {
        // Draws Background
        Draw.SetLineColor(Color.Gray);
        Draw.SetFillColor(Color.Gray);
        Draw.Rectangle(0, 0, 100, 800);
        // Draws border
        Draw.SetLineColor(79, 79, 79); //dark grey
        Draw.SetFillColor(79, 79, 79);
        Draw.SetLineSize(5);
        Draw.Line(100, 0, 100, 800);

    }

    //void DrawPencilIcon() //This draws the pencil button. Is it a good idea to separate all that in different functions? Probably not. Am I going to do it regardless? yeah
    //{
    //    Boolean IsMouseOverButton = false;

    //    if (IsMouseOverButton == true)
    //    {
            
    //    }
    //}
}