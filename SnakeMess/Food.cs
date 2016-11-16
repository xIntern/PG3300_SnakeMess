using System;
using System.Collections.Generic;

namespace SnakeMess
{
    class Food
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Food()
        {
            X = 0;
            Y = 0;
        }
        public void PlaceFood(int boardWidth, int boardHeight, List<Point> snake)
        {
            var random = new Random();

            while (true)
            {
                this.X = random.Next(0, boardWidth);
                this.Y = random.Next(0, boardHeight);
                var foundSpot = true;

                foreach (var point in snake)
                    if (point.Equals(this))
                    {
                        foundSpot = false;
                        break;
                    }

                if (!foundSpot) continue;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(this.X, this.Y);
                Console.Write("$");
                break;
            }
        }
    }
}