﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRstaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository,IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating restaurant with id : {request.Id}");
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
                return false;

            mapper.Map(request, restaurant);

            //restaurant.Name = request.Name;
            //restaurant.Description = request.Description;
            //restaurant.HasDelivery = request.HasDelivery;

            await restaurantsRepository.SaveChange();

            return true;

        }
    }
}
