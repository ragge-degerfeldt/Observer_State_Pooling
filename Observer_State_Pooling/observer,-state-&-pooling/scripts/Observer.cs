using Godot;
using System;

public interface Observer
{
	public void OnNotify(Event _event);
}
