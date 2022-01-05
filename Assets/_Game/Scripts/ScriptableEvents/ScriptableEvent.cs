using System;
using UnityEngine;

[CreateAssetMenu( fileName = "New ScriptableEvent", menuName = "ScriptableObjects/ScriptableEvent" )]
public abstract class ScriptableEvent : ScriptableEventBase
{
}

public abstract class ScriptableEvent<T> : ScriptableEventBase
{
    private event Action<T> _event;

    public void Invoke(T arg)
    {
        _event?.Invoke( arg );
    }

    public void Register(Action<T> action)
    {
        _event += action;
    }

    public void Unregister(Action<T> action)
    {
        _event -= action;
    }
}