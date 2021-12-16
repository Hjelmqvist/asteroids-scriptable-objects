using UnityEngine;

[CreateAssetMenu( fileName = "New IntObservable", menuName = "ScriptableObjects/Variables/IntObservable" )]
public class IntObservable : IntVariable
{
    [SerializeField] ScriptableIntEvent _onValueChangedEvent;

    public override void ApplyChange(int change)
    {
        base.ApplyChange( change );
        _onValueChangedEvent.Invoke( Value );
    }
}