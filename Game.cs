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
        private bool timerCreated = false;
        public int turn_player_id;
		public Dictionary<int, Player> players = new();
		private  Configurations config = new Configurations();
		private MainPage main = null;
		public Game(int game_time, int players_count, int turn_add_time, Dictionary<int, Dictionary<string, string>> players)
		{
		}

		public Game(Configurations config, MainPage main)
		{
			this.config = config;
			this.main = main;
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
		public int get_next_player_id() 
		{
	
			if (this.turn_player_id == this.)
			int nextIndex = (currentIndex + 1) % config.players.Count;
			return players.Count == nextIndex ? config.players.First().Value["name"] : config.players[nextIndex]["name"];
			
		}
		public void Turn()
		{
			if (String.IsNullOrEmpty(this.player_turn))
			{
				string first_player_name = config.players[1]["name"];
				this.player_turn = first_player_name;
			}

            if (!timerCreated)
            {
                // create new timer object
                Device.StartTimer(TimeSpan.FromMilliseconds(1000), main.Timer_Tick);
                timerCreated = true;
            }
			this.player_turn = this.get_next_player();
		}

	}

}


