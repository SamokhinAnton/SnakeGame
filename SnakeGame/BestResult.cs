using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class BestResult
    {
        public static List<ScoreModel> List = new List<ScoreModel>();
        public const string Path = "../../Data/score.txt";

        public static void ParseResult()
        {
            var lines = File.ReadAllLines(Path, Encoding.Unicode).Where(l => !string.IsNullOrEmpty(l));
            List.Clear();
            foreach (var item in lines)
            {
                var arr = item.Split('|');
                List.Add(new ScoreModel() { Name = arr[0], Score = int.Parse(arr[1]) });
            }
        }

        public static void ViewResults(int top)
        {
            ParseResult();
            var topResults = List.OrderByDescending(r => r.Score).Take(top);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Score ");
            foreach (var item in topResults)
            {
                Console.WriteLine("{0} - {1}", item.Name, item.Score);
            }
            if(topResults.Count() == 0)
            {
                Console.WriteLine("There is no result!");
            }
            Console.WriteLine("PRESS TO RETURN...");
            Console.ReadKey();
        }

        public static void WriteResult(int score)
        {
            Console.Clear();
            Console.WriteLine("Write your name");
            var name = Console.ReadLine();
            using(var write = new StreamWriter(Path, true , Encoding.Unicode))
            {
                write.WriteLine("{0}|{1}", name, score);
            }
        }
    }
}
