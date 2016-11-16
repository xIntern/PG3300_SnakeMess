using System;
using System.Collections.Generic;

namespace SnakeMess
{
    class Food {
        public ConsoleColor FColor { get; set; } = ConsoleColor.Yellow;
        public String FoodSymbol { get; set; } = "$";
        public Point Point { get; set; }

        public Food() {
            Point = new Point();
        }


        public void PlaceFood(int boardWidth, int boardHeight, List<Point> snake) {
            while (true) {
                Point = new Point().Random(boardWidth, boardHeight);
                var foundSpot = true;

                foreach (var snakePoint in snake)
                    if (snakePoint == Point) {
                        foundSpot = false;
                        break;
                    }

                if (!foundSpot) continue;
                FColor = new RandomColor(new[] {"Black", "DarkBlue"}).Color;
                Console.ForegroundColor = FColor;
                Console.SetCursorPosition(Point.X, Point.Y);
                Console.Write(FoodSymbol);
                break;
            }
        }
    }
}