using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using Random = UnityEngine.Random;

public class ResumeGenerator : MonoBehaviour
{
    public List<LocalizedString> Generate(Character character, List<Character> others)
    {
        var strings = new List<LocalizedString>();

        foreach (var trait in character.Traits)
        {
            strings.Add(GetString(trait, character, others.GetRandom(), (character , trait) =>
            {
                if (!character.Traits.Contains(trait))
                    return (new LocalizedString(), 0);

                var t = character.Traits.First(t => t == trait);
                return (new LocalizedString(t.name, "NAME") { { "sexe", new BoolVariable { Value = character.Sexe == 0 } } }, t.Value);
            }));
        }
        
        return strings;
    }

    LocalizedString GetString(Trait trait, Character character, Character other, Func<Character, Trait, (LocalizedString name, float value)> getTrait)
    {
        var charTrait = getTrait(character, trait);
        var otherTrait = getTrait(other, trait);
        
        return new LocalizedString(trait.Type.name, $"{trait.Type.name.ToUpper()}_0")
        {
            { "character", new ObjectVariable { Value = character } },
            { "other", new ObjectVariable { Value = other } },
            { "characterTrait", charTrait.name },
            { "otherTrait", otherTrait.name },
            { "characterValue", new FloatVariable { Value = charTrait.value } },
            { "otherValue", new FloatVariable { Value = otherTrait.value } },
            { "randomValue", new IntVariable { Value = Random.Range(0, 3) } },
        };
    }
}