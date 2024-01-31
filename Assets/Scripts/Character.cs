using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI _nameText;

    [SerializeField] Image _faceImage;
    [SerializeField] Image _hatImage;
    [SerializeField] Image _clothesImage;
    [SerializeField] Image _beardImage;

    [SerializeField] TextMeshProUGUI _traitsText;
    
    public string Name { get; set; }
    public Sprite IconFace { get; set; }
    public Sprite IconHat { get; set; }
    public Sprite IconClothes { get; set; }
    public Sprite IconBeard { get; set; }
    public int Age { get; set; }
    public int Sexe { get; set; }
    [SerializeField] TextMeshProUGUI _resumeText;

    public List<Trait> Traits { get; set; }
    public List<Sentence> Sentences { get; set; }

    public void UpdateCharacter()
    {
        _nameText.text = $"{Name} ({Age})";

        updateImage(_faceImage, IconFace);
        updateImage(_clothesImage, IconClothes);
        updateImage(_hatImage, IconHat);
        updateImage(_beardImage, IconBeard);

        _traitsText.text = $"{Traits[0].Name} - {Traits[1].Name} - {Traits[2].Name}";
        _resumeText.text = $"{Sentences[0].Content}. {Sentences[1].Content}. {Sentences[2].Content}";
    }

    private void updateImage(Image img, Sprite icon)
    {
        img.sprite = icon;
        if (img.sprite == null)
        {
            img.color = new Color(0, 0, 0, 0);
        }
    }
}