using Godot;
using System;

public class EnemyDisabledState : IEnemyState
{
	Enemy enemy;
	StandardMaterial3D mat;

	float alpha = 0.0f;

	public IEnemyState Update(float delta)
	{
		mat.AlbedoColor = Color.FromHsv(540.0f, 100.0f, 41.0f, alpha);
		enemy.Position -= new Vector3(0.0f, 0.5f * delta, 0.0f);
		if (enemy.Position.Y < -1.0f)
		{
			enemy.Die();
			SetDefaultOverlay();
			return new EnemyIdleState();
		}
		alpha += delta * 0.0001f;
		return null;
	}

	public void Initialize(Enemy _enemy, CharacterController _player)
	{
		enemy = _enemy;	

		SetDefaultOverlay();
	}

	private void SetDefaultOverlay()
	{
		mat = new StandardMaterial3D();
		mat.Transparency = BaseMaterial3D.TransparencyEnum.Alpha;
		mat.AlbedoColor = Color.FromHsv(140.0f, 100.0f, 41.0f, 0.0f);
		enemy.graphics.MaterialOverlay = mat;
	}

	public IEnemyState HorizontalCollision()
	{
		return null;
	}

	public IEnemyState VerticalCollision()
	{
		return null;
	}
}
