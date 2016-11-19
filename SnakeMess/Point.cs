using System;
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

        public Point Random(int limitW, int limitH) {
            var random = new Random();
            return new Point(random.Next(limitW), random.Next(limitH));
        }

        public static bool operator ==(Point p1, Point p2) {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2) {
            return !(p1 == p2);
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

    }
}