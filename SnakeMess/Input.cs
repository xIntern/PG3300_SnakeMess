using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Input
    {

        public Point newDirection { get; set; }
        public Point previousDirection { get; set; }
        public bool pause { get; set; } = false;
        public bool escape { get; set; } = false;



        public Input()
        {
            newDirection = new Point(0, 1);
            previousDirection = newDirection;
        }

        public void GetInput()
        {
            if (!Console.KeyAvailable) return;
            var consoleInput = Console.ReadKey(true);
            if (consoleInput.Key == ConsoleKey.Escape)
                escape = true;
            if (consoleInput.Key == ConsoleKey.Spacebar)
                pause = !pause;
            else
            {
                newDirection = SnakeDirection(consoleInput, previousDirection);
            }
        }


        public static Point SnakeDirection(ConsoleKeyInfo consoleInput, Point previousDirection)
        {
            Point newDirection = previousDirection;

            if (consoleInput.Key == ConsoleKey.UpArrow && previousDirection.Y != 1)
            {
                newDirection = new Point(0, -1);
            }
            else if (consoleInput.Key == ConsoleKey.RightArrow && previousDirection.X != -1)
            {
                newDirection = new Point(1, 0);
            }
            else if (consoleInput.Key == ConsoleKey.DownArrow && previousDirection.Y != -1)
            {
                newDirection = new Point(0, 1);
            }
            else if (consoleInput.Key == ConsoleKey.LeftArrow && previousDirection.X != 1)
            {
                newDirection = new Point(-1, 0);
            }
            return newDirection;
        }



    }
}
