using System.Collections.Generic;
using UnityEngine;

public class IconGenerator : MonoBehaviour
{
    [SerializeField] List<Sprite> _maleIcons;
    [SerializeField] List<Sprite> _femaleIcons;
    
    public Sprite Generate(int sexe)
    {
        return sexe == 0 ? _maleIcons.GetRandom() : _femaleIcons.GetRandom();
    }
}