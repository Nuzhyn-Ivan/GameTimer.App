using System.Collections.Generic;

namespace GameTimer;

public partial class MainPage : ContentPage
{
	int count = 0;
	int players_count = 4;
	bool pause = false;
	turn_add_time = 0;
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

