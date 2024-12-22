namespace VirtualTourApp2.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!; // Необязательное поле
        public string Comment { get; set; } = null!; // Необязательное поле
        public int Rating { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; } = null!; // Навигационное свойство
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
