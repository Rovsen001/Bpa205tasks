using System;
using System.Collections.Generic;
using System.Text;

namespace VMS
{
    internal class Truck : Vehicle
    {
        private int _loadCapacity;
        public int  LoadCapacity{ get { return _loadCapacity; } set { _loadCapacity = value; } }
        public Truck(string brand,string model,int year,int loadcapacity) : base(brand,model,year)
        {
            LoadCapacity = loadcapacity;
            
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Load capacity: {LoadCapacity}");
        }
    }
}
