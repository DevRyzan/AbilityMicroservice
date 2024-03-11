
namespace Application.Feature.AbilityFeatures.AbilityEnemyEffectStats.Dto;

public class UpdateAbilityEnemyEffectStatDto
{
    public string Id { get; set; }
    public string AbilityEffectStatsId { get; set; }
    public bool EnemyCrowdControl { get; set; }
    public int EnemyCrowdControlReduction { get; set; }
    public int EnemyDamageAmplification { get; set; }
    public bool EnemyDamageOverTime { get; set; }
    public int EnemyDebuffRange { get; set; }
    public int EnemyDisarmDuration { get; set; }
    public bool EnemyManaBurn { get; set; }
    public bool EnemyMovementImpairment { get; set; }
    public int EnemySilenceDuration { get; set; }
    public bool EnemySpellVampirism { get; set; }
    public int EnemyStunDuration { get; set; }
    public int EnemyVisionReduction { get; set; }
    public int? InterruptEnemyCasts { get; set; }

}
