using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SnakeMess {

    class Client {
        public static void Main(string[] arguments) {
            Board snakeGame = new Board();
            snakeGame.SetBoard();
            snakeGame.StartGame();
        }
    }
}