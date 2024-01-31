using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI _traitsText;
    
    public List<Trait> Traits { get; set; }

    public void UpdateTraits()
    {
        _traitsText.text = $"{Traits[0].Name} - {Traits[1].Name} - {Traits[2].Name}";
    }
}