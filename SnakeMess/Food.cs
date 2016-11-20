﻿using System;
using System.Collections.Generic;

namespace SnakeMess
{
    class Food
    {
        public ConsoleColor FColor { get; set; } = ConsoleColor.Green;
        public string FoodSymbol { get; set; } = "$";
        public Point Point { get; set; } = new Point();

        public void PlaceFood(int boardWidth, int boardHeight, List<Point> snake)
        {
            while (true)
            {
                Point = new Point().Random(boardWidth, boardHeight);
                var foundSpot = true;

                foreach (var snakePoint in snake)
                    if (snakePoint == Point)
                    {
                        foundSpot = false;
                        break;
                    }

                if (!foundSpot) continue;
//              string[] colorBlacklist = {"Black", "DarkBlue", FColor.ToString()};
//              var randomColor = new RandomColor(colorBlacklist).Color;
//              FColor = randomColor;
                Console.ForegroundColor = FColor;
                Console.SetCursorPosition(Point.X, Point.Y);
                Console.Write(FoodSymbol);
                break;
            }
        }

        public bool NoRoomForMore(List<Point> snake, int boardWidth, int boardHeight)
        {
            return snake.Count + 1 >= boardWidth * boardHeight;
        }
    }
}