using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public static class GameMenu
    {
        public static void Menu()
        {
            var check = true;

            while (check)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1 - New game!");
                Console.WriteLine("2 - Best results!");
                Console.WriteLine("3 - Exit game!");
                var point = Console.ReadKey();
                switch (point.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        var game = new Game();
                        game.NewGame();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        BestResult.ViewResults(10);
                        break;
                    case ConsoleKey.D3:
                        check = false;
                        return;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
