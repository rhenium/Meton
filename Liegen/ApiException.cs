using Meton.Liegen.DataModels;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Linq;

namespace Meton.Liegen
{
    public class ApiException<T> : Exception
        where T : ApiResponseBase
    {
        public T Response { get; private set; }

        public ApiException(T ApiResponse)
        {
            this.Response = ApiResponse;
        }
    }
}
