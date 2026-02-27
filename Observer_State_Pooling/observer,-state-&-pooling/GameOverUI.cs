using Godot;
using System;

public partial class GameOverUI : Label, Observer
{
	[Export] Node obj;

	public override void _Ready()
	{
		Visible = false;
		CharacterController player = (CharacterController)GetParent();
		player.subject.Register(this);
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
