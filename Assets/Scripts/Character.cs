using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Character : MonoBehaviour 
{
    public GameObject totalImage;

    [SerializeField] Image _faceImage;
    [SerializeField] Image _hatImage;
    [SerializeField] Image _clothesImage;
    [SerializeField] Image _beardImage;
    [SerializeField] Image _happyImage;
    [SerializeField] Image _itemImage;

    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _traitsText;
    [SerializeField] TextMeshProUGUI _resumeText;
    
    Sprite _iconFace;
    Sprite _iconHat;
    Sprite _iconClothes;
    Sprite _iconBeard;
    Sprite _iconHappy;
    Sprite _iconItem;
    
    public string Name { get; set; }
    public int Age { get; set; }
    public int Sexe { get; set; } // 0 = Homme, 1 = Femme

    public bool faceSet;
    public bool hatSet;
    public bool clothesSet;
    public bool beardSet;
    public bool happySet;
    public bool itemSet;

    public Sprite IconFace
    {
        get => _iconFace;
        set
        {
            _iconFace = value;
            UpdateImage(_faceImage, IconFace);
        }
    }

    public Sprite IconHat
    {
        get => _iconHat;
        set
        {
            _iconHat = value;
            UpdateImage(_hatImage, IconHat);
        }
    }

    public Sprite IconClothes
    {
        get => _iconClothes;
        set
        {
            _iconClothes = value;
            UpdateImage(_clothesImage, IconClothes);
        }
    }

    public Sprite IconBeard
    {
        get => _iconBeard;
        set
        {
            _iconBeard = value;
            UpdateImage(_beardImage, IconBeard);
        }
    }

    public Sprite IconHappy
    {
        get => _iconHappy;
        set
        {
            _iconHappy = value;
            UpdateImage(_happyImage, IconHappy);
        }
    }

    public Sprite IconItem
    {
        get => _iconItem;
        set
        {
            _iconItem = value;
            UpdateImage(_itemImage, IconItem);
        }
    }

    public List<Trait> Traits { get; set; }
    public List<LocalizedString> Resume { get; set; }

    public void UpdateCharacter()
    {
        _nameText.text = $"{Name} ({Age} ans)";
        UpdateTraits();
        _resumeText.text = string.Join("\n", Resume.Select(strings => strings.GetLocalizedString()));
    }

    public void UpdateTraits()
    {
        _traitsText.text = string.Join("\n", Traits.Select(trait => trait.Name));
    }

    public void UpdateImage(Image img, Sprite icon)
    {
        img.sprite = icon;
        if (img.sprite == null)
        {
            img.color = new Color(0, 0, 0, 0);
        }
    }
}