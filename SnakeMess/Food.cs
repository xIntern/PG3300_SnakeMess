using System;
using System.Collections.Generic;

namespace SnakeMess
{
    class Food {
        
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor FColor { get; set; } = ConsoleColor.Yellow;
        public String FoodSymbol { get; set; } = "$";
        public Point Point { get; set; }

        public Food()
        {
            Point = new Point();
        }


        public void PlaceFood(int boardWidth, int boardHeight, List<Point> snake)
        {
            var random = new Random();

            while (true) {
                var randomPoint = new Point().Random(boardWidth, boardHeight);
                X = randomPoint.X;
                Y = randomPoint.Y;
                var foundSpot = true;

                foreach (var snakePoint in snake)
                    if (snakePoint == Point) {
                        foundSpot = false;
                        break;
                    }

                if (!foundSpot) continue;
                Console.ForegroundColor = FColor;
                Console.SetCursorPosition(this.X, this.Y);
                Console.Write(FoodSymbol);
                break;
            }
        }
    }
}