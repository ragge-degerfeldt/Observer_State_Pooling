using Godot;
using System;
using System.Runtime.Serialization;

public class EnemyWaitingState : IEnemyState
{
	Enemy enemy;
	CharacterController player;
	
	float timer = 0.0f;
	float waitDuration = 3.0f;

	public IEnemyState Update(float delta)
	{
		timer += delta;
		if (timer > waitDuration)
		{
			return new EnemyIdleState();
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
		return null;
	}

	public IEnemyState VerticalCollision()
	{
		return new EnemyDisabledState();
	}
}
