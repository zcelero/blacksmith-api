using Microsoft.AspNetCore.Mvc;

namespace BlacksmithAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet(Name = "GetOrder")]
    public Order Get()
    {
        return new Order(){ Date = DateTime.Now };
    }
}
