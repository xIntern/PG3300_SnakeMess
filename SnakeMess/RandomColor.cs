using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMess {
    public class RandomColor {
        public ConsoleColor Color { get; set; }
        public string[] BlackList { get; set; }
        public RandomColor(string[] blackList = null)
        {
            BlackList = blackList;
            Color = NewColor();
        }
        private ConsoleColor NewColor()
        {
            var random = new Random();
            var colorArray = Enum.GetValues(typeof(ConsoleColor));
            var randomNum = random.Next(0, colorArray.Length);
            var randomColor = (ConsoleColor) colorArray.GetValue(randomNum);
            if (BlackList != null)
            {
                while (BlackList.Contains(randomColor.ToString()))
                {
                    randomColor = (ConsoleColor) colorArray.GetValue(random.Next(0, colorArray.Length));
                }
            }
            return randomColor;
        }
    }
}