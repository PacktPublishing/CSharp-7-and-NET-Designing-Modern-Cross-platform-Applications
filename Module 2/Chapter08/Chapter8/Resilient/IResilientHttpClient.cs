using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserRegService.Resilient
{
    public interface IResilientHttpClient
    {
        HttpResponseMessage Get(string uri);

        HttpResponseMessage Post<T>(string uri, T item);

        HttpResponseMessage Delete(string uri);

        HttpResponseMessage Put<T>(string uri, T item);
    }
}
