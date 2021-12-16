using UnityEngine;

[CreateAssetMenu( fileName = "New IntVariable", menuName = "ScriptableObjects/Variables/IntVariable" )]
public class IntVariable : ScriptableObject
{
    [SerializeField] int _value;

    int _currentValue;

    public int Value => _currentValue;

    public virtual void ApplyChange(int change)
    {
        _currentValue += change;
    }

    private void OnEnable()
    {
        _currentValue = _value;
    }
}