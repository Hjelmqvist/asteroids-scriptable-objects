using System;
using UnityEngine;

public abstract class ScriptableEventBase : ScriptableObject
{
    private event Action _eventNoPayload;

    public void Invoke()
    {
        _eventNoPayload?.Invoke();
    }

    public void Register(Action action)
    {
        _eventNoPayload += action;
    }

    public void Unregister(Action action)
    {
        _eventNoPayload -= action;
    }
}

[CreateAssetMenu( fileName = "New ScriptableEvent", menuName = "ScriptableObjects/ScriptableEvent" )]
public abstract class ScriptableEvent : ScriptableEventBase
{
}