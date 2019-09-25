namespace Domain.Models
{
    public class Car
    {
        public string RegNo { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
        public float Tax { get; set; }

        public Car(string regNo)
        {
            RegNo = regNo;
        }
    }
}
