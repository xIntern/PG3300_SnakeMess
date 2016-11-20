
namespace SnakeMess {

    class Client
    {
        public static void Main(string[] arguments)
        {
            bool withScoreMenu = true;
            var snakeGame = new Board();
            snakeGame.SetBoard();
            snakeGame.StartGame(!withScoreMenu);
        }
    }
}