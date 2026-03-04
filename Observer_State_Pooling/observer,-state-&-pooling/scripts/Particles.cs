using Godot;
using System;

public partial class Particles : GpuParticles3D, IObserver
{
	float timer = 0.0f;
	
	[Export] float emissionDuration = 1.0f;

	[Export] Node subject;

	public override void _Ready()
	{
		Emitting = false;
		if(!Subject.TryRegister(subject, this))
		{
			GD.Print("Player Particles observer did not register");
		}
	}

	public override void _Process(double delta)
	{
		if (Emitting)
		{
			if (timer >= emissionDuration)
			{
				Emitting = false;
				timer = 0.0f;
				return;
			}
			timer += (float)delta;
		}
	}

	public void OnNotify(Event _event)
	{
		switch(_event)
		{
		case Event.PlayerDamaged:
			Emitting = true;
			timer = 0.0f;
			break;
		}
	}
}
