using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Character : MonoBehaviour 
{
    [SerializeField] Image _faceImage;
    [SerializeField] Image _hatImage;
    [SerializeField] Image _clothesImage;
    [SerializeField] Image _beardImage;
    [SerializeField] Image _happyImage;
    [SerializeField] Image _itemImage;

    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _traitsText;
    [SerializeField] TextMeshProUGUI _resumeText;
    
    public string Name { get; set; }
    public int Age { get; set; }
    public int Sexe { get; set; } // 0 = Homme, 1 = Femme
    public Sprite IconFace { get; set; }
    public bool faceSet = false;
    public Sprite IconHat { get; set; }
    public bool hatSet = false;
    public Sprite IconClothes { get; set; }
    public bool clothesSet = false;
    public Sprite IconBeard { get; set; }
    public bool beardSet = false;
    public Sprite IconHappy { get; set; }
    public bool happySet = false;
    public Sprite IconItem { get; set; }
    public bool itemSet = false;

    public List<Trait> Traits { get; set; }
    public List<LocalizedString> Resume { get; set; }

    public void UpdateCharacter()
    {
        _nameText.text = $"{Name} ({Age})";

        UpdateImage(_faceImage, IconFace);
        UpdateImage(_clothesImage, IconClothes);
        UpdateImage(_hatImage, IconHat);
        UpdateImage(_beardImage, IconBeard);
        UpdateImage(_happyImage, IconHappy);
        UpdateImage(_itemImage, IconItem);

        _traitsText.text = string.Join(" - ", Traits.Select(trait => trait.Name));
        _resumeText.text = string.Join("\n\n", Resume.Select(strings => strings.GetLocalizedString()));
    }

    void UpdateImage(Image img, Sprite icon)
    {
        img.sprite = icon;
        if (img.sprite == null)
        {
            img.color = new Color(0, 0, 0, 0);
        }
    }
}