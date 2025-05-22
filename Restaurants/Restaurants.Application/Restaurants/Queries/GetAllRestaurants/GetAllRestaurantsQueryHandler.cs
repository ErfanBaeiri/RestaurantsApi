using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantsDto>>
    {
        public async Task<IEnumerable<RestaurantsDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All restaurants");

            var restaurants = await restaurantsRepository.GetAllAsync();

            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantsDto>>(restaurants);

            return restaurantsDtos!;
        }
    }
}
