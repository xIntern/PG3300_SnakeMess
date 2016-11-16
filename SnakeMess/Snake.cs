using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess {
    public class Snake {
        private int Length { get; set; }

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

        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
        public string HeadSymbol { get; set; } = "@";
        public string BodySymbol { get; set; } = "0";

        public Snake(int length = 4) {
            Length = length;
            for (var i = 0; i <= Length; i++) {
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
            return Body.Count - 1 - Length;
        }

        public void Print(Point newHead) {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Head.X, Head.Y);
            Console.Write(BodySymbol);
            Body.Add(newHead);
            Console.SetCursorPosition(newHead.X, newHead.Y);
            Console.Write(HeadSymbol);
        }
    }
}