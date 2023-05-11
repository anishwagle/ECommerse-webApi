using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_webApi.Services.Models
{
    public class Response<T>
    {
        public bool HasError { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Result { get; set; }

        public void CreateSuccess(T result)
        {
            Result = result;
            HasError = false;
            ErrorMessage = string.Empty;
        }

        public void CreateError(string errorMessage)
        {
            HasError = true;
            ErrorMessage = errorMessage;
        }
    }
}
