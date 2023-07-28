using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleApp_WebserviceTest.HttpClient.Models;
using Newtonsoft.Json;

namespace ConsoleApp_WebserviceTest.HttpClient
{
    public class UseHttpClientFactory
    {
        public static void CallRestWithHttpClinet()
        {
            //CallBvdById();
            CallBvdByAddress();
        }


        private static void CallBvdById()
        {
            try
            {
                var bvdId = "'AT9070138618-0002'"; //"'DE8350289399','AT9070138618-0002'"; //','DE8350289399'";

                var bvdUrl = "https://api.bvdinfo.com/v1/orbis/Companies/data";


                var jsonBodyString =
                    "{'WHERE':{'BvDID':['#bvdId#']},'SELECT':['NAME','ADDRESS_LINE1','ADDRESS_LINE2','COUNTRY','COUNTRY_ISO_CODE','POSTCODE','CITY','FAX','NACE2_CORE_CODE','NACE2_SECONDARY_CODE','COMPANY_CATEGORY','EMPL','VAT_NUMBER','TRADE_DESCRIPTION_EN','GUO_NAME','ISH_NAME','BVD_ID_NUMBER',{'PHONE_NUMBER':{'LIMIT':1}},{'WEBSITE':{'LIMIT':1}},{'EMAIL':{'LIMIT':1}},{'OPRE':{'CURRENCY':'EUR','UNIT':3,'INDEXORYEAR':'0'}},{'TRADE_REGISTER_NUMBER':{'LIMIT':1}}]}";

                var jsonBody = Regex.Replace(jsonBodyString, "'#bvdId#'", bvdId);
                //var jsonBody = jsonBodyString;
                var dataBody = new StringContent(jsonBody, Encoding.UTF8, "application/json");


                using var client = new System.Net.Http.HttpClient();

                client.DefaultRequestHeaders.Add("ApiToken", "26IS8b694bbe4d96ed1180d100155d115311");
                var response = client.PostAsync(bvdUrl, dataBody).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<BvdGetDataResponseModel>(responseString);
                    if (result != null && result.SearchSummary.TotalRecordsFound > 0 && result.Data.Any())
                    {
                        var x = result.Data.ToList();
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

        private static void CallBvdByAddress()
        {
            try
            {
                var bvdUrl = "https://api.bvdinfo.com/v1/orbis/Companies/data?Query=";

                var name = "Cosmo Consult";
                var country = "DE";
                var city = "";
                var postCode = "";
                var address = ""; //"1,BowermanDrive";
                string scoreLimit = "0.85";
                int max = 3;
                int offset = 0;
                var jsonBodyString =
                    "{'WHERE': [ {'MATCH':{'Criteria':{'Name':'#name#','Country':'#country#','City':'#city#','Postcode':'#postCode#','Address':'#address#'},'Options': {'ScoreLimit': #scoreLimit#}}}],'SELECT':['Match.Hint','Match.Score','Match.Name','Match.Name_Local','Match.MatchedName','Match.MatchedName_Type','Match.Address','Match.Postcode','Match.City','Match.Country','Match.Address_Type','Match.PhoneOrFax','Match.EmailOrWebsite','Match.National_Id','Match.NationalIdLabel','Match.State','Match.Region','Match.LegalForm','Match.ConsolidationCode','Match.Status','Match.Ticker','Match.CustomRule','Match.Isin','Match.BvDId'], 'RANGE': {'MAX': #max#, 'OFFSET' :#offset#}}";

                var replacements = new Dictionary<string, string>
                                   {
                                       { "#name#", name },
                                       { "#country#", country },
                                       { "#city#", city },
                                       { "#postCode#", postCode },
                                       { "#address#", address },
                                       { "#scoreLimit#", scoreLimit },
                                       { "#max#", max.ToString() },
                                       { "#offset#", offset.ToString() }
                                   };


                var jsonBody = Regex.Replace(jsonBodyString, string.Join("|", replacements.Keys.Select(k => k.ToString()).ToArray()), m => replacements[m.Value]);

                //var jsonBody = jsonBodyString;
                var dataBody = new StringContent(jsonBody, Encoding.UTF8, "application/json");


                using var client = new System.Net.Http.HttpClient();

                client.DefaultRequestHeaders.Add("ApiToken", "189P29998ad681b4ea1190b5d89d672fa480");
                var response = client.PostAsync(bvdUrl, dataBody).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;

                    var validResponseString = Regex.Replace(responseString, "{\"MATCH\":{\"0\":", "{\"MATCH\":{\"AdressData\":");

                    var attach = JsonConvert.DeserializeObject<BvdDataByAddressResponseModel>(validResponseString);
                    if (attach.Data.Any())
                    {
                        foreach (var datum in attach.Data)
                        {
                            var bvdId = datum.MATCH.AdressData.BvDId;
                        }
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