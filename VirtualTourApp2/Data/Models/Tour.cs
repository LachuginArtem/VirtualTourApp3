using System;

namespace VirtualTourApp2.Data.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!; // Необязательное поле
        public ICollection<Place> Places { get; set; } = new List<Place>();
        public string Description { get; set; } = null!; // Необязательное поле
        public int GuideId { get; set; }
        public Guide Guide { get; set; } = null!; // Навигационное свойство
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public string? ImageUrl { get; set; }
    }
}
