using System.Collections.Generic;
using System.Linq;

namespace SnakeMess
{
    class Snake
    {
        private int _startLength = 4;
        private List<Point> _body = new List<Point>();
        private bool _isAlive = true;

        public int Size
        {
            get { return _startLength; }
            set { _startLength = value; }
        }

        public Point Tail
        {
            get { return Body.First(); }
            set { Body[0] = value; }
        }

        public Point Head
        {
            get { return Body.Last(); }
            set { Body.Add(value); }
        }

        public List<Point> Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        public Snake()
        {
            for (var i = 0; i < Size; i++)
            {
                Body.Add(new Point(10, 10));
            }
        }

        public void Grow(int growBy = 1)
        {
            for (var i = 0; i < growBy; i++)
            {
                Body.Add(new Point(Head.X, Head.Y));
            }
        }

        public void Die()
        {
            IsAlive = !IsAlive;
        }

        public int FruitsEaten()
        {
            return Body.Count - Size;
        }

    }
}