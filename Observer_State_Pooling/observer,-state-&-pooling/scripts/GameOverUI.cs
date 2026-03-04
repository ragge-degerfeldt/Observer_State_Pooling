using Godot;
using System;

public partial class GameOverUI : Label, IObserver
{

	[Export] Node subject;

	public override void _Ready()
	{
		Visible = false;
		if (!Subject.TryRegister(subject, this))
		{
			GD.Print("Game Over UI observer did not register");
		}
	}

    public override void _Process(double delta)
	{
		if (Visible)
		{
			LabelSettings.FontSize += 2;
			LabelSettings.ShadowSize += 5;
			if (LabelSettings.FontSize > 800)
			{
				GetTree().Quit();
			}
		}
	}

	public void OnNotify(Event _event)
	{
		switch(_event)
		{
		case Event.PlayerDied:
			Visible = true;
			break;
		}
	}
}
