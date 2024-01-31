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

    public Sprite Generate(int sexe)
    {
        return sexe == 0 ? _maleIcons.GetRandom() : _femaleIcons.GetRandom();
    }

    public Sprite GenerateIcon(List<Sprite> icons)
    {
        return icons.GetRandom();
    }
}