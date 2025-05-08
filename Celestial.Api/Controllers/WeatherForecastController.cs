using Celestial.Data.Repositories;
using Celestial.Entities.Post;
using Microsoft.AspNetCore.Mvc;

namespace Celestial.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    #region Dependency Injection
    public WeatherForecastController(UserRepository userRepository, Repository<Category> categoryRepository)
    {
        this.userRepository = userRepository;
        this.categoryRepository = categoryRepository;
    }
    private readonly UserRepository userRepository;
    private readonly Repository<Category> categoryRepository;
    #endregion


}
