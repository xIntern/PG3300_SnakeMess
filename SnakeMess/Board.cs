using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Board
    {
        int boardWidth { set; get; }
        int boardHeight { set; get; }
        Input consoleInput { set; get; }
        Snake snake { set; get; }
        Stopwatch time { set; get; }
        Food food { set; get; }

        public Board()
        {
            consoleInput = new Input();
            boardHeight = Console.WindowHeight;
            boardWidth = Console.WindowWidth;
            snake = new Snake();
            time = new Stopwatch();
            food = new Food();
        }

        public void SetBoard()
        {

            Console.Clear();
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            Console.SetCursorPosition(10, 10);
            Console.Write(snake.BodySymbol);
            food.PlaceFood(boardWidth, boardHeight, snake.Body);
            time.Start();
        }

        public void StartGame()
        {
            while (snake.IsAlive)
            {
                consoleInput.GetInput();

                if (consoleInput.pause)
                    continue;


                if (time.ElapsedMilliseconds < 100)
                    continue;
                time.Restart();

                var newHead = new Point(snake.Head);

                newHead.X += consoleInput.newDirection.X;
                newHead.Y += consoleInput.newDirection.Y;


                if (newHead.X < 0 || newHead.X >= boardWidth)
                    break;
                if (newHead.Y < 0 || newHead.Y >= boardHeight)
                    break;
                if (newHead == food.Point)
                {

                    if (food.NoRoomForMore(snake.Body, boardWidth, boardHeight))
                        break;

//                    snake.Color = food.FColor;
                    food.PlaceFood(boardWidth, boardHeight, snake.Body);


                }
                else
                {
                    snake.Body.RemoveAt(0);


                    if (snake.EatsItself(snake.Body, newHead))
                        snake.Die();

                    Console.SetCursorPosition(snake.Tail.X, snake.Tail.Y);
                    Console.Write(" ");
                }
                snake.Print(newHead);
                consoleInput.previousDirection = consoleInput.newDirection;
            }
            GameOver();
        }

        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Score: {0}", snake.FruitsEaten());

            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
}
