using System;
using System.Collections.Generic;
using System.Text;

namespace GCS
{
    internal class PowerStrike : Skill
    {

        public override void UseSkill(Character ti)
        {
         
            ti.Health = ti.Health - 300;
        }
    }
}
