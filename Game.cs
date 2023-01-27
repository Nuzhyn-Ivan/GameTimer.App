using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimer
{

	public class Game
	{
		public Game()
		{
			Configurations config = new Configurations();
			Dictionary<string, int> players = new();
			foreach (KeyValuePair<string, string> entry in config.players)
			{
				
			}

		}

	}

}


