using Godot;
using System;

public class EnemyIdleState : IEnemyState
{
	Enemy enemy;
	CharacterController player;


	float detectionDistance = 5.0f;

	public void Update(float delta, ref IEnemyState state)
	{
		if ((enemy.Position - player.Position).Length() < detectionDistance)
		{
			state = new EnemyChasingState();
			state.Initialize(enemy, player);
		}
	}	

	public void Initialize(Enemy _enemy, CharacterController _player)
	{
		enemy = _enemy;
		player = _player;
	}

	public void HorizontalCollision(ref IEnemyState state)
	{
		player.Damaged();
		state = new EnemyWaitingState();
		state.Initialize(enemy, player);
	}

	public void VerticalCollision(ref IEnemyState state)
	{
		state = new EnemyDisabledState();
		state.Initialize(enemy, player);
	}
}
