using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace RedisTemp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RedisController(IMemoryCache memoryCache, IDistributedCache distributedCache) : ControllerBase
{

    [HttpGet("MemoryGetCache")]
    public IActionResult Get(string key)
    {
        var result = memoryCache.Get(key);
        return Ok(result);
    }

    [HttpPost("MemorySetCache")]
    public IActionResult Set(string key, string value)
    {
        var result = memoryCache.Set(key, value);
        return Ok(result);
    }

    [HttpPost("MmeorySetDate")]
    public IActionResult SetDate()
    {
        var result = memoryCache.Set("tarih", DateTime.Now, new MemoryCacheEntryOptions()
        {
            //bellekte kaç saniye kalacağını tutuyor
            AbsoluteExpiration = DateTime.Now.AddSeconds(30),
            //bellekteki veride kaç saniye işlem yapılmazsa silineceğini ayarlar
            SlidingExpiration = TimeSpan.FromSeconds(5)
        });
        return Ok(result);
    }

    [HttpGet("MemoryGetDate")]
    public IActionResult GetDate()
    {
        var result = memoryCache.Get("tarih");
        return Ok(result);
    }

    [HttpPost("RedisSetData")]
    public async Task<IActionResult> SetData(string name, string surname)
    {
        await distributedCache.SetStringAsync("ad", name, new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(30),
            SlidingExpiration = TimeSpan.FromSeconds(5)
        });
        await distributedCache.SetAsync("soyad", Encoding.UTF8.GetBytes(surname), new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(30),
            SlidingExpiration = TimeSpan.FromSeconds(5)
        });//binary olarak cache'e eklendi
        return Ok(new
        {
            message = "Eklendi"
        });
    }

    [HttpGet("RedisGetData")]
    public async Task<IActionResult> GetData()
    {
        var name = await distributedCache.GetStringAsync("ad");
        var surnameBinary = await distributedCache.GetAsync("soyad");
        var surname = string.Empty;
        if (surnameBinary != null)
        {
            surname = Encoding.UTF8.GetString(surnameBinary);

        }

        return Ok(new
        {
            Name = name,
            Surname = surname
        });
    }
}

