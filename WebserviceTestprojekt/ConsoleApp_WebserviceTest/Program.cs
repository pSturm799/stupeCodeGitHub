using System;
using System.IO;
using System.Net;
using System.Text;
using ConsoleApp_WebserviceTest.HttpClient;

namespace ConsoleApp_WebserviceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UseHttpClient.CallRestWithHttpClinet();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return;


            FileStream fs = new FileStream(@"C:\Users\psturm\Downloads\Kontoauszug_431023048200_2021-12-01_1104.pdf", FileMode.Open, FileAccess.Read);
            byte[] ar = new byte[(int)fs.Length];
            fs.Read(ar, 0, (int)fs.Length);


            File.WriteAllBytes(@"C:\Users\psturm\Downloads\hello.pdf", ar);

            fs.Close();


            //SharepointHandling.Run();
            //CallWebserviceWithMultipartFormDataContentType.CallWebservice();
            //XLocateWebservice.CallWebservice();
            return;

            //var jsonAdresse = "{  \"firmenReference\": \"A218345c\",  \"adressart\": \"HPT\",  \"land\": \"DE\",  \"ort\": \"string\",  \"plz\": \"string\",  \"strasse\": \"string\",  \"hausnummer\": \"string\",  \"sprache\": \"DE\",  \"manuellGeokodiert\": true,  \"vorlaufigeGeokodierung\": true}";
            //var jsonFirma = "{\"uname1\": \"e\",\"uname1Freigabestatus\": \"neu\", \"unternehmensarten\": [{\"geschaeftsfeld\": \"LKW\",\"partnerart\": \"KUN\" }  ],\"partnerbranche\": [{\"gruppe\": \"01\" }  ]}";
            //var jsonAnspr = "{  \"adressReference\": \"459348d4-e273-4032-ae6d-bac30cee57ac\",  \"firmenReference\": \"A232329\",  \"aussendungen\": \"Ja\",    \"wurmBenutzerAccountStatus\": \"NEU\",  \"wurmBerechtigungsSetId\": 0,  \"ansprechpersonEmails\": [    {      \"email\": \"string@gs.de\",\t  \"emailTyp\": \"Geschaeftlich\",\t  \"wurmAccountEmail\": true    }  ],  \"ansprechpersonTelefonnummern\": [    {      \"telefonnummer\": \"059844\",\t        \"telefontyp\": \"Festnetz\"    }  ],  \"ansprechpersonTaetigkeiten\": [    {      \"geschaeftsfeld\": \"LKW\",      \"taetigkeit\": \"ADM\"    }  ],     \"person\": {      \"vorname\": \"string\",    \"nachname\": \"string\",    \"sprache\": \"DE\",\t\"anrede\": \"H\"  } }";
            var jsonHaendlerMail =
                "{\r\n\t\"mailMessages\": [{\r\n\t\t\"sourceSystem\": \"CTX\",\r\n\t\t\"messageTypeKey\": \"ONLINE_ANFRAGE_HAENDLER_EXTERN\",\r\n\t\t\"messageId\": \"65d4605c-0e1c-4d76-89af-19b84bb52a26\",\r\n\t\t\"documentParameter\": \"{\\\"language\\\": \\\"DE\\\",\\\"empfaengerAnrede\\\": \\\"Bachelolr\\\",\\\"empfaengerVorname\\\": \\\"pera\\\",\\\"empfaengerNachname\\\": \\\"peric\\\",\\\"kundeFirmenName\\\": \\\"Firma\\\",\\\"kundeAdresse\\\": \\\"tolstojeva\\\",\\\"kundePLZ\\\": \\\"18000\\\",\\\"kundeORT\\\": \\\"nis\\\",\\\"kundeLand\\\": \\\"YU\\\",\\\"kundeAnsprechpersonAnrede\\\": \\\"frau\\\",\\\"kundeAnsprechpersonVorname\\\": \\\"zika\\\",\\\"kundeAnsprechpersonNachname\\\": \\\"zikic\\\",\\\"kundeTelefon\\\": \\\"123456789\\\",\\\"kundeFax\\\": \\\"123456789\\\",\\\"kundeEMail\\\": \\\"mika@mika.com\\\",\\\"kundenBemerkung\\\": \\\"komment\\\",\\\"kundeZusatztext\\\": \\\"zusatz\\\",\\\"belege\\\": [ \\\"belege1\\\", \\\"belege2\\\", \\\"belege3\\\" ]}\",\r\n\t\t\"archiving\": null,\r\n\t\t\"archive\": false,\r\n\t\t\"priority\": null,\r\n\t\t\"messageFormat\": [\"text/html\"],\r\n\t\t\"mailContent\": {\r\n\t\t\t\"fromSender\": \"\",\r\n\t\t\t\"toRecipients\": [\"Mikcarry.office@gmail.com\"],\r\n\t\t\t\"ccRecipients\": [],\r\n\t\t\t\"bccRecipients\": [],\r\n\t\t\t\"replyToRecipient\": null,\r\n\t\t\t\"subject\": \"\",\r\n\t\t\t\"body\": {\r\n\t\t\t\t\"mimeType\": \"text/html\",\r\n\t\t\t\t\"content\": \"\"\r\n\t\t\t}\r\n\t\t}\r\n\t}]\r\n}";
            var data = Encoding.ASCII.GetBytes(jsonHaendlerMail);

            //var uriFirma = "http://winwilf.test.lkw-walter.com/erp/services/gpm/rest/api/v-1-0/firmen";
            //var uriAdresse = "http://winwilf.test.lkw-walter.com/erp/services/gpm/rest/api/v-1-0/firmen/firma-id-A2183455/adressen";
            //var uriAnsprechperson = "http://winwilf.test.lkw-walter.com/erp/services/gpm/rest/api/v-1-0/ansprechPersonBeziehungen/erweitert";
            var uriZdom = "http://lkww-ds-app-zdom-engine.zdom.test.lkw-walter.com/lkww-ds-app-zdom-engine/api/zdom/document-messages";


            var userName = "admin-test"; //"prm_external";
            var password = "a1ms75ku"; //"pRM3xt3n@l";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(uriZdom));
            //httpWebRequest.Accept = "*/*";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{userName}:{password}"));
            httpWebRequest.Headers.Add("Authorization", $"Basic {encoded}");
            //httpWebRequest.ContentLength = data.Length;
            httpWebRequest.Headers.Add("X-TS", "2020-11-25T14:07:00Z");
            httpWebRequest.Headers.Add("X-TId", "44444");


            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var i = httpWebRequest.GetResponse();
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


                error.AppendLine($"JSON: {jsonHaendlerMail}");
                Console.WriteLine(error);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}