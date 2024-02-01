using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class ResumeGenerator : MonoBehaviour
{
    public List<LocalizedString> Generate(Character character)
    {
        var strings = new List<LocalizedString>();
        
        strings.Add(new LocalizedString("Age", "AGE_0") { {"character", new ObjectVariable { Value = character }}});

        return strings;
    }
}