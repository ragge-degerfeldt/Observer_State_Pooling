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
	IObserver[] observers;

	public void Notify(Event _event)
	{
		for (int i = 0; i < observers.Length; i++)
		{
			observers[i].OnNotify(_event);
		}
	}

	public Subject()
	{
		observers = Array.Empty<IObserver>();
	}

	public void Register(IObserver _observer)
	{
		IObserver[] temp = new IObserver[observers.Length + 1];
		for (int i = 0; i < observers.Length; i++)
		{
			temp[i] = observers[i];
		}
		temp[observers.Length] = _observer;
		observers = temp;
	}

	public bool UnRegister(IObserver _observer)
	{
		IObserver[] temp = new IObserver[observers.Length - 1];
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

	public static bool TryRegister(Node subject, IObserver observer)
	{
		if (subject is ISubject)
		{
			ISubject iSub = (ISubject)subject;
			iSub.GetSubject().Register(observer);
			return true;
		}
		return false;
	}
}
