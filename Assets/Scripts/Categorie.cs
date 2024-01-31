using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Categorie : ScriptableObject
{
    [field: SerializeField] public List<Trait> Traits { get; private set; }
}