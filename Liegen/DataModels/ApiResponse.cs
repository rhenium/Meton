using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reactive;

namespace Meton.Liegen.DataModels
{
    public class ApiResponse<T>
        where T : IRawApiResponse
    {
        public IObservable<T> Result { get; private set; }

        public Dictionary<string, IEnumerable<string>> ResponseHeaders { get; internal set; }

        public ApiResponse(IObservable<T> result, HttpResponseMessage message)
        {
            this.Result = result;
            this.ResponseHeaders = message.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
