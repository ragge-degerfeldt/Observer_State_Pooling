using Godot;
using System;

public interface IEnemyState
{
	public IEnemyState Update(float delta);
	public void Initialize(Enemy _enemy, Node3D _player);
	public IEnemyState HorizontalCollision();
	public IEnemyState VerticalCollision();
}
