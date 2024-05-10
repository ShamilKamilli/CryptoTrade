using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.External.Models
{
    public class ServiceError
    {
        public string? ErrorMessage { get; set; }

        public ServiceError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
