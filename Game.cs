using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimer
{

	public class Game
	{
		public bool pause = false;
		public string player_turn;
		public Dictionary<string, int> players = new();
		private  Configurations config = new Configurations();
		public Game()
		{
		}

		public Game(Configurations config)
		{
			this.config = config;
			players.Clear();
			foreach (KeyValuePair<int, Dictionary<string, string>> entry in config.players)
			{
				// player name, time
				if (config.players_count > this.players.Count)
					this.players.Add(entry.Value["name"], config.game_time );
				else
					return;

			}

		}
		public string get_next_player() 
		{
	
			int currentIndex = config.players.FirstOrDefault(p => p.Value["name"] == this.player_turn).Key;
			int nextIndex = (currentIndex + 1) % config.players.Count;
			return players.Count == nextIndex ? config.players.First().Value["name"] : config.players[nextIndex]["name"];
			
		}

	}

}


