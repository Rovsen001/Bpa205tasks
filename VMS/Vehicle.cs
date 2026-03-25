using System;
using System.Collections.Generic;
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
                else Console.WriteLine("Year cannnot be lower than 1900!");
            }
        }
        public Vehicle(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year:{Year}.");
        }
    }
}
