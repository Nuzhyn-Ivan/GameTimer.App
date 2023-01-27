using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimer
{
	public class Configurations
	{
		public int players_count = 4;
		public bool pause = false;
		public int game_time = 30 * 60;  // len of players time in sec
		public int turn_add_time = 7; // how much sec shoud be added after turn
		public Dictionary<string, string> players = new()  // name, colour 
		{
			{ "Player 1", "White" },
			{ "Player 2", "Black" },
			{ "Player 3", "Yellow" },
			{ "Player 4", "Blue" },
			{ "Player 5", "Red" },
			{ "Player 6", "Green" },
			{ "Player 7", "Purple" },
			{ "Player 8", "Orange" },
		};
	}
}
