using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    const int TRAIT_COUNT = 3;

    const int PNJ_COUNT = 6;

    [SerializeField] List<Categorie> _categories;

    [SerializeField] GameObject card_PNJ;

    [SerializeField] GameObject PNJ_Group;

    [ContextMenu("Generate")]
    public void Generate()
    {
        for (var i = 0; i < PNJ_COUNT; i++)
        {
            Instantiate(card_PNJ, PNJ_Group.transform);
        }

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