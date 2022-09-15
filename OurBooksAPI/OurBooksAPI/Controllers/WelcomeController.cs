using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; // 👈 new code

namespace OurBooksAPI.Controllers;

public class WelcomeController : ControllerBase {
    private readonly ILogger<Controller> _logger;

    public WelcomeController(ILogger<Controller> logger)
    {
        _logger = logger;
    }

    /* enables the authorization check on the welcome view so that only 
    authenticated users can access it */
    [Authorize] // 👈 new code
    public IActionResult Index()
    {
        return View();
    }
}