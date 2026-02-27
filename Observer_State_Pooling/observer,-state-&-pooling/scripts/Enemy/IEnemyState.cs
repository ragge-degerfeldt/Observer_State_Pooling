using Godot;
using System;

public interface IEnemyState
{
	public void Update(float delta, ref IEnemyState state);
	public void Initialize(Enemy _enemy, CharacterController _player);
	public void HorizontalCollision(ref IEnemyState state);
	public void VerticalCollision(ref IEnemyState state);
}
