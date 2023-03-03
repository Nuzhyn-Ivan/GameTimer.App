using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimer
{
    internal class Player
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public int Time { get; set; }

        public Player(string name, string colour, int time) 
        {
            this.Name = name;
            this.Colour = colour;
            this.Time = time;
        }
    }
}
