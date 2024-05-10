using CSharpFunctionalExtensions;
using Service.External.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.External.Abstraction
{
    public interface IMarketService
    {
        Task<IResult<CryptoModel, ServiceError>> GetAllAssetsAsync();
    }
}
