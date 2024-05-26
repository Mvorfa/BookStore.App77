using CarStore.App.Models;

namespace CarStore.App.ViewModels
{
    public class PostCarVM
    {
        public Car Car { get; set; } = new Car();
        public List<Company> Companies { get; set; } = new List<Company>();
    }
}
