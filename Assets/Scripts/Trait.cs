using System;
using UnityEngine;

[CreateAssetMenu]
public class Trait : ScriptableObject
{
    [field: SerializeField] public Categorie Type { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public float Value { get; private set; }

    [field: SerializeField] public Sprite Icon { get; set; }
    [field: SerializeField] public String IconType { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(Type)}: {Type}, {nameof(Value)}: {Value}";
    }
}