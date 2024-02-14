using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TraitEditUI : MonoBehaviour
{
    [SerializeField] Character _character;
    [SerializeField] List<Trait> _traits;
    [SerializeField] TMP_Dropdown _dropdown1;
    [SerializeField] TMP_Dropdown _dropdown2;
    [SerializeField] TMP_Dropdown _dropdown3;
    [SerializeField] Button _checkButton;
    
    IconGenerator _iconGenerator;

    readonly Dictionary<int, Trait> _traitsIndex = new Dictionary<int, Trait>();

    void Awake()
    {
        _iconGenerator = FindObjectOfType<IconGenerator>();
        
        for (var i = 0; i < _traits.Count; i++)
        {
            _traitsIndex.Add(i, _traits[i]);
        }

        var options = new List<TMP_Dropdown.OptionData>();

        foreach (var pair in _traitsIndex)
        {
            options.Add(new TMP_Dropdown.OptionData(pair.Value.Name));
        }
        
        _dropdown1.options = options;
        _dropdown2.options = options;
        _dropdown3.options = options;
    }

    void OnEnable()
    {
        _dropdown1.value = _traitsIndex.FirstOrDefault(x => x.Value == _character.Traits[0]).Key;
        _dropdown2.value = _traitsIndex.FirstOrDefault(x => x.Value == _character.Traits[1]).Key;
        _dropdown3.value = _traitsIndex.FirstOrDefault(x => x.Value == _character.Traits[2]).Key;
    }

    public void CheckTraits()
    {
        ChangeDropdownColor(_dropdown1, Color.white);
        ChangeDropdownColor(_dropdown2, Color.white);
        ChangeDropdownColor(_dropdown3, Color.white);
        
        var trait1 = _traitsIndex[_dropdown1.value];
        var trait2 = _traitsIndex[_dropdown2.value];
        var trait3 = _traitsIndex[_dropdown3.value];

        _checkButton.interactable = trait1 != trait2 && trait2 != trait3 && trait1.Type != trait2.Type && trait2.Type && trait3.Type;

        if (_checkButton.interactable)
            return;

        if (trait1 == trait2 || trait1.Type == trait2.Type)
        {
            ChangeDropdownColor(_dropdown1, Color.red);
            ChangeDropdownColor(_dropdown2, Color.red);
        }
        
        if (trait1 == trait3 || trait1.Type == trait3.Type)
        {
            ChangeDropdownColor(_dropdown1, Color.red);
            ChangeDropdownColor(_dropdown3, Color.red);
        }
        
        if (trait2 == trait3 || trait2.Type == trait3.Type)
        {
            ChangeDropdownColor(_dropdown2, Color.red);
            ChangeDropdownColor(_dropdown3, Color.red);
        }
    }

    public void Confirm()
    {
        _character.Traits.Clear();
        _character.Traits.Add(_traitsIndex[_dropdown1.value]);
        _character.Traits.Add(_traitsIndex[_dropdown2.value]);
        _character.Traits.Add(_traitsIndex[_dropdown3.value]);
        _character.UpdateTraits();
        _iconGenerator.setTraitIcon(_traitsIndex[_dropdown1.value], _character);
        _iconGenerator.setTraitIcon(_traitsIndex[_dropdown2.value], _character);
        _iconGenerator.setTraitIcon(_traitsIndex[_dropdown3.value], _character);
    }

    void ChangeDropdownColor(TMP_Dropdown dropdown, Color color)
    {
        var block = dropdown.colors;
        block.normalColor = color;
        block.selectedColor = new Color(color.r, color.b, color.g, 0.9f);
        dropdown.colors = block;
    }
}