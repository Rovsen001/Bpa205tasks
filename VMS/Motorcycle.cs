using System;
using System.Collections.Generic;
using System.Text;

namespace VMS
{
    internal class Motorcycle : Vehicle
    {
        private string _fuelType;
        private float _engineSize;
        public string FuelType { get { return _fuelType; } set { _fuelType = value; } }
        public float EngineSize { get { return _engineSize; } set { _engineSize = value; } }
   
        public Motorcycle(string brand,string model,int year,string fueltype,float enginesize) : base(brand,model,year)
        {
            Console.WriteLine("Fuel type:");
            _fuelType = Console.ReadLine();
            Console.WriteLine("Engine size:");
            _engineSize = float.Parse(Console.ReadLine());
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Fuel type: {FuelType}, Engine size: {EngineSize}");
        }
    }
}
