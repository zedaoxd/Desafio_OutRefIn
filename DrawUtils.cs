using System;


/// <summary>
/// Reference: https://www.codeproject.com/Tips/1091249/Drawing-a-Rectangle-in-the-Csharp-Console
/// </summary>
public static class DrawUtils
{
    public static void Rectangle(
        int width,
        int height,
        int xLocation = 0,
        int yLocation = 0,
        ConsoleColor? color = null)
    {
        // if the size is smaller then 1 than don't do anything
        if (width < 1 || height < 1)
        {
            return;
        }

        // Save original cursor location
        int savedCursorTop = Console.CursorTop;
        int savedCursorLeft = Console.CursorLeft;

        // Save and then set cursor color
        ConsoleColor savedColor = Console.ForegroundColor;
        if (color.HasValue)
        {
            Console.ForegroundColor = color.Value;
        }

        char tl, tt, tr, mm, bl, br;

        tl = '+'; tt = '-'; tr = '+'; mm = '¦'; bl = '+'; br = '+';

        SafeDraw(xLocation, yLocation, tl);
        for (int x = xLocation + 1; x < xLocation + width; x++)
        {
            SafeDraw(x, yLocation, tt);
        }
        SafeDraw(xLocation + width, yLocation, tr);

        for (int y = yLocation + height; y > yLocation; y--)
        {
            SafeDraw(xLocation, y, mm);
            SafeDraw(xLocation + width, y, mm);
        }

        SafeDraw(xLocation, yLocation + height + 1, bl);
        for (int x = xLocation + 1; x < xLocation + width; x++)
        {
            SafeDraw(x, yLocation + height + 1, tt);
        }
        SafeDraw(xLocation + width, yLocation + height + 1, br);

        Console.SetCursorPosition(savedCursorLeft, savedCursorTop);

        if (color.HasValue)
        {
            Console.ForegroundColor = savedColor;
        }
    }

    private static void SafeDraw(int xLocation, int yLocation, char ch)
    {
        if (xLocation >= 0 && yLocation >= 0 && xLocation < Console.BufferWidth && yLocation < Console.BufferHeight)
        {
            Console.SetCursorPosition(xLocation, yLocation);
            Console.Write(ch);
        }
    }
}