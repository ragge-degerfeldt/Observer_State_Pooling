using Godot;
using System;

public enum Event
{
	PlayerDamaged,
	PlayerAttacked,
	PlayerJumped,
	PlayerDied
}

public class Subject
{
	Observer[] observers;

	public void Notify(Event _event)
	{
		for (int i = 0; i < observers.Length; i++)
		{
			observers[i].OnNotify(_event);
		}
	}

	public Subject()
	{
		observers = Array.Empty<Observer>();
	}

	public void Register(Observer _observer)
	{
		Observer[] temp = new Observer[observers.Length + 1];
		for (int i = 0; i < observers.Length; i++)
		{
			temp[i] = observers[i];
		}
		temp[observers.Length] = _observer;
		observers = temp;
	}

	public bool UnRegister(Observer _observer)
	{
		Observer[] temp = new Observer[observers.Length - 1];
		int ctr = 0;
		for (int i = 0; i < observers.Length; i++)
		{
			if (observers[i] == _observer) { continue; }
			ctr++;
			if (ctr >= temp.Length) { return false; }
			temp[ctr] = observers[i];
		}
		observers = temp;
		return true;
	}
}
