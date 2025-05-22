using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantsDto?>
    {
        public async Task<RestaurantsDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting restaurant {request.Id}");

            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

            var restaurantDto = mapper.Map<RestaurantsDto?>(restaurant);

            return restaurantDto;
        }
    }
}
