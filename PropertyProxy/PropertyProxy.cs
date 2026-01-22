namespace PropertyProxyDemo
{
    public class Property<T> where T : new()
    {
        private T value;

        public T Value
        {
            get => value;
            set
            {
                if (Equals(this.value, value)) return;
                Console.WriteLine($"Assigning value to {value}");
                this.value = value;
            }
        }

        public Property() : this(default(T))
        {
            
        }

        public Property(T value)
        {
            this.value = value;
        }

        public static implicit operator T(Property<T> property)
        {
            return property.value;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value);
        }
    }

    public class Creature
    {
        private Property<int> agility = new Property<int>();
        public Property<int> Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var c = new Creature();
            c.Agility = 10;
            c.Agility = 20;
        }
    }
}