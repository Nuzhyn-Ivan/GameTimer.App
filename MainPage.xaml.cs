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
        double screenWidth = DeviceDisplay.MainDisplayInfo.Width;
        PlayBtn.FontSize = screenWidth / 20;

        string players_repr = "";
        foreach (Player player in game.playersList)
        {
			// TODO: text to take all widget size
			TimeSpan time = TimeSpan.FromSeconds(player.Time);
			players_repr = $"{players_repr}{player.Name}   {time:mm':'ss} \n";
			

		}
		return players_repr;
	}
	private void InitGame()
	{
		this.game = new Game(this.config, this);
		

    }
    public bool Timer_Tick()
	{
		if (game.pause) 
		{ 
			return false; 
		}

		game.tickCurrentPlayer();

		if (game.playersList.Count() == 1)
			//TODO implement end of game
			game.pause = true;

		PlayBtn.Text = PlayersRepr();
		SemanticScreenReader.Announce(PlayBtn.Text);
		return true;  // keep the timer running
	}
}

