using UnityEngine;

[System.Serializable]
public class IntReference
{
    [SerializeField] IntVariable _intVariable;
    [SerializeField] int _simpleValue;
    [SerializeField] bool _useSimple;

    #if UNITY_EDITOR
    public static string VariableName = nameof( _intVariable );
    public static string UseSimpleValueName = nameof( _useSimple );
    public static string SimpleValueName = nameof( _simpleValue );
    #endif

    public IntReference(IntVariable variable)
    {
        _intVariable = variable;
        _useSimple = false;
    }

    public IntReference(int value)
    {
        _simpleValue = value;
        _useSimple = true;
    }

    public int GetValue()
    {
        return _useSimple ? _simpleValue : _intVariable.Value;
    }

    public void ApplyChange(int change)
    {
        if (_useSimple)
        {
            _simpleValue += change;
        }
        else
        {
            _intVariable.ApplyChange( change );
        }    
    }
}