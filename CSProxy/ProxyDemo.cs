namespace DesignPatterns
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Driving the car.");
        }
    }

    public class Driver
    {
        public int Age { get; set; }

        public Driver(int age)
        {
            this.Age = age;
        }
    }

    public class CarProxy : ICar
    {
        private Driver driver;
        private Car car = new Car();

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if(driver.Age >= 18)
            {
                car.Drive();
            }
            else
            {
                Console.WriteLine("too young");
            }
        }
    }

    public class Program
    {        
        static void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver(8));
            car.Drive();
        }
    }
}