using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRstaurant
{
    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(c => c.Name)
            .Length(3, 100);
        }
    }
}
