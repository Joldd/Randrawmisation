using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] Image _iconImage;
    [SerializeField] TextMeshProUGUI _traitsText;
    
    public string Name { get; set; }
    public Sprite Icon { get; set; }
    public int Age { get; set; }
    public int Sexe { get; set; }
    public List<Trait> Traits { get; set; }

    public void UpdateCharacter()
    {
        _nameText.text = $"{Name} ({Age})";
        _iconImage.sprite = Icon;
        _traitsText.text = $"{Traits[0].Name} - {Traits[1].Name} - {Traits[2].Name}";
    }
}