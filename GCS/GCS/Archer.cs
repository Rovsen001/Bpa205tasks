using System;
using System.Collections.Generic;
using System.Text;

namespace GCS
{
    internal class Archer : Character
    {
        public Archer(string name,int health,double mana,int level) : base(name,health,mana,level)
        {
           
        }
        public override void Attack(Character target, Skill spell)
        {
            base.Attack(target, spell);

        }
    }
}
