using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Game
    {
        private bool Play { get; set; }
        private DateTime StartTime { get; set; }
        private Food Food { get; set; }
        private Snake Snake { get; set; }
        private Field Field { get; set; }
        private int Lives { get; set; }
        private int Score { get; set; }
        private int Speed { get; set; }
        private int EatenFoods { get; set; }

        public Game()
        {
            Play = true;
            StartTime = DateTime.Now;
            Food = new Food();
            Snake = new Snake(6);
            Field = new Field();
            Lives = 3;
            Score = 0;
            Speed = 100;
            EatenFoods = 0;
        }

        private void CheckKeyPress()
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

        private void Move()
        {
            var game = Snake.Move();
            if (!game)
            {
                GameOver();
            }
        }

        private void CheckBiteOwnTail()
        {
            if (Snake.BiteOwnTail())
            {
                GameOver();
            }
        }

        private void CheckFood()
        {
            if (Snake.EatFood(Food.X, Food.Y))
            {
                if (++EatenFoods % 5 == 0)
                {
                    Speed -= 5;
                }
                StartTime = DateTime.Now;
                Score += Food.Value;
                Snake.Grow();
                Field.Statistic(Speed, Score, Lives);
                Food = new Food();
                Food.Appear();
            }
        }

        private void ResetFood()
        {
            if (StartTime <= DateTime.Now.Subtract(TimeSpan.FromSeconds(10)))
            {
                Food.Disappear();
                StartTime = DateTime.Now;
                Food = new Food();
                Food.Appear();
            }
        }

        public void NewGame()
        {
            Field.GameField();
            Field.Statistic(Speed, Score, Lives);
            Food.Appear();
            Snake.BuildDefaultSnake();
            Start();
        }

        private void GameOver()
        {
            if (Lives > 0)
            {
                Console.SetCursorPosition((Console.WindowWidth-20)/2, Console.WindowHeight/2);
                Console.WriteLine("You lost. Press to continue");
                Console.ReadKey();
                Lives--;
                Console.Clear();
                Snake.ClearSnake();
                NewGame();
            }
            else
            {
                Play = false;
                Console.ForegroundColor = ConsoleColor.Red;
                var str = "GAME OVER";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(str);
                Console.ResetColor();
                BestResult.WriteResult(Score);
            }
        }

        private void Start()
        {
            while (Play)
            {
                CheckKeyPress();
                ResetFood();
                Move();
                CheckBiteOwnTail();
                CheckFood();
                Thread.Sleep(Speed);
            }
        }
    }
}
