using UnityEngine;

[CreateAssetMenu( fileName = "New ScriptableEventIntReference", menuName = "ScriptableObjects/ScriptableEventIntReference" )]
public class ScriptableEventIntReference : ScriptableEvent<IntReference>
{
    public void Invoke(int value)
    {
        Invoke( new IntReference( value ) );
    }
}
