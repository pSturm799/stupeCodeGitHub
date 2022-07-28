using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace ConsoleApp_WebserviceTest.xLocate
{
    public class XLocateWebservice
    {
        public static void CallWebservice()
        {
            var uri = "http://xlocate.ptv.dev.lkw-walter.com/xlocate/rs/XLocate/findAddress";

            var xLocateModelRequest = new XlocateModelRequest
                                      {
                                          options = new Option[3]
                                      };

            xLocateModelRequest.options[0] = new Option { type = "SearchOption", param = "MAX_RESULT", value = "5" };
            xLocateModelRequest.options[1] = new Option { type = "SearchOption", param = "SEARCH_FUZZY", value = "false" };
            xLocateModelRequest.options[2] = new Option { type = "SearchOption", param = "CITY_RETURNALLCITY2", value = "true" };
            xLocateModelRequest.callerContext = new Callercontext
                                                {
                                                    properties = new Property1[2]
                                                };
            xLocateModelRequest.callerContext.properties[0] = new Property1
                                                              {
                                                                  key = "CoordFormat",
                                                                  value = "OG_GEODECIMAL"
                                                              };
            xLocateModelRequest.callerContext.properties[1] = new Property1
                                                              {
                                                                  key = "Profile",
                                                                  value = "default"
                                                              };
            xLocateModelRequest.addr = new Addr
                                       {
                                           country = "DE",
                                           postCode = "",
                                           city = "Neumarkt",
                                           street = "",
                                           houseNumber = "",
                                           state = ""
                                       };


            //var inputJson = "{\"addr\": {\"country\": \"DE\",\"state\": \"\",\"postCode\": \"\",\"city\": \"Neumarkt\",\"city2\": \"\",\"street\": \"\",\"houseNumber\": \"\"},\"" +
            //                "options\": [{\"$type\": \"SearchOption\",\"param\": \"MAX_RESULT\",\"value\": \"5\"},{\"$type\": \"SearchOption\",\"param\": \"SEARCH_FUZZY\",\"value\": \"false\"}" +
            //                ",{\"$type\": \"SearchOption\",\"param\": \"CITY_RETURNALLCITY2\",\"value\": \"true\"}],\"sorting\": []," +
            //                "\"additionalFields\": [],\"callerContext\": {\"properties\": [{\"key\": \"CoordFormat\",\"value\": \"OG_GEODECIMAL\"},{\"key\": \"Profile\",\"value\": \"default\"}]}}";


            //var inputJson = JsonSerializer.Serialize(xLocateModelRequest);
            var inputJson = JsonConvert.SerializeObject(xLocateModelRequest);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(inputJson);
                }

                var response = httpWebRequest.GetResponse();

                if (string.IsNullOrEmpty(response.ToString()))
                {
                    throw new InvalidOperationException("response is null");
                }

                HttpStatusCode statusCode = ((HttpWebResponse)response).StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    using (var reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        var json = reader.ReadToEnd();

                        var responseModel = JsonConvert.DeserializeObject<XLocateResponse>(json);
                        //var responseModel = JsonSerializer.Deserialize<XLocateResponse>(json);

                        foreach (var resultlist in responseModel.resultList)
                        {
                            var longitude = resultlist.coordinates.point.x;
                            var latitude = resultlist.coordinates.point.y;
                            decimal xDecimal = Convert.ToDecimal(resultlist.coordinates.point.x);
                        }

                        Console.Write(json);
                    }
                }
            }
            catch (WebException ex)
            {
                HttpStatusCode statusCode = ((HttpWebResponse)ex.Response).StatusCode;
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


                error.AppendLine($"JSON: {inputJson}");
                Console.WriteLine(error);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}