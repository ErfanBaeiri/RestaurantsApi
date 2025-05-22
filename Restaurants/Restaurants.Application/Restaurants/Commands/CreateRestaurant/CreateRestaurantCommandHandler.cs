using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
    {
        private readonly ILogger<CreateRestaurantCommandHandler> logger;
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IMapper mapper;

        public CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper)
        {
            this.logger = logger;
            this.restaurantsRepository = restaurantsRepository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating New restaurant");

            var restaurant = mapper.Map<Restaurant>(request);

            int id = await restaurantsRepository.Create(restaurant);

            return id;
        }
    }
}
