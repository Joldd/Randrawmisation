using UnityEngine;

[CreateAssetMenu]
public class Sentence : ScriptableObject
{
    [field: SerializeField] public Categorie Type { get; private set; }
    [field: SerializeField] public string Content { get; private set; }
    [field: SerializeField] public float Value { get; private set; }

    public void test()
    {
        if (Content.Contains(";"))
        {
            Debug.Log(Type.ToString());
        }
    }
}
