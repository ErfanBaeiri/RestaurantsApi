﻿using Restaurants.Application.Dishes;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public List<DishDto> Dishes { get; set; } = new();

        //public static RestaurantsDto? FromEntity(Restaurant? restaurant)
        //{
        //    if (restaurant == null) return null;
        //    return new RestaurantsDto
        //    {
        //        Category = restaurant.Category,
        //        Description = restaurant.Description,
        //        Id = restaurant.Id,
        //        HasDelivery = restaurant.HasDelivery,
        //        Name = restaurant.Name,
        //        City = restaurant.Address?.City,
        //        Street = restaurant.Address?.Street,
        //        PostalCode = restaurant.Address?.PostalCode,
        //        Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList()
        //    };
        //}
    }

}
