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
        private bool _play { get; set; }
        private DateTime _startTime { get; set; }
        private Food _food { get; set; }
        private Snake _snake { get; set; }
        private Field _field { get; set; }
        private int _lives { get; set; }
        private int _score { get; set; }
        private int _speed { get; set; }
        private int _eatenFoods { get; set; }

        public Game()
        {
            _play = true;
            _startTime = DateTime.Now;
            _food = new Food();
            _snake = new Snake(6);
            _field = new Field();
            _lives = 3;
            _score = 0;
            _speed = 100;
            _eatenFoods = 0;
        }

        private void CheckKeyPress()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow && _snake.Direction != Direction.right)
                {
                    _snake.Direction = Direction.left;
                }
                if (key.Key == ConsoleKey.RightArrow && _snake.Direction != Direction.left)
                {
                    _snake.Direction = Direction.right;
                }
                if (key.Key == ConsoleKey.UpArrow && _snake.Direction != Direction.down)
                {
                    _snake.Direction = Direction.up;
                }
                if (key.Key == ConsoleKey.DownArrow && _snake.Direction != Direction.up)
                {
                    _snake.Direction = Direction.down;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    _play = false;
                }
            }
        }

        private void Move()
        {
            var game = _snake.Move();
            if (!game)
            {
                GameOver();
            }
        }

        private void CheckBiteOwnTail()
        {
            if (_snake.BiteOwnTail())
            {
                GameOver();
            }
        }

        private void CheckFood()
        {
            if (_snake.EatFood(_food.X, _food.Y))
            {
                if (++_eatenFoods % 5 == 0)
                {
                    _speed -= 5;
                }
                _startTime = DateTime.Now;
                _score += _food.Value;
                _snake.Grow();
                _field.Statistic(_speed, _score, _lives);
                _food = new Food();
                _food.Appear();
            }
        }

        private void ResetFood()
        {
            if (_startTime <= DateTime.Now.Subtract(TimeSpan.FromSeconds(10)))
            {
                _food.Disappear();
                _startTime = DateTime.Now;
                _food = new Food();
                _food.Appear();
            }
        }

        public void NewGame()
        {
            _field.GameField();
            _field.Statistic(_speed, _score, _lives);
            _food.Appear();
            _snake.BuildDefaultSnake();
            Start();
        }

        private void GameOver()
        {
            if (_lives > 0)
            {
                Console.SetCursorPosition((Console.WindowWidth-20)/2, Console.WindowHeight/2);
                Console.WriteLine("You lost. Press to continue");
                Console.ReadKey();
                _lives--;
                Console.Clear();
                _snake.ClearSnake();
                NewGame();
            }
            else
            {
                _play = false;
                Console.ForegroundColor = ConsoleColor.Red;
                var str = "GAME OVER";
                Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(str);
                Console.ResetColor();
                BestResult.WriteResult(_score);
            }
        }

        private void Start()
        {
            while (_play)
            {
                CheckKeyPress();
                ResetFood();
                Move();
                CheckBiteOwnTail();
                CheckFood();
                Thread.Sleep(_speed);
            }
        }
    }
}
