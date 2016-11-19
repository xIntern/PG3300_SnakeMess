using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SnakeMess {

    class Client {
        public static void Main(string[] arguments) {
            bool withScoreMenu = true;
            Board snakeGame = new Board();
            snakeGame.SetBoard();
            snakeGame.StartGame(withScoreMenu);
        }
    }
}