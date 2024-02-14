using System.Collections.Generic;
using UnityEngine;

public class IconGenerator : MonoBehaviour
{
    [SerializeField] List<Sprite> _maleIcons;
    [SerializeField] List<Sprite> _femaleIcons;

    public List<Sprite> _faceIcons;
    public List<Sprite> _hatIcons;
    public List<Sprite> _clothesIcons;
    public List<Sprite> _beardIcons;
    public List<Sprite> _happyIcons;
    public List<Sprite> _itemIcons;

    public Sprite Generate(int sexe)
    {
        return sexe == 0 ? _maleIcons.GetRandom() : _femaleIcons.GetRandom();
    }

    public Sprite GenerateIcon(List<Sprite> icons)
    {
        return icons.GetRandom();
    }

    public void setTraitIcon(Trait trait, Character character)
    {
        if (trait.IconType == "Face")
        {
            character.IconFace = trait.Icon;
            character.faceSet = true;
        }
        else if (trait.IconType == "Hat")
        {
            character.IconHat = trait.Icon;
            character.hatSet = true;
        }
        else if(trait.IconType == "Clothes")
        {
            character.IconClothes = trait.Icon;
            character.clothesSet = true;
        }
        else if(trait.IconType == "Beard")
        {
            character.IconBeard = trait.Icon;
            character.beardSet = true;
        }
        else if (trait.IconType == "Happy")
        {
            character.IconHappy = trait.Icon;
            character.happySet = true;
        }
        else if (trait.IconType == "Item")
        {
            character.IconItem = trait.Icon;
            character.itemSet = true;
        }
    }
}