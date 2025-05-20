using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger,
        IMapper mapper) : IRestaurantsService
    {
        public async Task<int> Create(CreateRestaurantDto dto)
        {
            logger.LogInformation("Creating New restaurant");

            var restaurant = mapper.Map<Restaurant>(dto);

            int id = await restaurantsRepository.Create(restaurant);

            return id;

        }

        public async Task<IEnumerable<RestaurantsDto>> GetAllRestaurants()
        {
            logger.LogInformation("Getting All restaurants");

            var restaurants = await restaurantsRepository.GetAllAsync();

            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantsDto>>(restaurants);

            return restaurantsDtos!;
        }

        public async Task<RestaurantsDto?> GetById(int id)
        {
            logger.LogInformation($"Getting restaurant {id}");

            var restaurant = await restaurantsRepository.GetByIdAsync(id);

            var restaurantDto = mapper.Map<RestaurantsDto?>(restaurant);

            return restaurantDto;
        }
    }
}
