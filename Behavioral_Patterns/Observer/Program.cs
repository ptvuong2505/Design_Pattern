namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();
            
            Observer phoneDisplay = new PhoneDisplay();
            Observer tvDisplay = new TVDisplay();

            weatherStation.addObserver(phoneDisplay);
            weatherStation.addObserver(tvDisplay);

            weatherStation.setWeather("Sunny");
            ((PhoneDisplay)phoneDisplay).display();
            ((TVDisplay)tvDisplay).display();

            weatherStation.setWeather("Rainy");
            ((PhoneDisplay)phoneDisplay).display();
            ((TVDisplay)tvDisplay).display();
        }

        // Interface Observer: định nghĩa phương thức update() mà các observer phải triển khai.
        public interface Observer
        {
            void update(String weather);
        }

        // Interface Subject: định nghĩa các phương thức để quản lý observer và thông báo cho chúng khi có thay đổi.
        public interface Subject
        {
            void addObserver(Observer observer);
            void removeObserver(Observer observer);
            void notifyObservers();
        }

        // Concrete Subject: triển khai interface Subject, giữ danh sách các observer và thông báo cho chúng khi có thay đổi
        class WeatherStation : Subject
        {
            private List<Observer> observers = new();
            private String weather = "";
            public void addObserver(Observer observer)
            {
                observers.Add(observer);
            }

            public void notifyObservers()
            {
                foreach (Observer observer in observers)
                {
                    observer.update(weather);
                }
            }

            public void removeObserver(Observer observer)
            {
                observers.Remove(observer);
            }

            public void setWeather(String newWeather)
            {
                this.weather = newWeather;
                notifyObservers();
            }
        }

        class PhoneDisplay : Observer
        {
            private String? weather;
            public void update(string weather)
            {
                this.weather = weather;
            }
            public void display()
            {
                Console.WriteLine("Phone Display: updated - " + weather);
            }
        }

        public class TVDisplay : Observer
        {
            private String? weather;
            public void update(string weather)
            {
                this.weather = weather;
            }
            public void display()
            {
                Console.WriteLine("TV Display: updated - " + weather);
            }
        }
    }
}
