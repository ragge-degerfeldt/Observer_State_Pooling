using Godot;
using System;

public partial class CharacterController : CharacterBody3D
{
	[Export] float Speed = 7.0f;
	[Export] float JumpVelocity = 4.5f;

	string jump = "Jump";
	string moveForward = "Forward";
	string moveBackward = "Backward";
	string moveLeft = "Left";
	string moveRight = "Right";

	[Export] Node3D camera;

	public Subject subject;

    public override void _EnterTree()
	{
		subject = new Subject();
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed(jump) && IsOnFloor())
		{
			subject.Notify(Event.PlayerJumped);
			velocity.Y = JumpVelocity;
		}

		Vector2 inputDir = new Vector2
		(
			Input.IsActionPressed(moveRight) ? 1.0f : Input.IsActionPressed(moveLeft) ? -1.0f : 0.0f,
			Input.IsActionPressed(moveForward) ? -1.0f : Input.IsActionPressed(moveBackward) ? 1.0f : 0.0f
		);

		
		Vector3 direction = (camera.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void Damaged()
	{
		subject.Notify(Event.PlayerDamaged);
	}
}
