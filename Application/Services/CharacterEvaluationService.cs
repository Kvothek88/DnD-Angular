using Core.Entities;
using Core.Entities.ASI;
using Core.Entities.CharacterEntities;
using Core.Entities.Features;
using Core.Entities.Prerequisites;

namespace Application.Services;

public class CharacterEvaluationService(IPrerequisiteEvaluator prerequisiteEvaluator) : ICharacterEvaluationService
{
    public IReadOnlyList<Feature> GetAllCharacterFeatures(Character character)
    {
        var features = new List<Feature>();

        //// Always-on features
        //if (character.Race.Features != null && character.Race.Features.Count > 0)
        //    features.AddRange(character.Race.Features);
        //if (character.Background.Features != null && character.Background.Features.Count > 0)
        //    features.AddRange(character.Background.Features);

        //// Class-based automatic features
        //foreach (var ca in character.ClassAdvancements)
        //{
        //    foreach (var feature in ca.Class.Features)
        //    {
        //        // Only include the feature if all its prerequisites are satisfied
        //        if (feature.Prerequisites
        //            .Where(p => p.OwnerType == PrerequisiteOwnerType.Feature && p.OwnerId == feature.Id)
        //            .All(p => prerequisiteEvaluator.IsSatisfied(character, p)))
        //        {
        //            features.Add(feature);
        //        }
        //    }
        //}

        //// Subclass-based automatic features
        //foreach (var sa in character.SubclassAdvancements)
        //{
        //    foreach (var feature in sa.Subclass.Features)
        //    {
        //        if (feature.Prerequisites
        //            .Where(p => p.OwnerType == PrerequisiteOwnerType.Feature && p.OwnerId == feature.Id)
        //            .All(p => prerequisiteEvaluator.IsSatisfied(character, p)))
        //        {
        //            features.Add(feature);
        //        }
        //    }
        //}

        //// Explicitly chosen features
        //features.AddRange(
        //    character.FeatureAdvancements.Select(fa => fa.Feature)
        //);

        //// Remove duplicates
        return [.. features.DistinctBy(f => f.Id)];
    }

    public IReadOnlyList<Feat> GetAllCharacterFeats(Character character)
    {
        var feats = new List<Feat>();

        //// Always-on feats
        //if (character.Race.Feats != null && character.Race.Feats.Count > 0)
        //    feats.AddRange(character.Race.Feats);
        //if (character.Background.Feats != null && character.Background.Feats.Count > 0)
        //    feats.AddRange(character.Background.Feats);

        //// Explicitly chosen feats
        //var chosenFeats = character.ASIAdvancements.OfType<FeatAdvancement>()
        //    .Select(a => a.Feat).ToList();

        //if (chosenFeats.Count > 0)
        //    feats.AddRange(chosenFeats);

        return [.. feats.DistinctBy(f => f.Id)];
    }


    public IReadOnlyList<GrantedProficiency> GetAllCharacterProficiencies(Character character)
    {
        List<GrantedProficiency> proficiencies = 
        [
            ..character.Race.Proficiencies,
            ..character.Background.Proficiencies,
        ];

        return proficiencies;
    }
}


