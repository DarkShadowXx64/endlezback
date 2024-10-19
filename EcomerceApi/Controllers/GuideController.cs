using Microsoft.AspNetCore.Mvc;

namespace EcomerceApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuideController : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://seller.pakke.mx/api/v1/Shipments");
        var content = await response.Content.ReadAsStringAsync();
        return Ok(content);
    }
}