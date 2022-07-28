using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ConsoleApp_WebserviceTest_DownloadFileFromSharePointModel;
using Newtonsoft.Json;

namespace ConsoleApp_WebserviceTest
{
    public class SharepointHandling
    {
        public static void Run()
        {
            //CreateFolderInSharepoint();
            //UploadFileToSharepoint();
            DownloadFileFromSharepoint();
        }

        public static List<Tuple<string, Stream>> DownloadFileFromSharepoint()
        {
            var token = GetToken();

            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            string webUrl = "https://sharepoint.prm.ctx.test.lkw-walter.com";

            try
            {
                IGetWebClient clientT = new GetWebClient();
                var client = clientT.Value;

                var webRelativeUrl = "fwi_suggestion"; // Site Hinweis in Sharepoint
                var documentLibName = "_Guid"; // Folder in Sharepoint

                // 1. Get all files in document lib
                Uri endpointUri = new Uri(webUrl + "/_api/web/GetFolderByServerRelativeUrl('" + webRelativeUrl + "/" + documentLibName + "')/Files");

                byte[] data = client.DownloadData(endpointUri);
                var str = Encoding.Default.GetString(data);
                var downLoadResult = JsonConvert.DeserializeObject<DownloadFileFromSharePointModel>(str);
                
                var fileNames = new List<string>();
                
                foreach (var dResult in downLoadResult.d.results)
                {
                    fileNames.Add(dResult.Name);
                }


                var folderRelativeUrl = $"/{webRelativeUrl}/{documentLibName}";
                var fileList = new List<Tuple<string, Stream>>();
                
                foreach (var fileName in fileNames)
                {
                    var commandString = string.Format("/_api/web/GetFolderByServerRelativeUrl('{0}')/files('{1}')/$value", folderRelativeUrl, fileName);
                    Uri uri = new Uri(webUrl + commandString);

                    //Set up the HTTP Request  
                    byte[] data2 = client.DownloadData(uri);

                    Stream stream = new MemoryStream(data2);
                    if (stream.Length == 0)
                    {
                        throw new InvalidOperationException("stream length is 0");
                    }
                    
                    fileList.Add(new Tuple<string, Stream>(fileName, stream));
                    
                }

                client.Dispose();

                return fileList;
            }
            catch (WebException ex)
            {
                if (ex.Response == null)
                {
                    throw new InvalidOperationException($"Authorization failed. Message: {ex.InnerException}");
                }


                HttpStatusCode statusCode = ((HttpWebResponse) ex.Response).StatusCode;
                if (statusCode == HttpStatusCode.Unauthorized)
                {
                    throw new InvalidOperationException($"Authorization failed. Message: {ex.Message}");
                }

                var error = new StringBuilder();
                error.AppendLine("Error Response: ");
                Stream stream = null;

                try
                {
                    stream = ex.Response.GetResponseStream();
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        stream = null;
                        error.AppendLine(reader.ReadToEnd());
                    }
                }
                finally
                {
                    stream?.Dispose();
                }

                throw new InvalidOperationException($"HTTP request failed. Message: {error}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }


        public static void UploadFileToSharepoint()
        {
            try
            {
                var fileName1 = "testO_3";
                var filePath = @"C:\Temp\" + fileName1;


                byte[] byteArray = File.ReadAllBytes(filePath);

                var token = GetToken();


                if (string.IsNullOrEmpty(token))
                {
                    return;
                }


                var webClient = new WebClient
                                {
                                    Headers =
                                    {
                                        [HttpRequestHeader.Accept] = "application/json;odata=verbose",
                                        [HttpRequestHeader.ContentType] = "application/json;odata=verbose"
                                    }
                                };

                webClient.Headers.Add("X-RequestDigest", token);
                webClient.Headers.Add("Method", "POST");
                webClient.Credentials = new NetworkCredential("crm-Install", "7yEGVFwJ97sN", "LKW-Walter");

                var serverRelativeUrl = "fwi_suggestion/_Guid";

                var url =
                    $"https://sharepoint.prm.ctx.test.lkw-walter.com/_api/web/getfolderbyserverrelativeurl('{serverRelativeUrl}')/files/add(overwrite=true, url='{fileName1}')";
                var uri = new Uri(url);


                var responseBytes = webClient.UploadData(uri, "POST", byteArray);


                var response = Encoding.UTF8.GetString(responseBytes);

                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Response of UploadFileToSharePoint request was empty.");
                }
                else
                {
                    Console.WriteLine("Uploaded file");
                }
            }
            catch (WebException ex)
            {
                if (ex.Response == null)
                {
                    throw new InvalidOperationException($"Authorization failed. Message: {ex.InnerException}");
                }


                HttpStatusCode statusCode = ((HttpWebResponse) ex.Response).StatusCode;
                if (statusCode == HttpStatusCode.Unauthorized)
                {
                    throw new InvalidOperationException($"Authorization failed. Message: {ex.Message}");
                }

                var error = new StringBuilder();
                error.AppendLine("Error Response: ");
                Stream stream = null;

                try
                {
                    stream = ex.Response.GetResponseStream();
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        stream = null;
                        error.AppendLine(reader.ReadToEnd());
                    }
                }
                finally
                {
                    stream?.Dispose();
                }

                throw new InvalidOperationException($"HTTP request failed. Message: {error}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private static void CreateFolderInSharepoint()
        {
            try
            {
                var token = GetToken();


                if (string.IsNullOrEmpty(token))
                {
                    return;
                }

                var serverRelativeUrl = "fwi_suggestion/_Guid_9";
                var body = @"{ '__metadata': { 'type': 'SP.Folder'  }, 'ServerRelativeUrl': '" + serverRelativeUrl + "'}";

                string url11 = "https://sharepoint.prm.ctx.test.lkw-walter.com";

                var urlToCreateSharePointFolder = url11 + "/_api/web/folders";
                HttpWebRequest createFolderRequest =
                    (HttpWebRequest) WebRequest.Create($"{urlToCreateSharePointFolder}");


                createFolderRequest.Method = "POST";
                createFolderRequest.Accept = "application/json;odata=verbose";
                NetworkCredential cred2 = new NetworkCredential("crm-Install", "7yEGVFwJ97sN", "LKW-Walter");
                createFolderRequest.Credentials = cred2;
                createFolderRequest.ContentType = "application/json;odata=verbose";
                createFolderRequest.Headers.Add("X-RequestDigest", token);


                using (StreamWriter writer = new StreamWriter(createFolderRequest.GetRequestStream()))
                {
                    writer.Write(body);
                }

                HttpWebResponse response = (HttpWebResponse) createFolderRequest.GetResponse();
                response.Dispose();
            }
            catch (WebException ex)
            {
                if (ex.Response == null)
                {
                    throw new InvalidOperationException($"Authorization failed. Message: {ex.InnerException}");
                }


                HttpStatusCode statusCode = ((HttpWebResponse) ex.Response).StatusCode;
                if (statusCode == HttpStatusCode.Unauthorized)
                {
                    throw new InvalidOperationException($"Authorization failed. Message: {ex.Message}");
                }

                var error = new StringBuilder();
                error.AppendLine("Error Response: ");
                Stream stream = null;

                try
                {
                    stream = ex.Response.GetResponseStream();
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        stream = null;
                        error.AppendLine(reader.ReadToEnd());
                    }
                }
                finally
                {
                    stream?.Dispose();
                }


                throw new InvalidOperationException($"HTTP request failed. Message: {error}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static string GetToken()
        {
            var token = string.Empty;

            // get access token
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            string url1 = "https://sharepoint.prm.ctx.test.lkw-walter.com";
            HttpWebRequest endpointRequest =
                (HttpWebRequest) WebRequest.Create($"{url1}/_api/contextinfo");

            endpointRequest.Method = "POST";
            endpointRequest.Accept = "application/json;odata=verbose";
            NetworkCredential cred = new NetworkCredential("crm-Install", "7yEGVFwJ97sN", "LKW-Walter");
            endpointRequest.Credentials = cred;
            endpointRequest.ContentType = "application/json;odata=verbose";
            endpointRequest.ContentLength = 0;
            HttpWebResponse endpointResponse = (HttpWebResponse) endpointRequest.GetResponse();
            try
            {
                WebResponse webResponse = endpointResponse;
                Stream webStream = webResponse.GetResponseStream();
                if (webStream == null)
                {
                    return "";
                }

                var responseReader = new StreamReader(webStream);
                var response2 = responseReader.ReadToEnd();

                var tokenModel = JsonConvert.DeserializeObject<TokenModel>(response2);

                if (tokenModel != null)
                {
                    token = tokenModel.d.GetContextWebInformation.FormDigestValue;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.ReadLine();
            }

            return token;
        }
    }
}