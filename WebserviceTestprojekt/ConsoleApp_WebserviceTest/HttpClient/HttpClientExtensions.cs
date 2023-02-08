using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_WebserviceTest.HttpClient
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> GetWithQueryStringAsync(this System.Net.Http.HttpClient client, string uri,
                                                                              Dictionary<string, string> queryStringParams)
        {
            var url = GetUriWithQueryString(uri, queryStringParams);

            return await client.GetAsync(url);
        }

        private static string GetUriWithQueryString(string requestUri,
                                                    Dictionary<string, string> queryStringParams)
        {
            bool startingQuestionMarkAdded = false;
            var sb = new StringBuilder();
            sb.Append(requestUri);
            foreach (var parameter in queryStringParams)
            {
                if (parameter.Value == null)
                {
                    continue;
                }

                sb.Append(startingQuestionMarkAdded ? '&' : '?');
                sb.Append(parameter.Key);
                sb.Append('=');
                sb.Append(parameter.Value);
                startingQuestionMarkAdded = true;
            }

            return sb.ToString();
        }
    }
}