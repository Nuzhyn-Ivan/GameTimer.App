using System.Collections.Generic;

namespace GameTimer;

public partial class MainPage : ContentPage
{
	Configurations config = new Configurations();
	Game game = new Game();



	// Class player: number, color, time
	// Class timer: change btn title and colour according current player

	public MainPage()
	{
		InitializeComponent();
	}

	private void PlayBtnPress(object sender, EventArgs e)
	{
		bool game = true;

		if (!game) // if Game not started
			{
			this.InitGame();
			PlayBtn.Text = $"players and timers";
			}

		else if (config.pause)  // game on pause
			config.pause = false ;

		this.Turn();
	}

	private void SettingsBtnPress(object sender, EventArgs e)
	{
		if (config.players_count != 8)
			config.players_count++;
		else config.players_count = 1;
		this.InitGame();
		SettingsBtn.Text = $"Players: {config.players_count}";

	}

	private void PauseBtnPress(object sender, EventArgs e)
	{
		PauseBtn.Text = config.pause ? "Resume" : "Pause";
		config.pause = !config.pause;
	}

	private void Turn() 
	{
		PlayBtn.Text = $"Clicked times";
		SemanticScreenReader.Announce(PlayBtn.Text);
	}

	private void InitGame()
	{

	}
}

