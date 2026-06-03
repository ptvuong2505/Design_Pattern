namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Adapter Pattern là mẫu thiết kế dùng để chuyển đổi interface của một class có sẵn thành interface khác mà client mong muốn.
            //Adapter Pattern dùng để:
            // - Giúp các class không tương thích interface vẫn làm việc được với nhau.
            // - Tái sử dụng class cũ mà không cần sửa code class cũ.
            // - Tách client khỏi class cụ thể bên trong.
            // - Làm hệ thống dễ mở rộng, dễ thay thế hơn.

            // Client chỉ biết Printer, không cần biết LegacyPrinter
            Printer printer = new PrinterAdapter(new LegacyPrinter());
            printer.print();
        }
    }

    // Adaptee: class cũ, interface không phù hợp với hệ thống mới
    class LegacyPrinter
    {
        public void printDocument()
        {
            Console.WriteLine("Legacy Printer is printing a document.");
        }
    }

    // Target: interface mà client muốn dùng
    interface Printer
    {
        void print();
    }

    // Adapter: chuyển print() sang printDocument()
    class PrinterAdapter : Printer
    {
        private readonly LegacyPrinter _legacyPrinter;

        public PrinterAdapter(LegacyPrinter legacyPrinter)
        {
            _legacyPrinter = legacyPrinter;
        }

        public void print()
        {
            _legacyPrinter.printDocument();
        }
    }
}