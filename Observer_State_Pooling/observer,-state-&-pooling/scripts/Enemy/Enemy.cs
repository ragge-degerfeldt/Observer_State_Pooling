using Godot;
using System;

public partial class Enemy : Node3D
{
	IEnemyState state;
	CharacterController player;

	[Export] public MeshInstance3D graphics;

    public override void _Ready()
	{
	}

	bool inUse = false;

    public override void _Process(double delta)
	{
		if (!inUse) { return; }
		
		state.Update((float)delta, ref state);
	}

	public void HorizontalCollision(Node3D obj)
	{
		if (obj == player)
		{
			state.HorizontalCollision(ref state);
		}
	}

	public void VerticalCollision(Node3D obj)
	{
		if (obj == player)
		{
			state.VerticalCollision(ref state);
		}
	}


	public void Initialize(CharacterController _player, Vector3 position)
	{
		inUse = true;
		player = _player;
		Position = position;
		state = new EnemyIdleState();
		state.Initialize(this, player);
	}

	public void Die()
	{
		inUse = false;
	}

	public bool InUse() { return inUse; }
}
