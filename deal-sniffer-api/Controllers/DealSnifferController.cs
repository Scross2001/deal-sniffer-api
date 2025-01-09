using Microsoft.AspNetCore.Mvc;

namespace deal_sniffer_api.Controllers;

[ApiController]
[Route("[controller]")]
public class DealSnifferController : ControllerBase
{

    private readonly ILogger<DealSnifferController> _logger;

    public DealSnifferController(ILogger<DealSnifferController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetDeals", Name = "GetDeals")]
    public IActionResult GetProducts()
    {
        var products = new[]
        {
            new { Id = 1, Name = "Laptop", Price = 999.99 },
            new { Id = 2, Name = "Phone", Price = 799.99 }
        };
        return Ok(products);
    }
}
