delegate void Washing(Car car);
class Program
{
    static void Main()
    {
        Car car1 = new Car("Car1");
        Car car2 = new Car("Car2");
        Car car3 = new Car("Car3");
        List<Car> cars = new List<Car>() {car1, car2, car3};

        Garage garage = new Garage(cars);

        CarWash carWash = new CarWash();
        Washing washing = carWash.CarWashing;

        foreach (Car car in garage.Cars)
            washing(car);
    }
}

class Car
{
    public string Name { get; }
    public bool IsClean { get; set; } = false;
    public Car(string name)
    {
        Name = name;
    }
}

class Garage
{
    public List<Car> Cars { get; }
    public Garage(List<Car> cars)
    {
        Cars = cars;
    }
}
class CarWash
{
    public void CarWashing(Car car)
    {
        car.IsClean = true;
        Console.WriteLine($"Машина {car.Name} вымыта");
    }
}
