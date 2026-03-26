namespace VMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            Car car = new Car("h","h",2000,"g",6);
            Motorcycle motorcycle=new Motorcycle("Yamaha","R6",2023,"Premium Unleaded",599);
            Truck truck = new Truck("Isuzu", "N series", 2019,3);
            car.GetInfo();
            motorcycle.GetInfo();
            truck.GetInfo();
            garage.AddVehicle(car);
            garage.AddVehicle(motorcycle);
            garage.AddVehicle(truck);
            garage.ShowAllVehicles();

        }

    }
}
