using System;
using System.Diagnostics;

namespace SnakeMess
{
    class Board
    {
        int BoardWidth { set; get; }
        int BoardHeight { set; get; }
        Input ConsoleInput { set; get; }
        Snake Snake { set; get; }
        Stopwatch Time { set; get; }
        Food Food { set; get; }

        public Board()
        {
            ConsoleInput = new Input();
            BoardHeight = Console.WindowHeight;
            BoardWidth = Console.WindowWidth;
            Snake = new Snake();
            Time = new Stopwatch();
            Food = new Food();
        }

        public void SetBoard()
        {

            Console.Clear();
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            Console.SetCursorPosition(10, 10);
            Console.Write(Snake.BodySymbol);
            Food.PlaceFood(BoardWidth, BoardHeight, Snake.Body);
            Time.Start();
        }

        public void StartGame(bool menu)
        {
            while (Snake.IsAlive && !ConsoleInput.escape)
            {
                ConsoleInput.GetInput();

                if (ConsoleInput.pause)
                    continue;

                if (Time.ElapsedMilliseconds < 100)
                    continue;

                Time.Restart();

                var newHead = new Point(Snake.Head);
                newHead = newHead + ConsoleInput.newDirection;

                if (Snake.HitsWall(newHead, BoardHeight, BoardWidth))
                    break;

                if (Snake.EatsItself(Snake.Body, newHead))
                    Snake.Die();

                if (newHead == Food.Point)
                {
                    if (Food.NoRoomForMore(Snake.Body, BoardWidth, BoardHeight))
                        break;

//                    snake.Color = food.FColor;
                    Food.PlaceFood(BoardWidth, BoardHeight, Snake.Body);

                }
                else
                {
                    Snake.Body.RemoveAt(0);

                    Console.SetCursorPosition(Snake.Tail.X, Snake.Tail.Y);
                    Console.Write(" ");
                }
                Snake.Print(newHead);
                ConsoleInput.previousDirection = ConsoleInput.newDirection;
            }
            if(menu)ScoreMenu();
        }

        public void ScoreMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Score: {0}", Snake.FruitsEaten());

            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
}
