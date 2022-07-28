using System;
using System.IO;
using System.Net;
using System.Text;
using ConsoleApp_WebserviceTest.Models.AddAttachmentResponse;
using Newtonsoft.Json;

namespace ConsoleApp_WebserviceTest
{
    public class CallWebserviceWithMultipartFormDataContentType
    {
        public static void CallWebservice()
        {
            var uriZdom = "http://lkww-ds-app-zdom-engine.zdom.test.lkw-walter.com/lkww-ds-app-zdom-engine/api/zdom/attachments";

            var userName = "admin-test";
            var password = "a1ms75ku";

            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{userName}:{password}"));


            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");


            try
            {
                //var file = @"C:\Temp\Af1.jpeg";
                //var fileBytes = new byte[0]; //File.ReadAllBytes(file);

                var streamList = SharepointHandling.DownloadFileFromSharepoint();
                foreach (var stream in streamList)
                {
                    var fileStream = stream.Item2;
                    var fileName = stream.Item1;

                    var fileInfo = new FileInfo(fileName);
                    var extn = fileInfo.Extension.TrimStart('.');
                    var contentType = "application/octet-stream";
                    if (extn.Equals("txt"))
                    {
                        contentType = "txt/plain";
                    }

                    if (extn.Equals("jpeg") || extn.Equals("jpg"))
                    {
                        contentType = "image/jpeg";
                    }

                    if (extn.Equals("pdf"))
                    {
                        contentType = "application/pdf";
                    }


                    HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uriZdom);
                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    request.Method = "POST";
                    request.KeepAlive = true;
                    request.Headers.Add("Authorization", $"Basic {encoded}");
                    request.Headers.Add("X-TS", "2020-11-25T14:07:00Z");
                    request.Headers.Add("X-TId", "44444");
                    request.CachePolicy = HttpWebRequest.DefaultCachePolicy;
                    byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");


                    using (Stream requestStream = request.GetRequestStream())
                    {
                        {
                            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                            {
                                // FormFile file = pair.Value as FormFile;
                                string header = "Content-Disposition: form-data; name=\"attachment\"; filename=\"" + fileName + "\"\r\nContent-Type: " + contentType +
                                                "\r\n\r\n";
                                byte[] bytes = Encoding.UTF8.GetBytes(header);
                                requestStream.Write(bytes, 0, bytes.Length);
                                byte[] buffer = new byte[32768];
                                int bytesRead;

                                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                                {
                                    requestStream.Write(buffer, 0, bytesRead);
                                }
                            }
                        }

                        byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                        requestStream.Write(trailer, 0, trailer.Length);
                        requestStream.Close();
                    }

                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                var x = reader.ReadToEnd();
                                var attach2 = JsonConvert.DeserializeObject<AddAttachmentResponse>(x);

                                var id2 = attach2.attachmentId; //{"attachmentId":"5acc8d74-1091-4e4b-b4ba-c896a853fa0f"}
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
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


                Console.WriteLine(error);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}