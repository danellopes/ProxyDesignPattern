public class ProxyDemo {
    public interface ICar
    {
        void drive();
    }

    public class Car implements ICar
    {
        public void drive()
        {
            System.debug('Driving a car');
        }
    }

    public class Driver
    {
        public Integer age;
        public Driver(Integer age) {
            this.age = age;
        }
    }

    public class CarProxy implements ICar
    {
        private Driver driver;
        private Car car = new Car();

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void drive()
        {
            if (driver.age >= 18)
            {
                car.drive();
            }
            else
            {
                System.debug('Driver is too young to drive');
            }
        }
    }

    public static void runDemo()
    {
        ICar car = new CarProxy(new Driver(12));
        car.drive();
    }
}