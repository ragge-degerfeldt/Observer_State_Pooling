using Godot;
using System;
using System.Runtime.Serialization;

public class EnemyWaitingState : IEnemyState
{
	Enemy enemy;
	CharacterController player;

	
	float timer = 0.0f;
	float waitDuration = 3.0f;

	public void Update(float delta, ref IEnemyState state)
	{
		timer += delta;
		if (timer > waitDuration)
		{
			state = new EnemyIdleState();
			state.Initialize(enemy, player);
		}
	}

	public void Initialize(Enemy _enemy, CharacterController _player)
	{
		enemy = _enemy;
		player = _player;
	}

	public void HorizontalCollision(ref IEnemyState state) {}

	public void VerticalCollision(ref IEnemyState state)
	{
		state = new EnemyDisabledState();
		state.Initialize(enemy, player);
	}
}
