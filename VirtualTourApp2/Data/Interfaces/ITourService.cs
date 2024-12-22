using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualTourApp2.Data.Models;

namespace VirtualTourApp2.Data.Interfaces
{
    public interface IGuideService
    {
        Task<IEnumerable<Guide>> GetAllGuidesAsync();
        Task<Guide?> GetGuideByIdAsync(int id);
        Task AddGuideAsync(Guide guide);
        Task UpdateGuideAsync(Guide guide);
        Task DeleteGuideAsync(int id);
    }

    public interface IPlaceService
    {
        Task<IEnumerable<Place>> GetAllPlacesAsync();
        Task<Place?> GetPlaceByIdAsync(int id);
        Task AddPlaceAsync(Place place);
        Task UpdatePlaceAsync(Place place);
        Task DeletePlaceAsync(int id);
    }

    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review?> GetReviewByIdAsync(int id);
        Task AddReviewAsync(Review review);
        Task UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(int id);
    }

    public interface ITourService
    {
        Task<IEnumerable<Tour>> GetAllToursAsync();
        Task<Tour?> GetTourByIdAsync(int id);
        Task AddTourAsync(Tour tour);
        Task UpdateTourAsync(Tour tour);
        Task DeleteTourAsync(int id);
        Task AddReviewAsync(Review review); // Добавлено для добавления отзывов
    }
}

