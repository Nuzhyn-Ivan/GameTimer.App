using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimer
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public int Time { get; set; }

        public Player(int id, string name, string colour, int time) 
        {
            this.Id = id;
            this.Name = name;
            this.Colour = colour;
            this.Time = time;
        }
    }
}
