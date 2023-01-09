using System.Collections.Generic;
using Java.Lang;

namespace GameTimer;

public partial class MainPage : ContentPage
{
	int count = 0;
	int players_count = 4;
	bool pause = false;
	int game_time = 30;  // len of players time in sec
	int turn_add_time = 4; // how much sec shoud be added after turn
	Dictionary<int, string> players = new Dictionary<int, string>
		{
			{ 1, "White" },
			{ 2, "Black" },
			{ 3, "Yellow" },
			{ 4, "Blue" },
			{ 5, "Red" },
			{ 6, "Green" },
			{ 7, "Purple" },
			{ 8, "Orange" },
		};

	// Class player: number, color, time
	// Class timer: change btn title and colour according current player

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private void OpenSettings(object sender, EventArgs e)
	{
		if (players_count != 8)
			players_count++;
		else players_count = 1;
		SettingsBtn.Text = $"Players: {players_count}";

	}

	private void PauseGame(object sender, EventArgs e)
	{
		PauseBtn.Text = pause ? "Resume" : "Pause";
		pause = !pause;
	}
}

