using System;
using System.Collections.Generic;
using System.Linq;
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

    List<Character> _characters = new List<Character>();

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
            _characters.Add(character);
        }

        foreach (var character in _characters)
        {
            character.Resume = _resumeGenerator.Generate(character, _characters.Except(_characters.Where(c => c == character)).ToList());
            character.UpdateCharacter(); 
        }

        return seed;
    }

    void Clear()
    {
        _characters.Clear();
        foreach (Transform child in _cardContainer)
            Destroy(child.gameObject);
    }
}