using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu]
public class Sentence : ScriptableObject
{
    [field: SerializeField] public Categorie Type { get; private set; }
    [field: SerializeField] public LocalizedString Content;
    [field: SerializeField] public float Value { get; private set; }

}
