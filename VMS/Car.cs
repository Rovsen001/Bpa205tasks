using System;
using System.Collections.Generic;
using System.Text;

namespace VMS
{
    internal class Car : Vehicle
    {
        private string _fuelType;
        private sbyte _doorCount;
        public string FuelType { get { return _fuelType; } set { _fuelType = value; } }
        public sbyte DoorCount { get { return _doorCount; } set { _doorCount = value; } }
        public Car(string brand,string model,int year,string fueltype,sbyte doorcount) : base(brand,model,year)
        {
            FuelType = fueltype;
            DoorCount = doorcount;
            
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Fuel type: {FuelType}, Door count: {DoorCount}");
        }
    }
}
