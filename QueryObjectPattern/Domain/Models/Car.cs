namespace Domain.Models
{
    public class Car
    {
        public string RegNo { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
        public float Tax { get; private set; }

        public Car(string regNo, string brand, string model, int year)
        {
            RegNo = regNo;
            Brand = brand;
            Model = model;
            Year = year;
        }
    }
}
