using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public static class Rules
    {
        public static bool Play = true;
        public static DateTime StartTime = DateTime.Now;
        public static Food Food = new Food();
        public static Field Field = new Field();
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

        private static void Move()
        {
            var game = Snake.Move();
            if (!game)
            {
                GameOver();
            }
        }
        private static void CheckBiteOwnTail()
        {
            if (Snake.BiteOwnTail())
            {
                GameOver();
            }
        }

        private static void CheckFood()
        {
            if (Snake.EatFood(Food.X, Food.Y))
            {
                if (++eatenFoods % 5 == 0)
                {
                    speed -= 5;
                }
                score += Food.Value;
                Snake.Grow();
                Field.Statistic(speed, score);
                Food = new Food();
                Food.Appear();
            }
        }
        private static void ResetFood()
        {
            if (StartTime <= DateTime.Now.Subtract(TimeSpan.FromSeconds(10)))
            {
                Food.Disappear();
                StartTime = DateTime.Now;
                Food = new Food();
                Food.Appear();
            }
        }
        public static void NewGame()
        {
            Field.GameField();
            Field.Statistic(speed, score);
            Food.Appear();
            Snake.BuildDefaultSnake(15);
            Start();
        }

        private static void GameOver()
        {
            Play = false;
            Console.ForegroundColor = ConsoleColor.Red;
            var str = "GAME OVER";
            Console.SetCursorPosition((Console.WindowWidth - str.Length)/2, Console.WindowHeight/2);
            Console.WriteLine(str);
            Console.ResetColor();
        }
        private static void Start()
        {
            while (Play)
            {
                CheckKeyPress();
                ResetFood();
                Move();
                CheckBiteOwnTail();
                CheckFood();
                Thread.Sleep(speed);
            }
        }



    }
}
