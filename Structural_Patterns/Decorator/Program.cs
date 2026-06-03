namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Decorator Pattern là mẫu thiết kế dùng để thêm chức năng mới cho object mà không sửa class gốc.
            // Decorator dùng để:
            // - Thêm hành vi mới cho object.
            // - Không sửa class gốc.
            // - Không tạo quá nhiều class con bằng kế thừa.
            // - Có thể kết hợp nhiều chức năng linh hoạt.

            // Tạo một ly cà phê đơn giản
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine("Coffee simple: " + "des: " + coffee.GetDescription() +", cost: " + coffee.GetCost()); // Output: Coffee
            Console.WriteLine();

            coffee = new MilkDecorator(coffee); // Thêm sữa vào cà phê
            Console.WriteLine("Coffee add milk: " + "des: " + coffee.GetDescription() +", cost: " + coffee.GetCost());
            Console.WriteLine();

            coffee = new SugarDecorator(coffee); // Thêm đường vào cà phê
            Console.WriteLine("Coffee add sugar: " + "des: " + coffee.GetDescription() +", cost: " + coffee.GetCost());
        }
    }

    // Component: Định nghĩa giao diện chung cho tất cả các đối tượng có thể được trang trí.
    interface ICoffee
    {
        String GetDescription();
        double GetCost();
    }

    // Concrete Component: Lớp cụ thể thực hiện giao diện Component, đại diện cho đối tượng gốc mà chúng ta muốn trang trí.
    class SimpleCoffee : ICoffee
    {
        public String GetDescription()
        {
            return "Coffee";
        }
        public double GetCost()
        {
            return 10;
        }
    }

    // Decorator: class bọc object gốc
    abstract class CoffeeDecorator : ICoffee
    {
        // Component được bọc bên trong Decorator.
        // Nhờ giữ ICoffee này, Decorator có thể gọi chức năng cũ rồi thêm chức năng mới.
        protected readonly ICoffee _coffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return _coffee.GetCost();
        }
    }

    // Concrete Decorator: Lớp cụ thể kế thừa CoffeeDecorator để thêm chức năng mới.

    // Decorator add milk
    class MilkDecorator : CoffeeDecorator
    {
        // Truyền object cần trang trí lên lớp cha để Decorator có thể bọc và gọi lại nó.
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override double GetCost()
        {
            return _coffee.GetCost() + 2; // Thêm 2 đơn vị chi phí cho sữa
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Milk"; // Thêm "Milk" vào mô tả
        }
    }

    // Decorator add sugar
    class SugarDecorator : CoffeeDecorator
    {
        // Truyền object cần trang trí lên lớp cha để Decorator có thể bọc và gọi lại nó.
        public SugarDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override double GetCost()
        {
            return _coffee.GetCost() + 1; // Thêm 1 đơn vị chi phí cho đường
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Sugar"; // Thêm "Sugar" vào mô tả
        }
    }
}
