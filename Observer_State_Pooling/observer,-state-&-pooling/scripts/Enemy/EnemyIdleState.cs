using Godot;
using System;

public class EnemyIdleState : IEnemyState
{
	Enemy enemy;
	Node3D player;

	float detectionDistance = 5.0f;

	public IEnemyState Update(float delta)
	{
		if ((enemy.Position - player.Position).Length() < detectionDistance)
		{
			return new EnemyChasingState();
		}
		return null;
	}	

	public void Initialize(Enemy _enemy, Node3D _player)
	{
		enemy = _enemy;
		player = _player;
	}

	public IEnemyState HorizontalCollision()
	{
		return new EnemyWaitingState();
	}

	public IEnemyState VerticalCollision()
	{
		return new EnemyDisabledState();
	}
}
