using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace VMS
{
    internal class Vehicle
    {
        private string _brand;
        private string _model;
        private int _year;
        public string Brand { get { return _brand; } set { _brand = value; } }
        public string Model { get { return _model; } set { _model = value; } }
        public int Year
        {
            get { return _year; }
            set
            {
                if (_year > 1900) _year = value;
                else if (_year<1900)Console.WriteLine("Year cannnot be lower than 1900!");
            }
        }
     
        public Vehicle(string brand, string model, int year)
        {
            Console.WriteLine("Brand:");
            _brand = Console.ReadLine();
            Console.WriteLine("Model:");
            _model = Console.ReadLine();
            Console.WriteLine("Year:");
            _year = int.Parse(Console.ReadLine());
        }
        public virtual void GetInfo()
        {
            Console.Write($"Brand: {Brand}, Model: {Model}, Year:{Year}, ");
        }
    }
}
