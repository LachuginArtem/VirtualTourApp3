namespace VirtualTourApp2.Data.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? ImageUrl { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; } = null!; // Навигационное свойство
    }
}
