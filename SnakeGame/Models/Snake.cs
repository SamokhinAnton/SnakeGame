﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public static class Snake
    {
        private static List<Segment> _snake = new List<Segment>();
        public static Direction Direction;
        public static void BuildDefaultSnake(int segments)
        {
            for (int i = 0; i < segments; i++)
            {
                var segment = new Segment();
                segment.X = i+2;
                segment.Y = 1;
                _snake.Add(segment);
                Console.SetCursorPosition(segment.X, segment.Y);
                Console.Write(segment.Shape);
            }
            Direction = Direction.right;
        }
        public static void ClearSegment(Segment segment)
        {
            Console.SetCursorPosition(segment.X, segment.Y);
            Console.Write(" ");
        }
        public static void AddSegment(Segment segment)
        {
            Console.SetCursorPosition(segment.X, segment.Y);
            Console.Write(segment.Shape);
        }
        public static void ClearSnake()
        {
            for (int i = 0; i < _snake.Count; i++)
            {
                ClearSegment(_snake[i]);
            }
            _snake.Clear();
        }
        public static void MoveUp()
        {
            ClearSegment(_snake[0]);
            _snake.RemoveAt(0);
            var newSegment = new Segment();
            newSegment.X = _snake[_snake.Count() - 1].X;
            newSegment.Y = _snake[_snake.Count() - 1].Y - 1;
            _snake.Add(newSegment);
            AddSegment(newSegment);
        }
        public static void MoveDown()
        {
            ClearSegment(_snake[0]);
            _snake.RemoveAt(0);
            var newSegment = new Segment();
            newSegment.X = _snake[_snake.Count() - 1].X;
            newSegment.Y = _snake[_snake.Count() - 1].Y + 1;
            _snake.Add(newSegment);
            AddSegment(newSegment);
        }
        public static void MoveRight()
        {
            ClearSegment(_snake[0]);
            _snake.RemoveAt(0);
            var newSegment = new Segment();
            newSegment.X = _snake[_snake.Count() - 1].X + 1;
            newSegment.Y = _snake[_snake.Count() - 1].Y;
            _snake.Add(newSegment);
            AddSegment(newSegment);
        }
        public static void MoveLeft()
        {
            ClearSegment(_snake[0]);
            _snake.RemoveAt(0);
            var newSegment = new Segment();
            newSegment.X = _snake[_snake.Count() - 1].X - 1;
            newSegment.Y = _snake[_snake.Count() - 1].Y;
            _snake.Add(newSegment);
            AddSegment(newSegment);
        }
        public static bool Move()
        {
            switch (Direction)
            {
                case Direction.right:
                    if (_snake[_snake.Count - 1].X >= Console.WindowWidth - 6)
                    {
                        return false;
                    }
                    MoveRight();
                    break;
                case Direction.left:
                    if (_snake[_snake.Count - 1].X <= 2)
                    {
                        return false;
                    }
                    MoveLeft();
                    break;
                case Direction.up:
                    if (_snake[_snake.Count - 1].Y <= 1)
                    {
                        return false;
                    }
                    MoveUp();
                    break;
                case Direction.down:
                    if (_snake[_snake.Count - 1].Y >= Console.WindowHeight - 6)
                    {
                        return false;
                    }
                    MoveDown();
                    break;
                default:
                    break;
            }
            return true;
        }

        public static void Grow()
        {
            var segment = new Segment();
            switch (Direction)
            {
                case Direction.right:
                    segment.Y = _snake[_snake.Count - 1].Y;
                    segment.X = _snake[_snake.Count - 1].X + 1;
                    break;
                case Direction.left:
                    segment.Y = _snake[_snake.Count - 1].Y;
                    segment.X = _snake[_snake.Count - 1].X - 1;
                    break;
                case Direction.up:
                    segment.Y = _snake[_snake.Count - 1].Y - 1;
                    segment.X = _snake[_snake.Count - 1].X;
                    break;
                case Direction.down:
                    segment.Y = _snake[_snake.Count - 1].Y + 1;
                    segment.X = _snake[_snake.Count - 1].X;
                    break;
                default:
                    break;
            }
            _snake.Add(segment);
            AddSegment(segment);
        }

        public static bool BiteOwnTail()
        {
            for (int i = 0; i < _snake.Count-1; i++)
            {
                if (_snake[_snake.Count - 1].X == _snake[i].X && _snake[_snake.Count - 1].Y == _snake[i].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool EatFood(int foodX, int foodY)
        {
            if (_snake[_snake.Count - 1].X == foodX && _snake[_snake.Count - 1].Y == foodY)
            {
                return true;
            }
            return false;
        }
    }
}
