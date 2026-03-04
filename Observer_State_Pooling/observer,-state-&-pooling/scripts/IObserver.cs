using Godot;
using System;

public interface IObserver
{
	public void OnNotify(Event _event);
}
