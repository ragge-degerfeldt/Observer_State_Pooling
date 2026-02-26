using Godot;
using System;

public class EnemyChasingState : IEnemyState
{
	Enemy enemy;
	CharacterController player;

	float movementSpeed = 0.5f;
	float timer = 0.0f;
	float loseDetectionDistance = 7.0f;
	float graphicsMaxOffset = 0.15f;
	float graphicsAnimationSpeed = 8.0f;

	public IEnemyState Update(float delta)
	{
		Vector3 direction = player.Position;
		direction.Y = 0.0f;

		enemy.Position = enemy.Position.Lerp(direction, movementSpeed * delta);

		if ((player.Position - enemy.Position).Length() > loseDetectionDistance)
		{
			enemy.graphics.Position = new Vector3(0.0f, 0.0f, 0.0f);
			return new EnemyIdleState();
		}

		enemy.graphics.Position = new Vector3(0.0f,graphicsMaxOffset + Mathf.Sin(timer) * graphicsMaxOffset, 0.0f);
		timer += delta * graphicsAnimationSpeed;
		return null;
	}

	public void Initialize(Enemy _enemy, CharacterController _player)
	{
		enemy = _enemy;
		player = _player;
	}

	public IEnemyState HorizontalCollision()
	{
		enemy.graphics.Position = new Vector3(0.0f, 0.0f, 0.0f);
		player.Damaged();
		return new EnemyWaitingState();
	}

	public IEnemyState VerticalCollision()
	{
		enemy.graphics.Position = new Vector3(0.0f, 0.0f, 0.0f);
		return new EnemyDisabledState();
	}
}
