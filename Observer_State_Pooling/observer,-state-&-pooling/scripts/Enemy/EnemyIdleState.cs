using Godot;
using System;

public class EnemyIdleState : IEnemyState
{
	Enemy enemy;
	CharacterController player;

	float detectionDistance = 5.0f;

	public IEnemyState Update(float delta)
	{
		if ((enemy.Position - player.Position).Length() < detectionDistance)
		{
			return new EnemyChasingState();
		}
		return null;
	}	

	public void Initialize(Enemy _enemy, CharacterController _player)
	{
		enemy = _enemy;
		player = _player;
	}

	public IEnemyState HorizontalCollision()
	{
		player.Damaged();
		return new EnemyWaitingState();
	}

	public IEnemyState VerticalCollision()
	{
		return new EnemyDisabledState();
	}
}
