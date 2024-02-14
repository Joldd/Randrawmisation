using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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

    public void updatePhysique(Trait trait, Character character)
    {
        if (trait.Type.name == "Physique")
        {
            switch (trait.Name)
            {
                case "Gros":
                    character.totalImage.transform.localScale = new Vector3(1.3f, 1, 1);
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
}