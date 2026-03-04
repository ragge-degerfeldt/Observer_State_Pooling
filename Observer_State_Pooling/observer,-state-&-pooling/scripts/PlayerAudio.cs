using Godot;
using System;
using System.Collections;

public partial class PlayerAudio: Node3D, IObserver
{
	[Export] AudioStreamPlayer3D hit;
	[Export] AudioStreamPlayer3D jump;
	[Export] AudioStreamPlayer3D hurt;
	[Export] AudioStreamPlayer3D death;

	[Export] Node subject;

	public override void _Ready()
	{
		if(!Subject.TryRegister(subject, this))
		{
			GD.Print("Player Audio observer did not register");
		}
	}

	public void OnNotify(Event _event)
	{
		switch(_event)
		{
		case Event.PlayerDamaged:
			hurt.Play();
			break;
		case Event.PlayerAttacked:
			hit.Play();
			break;
		case Event.PlayerJumped:
			jump.Play();
			break;
		case Event.PlayerDied:
			death.Play();
			break;
		}
	}
}
