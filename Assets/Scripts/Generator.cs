using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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

    [SerializeField] GameObject title;

    public void Generate()
    {
        var seed = Generate(!string.IsNullOrWhiteSpace(_seedInput.text) ? int.Parse(_seedInput.text) : -1);
        _seedText.text = $"Seed : {seed}";
        title.SetActive(false);
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

                var trait = cat.Traits.GetRandom();
                traits.Add(trait);
                _iconGenerator.setTraitIcon(trait, character);

                if (trait.Type.name == "Physique")
                {
                    switch (trait.Name)
                    {
                        case "Gros":
                            character.totalImage.transform.localScale = new Vector3(1.3f,1,1);
                            break;
                        case "Maigre":
                            character.totalImage.transform.localScale = new Vector3(0.8f, 1, 1);
                            break;
                        case "Grand":
                            character.totalImage.transform.localScale = new Vector3(1, 1.2f, 1);
                            break;
                        case "Petit":
                            character.totalImage.transform.localScale = new Vector3(1, 0.7f, 1);
                            break;
                        case "Trapu":
                            character.totalImage.transform.localScale = new Vector3(1.2f, 0.8f, 1);
                            break;
                        default:
                            break;
                    }
                }
            }

            character.Sexe = Random.Range(0, 2);
            character.Name = _nameGenerator.Generate(character.Sexe);

            if (!character.faceSet) character.IconFace = _iconGenerator.GenerateIcon(_iconGenerator._faceIcons);
            if (!character.clothesSet) character.IconClothes = _iconGenerator.GenerateIcon(_iconGenerator._clothesIcons);
            if (!character.hatSet) character.IconHat = _iconGenerator.GenerateIcon(_iconGenerator._hatIcons);
            if (!character.beardSet) character.IconBeard = _iconGenerator.GenerateIcon(_iconGenerator._beardIcons);
            if (!character.happySet) character.IconHappy = _iconGenerator.GenerateIcon(_iconGenerator._happyIcons);
            if (!character.itemSet) character.IconItem = _iconGenerator.GenerateIcon(_iconGenerator._itemIcons);

            character.Age = Random.Range(17, 75);
            
            if(character.Sexe == 1)
            {
                character.IconBeard = null;
            }

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