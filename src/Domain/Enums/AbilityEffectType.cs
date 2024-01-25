using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;

public enum AbilityEffectType
{
    Radius = 0,
    Cone = 1,
    Linear = 2,
    TargetableRadius = 3,
    MeleeAffect = 4,
    MeleeTargetableRadius = 5,
}
