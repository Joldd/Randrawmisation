using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    const int TRAIT_COUNT = 3;

    const int PNJ_COUNT = 6;

    [SerializeField] List<Categorie> _categories;

    [SerializeField] GameObject PNJ_Group;
    [SerializeField] Character card_PNJ;

    [SerializeField] NameGenerator _nameGenerator;

    [ContextMenu("Generate")]
    public void Generate()
    {
        for (var i = 0; i < PNJ_COUNT; i++)
        {
            var character = Instantiate(card_PNJ, PNJ_Group.transform);
            
            var categoriesClone = new List<Categorie>(_categories);
            var traits = new List<Trait>();
        
            for (var j = 0; j < TRAIT_COUNT; j++)
            {
                if (categoriesClone.Count == 0)
                    break;
            
                var cat = categoriesClone.GetRandom();
                categoriesClone.Remove(cat);
                traits.Add(cat.Traits.GetRandom());
            }

            character.Sexe = Random.Range(0, 2);
            character.Name = _nameGenerator.Generate(character.Sexe);
            character.Age = Random.Range(17, 75);
            character.Traits = traits;
            character.UpdateCharacter();
        }
    }
}