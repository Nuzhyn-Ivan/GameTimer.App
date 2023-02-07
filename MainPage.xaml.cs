namespace GameTimer;

public partial class MainPage : ContentPage
{
	public Configurations config = new Configurations();
	Game game = new Game();
	private bool timer = false;



	// Class player: number, color, time
	// Class timer: change btn title and colour according current player

	public MainPage()
	{
		InitializeComponent();
	}

	private void PlayBtnPress(object sender, EventArgs e)
	{

		if (this.game.players.Count == 0) // if Game not started
			{
			this.InitGame();
			PlayBtn.Text = PlayersRepr();
		}

		game.player_turn = game.get_next_player();

		this.Turn();
	}

	private void SettingsBtnPress(object sender, EventArgs e)
	{
		if (config.players_count != 8)
			config.players_count++;
		else config.players_count = 2;
		this.InitGame();
		SettingsBtn.Text = $"Players: {config.players_count}";

	}

	private void PauseBtnPress(object sender, EventArgs e)
	{
		PauseBtn.Text = game.pause ? "Resume" : "Pause";
		game.pause = !game.pause;
		if (!game.pause)
		{
			this.Turn();
		}

	}

	private void Turn() 
	{
		if (String.IsNullOrEmpty(game.player_turn)) 
			{
			string first_player_name = config.players[1]["name"];
			game.player_turn = first_player_name;
			}
		if (game.pause)
		{
			Device.StartTimer(TimeSpan.FromMilliseconds(1000), this.Timer_Tick);
			game.pause = false;
		}
	}

	private string PlayersRepr()
	{
		string players_repr = "";
		foreach (KeyValuePair<string, int> player in game.players)
		{
			// TODO: text to take all widget size
			TimeSpan time = TimeSpan.FromSeconds(player.Value);
			players_repr = $"{players_repr}{player.Key}   {time:mm':'ss} \n";
			

		}
		return players_repr;
	}
	private void InitGame()
	{
		this.game = new Game(this.config);
	}
	private bool Timer_Tick()
	{
		if (game.pause) 
		{ 
			return false; 
		}
		game.players[game.player_turn] -= 1;
		PlayBtn.Text = PlayersRepr();
		SemanticScreenReader.Announce(PlayBtn.Text);
		return true;  // keep the timer running
	}
}

