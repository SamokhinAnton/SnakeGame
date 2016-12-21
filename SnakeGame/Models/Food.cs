using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Food
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Shape { get; private set; } = (char)0x00A4;//
        public int Value { get; private set; }
        public static int Quantity { get; private set; } = 1;
        public Food()
        {
            var random = new Random();
            X = random.Next(2, Console.WindowWidth - 6);
            Y = random.Next(2, Console.WindowHeight - 6);
            var k = random.Next(1, 9);
            Value = k * Quantity;
            Quantity++;
        }
        public void Appear()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Shape);
            Console.ResetColor();
        }
        public void Disappear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
