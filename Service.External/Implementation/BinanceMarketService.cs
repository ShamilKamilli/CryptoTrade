using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using Service.External.Abstraction;
using Service.External.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.External.Implementation
{
    public class BinanceMarketService : IMarketService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BinanceMarketService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory; 
        }

        public async Task<IResult<CryptoModel, ServiceError>> GetAllAssetsAsync()
        {
            using (var client = _httpClientFactory.CreateClient("binanceApiCient"))
            {
               var result = await client.GetAsync("/api/v3/exchangeInfo");

                if (!result.IsSuccessStatusCode)
                {
                    return Result.Failure<CryptoModel, ServiceError>(new ServiceError($"GetAllAssetsAsync returned error.statusCode:{result.StatusCode}"));
                }

                var resultString = await result.Content.ReadAsStringAsync();

                var cryptoModel = JsonSerializer.Deserialize<CryptoModel>(resultString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                    IgnoreNullValues = true
                });

                if(cryptoModel == null)
                {
                    return Result.Failure<CryptoModel, ServiceError>(new ServiceError($"GetAllAssetsAsync returned null.statusCode:{result.StatusCode}"));
                }

                return Result.Success<CryptoModel, ServiceError>(cryptoModel);
            }
        }

    }
}
