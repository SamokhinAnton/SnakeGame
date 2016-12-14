using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    public class Segment
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Shape { get; set; } = (char)0x58D;
    }
}
