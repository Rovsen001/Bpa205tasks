namespace GCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Skill fireball= new Fireball();   
            Skill heal= new Heal();
            Skill powerstrike=new PowerStrike();
            Warrior warrior= new Warrior("Aatrox",-6,0,7);
            Mage mage= new Mage("Karthus",2700,1000,7);
            Archer archer= new Archer("Ashe",2500,1000,7);
            warrior.Attack(archer, powerstrike);
            
            Console.WriteLine(archer.Health);
        }
    }
}
