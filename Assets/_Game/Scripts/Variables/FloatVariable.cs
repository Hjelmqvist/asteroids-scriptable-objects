using UnityEngine;

[CreateAssetMenu(fileName = "New FloatVariable", menuName = "ScriptableObjects/Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] float _value;

    public float Value => _value;
}