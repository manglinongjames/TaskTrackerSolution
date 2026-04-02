using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.WebAPI.Controllers
{
    // Create a custom base controller class that inherits from ControllerBase and is decorated with the [ApiController] attribute. This will allow you to apply common functionality or attributes to all your controllers that inherit from this base class.
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase: ControllerBase
    {
    }
}