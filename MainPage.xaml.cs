namespace GameTimer;

public partial class MainPage : ContentPage
{
	public Configurations config = null;
	public Game game = null;



	// Class player: number, color, time
	// Class timer: change btn title and colour according current player

	public MainPage()
	{
		InitializeComponent();
		this.config = new Configurations();	
		this.game = new Game(this.config, this);
		this.InitGame();

	}

	private void PlayBtnPress(object sender, EventArgs e)
	{

		game.turn_player_id = game.get_next_player_id();
		game.Turn();
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
			game.Turn();
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
		this.game = new Game(this.config, this);
        PlayBtn.Text = PlayersRepr();
		this.game.turn_player_id = 1;

    }
    public bool Timer_Tick()
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

