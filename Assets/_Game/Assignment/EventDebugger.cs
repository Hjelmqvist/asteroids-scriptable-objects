using UnityEditor;
using UnityEngine;

public class EventDebugger : MonoBehaviour
{
    [SerializeField] private string _searchFilter = "t:ScriptableEventBase";

    private void OnEnable()
    {
        string[] guids = AssetDatabase.FindAssets( _searchFilter );

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath( guid );
            var scriptableEvent = AssetDatabase.LoadAssetAtPath<ScriptableEventBase>( path );
            RegisterEvent( scriptableEvent );
        }
    }

    private void RegisterEvent(ScriptableEventBase scriptableEvent)
    {
        if (scriptableEvent != null)
        {
            scriptableEvent.Register( () => PrintEvent( scriptableEvent ) );

            // Any way to make it possible to use ScriptableEvent<T> somehow?
            switch (scriptableEvent)
            {
                case ScriptableEventInt intEvent:
                    intEvent.Register( (x) => PrintEvent( intEvent, x ) );
                    break;
                case ScriptableEventIntReference intRefEvent:
                    intRefEvent.Register( (x) => PrintEvent( intRefEvent, x ) );
                    break;
            }
        }
    }

    private void PrintEvent(ScriptableEventBase scriptableEvent)
    {
        Debug.Log( $"Event {scriptableEvent.name} was invoked!" );
    }

    private void PrintEvent(ScriptableEventBase scriptableEvent, object args)
    {
        Debug.Log( $"Event {scriptableEvent.name} was invoked with argument: {args}!" );
    }
}