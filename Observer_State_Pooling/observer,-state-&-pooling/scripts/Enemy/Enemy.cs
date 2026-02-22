using Godot;
using System;

public partial class Enemy : Node3D
{
	IEnemyState state;
	Node3D player;

	[Export] public MeshInstance3D graphics;

    public override void _Ready()
	{
		SetState(new EnemyIdleState());
	}

	bool inUse = false;

    public override void _Process(double delta)
	{
		if (!inUse) { return; }
		IEnemyState newState = state.Update((float)delta);
		if (newState != null)
		{
			SetState(newState);
		}
	}

	public void HorizontalCollision(Node3D obj)
	{
		if (obj == player)
		{
			IEnemyState newState = state.HorizontalCollision();
			if (newState != null)
			{
				SetState(newState);
			}
		}
	}

	public void VerticalCollision(Node3D obj)
	{
		if (obj == player)
		{
			IEnemyState newState = state.VerticalCollision();
			if (newState != null)
			{
				SetState(newState);
			}
		}
	}

	private void SetState(IEnemyState newState)
	{
		state = newState;
		state.Initialize(this, player);
	}

	public void Initialize(Node3D _player, Vector3 position)
	{
		inUse = true;
		player = _player;
		Position = position;
		SetState(new EnemyIdleState());
	}

	public void Die()
	{
		inUse = false;
		GD.Print("Enemy died");
	}

	public bool InUse() { return inUse; }
}
