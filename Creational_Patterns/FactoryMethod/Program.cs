namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory twoWheelerFactory = new TwoWheelerFactory();
            Client twoWheelerClient = new Client(twoWheelerFactory);
            Vehicle twoWheeler = twoWheelerClient.GetVehicle();
            twoWheeler.printVehicle();

            VehicleFactory fourWheelerFactory = new FourWheelerFactory();
            Client fourWheelerClient = new Client(fourWheelerFactory);
            Vehicle fourWheeler = fourWheelerClient.GetVehicle();
            fourWheeler.printVehicle();
        }
    }

    class Client
    {
        private Vehicle vehicle;
        public Client(VehicleFactory vehicleFactory)
        {
            vehicle = vehicleFactory.CreateVehicle();
        }
        public Vehicle GetVehicle()
        {
            return vehicle;
        }
    }

    // Creator: abstract class or an interface that declares the factory method.
    // Contains a method that serves as a factory for creating objects.
    // It may also contain other methods that work with the created objects.
    interface VehicleFactory
    {
        Vehicle CreateVehicle();
    }

    // Concrete Creator: Subclass that implements the factory method to create specific types of objects.
    class TwoWheelerFactory : VehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new TwoWheeler();
        }
    }

    class FourWheelerFactory : VehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            return new FourWheeler();
        }
    }


    // Product: Interface or abstract class for the objects that the factory method creates.
    abstract class Vehicle
    {
        protected Vehicle() { }
        public abstract void printVehicle();
    }

    // Concrete Product: Actual objects that the factory method creates
    // Each concrete product implements the Product interface or extends the Product abstract class.
    class TwoWheeler : Vehicle
    {
        public override void printVehicle()
        {
            Console.WriteLine("This is a two-wheeler vehicle.");
        }
    }

    class FourWheeler : Vehicle
    {
        public override void printVehicle()
        {
            Console.WriteLine("This is a four-wheeler vehicle.");
        }
    }
}
