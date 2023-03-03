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
        public List<Player> playersList = new List<Player>();
        private  Configurations config = new Configurations();
		private MainPage main = null;
		public Game(int game_time, int players_count, int turn_add_time, Dictionary<int, Dictionary<string, string>> players)
		{
		}

		public Game(Configurations config, MainPage main)
		{
			this.config = config;
			this.main = main;
            playersList.Clear();
            for (int i = 1; i <= config.players_count; i++)
            {
                Dictionary<string, string> playerDict = config.players[i];
                string name = playerDict["name"];
                string colour = playerDict["colour"];
                Player player = new Player(name, colour, config.game_time);
                playersList.Add(player);
            }

        }
		public int get_next_player_id() 
		{
	
			if (this.turn_player_id == this.playersList.Count() - 1) 
			{
				return 0;
			}
			else
				return this.turn_player_id + 1;

		}
		public void Turn()
		{
            if (!timerCreated)
            {
                // create new timer object
                Device.StartTimer(TimeSpan.FromMilliseconds(1000), main.Timer_Tick);
                timerCreated = true;
            }
			else 
			{
				this.playersList[this.turn_player_id].Time += this.config.turn_add_time;
                this.turn_player_id = this.get_next_player_id();
            }
			
		}

	}

}


