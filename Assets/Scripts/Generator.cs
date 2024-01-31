﻿using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    const int TRAIT_COUNT = 3;

    const int PNJ_COUNT = 6;

    [SerializeField] List<Categorie> _categories;

    [SerializeField] Character _cardPrefab;

    [SerializeField] Transform _cardContainer;
    [SerializeField] NameGenerator _nameGenerator;
    [SerializeField] IconGenerator _iconGenerator;

    public void Generate()
    {
        Clear();
        
        for (var i = 0; i < PNJ_COUNT; i++)
        {
            var character = Instantiate(_cardPrefab, _cardContainer);
            
            var categoriesClone = new List<Categorie>(_categories);
            var traits = new List<Trait>();
            var sentences = new List<Sentence>();

            for (var j = 0; j < TRAIT_COUNT; j++)
            {
                if (categoriesClone.Count == 0)
                    break;
            
                var cat = categoriesClone.GetRandom();
                categoriesClone.Remove(cat);
                var trait = cat.Traits.GetRandom();
                traits.Add(trait);
                var sentence = cat.Sentences.GetRandom();
                sentences.Add(sentence);
            }

            character.Sexe = Random.Range(0, 2);
            character.Name = _nameGenerator.Generate(character.Sexe);
            character.Icon = _iconGenerator.Generate(character.Sexe);
            character.Age = Random.Range(17, 75);
            character.Traits = traits;
            character.UpdateCharacter();

            character.Sentences = sentences;
            character.UpdateResume();
        }
    }

    void Clear()
    {
        foreach (Transform child in _cardContainer)
            Destroy(child.gameObject);
    }
}