using Domain.Abilities;


namespace AbilityMicroservice.Test.Mocks.FakeDatas;

public class AbilityFakeData : BaseFakeData<Ability, string>
{
    public override List<Ability> CreateFakeData()
    {
        var data = new List<Ability>
    {
        new()
        {
            Id = Guid.NewGuid().ToString(),
            HeroId = Guid.NewGuid().ToString(),
            AbilityTypeId = Guid.NewGuid().ToString(),
            TargetTypeId = Guid.NewGuid().ToString(),
            DamageTypeId = Guid.NewGuid().ToString(),
            AffectUnitId = Guid.NewGuid().ToString(),
            CastTimeTypeId = Guid.NewGuid().ToString(),
            Name = "TestName",
            Description= "Description",
            Status = true,
            IsDeleted = false,
            CastTimeTypeValue = 10,
            Cooldown = 11,
            Radius = 12,
            Damage = 13,
            IsCondition = false,
            IsTrigger = false,
            IsHaveCombo = false,
            IsTargeted = false,
            IsBlockable = false,
            IsCharging = false,
            IsHaveDisable = false,
            AbilityLevelUpgradeFrequency = 14,
            Cost = 15
        },
        new()
        {
            Id = Guid.NewGuid().ToString(),
            HeroId = Guid.NewGuid().ToString(),
            AbilityTypeId = Guid.NewGuid().ToString(),
            TargetTypeId = Guid.NewGuid().ToString(),
            DamageTypeId = Guid.NewGuid().ToString(),
            AffectUnitId = Guid.NewGuid().ToString(),
            CastTimeTypeId = Guid.NewGuid().ToString(),
            Name = "TestName",
            Description= "Description",
            Status = true,
            IsDeleted = false,
            CastTimeTypeValue = 20,
            Cooldown = 21,
            Radius = 22,
            Damage = 23,
            IsCondition = false,
            IsTrigger = false,
            IsHaveCombo = false,
            IsTargeted = false,
            IsBlockable = false,
            IsCharging = false,
            IsHaveDisable = false,
            AbilityLevelUpgradeFrequency = 24,
            Cost = 25
        }
    };
        return data;
    }
}
