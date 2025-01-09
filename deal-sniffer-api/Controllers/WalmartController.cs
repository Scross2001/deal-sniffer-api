using Microsoft.AspNetCore.Mvc;
using deal_sniffer_api.Services;

namespace deal_sniffer_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalmartController : ControllerBase
    {
        private readonly WalmartScraperService _scraperService;

        public WalmartController()
        {
            _scraperService = new WalmartScraperService();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Query cannot be empty.");
            }

            var results = await _scraperService.ScrapeProductTitles(query);

            if (results.Count == 0)
            {
                return NotFound("No products found.");
            }

            return Ok(results);
        }
    }
}
