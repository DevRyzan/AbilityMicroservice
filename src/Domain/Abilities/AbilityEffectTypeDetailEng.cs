using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abilities
{
    public class AbilityEffectTypeDetailEng

    {
        //AbilityEffectType references as a ObjectId()
        public LanguageCode LanguageCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
