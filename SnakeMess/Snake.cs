using System.Collections.Generic;
using System.Linq;

namespace SnakeMess {
    public class Snake {
        private int Lenght { get; set; }

        public Point Tail {
            get { return Body.First(); }
            set { Body[0] = value; }
        }

        public Point Head {
            get { return Body.Last(); }
            set { Body.Add(value); }
        }

        public List<Point> Body { get; private set; } = new List<Point>();

        public bool IsAlive { get; private set; } = true;

        public Snake(int length = 4) {
            Lenght = length;
            for (var i = 0; i <= Lenght; i++) {
                Body.Add(new Point(10, 10));
            }
        }

        public void Grow(int growBy = 1) {
            for (var i = 0; i < growBy; i++) {
                Body.Add(new Point(Head.X, Head.Y));
            }
        }

        public void Die() {
            IsAlive = !IsAlive;
        }

        public int FruitsEaten() {
            return Body.Count - 1 - Lenght;
        }

    }
}