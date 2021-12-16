using UnityEngine;

[CreateAssetMenu( fileName = "New ScriptableIntReferenceEvent", menuName = "ScriptableObjects/ScriptableIntReferenceEvent" )]
public class ScriptableIntReferenceEvent : ScriptableEvent<IntReference>
{
    public void Invoke(int value)
    {
        Invoke( new IntReference( value ) );
    }
}
