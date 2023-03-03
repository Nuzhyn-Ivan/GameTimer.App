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
        public Player currentPlayer;
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
                Player player = new Player(i, name, colour, config.game_time);
                playersList.Add(player);
            }
            this.currentPlayer = playersList[0];

        }
		public Player GetNextPlayer() 
		{
			int player_index = this.playersList.IndexOf(this.currentPlayer);


			if (player_index == this.playersList.Count() - 1)
			{
                // return first player if player_index is the index of last player 
                return this.playersList[0];
			}
			else
				return this.playersList[player_index + 1];

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
                this.currentPlayer.Time += this.config.turn_add_time;
                this.currentPlayer = this.GetNextPlayer();
            }
			
		}

		public void tickCurrentPlayer()
        {
            this.currentPlayer.Time -= 1;

            if (this.currentPlayer.Time == 0)
            {
                Player player = this.currentPlayer;
                this.currentPlayer = this.GetNextPlayer();
                this.playersList.Remove(player);
                
            }
        }


    }

}


