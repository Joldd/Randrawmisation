using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    const int TRAIT_COUNT = 3;

    const int PNJ_COUNT = 6;

    [SerializeField] List<Categorie> _categories;

    [SerializeField] Character _cardPrefab;

    [SerializeField] Transform _cardContainer;
    [SerializeField] TextMeshProUGUI _seedText;
    [SerializeField] TMP_InputField _seedInput;
    [SerializeField] NameGenerator _nameGenerator;
    [SerializeField] IconGenerator _iconGenerator;
    [SerializeField] ResumeGenerator _resumeGenerator;

    public void Generate()
    {
        var seed = Generate(!string.IsNullOrWhiteSpace(_seedInput.text) ? int.Parse(_seedInput.text) : -1);
        _seedText.text = $"Seed : {seed}";
    }
    
    public int Generate(int seed)
    {
        if (seed == -1)
            seed = Math.Abs(Environment.TickCount);
        
        Random.InitState(seed);
        
        Clear();
        
        for (var i = 0; i < PNJ_COUNT; i++)
        {
            var character = Instantiate(_cardPrefab, _cardContainer);
            
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

            character.IconFace = _iconGenerator.GenerateIcon(_iconGenerator._faceIcons);
            character.IconClothes = _iconGenerator.GenerateIcon(_iconGenerator._clothesIcons);
            character.IconHat = _iconGenerator.GenerateIcon(_iconGenerator._hatIcons);
            character.IconBeard = _iconGenerator.GenerateIcon(_iconGenerator._beardIcons);

            character.Age = Random.Range(17, 75);
            character.Traits = traits;
            character.Resume = _resumeGenerator.Generate(character);
            character.UpdateCharacter(); 
        }

        return seed;
    }

    void Clear()
    {
        foreach (Transform child in _cardContainer)
            Destroy(child.gameObject);
    }
}