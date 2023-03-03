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
		public int game_time = 3 * 3;  // len of players time in sec
		public int turn_add_time = 7; // how much sec shoud be added after turn

		public Dictionary<int, Dictionary<string, string>> players = new Dictionary<int, Dictionary<string, string>>()
		{
			{1, new Dictionary<string, string>() { { "name", "Player 1" }, { "colour", "White" } } },
			{2, new Dictionary<string, string>() { { "name", "Player 2" }, { "colour", "Black" } } },
			{3, new Dictionary<string, string>() { { "name", "Player 3" }, { "colour", "Yellow" } } },
			{4, new Dictionary<string, string>() { { "name", "Player 4" }, { "colour", "Blue" } } },
			{5, new Dictionary<string, string>() { { "name", "Player 5" }, { "colour", "Red" } } },
			{6, new Dictionary<string, string>() { { "name", "Player 6" }, { "colour", "Green" } } },
			{7, new Dictionary<string, string>() { { "name", "Player 7" }, { "colour", "Purple" } } },
			{8, new Dictionary<string, string>() { { "name", "Player 8" }, { "colour", "Orange" } } }
		};
	}
}
