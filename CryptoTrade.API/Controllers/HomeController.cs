using Microsoft.AspNetCore.Mvc;
using Service.External.Abstraction;

namespace CryptoTrade.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMarketService _marketService;

        public HomeController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<string> Index()
        {
            var result = await _marketService.GetAllAssetsAsync();

            return "Ok";
        }
    }
}
