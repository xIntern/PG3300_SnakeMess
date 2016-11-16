using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SnakeMess {

    class Client {
        public static void Main(string[] arguments) {
            var pause = false;
            var newDirection = new Point(0, 1); // 0 = up, 1 = right, 2 = down, 3 = left
            var previousDirection = newDirection;
            int boardWidth = Console.WindowWidth, boardHeight = Console.WindowHeight;
            var time = new Stopwatch();
            var snake = new Snake {
                Color = ConsoleColor.Red,
                HeadSymbol = "@",
                BodySymbol = "0"
            };

            Console.Clear();
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            Console.SetCursorPosition(10, 10);
            Console.Write(snake.BodySymbol);

            var fruit = new Food {
                FColor = ConsoleColor.Cyan,
                FoodSymbol = "$"
            };
            fruit.PlaceFood(boardWidth, boardHeight, snake.Body);
            time.Start();

            while (snake.IsAlive) {

                if (Console.KeyAvailable) {
                    var consoleInput = Console.ReadKey(true);
                    if (consoleInput.Key == ConsoleKey.Escape)
                        break;
                    if (consoleInput.Key == ConsoleKey.Spacebar)
                        pause = !pause;
                    else if (consoleInput.Key == ConsoleKey.UpArrow && previousDirection.Y != 1)
                        newDirection = new Point(0, -1);
                    else if (consoleInput.Key == ConsoleKey.RightArrow && previousDirection.X != -1)
                        newDirection = new Point(1, 0);
                    else if (consoleInput.Key == ConsoleKey.DownArrow && previousDirection.Y != -1)
                        newDirection = new Point(0, 1);
                    else if (consoleInput.Key == ConsoleKey.LeftArrow && previousDirection.X != 1)
                        newDirection = new Point(-1, 0);

                }
                if (pause)
                    continue;


                if (time.ElapsedMilliseconds < 100)
                    continue;
                time.Restart();

                var newHead = new Point(snake.Head);

                newHead.X += newDirection.X;
                newHead.Y += newDirection.Y;


                if (newHead.X < 0 || newHead.X >= boardWidth)
                    break;
                if (newHead.Y < 0 || newHead.Y >= boardHeight)
                    break;
                if (newHead.X == fruit.X && newHead.Y == fruit.Y) {

                    if (NoRoomForFruit(snake.Body, boardWidth, boardHeight))
                        break;

                    fruit.PlaceFood(boardWidth, boardHeight, snake.Body);
                    
                    var newColor = new RandomColor().Color;
                    while (snake.Color == newColor || Console.BackgroundColor == newColor) {
                        newColor = new RandomColor().Color;
                    }
                    snake.Color = newColor;

                } else {
                    snake.Body.RemoveAt(0);


                    if (SnakeEatsItself(snake.Body, newHead))
                        snake.Die();

                    Console.SetCursorPosition(snake.Tail.X, snake.Tail.Y);
                    Console.Write(" ");
                }
                snake.Print(newHead);
                previousDirection = newDirection;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Score: {0}", snake.FruitsEaten());

            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
        }

        public static bool SnakeEatsItself(List<Point> snake, Point newHead) {
            foreach (var point in snake) {
                if (point.X == newHead.X && point.Y == newHead.Y)
                    return true;
            }
            return false;
        }

        public static bool NoRoomForFruit(List<Point> snake, int boardWidth, int boardHeight) {
            return snake.Count + 1 >= boardWidth * boardHeight;
        }
    }
}