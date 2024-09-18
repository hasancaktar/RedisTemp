using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace RedisTemp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RedisController(IMemoryCache memoryCache) : ControllerBase
{

    [HttpGet("GetCache")]
    public IActionResult Get(string key)
    {
      var result =  memoryCache.Get(key);
        return Ok(result);
    }
    [HttpPost("SetCache")]
    public IActionResult Set(string key, string value)
    {
      var result =  memoryCache.Set(key, value);
        return Ok(result);
    }
}

