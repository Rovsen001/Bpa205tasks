using System;
using System.Collections.Generic;
using System.Text;

namespace VMS
{
    internal class Garage
    {
        private List<Vehicle> _item;
        public List<Vehicle> Vehicles{ get; set; }=new List<Vehicle>();
        public void AddVehicle(Vehicle v) 
        {
            Vehicles.Add(v);
        }
        public void ShowAllVehicles()
        {
            foreach (Vehicle v in Vehicles)
            {
                Console.WriteLine(v);
            }
        }
    }
}
