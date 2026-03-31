using System;
using System.Collections.Generic;
using System.Text;

namespace GCS
{
    internal class Fireball : Skill
    {

        public override void UseSkill(Character t)
        {
            t.Health = t.Health - 500;
        }
    }
}
