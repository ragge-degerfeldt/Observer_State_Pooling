using Godot;
using System;

public partial class Health : Label3D, Observer
{
	int health;

    public override void _Ready()
	{
		health = 3;
		UpdateUI();
		CharacterController player = (CharacterController)GetParent();
		player.subject.Register(this);
	}

	public void OnNotify(Event _event)
	{
		switch(_event)
		{
		case Event.PlayerDamaged:
			health--;
			if (health <= 0)
			{
				// Die
			}
			UpdateUI();
			break;
		}
	}

	private void UpdateUI()
	{
		Text = health.ToString();
		Modulate = new Color(health == 3 ? 0 : 1, health == 1 ? 0 : 255, 0);
	}
}
