namespace CarStore.App.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        //Relationships
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
