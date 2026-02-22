using Godot;
using System;

public partial class EnemyPool : Node
{
	Enemy[] enemies;

	[Export] Node3D enemyParent;
	[Export] PackedScene enemyPrefab;
	[Export] Node3D player;
	[Export] float enemyMinSpawnDistance = 5.0f;
	[Export] float enemySpawnFrequency = 5.0f;

	private int enemyLimit = 5;

	RandomNumberGenerator rng = new RandomNumberGenerator();

	float timer = 0.0f;

	public override void _Ready()
	{
		enemies = new Enemy[enemyLimit];
		for (int i = 0; i < enemyLimit; i++)
		{
			Node instance = ResourceLoader.Load<PackedScene>(enemyPrefab.ResourcePath).Instantiate();
    		enemyParent.AddChild(instance);
			enemies[i] = (Enemy)instance;
		}
		for (int i = 0; i < enemyLimit; i++)
		{
			enemies[i].Initialize(player, GeneratePosition());
		}
	}

	public override void _Process(double delta)
	{
		timer += (float)delta;
		if (timer >= 5.0f)
		{
			timer = 0.0f;
			CreateEnemy();
		}
	}

	private Vector3 GeneratePosition()
	{
		while (true)
		{
			Vector3 attempt = new Vector3(rng.RandfRange(-24.0f, 24.0f), 0.0f, rng.RandfRange(-24.0f, 24.0f));
			bool collision = false;
			for (int i = 0; i < enemyLimit; i++)
			{
				Enemy enemy = enemies[i];
				if (!enemy.InUse()) { continue; }
				if ((enemy.Position - attempt).Length() < enemyMinSpawnDistance)
				{
					collision = true;
				}
			}
			if (collision) { continue; }
			return attempt;
		}
	}

	private void CreateEnemy()
	{
		for (int i = 0; i < enemyLimit; i++)
		{
			Enemy enemy = enemies[i];
			if (!enemy.InUse())
			{
				enemy.Initialize(player, GeneratePosition());
				return;
			}
		}
	}
}
