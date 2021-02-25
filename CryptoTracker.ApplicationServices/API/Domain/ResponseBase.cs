using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.ApplicationServices.API.Domain
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }
    }
}
