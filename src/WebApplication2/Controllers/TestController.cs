using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly WebApplication1HttpClient _webapp1Client;
    public TestController(WebApplication1HttpClient webapp1Client)
    {
        _webapp1Client = webapp1Client;
    }

    [HttpGet]
    public string Get()
    {
        return "WebApplication2 is here";
    }

    [HttpGet("web-app-1")]
    public async Task<string> GetWebApplication1()
    {
        return await _webapp1Client.GetWebApplication1Test();
    }

}