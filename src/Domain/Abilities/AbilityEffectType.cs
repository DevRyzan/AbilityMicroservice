using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abilities
{
    public class AbilityEffectType : Entity<Guid>
    {
       
        //you should take a reference AbilityId as a ObjectId
        public string Icon { get; set; }
        public double Duration { get; set; }
        public bool IsPositive { get; set; }
        public bool IsNegative { get; set; }




    }
}
