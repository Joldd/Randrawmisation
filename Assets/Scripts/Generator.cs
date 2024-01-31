using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    const int TRAIT_COUNT = 3;
    
    [SerializeField] List<Categorie> _categories;

    [ContextMenu("Generate")]
    public void Generate()
    {
        var categoriesClone = new List<Categorie>(_categories);
        var traits = new List<Trait>();
        
        for (var i = 0; i < TRAIT_COUNT; i++)
        {
            if (categoriesClone.Count == 0)
                break;
            
            var cat = categoriesClone.GetRandom();
            categoriesClone.Remove(cat);
            traits.Add(cat.Traits.GetRandom());
        }

        Debug.Log(traits.ToDisplayString());
    }
}