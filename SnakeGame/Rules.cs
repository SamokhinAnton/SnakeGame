using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public static class Rules
    {
        public static bool Play = true;
        public static DateTime StartTime = DateTime.Now;
        public static Food Food = new Food();
        public static int score = 0;
        public static int speed = 100;
        public static int eatenFoods = 0;


        private static void CheckKeyPress()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow && Snake.Direction != Direction.right)
                {
                     Snake.Direction = Direction.left;
                }
                if (key.Key == ConsoleKey.RightArrow && Snake.Direction != Direction.left)
                {
                    Snake.Direction = Direction.right;
                }
                if (key.Key == ConsoleKey.UpArrow && Snake.Direction != Direction.down)
                {
                    Snake.Direction = Direction.up;
                }
                if (key.Key == ConsoleKey.DownArrow && Snake.Direction != Direction.up)
                {
                    Snake.Direction = Direction.down;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Play = false;
                }
            }
        }
    }
}
