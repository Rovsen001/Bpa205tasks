using System;
using System.Collections.Generic;
using System.Text;

namespace GCS
{
    internal class Character
    {
        private string _name;
        private int _health;
        private double _mana;
        private int _level;
        public string Name { get { return _name; } set { if (value != null && value != "") value = _name; else Console.WriteLine("Cannot be empty!"); } }
        public int Health { get { return _health; } set { if (value >= 0) _health = value;  } }
        public double Mana { get { return _mana; } set { if (value >= 0) _mana = value; else Console.WriteLine("Mana cannot be negative!"); } }
        public int Level { get { return Level; } set { _level = value; } }
        public Character(string n,int h,double m,int l)
        {
            _name = n;
            _health = h;
            _mana = m;
            _level = l;
        }
        public virtual void Attack(Character target,Skill spell)
        {
            if (Health <= 0) Console.WriteLine("Character cannot attack, it is dead.");
            else if (target.Health <= 0) Console.WriteLine($"{target.Name} ölüdür.");
            else spell.UseSkill(target);
        }
    }
}
