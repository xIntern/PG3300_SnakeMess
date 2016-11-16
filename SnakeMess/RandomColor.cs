using System;

namespace SnakeMess {
    public class RandomColor {
        public ConsoleColor Color { get; set; }
        public RandomColor() {
            Color = NewColor();
        }
        ConsoleColor NewColor() {
            var random = new Random();
            var colorArray = Enum.GetValues(typeof(ConsoleColor));
            var randomNum = random.Next(0, colorArray.Length);
            return (ConsoleColor) colorArray.GetValue(randomNum);
        }
    }
}