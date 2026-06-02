namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Case 1: Singleton cơ bản, không thread-safe
            Singleton instance1 = Singleton.GetInstance();
            Singleton instance2 = Singleton.GetInstance();

            Console.WriteLine(ReferenceEquals(instance1, instance2)); // True

            // Case 2: Singleton thread-safe bằng Lazy<T>
            SingletonThreadSafe safe1 = SingletonThreadSafe.GetInstance();
            SingletonThreadSafe safe2 = SingletonThreadSafe.GetInstance();

            Console.WriteLine(ReferenceEquals(safe1, safe2)); // True
        }
    }

    class Singleton
    {
        // Lưu instance duy nhất của class
        private static Singleton? _instance;

        // Chặn không cho bên ngoài new Singleton()
        private Singleton()
        {
            Console.WriteLine("Creating new instance of Singleton.");
        }

        // Điểm truy cập toàn cục để lấy instance duy nhất
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }

    class SingletonThreadSafe
    {
        // Lazy<T> tạo instance khi dùng lần đầu và mặc định thread-safe
        private static readonly Lazy<SingletonThreadSafe> _instance =
            new Lazy<SingletonThreadSafe>(() => new SingletonThreadSafe());

        // Chặn không cho bên ngoài new SingletonThreadSafe()
        private SingletonThreadSafe()
        {
            Console.WriteLine("Creating new instance of SingletonThreadSafe.");
        }

        // Trả về instance duy nhất
        public static SingletonThreadSafe GetInstance()
        {
            return _instance.Value;
        }
    }
}