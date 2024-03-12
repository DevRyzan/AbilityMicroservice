

namespace Application.Feature.AbilityFeatures.AbilitySelfEffectStats.Queries.GetById;

public class GetByIdAbilitySelfEffectStatResponse
{
    public string Id { get; set; }
    public string AbilityEffectStatsId { get; set; }
    public bool AreaOfEffect { get; set; }
    public bool DamageReflection { get; set; }
    public bool DamageSoakingAbility { get; set; }
    public bool DisruptAbilityCasts { get; set; }
    public bool SelfShielding { get; set; }
    public int TauntDuration { get; set; }
    public bool TerrainCreation { get; set; }
    public int ThreatGeneration { get; set; }
    public bool Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
