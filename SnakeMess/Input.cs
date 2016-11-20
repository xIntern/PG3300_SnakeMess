using System;

namespace SnakeMess
{
    class Input
    {

        public Point NewDirection { get; set; }
        public Point PreviousDirection { get; set; }
        public bool Pause { get; set; } = false;
        public bool Escape { get; set; } = false;



        public Input()
        {
            NewDirection = new Point(0, 1);
            PreviousDirection = NewDirection;
        }

        public void GetInput()
        {
            if (!Console.KeyAvailable)
            {
                return;
            }
            var consoleInput = Console.ReadKey(true);
            if (consoleInput.Key == ConsoleKey.Escape)
            {
                Escape = true;
            }
            if (consoleInput.Key == ConsoleKey.Spacebar)
            {
                Pause = !Pause;
            } else
            {
                NewDirection = SnakeDirection(consoleInput, PreviousDirection);
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
