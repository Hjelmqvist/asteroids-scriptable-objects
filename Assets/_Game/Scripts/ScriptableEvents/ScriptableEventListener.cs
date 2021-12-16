using System;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventListener : MonoBehaviour
{
    [SerializeField] ScriptableEvent _eventNoPayload;
    [SerializeField] UnityEvent _responseNoPayload;

    private void OnEvent()
    {
        _responseNoPayload.Invoke();
    }

    private void OnEnable()
    {
        _eventNoPayload.Register( OnEvent );
    }

    private void OnDisable()
    {
        _eventNoPayload.Unregister( OnEvent );
    }
}

public class ScriptableEventListener<T> : ScriptableEventListener
{
    [SerializeField] ScriptableEvent<T> _event;
    [SerializeField] UnityEvent<T> _response;

    private void OnEvent(T arg)
    {
        _response.Invoke( arg );
    }

    private void OnEnable()
    {
        _event.Register( OnEvent );
    }

    private void OnDisable()
    {
        _event.Unregister( OnEvent );
    }
}