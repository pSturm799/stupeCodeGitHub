using System.Net;

namespace ConsoleApp_WebserviceTest
{
    /// <summary>
    ///     <inheritdoc cref="IGetWebClient" />
    /// </summary>
    public class GetWebClient : IGetWebClient
    {
        public WebClient Value
        {
            get
            {
                var token = SharepointHandling.GetToken();

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                WebClient client = new WebClient();

                NetworkCredential cred2 = new NetworkCredential("crm-Install", "7yEGVFwJ97sN", "LKW-Walter");
                client.Credentials = cred2;
                client.Headers.Add("Accept", "application/json;odata=verbose");
                client.Headers.Add("ContentType", "application/json;odata=verbose");
                client.Headers.Add("X-RequestDigest", token);
                return client;
            }
        }
    }
}