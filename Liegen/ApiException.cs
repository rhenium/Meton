using Meton.Liegen.DataModels;
using Meton.Liegen.Utility;
using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Linq;

namespace Meton.Liegen
{
    public class ApiException : Exception
    {
        public ErrorMessage[] Errors { get; protected set; }

        public ApiException(ErrorMessage[] errors)
        {
            this.Errors = errors;
        }
    }
}
