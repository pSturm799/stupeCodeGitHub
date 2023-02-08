using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ConsoleApp_WebserviceTest.HttpClient
{
    public class UseHttpClient
    {
        public static void CallRestWithHttpClinet()
        {
            try
            {
                var bvdId = "'DE8350289399','AT9070138618-0002'"; //','DE8350289399'";

                var bvdUrl = "https://api.bvdinfo.com/v1/orbis/Companies/data";


                var jsonBodyString =
                    "{'WHERE':{'BvDID':['#bvdId#']},'SELECT':['NAME','ADDRESS_LINE1','COUNTRY','COUNTRY_ISO_CODE','POSTCODE','CITY','FAX',{'PHONE_NUMBER':{'LIMIT':1}},{'WEBSITE':{'LIMIT':1}},{'EMAIL':{'LIMIT':1}},{'OPRE':{'CURRENCY':'EUR','UNIT':3,'INDEXORYEAR':'0'}},'NACE2_CORE_CODE','NACE2_SECONDARY_CODE','COMPANY_CATEGORY','EMPL','VAT_NUMBER','TRADE_DESCRIPTION_EN','GUO_NAME','ISH_NAME',{'TRADE_REGISTER_NUMBER':{'LIMIT':1}},'BVD_ID_NUMBER']}";

                var jsonBody = Regex.Replace(jsonBodyString, "'#bvdId#'", bvdId);
                //var jsonBody = jsonBodyString;
                var dataBody = new StringContent(jsonBody, Encoding.UTF8, "application/json");


                using var client = new System.Net.Http.HttpClient();

                client.DefaultRequestHeaders.Add("ApiToken", "26IS8b694bbe4d96ed1180d100155d115311");
                var response = client.PostAsync(bvdUrl, dataBody).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    var attach2 = JsonConvert.DeserializeObject<BvdGetDataResponseModel>(responseString);
                    if (attach2.Data.Any())
                    {
                        var city = attach2.Data[0].CITY;
                    }
                }
                else
                {
                    var returnString = response.StatusCode;
                    throw new InvalidOperationException($"Error while xxx:{returnString}. Url: {response.RequestMessage.RequestUri}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine(httpEx.Message);
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


                Console.WriteLine(error);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}