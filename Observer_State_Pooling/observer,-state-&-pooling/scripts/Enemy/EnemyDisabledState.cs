using Godot;
using System;

public class EnemyDisabledState : IEnemyState
{
	Enemy enemy;
	StandardMaterial3D mat;
	CharacterController player;

	float alpha = 0.0f;

	public void Update(float delta, ref IEnemyState state)
	{
		mat.AlbedoColor = Color.FromHsv(540.0f, 100.0f, 41.0f, alpha);
		enemy.Position -= new Vector3(0.0f, 0.5f * delta, 0.0f);
		if (enemy.Position.Y < -1.0f)
		{
			enemy.Die();
			SetDefaultOverlay();
			state = new EnemyIdleState();
			state.Initialize(enemy, player);
		}
		alpha += delta * 0.0001f;
	}

	public void Initialize(Enemy _enemy, CharacterController _player)
	{
		enemy = _enemy;
		player = _player;
		_player.subject.Notify(Event.PlayerAttacked);
		SetDefaultOverlay();
	}

	private void SetDefaultOverlay()
	{
		mat = new StandardMaterial3D();
		mat.Transparency = BaseMaterial3D.TransparencyEnum.Alpha;
		mat.AlbedoColor = Color.FromHsv(140.0f, 100.0f, 41.0f, 0.0f);
		enemy.graphics.MaterialOverlay = mat;
	}

	public void HorizontalCollision(ref IEnemyState state) {}

	public void VerticalCollision(ref IEnemyState state) {}
}
