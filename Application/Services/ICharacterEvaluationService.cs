using Core.Entities;
using Core.Entities.ASI;
using Core.Entities.CharacterEntities;
using Core.Entities.Features;

namespace Application.Services;

public interface ICharacterEvaluationService
{
    IReadOnlyList<Feature> GetAllCharacterFeatures(Character character);
    IReadOnlyList<Feat> GetAllCharacterFeats(Character character);
    IReadOnlyList<GrantedProficiency> GetAllCharacterProficiencies(Character character);
}
