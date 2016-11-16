using System.Collections;

namespace SnakeMess
{
    public class Point
    {
        public int X; public int Y;

        public Point(int x = 0, int y = 0)
        {
            X = x; Y = y;
        }

        public Point(Point input)
        {
            X = input.X; Y = input.Y;
        }
    }
}