using System.Collections.Generic;
using UnityEngine;

public class IconGenerator : MonoBehaviour
{
    public List<Sprite> _faceIcons;
    public List<Sprite> _hatIcons;
    public List<Sprite> _clothesIcons;
    public List<Sprite> _beardIcons;
    public List<Sprite> _happyIcons;
    public List<Sprite> _itemIcons;

    public Sprite GenerateIcon(List<Sprite> icons)
    {
        return icons.GetRandom();
    }

    public void setTraitIcon(Trait trait, Character character)
    {
        if (_faceIcons.Contains(trait.Icon))
        {
            character.IconFace = trait.Icon;
            character.faceSet = true;
        }
        else if (_hatIcons.Contains(trait.Icon))
        {
            character.IconHat = trait.Icon;
            character.hatSet = true;
        }
        else if(_clothesIcons.Contains(trait.Icon))
        {
            character.IconClothes = trait.Icon;
            character.clothesSet = true;
        }
        else if(_beardIcons.Contains(trait.Icon))
        {
            character.IconBeard = trait.Icon;
            character.beardSet = true;
        }
        else if (_happyIcons.Contains(trait.Icon))
        {
            character.IconHappy = trait.Icon;
            character.happySet = true;
        }
        else if (_itemIcons.Contains(trait.Icon))
        {
            character.IconItem = trait.Icon;
            character.itemSet = true;
        }
    }
}