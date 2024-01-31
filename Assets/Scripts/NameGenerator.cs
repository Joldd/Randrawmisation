using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour
{
    readonly List<string> _maleNames = new List<string> { "Liam", "Noah", "Ethan", "Oliver", "Aiden", "Lucas", "Mason", "Elijah", "Logan", "Caleb" };
    readonly List<string> _femaleNames = new List<string> { "Emma", "Olivia", "Ava", "Isabella", "Sophia", "Mia", "Amelia", "Harper", "Evelyn", "Abigail" };

    public string Generate(int sexe)
    {
        return sexe == 0 ? _maleNames.GetRandom() : _femaleNames.GetRandom();
    }
}