using CarStore.App.Models;

namespace CarStore.App.ViewModels
{
    public class GetCarVM
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string URLimg { get; set; }

        public Company Company{ get; set; }

    }
}
