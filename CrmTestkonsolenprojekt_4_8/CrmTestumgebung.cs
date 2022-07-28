using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace CrmTestkonsolenprojekt_4_8
{
    public class CrmTestumgebung
    {
        public static void CallCrm()
        {
            //RegexAction();
            //CreatePdf();
            //HandleHashCode();
            //return;


            bool onlineCrm = true;


            //var url = "https://dev-we.crm4.dynamics.com/" /*Wien Energie*/;
            //var url = "https://vsdev-lkwwalter.dev.gc/developctx"; /*CTX dev V8*/
            //var url = "https://vsdev-ctxv9.dev.gc/developctx"; /*CTX dev V9*/
            var url = "https://werkstatt40-dev.crm4.dynamics.com/"; // Strabag dev V9

            string crmConnectionString;
            if (onlineCrm)
            {
                bool useClientSecret = true;
                if (useClientSecret)
                {
                    var clientId = "f3310a2e-e28c-4552-9f75-6ccdababaafe" /*Strabag*/; //"65c9ec34-41d3-41af-9b73-896eb494cbf1";
                    var clientSecret = "zaQmJ.N._Yih.55q5qR4~s1BKM0~uIo4D0" /*Strabag*/; //"4is_Uyo~a73_dTOZTAZsRVG-1WM-34Ayj7";

                    crmConnectionString =
                        $"authtype=ClientSecret;url={url};ClientId={clientId};ClientSecret={clientSecret}";
                }
                else
                {
                    var userName = "nstpe6@wstw.energy-it.net";
                    var password = "WE_Stupe_NM3";

                    crmConnectionString = $"authtype=Office365;url={url};Username={userName};Password={password}";
                }
            }
            else
            {
                var userName = "ps";
                var password = "nmidopf";
                var domain = "dev";
                crmConnectionString = $"AuthType=AD;url={url};Domain={domain};Username={userName};Password={password}";
            }


            CrmServiceClient crmServiceClient = new CrmServiceClient(crmConnectionString);


            if (crmServiceClient.IsReady)
            {
                var organizationService = crmServiceClient; // (IOrganizationService) new OrganizationServiceProxy(uri, null, crmServiceClient, null);


                #region Create/Delete n:n relations (Associate, Disassociate)

                //var accountId = new Guid("FC824595-CB11-E611-80C2-005056841B8B");

                //var contactId = new Guid("CF8673A9-4F31-EA11-80EE-00155D840E0A");
                //var entityReferenceCollection = new EntityReferenceCollection
                //                                {
                //                                    new EntityReference("contact", contactId),
                //                                    // new EntityReference("contact", contactId)
                //                                };


                //try
                //{
                //    // create relationship
                //    organizationService.Associate("account", accountId, new Relationship("fwi_account_contact"), entityReferenceCollection);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.Message);
                //}

                //////delete relationship
                //organizationService.Disassociate("account", accountId, new Relationship("fwi_account_contact"), entityReferenceCollection);

                #endregion


                #region UpsertRequest

                //var value = "C001";
                //var key = "cos_contactcode";
                //var contact = new Entity("contact", new KeyAttributeCollection
                //                                    {
                //                                        { key, value }
                //                                    })
                //              {
                //                  ["firstname"] = "PS"
                //              };

                //var upsertRequest = new UpsertRequest
                //                    {
                //                        Target = contact
                //                    };


                //var upsertResponse = (UpsertResponse)organizationService.Execute(upsertRequest);
                //var i = upsertResponse;

                #endregion

                #region RetrieveMultiple

                var query = new QueryExpression("contact");
                query.ColumnSet.AddColumns("fullname");
                query.TopCount = 0;
                //var result = organizationService.RetrieveMultiple(query);
                var x = 0;

                //var query = new QueryExpression("fwi_suggestion");
                //query.ColumnSet.AddColumns("fwi_accountname", "fwi_lastname", "fwi_zip", "fwi_emailaddress", "fwi_city", "fwi_housenumber", "fwi_street",
                //    "fwi_firstname", "fwi_phonenumber");
                //query.Criteria.AddCondition("fwi_suggestionid", ConditionOperator.Equal, new Guid("834289AD-17DA-E911-80E8-005056841B8B"));

                //var linkedEntityFwiSuggestionToFwiCountry = query.AddLink("fwi_country", "fwi_countryid", "fwi_countryid", JoinOperator.LeftOuter);
                //linkedEntityFwiSuggestionToFwiCountry.Columns.AddColumns("fwi_name");
                //linkedEntityFwiSuggestionToFwiCountry.EntityAlias = "Country";

                //var linkedEntityFwiSuggestionToFwiLanguage = query.AddLink("fwi_language", "fwi_languageid", "fwi_languageid", JoinOperator.LeftOuter);
                //linkedEntityFwiSuggestionToFwiLanguage.Columns.AddColumns("fwi_name");
                //linkedEntityFwiSuggestionToFwiLanguage.EntityAlias = "Language";

                //var linkedEntityFwiSuggestionToFwiSalutation = query.AddLink("fwi_nameaffix", "fwi_salutationid", "fwi_nameaffixid", JoinOperator.LeftOuter);
                //linkedEntityFwiSuggestionToFwiSalutation.Columns.AddColumns("fwi_name");
                //linkedEntityFwiSuggestionToFwiSalutation.EntityAlias = "Salutaion";

                //var linkedEntityFwiSuggestionToFwiDealerContact = query.AddLink("contact", "fwi_contactid", "contactid", JoinOperator.LeftOuter);
                //linkedEntityFwiSuggestionToFwiDealerContact.EntityAlias = "DealerContact";
                //linkedEntityFwiSuggestionToFwiDealerContact.Columns.AddColumns("lastname", "firstname", "emailaddress1");


                //var linkedEntityFwiSuggestionDealerContactToFwiSalutation =
                //    linkedEntityFwiSuggestionToFwiDealerContact.AddLink("fwi_nameaffix", "fwi_salutationid", "fwi_nameaffixid", JoinOperator.LeftOuter);
                //linkedEntityFwiSuggestionDealerContactToFwiSalutation.EntityAlias = "ContactToSalutation";
                //linkedEntityFwiSuggestionDealerContactToFwiSalutation.Columns.AddColumns("fwi_name");


                //var result = organizationService.RetrieveMultiple(query); //.Entities[0];
                //var salutationName = result.Entities[0].GetAttributeValue<AliasedValue>("ContactToSalutation.fwi_name")?.Value?.ToString();
                //var x = 0;


                //var lookupQueryExpression = new QueryExpression("fwi_account_fwi_ban")
                //                            {
                //                                ColumnSet = new ColumnSet()
                //                            };


                //var list = new List<Entity>
                //           {
                //               new Entity("account", Guid.NewGuid())
                //               {
                //                   ["parentaccountid"] = new EntityReference("account", Guid.NewGuid())
                //               },
                //               new Entity("account", Guid.NewGuid())
                //               {
                //                   ["parentaccountid"] = new EntityReference("account", Guid.NewGuid())
                //               },
                //               //new Entity("account", Guid.NewGuid())
                //           };
                //var filter = list.Select(f => f.GetAttributeValue<EntityReference>("parentaccountid").Id).ToArray();
                //lookupQueryExpression.Criteria.AddCondition(new ConditionExpression("accountid", ConditionOperator.In, filter));
                //var result = organizationService.RetrieveMultiple(lookupQueryExpression); //.Entities[0];

                //var countryName = result.GetAttributeValue<AliasedValue>("Country.fwi_name").Value;
                //if (string.IsNullOrEmpty(countryName.ToString()))
                //{
                //    var x = 0;
                //}

                #endregion

                #region create CRM Link to open dataset on fwi_vehicle

                //// retrieve code
                //RetrieveEntityRequest request = new RetrieveEntityRequest();
                //request.LogicalName = "fwi_vehicle";
                //RetrieveEntityResponse response = (RetrieveEntityResponse) organizationService.Execute(request);
                //int entityCode = response.EntityMetadata.ObjectTypeCode.Value;

                //var entityId = "B862368F-C113-E711-80D1-005056841B8B";
                //var domainName = "vsdev-lkwwalter.dev.gc";
                //var orgName = "develop";

                //// template urls NB: use your cloud zone (es. crm4 for west europe)
                //string onpremiseurl = $"https://{domainName}/{orgName}/main.aspx?etc={entityCode}&id=%7b{entityId}%7d&pagetype=entityrecord" + System.Environment.NewLine;

                //var te = onpremiseurl + Environment.NewLine + onpremiseurl;
                //string hyperlink = string.Format($"<a href='{onpremiseurl}'></a>");

                //return;

                #endregion

                #region MetaDataRequest

                //var metaDataRequest = new RetrieveEntityRequest
                //                      {
                //                          EntityFilters = EntityFilters.Entity,
                //                          LogicalName = "annotation"
                //                      };

                //var metaDataResponse = (RetrieveEntityResponse) organizationService.Execute(metaDataRequest);

                //var metadata = metaDataResponse.EntityMetadata;

                //var u = metadata.ObjectTypeCode;

                #endregion

                #region ActivityParty

                //var query = new QueryExpression("phonecall")
                //            {
                //                ColumnSet = new ColumnSet("to")
                //            };
                //query.Criteria.AddCondition("activityid", ConditionOperator.Equal, "80DC2AE1-F51F-EA11-80EE-00155D840E0A");

                //var result = organizationService.RetrieveMultiple(query);
                //var existingRequiredattendess = result[0].GetAttributeValue<EntityCollection>("to");

                //var contact = new EntityReference("contact")
                //              {
                //                  Id = new Guid("E257D457-046A-E611-80C7-005056841B8B") //Flo Sieder
                //              };

                //// check if already existst
                //var entity1 =
                //    existingRequiredattendess.Entities.FirstOrDefault(
                //        e =>
                //            e.Contains("partyid") && (e.GetAttributeValue<EntityReference>("partyid") != null) &&
                //            e.GetAttributeValue<EntityReference>("partyid").Equals(contact));

                //if (entity1 == null)
                //{
                //    var partyEntity = new Entity("activityparty")
                //                      {
                //                          Attributes =
                //                          {
                //                              {
                //                                  "partyid", contact
                //                              }
                //                          }
                //                      };
                //    // add contact to partylist
                //    existingRequiredattendess.Entities.Add(partyEntity);

                //    var phonecallToUpdate = new Entity("phonecall");
                //    phonecallToUpdate.Id = new Guid("6D75CF67-946E-EA11-80EF-00155D840E0A");

                //    phonecallToUpdate.Attributes.Add(new KeyValuePair<string, object>("to", existingRequiredattendess));

                //    organizationService.Update(phonecallToUpdate);
                //}

                #endregion

                #region Delete

                try
                {
                    //organizationService.Delete("account", Guid.NewGuid());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                #endregion

                #region Create

                var task = new Entity("task");
                var attrColl1 = new AttributeCollection
                                {
                                    new KeyValuePair<string, object>("subject", "xxx"),
                                    new KeyValuePair<string, object>("description", "bla")
                                };
                task.Attributes = attrColl1;

                task["subject"] = "testPS_3";
                task["statecode"] = new OptionSetValue(0);
                task["statuscode"] = new OptionSetValue(3);
                task["regardingobjectid"] = new EntityReference("account", new Guid("577e1fbd-40f7-ea11-a815-000d3ada58ce"));
                //var idTask = organizationService.Create(task);

                //var entityToUpdate = new Entity("task", idTask);
                //entityToUpdate["statecode"] = new OptionSetValue(1);
                //entityToUpdate["statuscode"] = new OptionSetValue(5);
                //organizationService.Update(entityToUpdate);
                int i = 0;

                #endregion

                #region QueryExpression with LinkeEntity

                //var query = new QueryExpression("account")
                //            {
                //                ColumnSet = new ColumnSet("fwi_accountident", "name", "fwi_searchterm", "modifiedon")
                //            };
                //query.Criteria.AddCondition("accountid", ConditionOperator.Equal, new Guid("0286434D-2BF6-E911-80E8-005056841B8B"));
                //query.Criteria.AddCondition("fwi_accounttype", ConditionOperator.Equal, 100000001 /*Firma*/);

                //// get child addresses
                //var addresses = new LinkEntity("account", "account", "accountid", "parentaccountid", JoinOperator.Inner)
                //                {
                //                    LinkCriteria = new FilterExpression(LogicalOperator.And),
                //                    EntityAlias  = "Address",
                //                    Columns      = new ColumnSet("fwi_pnr", "name", "address1_postalcode", "address1_city", "address1_line1")
                //                    //JoinOperator = JoinOperator.LeftOuter
                //                };
                //addresses.LinkCriteria.AddCondition("statecode", ConditionOperator.Equal, 0 /*aktiv*/);
                //addresses.LinkCriteria.AddCondition("fwi_accounttype", ConditionOperator.Equal, 100000000 /*Adresse*/);

                //// get country name of address
                //var countryEntity = new LinkEntity("account", "fwi_country", "fwi_countryid", "fwi_countryid", JoinOperator.Inner)
                //                    {
                //                        LinkCriteria = new FilterExpression(LogicalOperator.And),
                //                        EntityAlias  = "Country",
                //                        Columns      = new ColumnSet("fwi_name"),
                //                        JoinOperator = JoinOperator.LeftOuter
                //                    };

                //addresses.LinkEntities.Add(countryEntity);
                //addresses.JoinOperator = JoinOperator.LeftOuter;

                //query.LinkEntities.Add(addresses);

                #endregion

                #region FetchExpression

                //var fetch =
                //    "<fetch><entity name = 'businessunit'><attribute name = 'name'/><link-entity name = 'fwi_contactfunction' from = 'fwi_businessunitid' to = 'businessunitid' link-type = 'inner'><filter><condition attribute = 'fwi_gpmcontactfunctionid' operator= 'eq' value = '87513B77-3CF4-4E98-850F-CB1C388DD83B'/></filter></link-entity></entity></fetch>";
                //var fetchExpression = new FetchExpression(fetch);
                //var result = organizationService.RetrieveMultiple(fetchExpression).Entities;
                //var name = result[0].GetAttributeValue<string>("name");

                #endregion

                #region Get OptionSet Labelnames

                //IRetrieveEntityResponseForGivenEntityName retrieveEntityResponseForGivenEntityName =
                //    new RetrieveEntityResponseForGivenEntityName(organizationService);
                //IPicklistMetadataForGivenRetrieveEntityResponse picklistMetadataForGivenRetrieveEntityResponse = new GetPicklistMetadataForGivenRetrieveEntityResponse();
                //IOptionSetLabelFromPicklistMetadata optionSetLabelFromPicklistMetadata = new GetOptionSetLabelFromPicklistMetadata();
                //IOptionsetLabel optionsetLabel = new GetOptionsetLabel(retrieveEntityResponseForGivenEntityName, picklistMetadataForGivenRetrieveEntityResponse,
                //    optionSetLabelFromPicklistMetadata);

                //var labelname = optionsetLabel.For("opportunity", "statuscode", 3);

                #endregion

                #region Get Statusgrund Labelnames (ohne Metadata retrieve)

                //var result = organizationService.Retrieve("opportunity", new Guid("CB54AD4B-62E0-EA11-9386-00155D840D1B"), new ColumnSet("statuscode"));
                //var fb = result.FormattedValues["statuscode"];
                //var name = fb;

                #endregion


                #region Retrieve

                //var retrieveResult = organizationService.Retrieve("metric", new Guid("9241F883-CEB1-4600-9C32-7CB1D9ECF6A3"), new ColumnSet("isamount", "name"));
                //var name = retrieveResult.GetAttributeValue<string>("name");
                //var attrValue = retrieveResult.GetAttributeValue<bool>("isamount");
                //if (attrValue.Equals(1))
                //{
                //    int i = 0;
                //}
                int i9 = 0;

                #endregion

                #region update

                //var entity = new Entity("fwi_vehicleconstruction")
                //             {
                //                 Id = new Guid("0239B879-6C0F-E611-80C2-005056841B8B"),
                //                 Attributes =
                //                 {
                //                     //["new_stringone"] = "testONE",
                //                     ["fwi_name"] = "Dreiachsige Zugmaschine 12"
                //                 }
                //             };

                var entity = new Entity("account")
                             {
                                 Id = new Guid("315689A7-12DA-E911-80E8-005056841B8B"),
                                 ["name"] = "vvv"
                             };
                //organizationService.Update(entity);

                #endregion Update


                #region Assign

                // assign Task to user
                //var taskGuid = new Guid("A7982412-6C5C-EA11-80EF-00155D840E0A");
                //var assignRequest = new AssignRequest
                //                    {
                //                        Assignee = new EntityReference("systemuser", new Guid("9B8127B3-A4F5-E511-80C5-005056848C3C")),
                //                        Target = new EntityReference("task", taskGuid)
                //                    };
                //organizationService.Execute(assignRequest);

                #endregion


                #region OrganizationRequests

                //var e = new Entity();

                //var x = e.GetAttributeValue<string>("dd");

                //var createRequest = new CreateRequest
                //                    {
                //                        Target = new Entity("task")
                //                    };
                //var updateRequest = new UpdateRequest
                //                    {
                //                        Target = new Entity("oze", new Guid())
                //                    };
                //var listWithRequest = new List<OrganizationRequest>();
                //listWithRequest.Add(createRequest);
                //listWithRequest.Add(updateRequest);
                //listWithRequest.Add(null);
                //foreach (var organizationRequest in listWithRequest)
                //{
                //    if (organizationRequest != null)
                //    {
                //        organizationService.Execute(organizationRequest);
                //    }
                //}

                #endregion


                #region Disable all Pluginsteps

                //var qe = new QueryExpression("sdkmessageprocessingstep");

                //qe.ColumnSet.AddColumns("sdkmessageprocessingstepid", "name", "statecode");
                //qe.Criteria.AddCondition("name", ConditionOperator.BeginsWith, "CRM.CTX");
                //var stepList = organizationService.RetrieveMultiple(qe).Entities.ToList();
                //foreach (var entity1 in stepList)
                //{
                //    var stepName = entity1.GetAttributeValue<string>("name");
                //    //var attributes = entity1.GetAttributeValue<string>("FilteringAttributes");
                //    var state = entity1.GetAttributeValue<OptionSetValue>("statecode").Value; // 1 disabled, 0 enabled
                //    if (stepName.Contains("account"))
                //    {
                //        var y = 0;
                //    }
                //}

                #endregion


                #region Multiselect OptionSet

                //var projectResource = organizationService.Retrieve("cos_projectresource", Guid.Parse("638d2de0-f1f5-ec11-bb3d-0022488094d5"),
                //    new ColumnSet("cos_projectrole", "cos_constructionprojectid"));
                //var multiSelect = projectResource.FormattedValues["cos_projectrole"]; // liefert den Namen der OptionSets zurück
                //OptionSetValueCollection multiselect = (OptionSetValueCollection)projectResource.Attributes["cos_projectrole"]; // liefert ein Array von OptionSet Values zurück
                //foreach (var optionSet in multiselect)
                //{
                //    var optionSetIn = optionSet.Value;
                //}

                //var name = projectResource.FormattedValues["cos_constructionprojectid"];

                #endregion


                #region AliasedValue

                var queryAliasedValue = new QueryExpression("bookableresourcebooking");
                queryAliasedValue.TopCount = 1;

                var leToWorkOrder = queryAliasedValue.AddLink("msdyn_workorder", "msdyn_workorder", "msdyn_workorderid");
                leToWorkOrder.EntityAlias = "leToWorkOrder";
                leToWorkOrder.Columns.AddColumns("cos_mgaticketid", "msdyn_workorderid", "msdyn_servicerequest");

                var leToCustomerAsset = leToWorkOrder.AddLink("msdyn_customerasset", "cos_customerasset", "msdyn_customerassetid");
                leToCustomerAsset.EntityAlias = "leToCustomerAsset";

                leToCustomerAsset.Columns.AddColumns("pde_mwa", "bmti_country");

                //var result = organizationService.RetrieveMultiple(queryAliasedValue);
                //var test1 = result.Entities[0].GetAttributeValue<AliasedValue>("leToWorkOrder.msdyn_servicerequest");
                //var t2 = result.Entities[0].GetAttributeValue<AliasedValue>("leToCustomerAsset.bmti_country");
                //var countryOptionSetValue = result.Entities[0].GetAttributeValue<AliasedValue>("leToCustomerAsset.bmti_country")?.Value;
                //var countryOptionSetName = result.Entities[0].FormattedValues["leToCustomerAsset.bmti_country"];

                #endregion

                #region GetSecurityRolesByName

                var querySR = new QueryExpression("role");
                querySR.ColumnSet = new ColumnSet("roleid", "name");
                querySR.Criteria = new FilterExpression(LogicalOperator.And);

                var roleNameFilter = new FilterExpression(LogicalOperator.Or);

                var secRoleName = new List<string>
                                  {
                                      "Tunnelbau_Bauleiter",
                                      "Tunnelbau_Controller"
                                  };

                foreach (var name in secRoleName)
                {
                    roleNameFilter.AddCondition(new ConditionExpression("name", ConditionOperator.Equal, name));
                }


                if (roleNameFilter.Conditions.Count > 0)
                {
                    querySR.Criteria.AddFilter(roleNameFilter);
                }

                Guid usersBuId = new Guid("8CC77E5E-AD2E-E911-A817-000D3A28963A");

                var bussinesUnitFilter = new FilterExpression();
                bussinesUnitFilter.AddCondition(new ConditionExpression("businessunitid", ConditionOperator.Equal, usersBuId));
                querySR.Criteria.AddFilter(bussinesUnitFilter);

                //var collection = organizationService.RetrieveMultiple(querySR);

                //var listOfRoles = new List<KeyValuePair<Entity, string>>();


                //for (int index = 0; index < collection.Entities.Count; index++)
                //{
                //    var roleEntity = collection.Entities[index];
                //    var kvp = secRoleName.First(x1 => x1.ToLower() == roleEntity.Attributes["name"].ToString().ToLower());

                //    listOfRoles.Add(new KeyValuePair<Entity, string>(roleEntity, kvp));
                //}

                #endregion
            }
            else
            {
                const string UNABLE_TO_LOGIN_ERROR = "Unable to Login to Dynamics CRM";
                if (crmServiceClient.LastCrmError.Equals(UNABLE_TO_LOGIN_ERROR))
                {
                    Console.WriteLine("Check the connection string values in cds/App.config.");
                    throw new Exception(crmServiceClient.LastCrmError);
                }

                throw crmServiceClient.LastCrmException;
            }


            Console.WriteLine("is durch");
            Console.ReadKey();
        }

        private static void RegexAction()
        {
            var regex = "(?!^\\+)[^0-9]";
            var inputString = "+54/152";
            var newValue = Regex.Replace(inputString, regex, "");
        }

        private static void CreatePdf()
        {
            //string pdfFromIl = "JVBERi0xLjQKJeLjz9MKNCAwIG9iajw8L1R5cGUvRm9udC9TdWJ0eXBlL1R5cGUxL0Jhc2VGb250L0hlbHZldGljYS9FbmNvZGluZy9XaW5BbnNpRW5jb2Rpbmc+PmVuZG9iago1IDAgb2JqPDwvVHlwZS9Gb250L1N1YnR5cGUvVHlwZTEvQmFzZUZvbnQvSGVsdmV0aWNhLUJvbGQvRW5jb2RpbmcvV2luQW5zaUVuY29kaW5nPj5lbmRvYmoKNiAwIG9iajw8L0xlbmd0aCAxNDI+PnN0cmVhbQowIDAgMCByZwogMCBnCmYKCkJUIC9GdDEgOCBUZiAzOTAuMjMyIDc1IFRkIChKYWhyZXNhYnJlY2hudW5nIE5yLiA1MTMxODQ2NDk5LCBCbGF0dCAxIHZvbiAzKSBUaiBFVAoKQlQgL0Z0MiAxNiBUZiAyNzAgODAwIFRkIChEVVBMSUtBVCkgVGogRVQKCmVuZHN0cmVhbQplbmRvYmoKMTYgMCBvYmo8PCAvQ29sb3JTcGFjZSA8PCAvQ1MxIDcgMCBSIC9DUzIgOCAwIFIgL0NTMyA5IDAgUiA+PgovRm9udDw8L0Z0MiA1IDAgUi9GdDEgNCAwIFIgL0YxIDEwIDAgUiAvRjIgMTEgMCBSIC9GMyAxMiAwIFIgPj4KL1Byb2NTZXQgWyAvUERGIC9UZXh0IC9JbWFnZUIgL0ltYWdlQyAvSW1hZ2VJIF0KL1hPYmplY3QgPDwgL1gyIDEzIDAgUiAvWGYxIDE0IDAgUiAvWGYyIDE1IDAgUiA+PiA+PmVuZG9iagozIDAgb2JqPDwgL1R5cGUgL1BhZ2UgL0NvbnRlbnRzIFsgMTcgMCBSIDE4IDAgUiAxOSAwIFIgMjAgMCBSIDIxIDAgUiAgNiAwIFIgXQovTWVkaWFCb3ggWyAwIDAgNTk1IDg0MSBdIC9QYXJlbnQgMiAwIFIKIC9SZXNvdXJjZXMgMTYgMCBSCj4+ZW5kb2JqCjcgMCBvYmoKWyAvU2VwYXJhdGlvbiAvQmxhY2sgL0RldmljZUNNWUsgMjIgMCBSIF0KZW5kb2JqCjggMCBvYmoKWyAvU2VwYXJhdGlvbiAvUEFOVE9ORSMyMDE1OCMyMEMgL0RldmljZUNNWUsgMjMgMCBSIF0KZW5kb2JqCjkgMCBvYmoKWyAvU2VwYXJhdGlvbiAvQmxhY2sgL0RldmljZUNNWUsgMjQgMCBSIF0KZW5kb2JqCjEwIDAgb2JqCjw8IC9UeXBlIC9Gb250IC9TdWJ0eXBlIC9UeXBlMSAvQmFzZUZvbnQgL0hlbHZldGljYS1Cb2xkCi9FbmNvZGluZyAvV2luQW5zaUVuY29kaW5nID4+CmVuZG9iagoxMSAwIG9iago8PCAvVHlwZSAvRm9udCAvU3VidHlwZSAvVHlwZTEgL0Jhc2VGb250IC9IZWx2ZXRpY2EKL0VuY29kaW5nIC9XaW5BbnNpRW5jb2RpbmcgPj4KZW5kb2JqCjEyIDAgb2JqCjw8IC9UeXBlIC9Gb250IC9TdWJ0eXBlIC9UeXBlMSAvQmFzZUZvbnQgL1RpbWVzLVJvbWFuCi9FbmNvZGluZyAvV2luQW5zaUVuY29kaW5nID4+CmVuZG9iagoxMyAwIG9iajw8IC9UeXBlIC9YT2JqZWN0IC9TdWJ0eXBlIC9Gb3JtIC9CQm94IFsgMCAtNTAwIDIyNTAwIDE1MDAgXQovRmlsdGVyIC9GbGF0ZURlY29kZSAvRm9ybVR5cGUgMSAvTGVuZ3RoIDQKL01hdHJpeCBbIDAuMDAxIDAgMCAwLjAwMSAwIDAgXQovUmVzb3VyY2VzIDw8IC9Db2xvclNwYWNlIDw8IC9DUyAyNSAwIFIgPj4gPj4gPj5zdHJlYW0KICAgCmVuZHN0cmVhbQplbmRvYmoKMTQgMCBvYmo8PCAvVHlwZSAvWE9iamVjdCAvU3VidHlwZSAvRm9ybSAvQkJveCBbIDAgMCA4NTAuMzEgMjA1LjUxIF0KL0ZpbHRlciAvRmxhdGVEZWNvZGUgL0Zvcm1UeXBlIDEgL0xlbmd0aCAyMzM4Ci9NYXRyaXggWyAxIDAgMCAxIDAgMCBdCi9SZXNvdXJjZXMgPDwgL0NvbG9yU3BhY2UgPDwgL0NTMSAyNiAwIFIgL0NTMiAyNyAwIFIgPj4KL0V4dEdTdGF0ZSA8PCAvR1MyIDI4IDAgUiA+PgovUHJvY1NldCBbIC9QREYgL1RleHQgL0ltYWdlQiAvSW1hZ2VDIC9JbWFnZUkgXQovUHJvcGVydGllcyA8PCAvTUMwIDI5IDAgUiA+PiA+PiA+PnN0cmVhbQpIicRXzc4dtw3dz1PMC8xYpP63dYtu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NDI5IC0yLjU4NCAtMTMuNDI5IC03LjQwOSBjIC0xMy40MjkgLTguNzggLTEzLjEwNCAtMTAuMDcxIC0xMi41MzggLTExLjIyNSBjIGggZiAwIDAuMSAxIDAgayAxIDAgMCAxIDQuMTQ2OSAtNy40MDkyIGNtIDAgMCBtIDAgMC44NTggLTAuMTMgMS42ODcgLTAuMzYzIDIuNDcyIGMgLTEyLjE0MyAtOC4wNzYgbCAtMTEuMTA5IC04LjUwMSAtOS45NzcgLTguNzM3IC04Ljc4OCAtOC43MzcgYyAtMy45MzUgLTguNzM3IDAgLTQuODI2IDAgMCBjIGYgMC40NSAwIDAuOTIgMCBrIDEgMCAwIDEgLTE3LjM1NCAtMzMuNDQ0MyBjbSAwIDAgbSAxNy4wNDYgMTUuMjYyIGwgMTcuMDQ5IDIwLjk0MSBsIDEyLjE0OCAyMC44OSBsIC0wLjAwMyAxMC4wMTEgbCBoIGYgMC44IDAuMSAwLjkgMC4zNSBrIDEgMCAwIDEgLTAuMDAwNCAwIGNtIDAgMCBtIDAuMDAzIC05LjQyIGwgMTcuMDQzIDUuODM3IGwgMTcuMDQ3IDE1LjI2MiBsIGggLTcuMzU3IC0xMC4xMiBtIC03LjM1NyAtMTYuMDEgbCAtMC43NzkgLTEwLjEyIGwgaCBmIDAuNTIgMCAwLjA4IDAgayAxIDAgMCAxIDAuMDAyOSAtOS40MTk5IGNtIDAgMCBtIDAgLTAuNyBsIC0wLjc4MiAtMC43IGwgLTcuMzYxIC02LjU5MSBsIC03LjM2MSAtNi42NTkgbCAzLjA4NiAtNi42NTkgbCAxNy4wMzYgNS44MzIgbCAxNy4wNDEgMTUuMjU2IGwgaCBmIDEgMC41IDAgMCBrIDEgMCAwIDEgMy4wODQ5IC02LjY1OTIgY20gMCAwIG0gMTAuNTI1IDAgbCAxNy4xODEgNS45NTkgbCAxMy45NDggNS45NTkgbCAxMy45NTEgMTIuNDg5IGwgaCBmIDAuOSAwLjg1IDAgMC4xIGsgMSAwIDAgMSAxNy4xODA3IDUuOTU5IGNtIDAgMCBtIC02LjY1NiAtNS45NTkgbCAzLjU4NiAtNS45NTkgbCAzLjU4NiAwIGwgaCBmIDAgMC41NSAxIDAgayAxIDAgMCAxIC0zLjEwNjQgNDUuMzc5OSBjbSAwIDAgbSAtMC41MSAyLjM5MiAtMi4wMDQgNC40MTUgLTQuMDQxIDUuNjQ2IGMgLTE2LjUzNiAtNS41NDEgbCAtMTUuNTA4IC03LjcwMSAtMTMuNjIzIC05LjM3OCAtMTEuMzA5IC0xMC4xMjUgYyBoIGYgMCAwLjEgMSAwIGsgMSAwIDAgMSAtMTcuMDk3NyAtMTQuNDk5MSBjbSAwIDAgbSAtNS4zMjggLTQuNzcxIGwgLTUuMzMxIC01LjY0IGwgLTAuMDY4IC01LjY0IGwgLTAuMDY3IC0xMC45ODcgbCAxMi4zNTIgMC4xMzIgbCBoIGYgMCAwLjU1IDEgMCBrIDEgMCAwIDEgLTUuMzE2OSAtMC4wNTY1OTk5IGNtIDAgMCBtIC0wLjAxMyAtNS4yMjcgbCA1Ljg5NSAwLjA2MiBsIGggZiBRIDAgMCAwIDAuOCBrIC9HUzAgZ3MgcSAxLjA2MzI2IDAgMCAxLjA2MzI2IDM3LjgxMTkxIDU5LjU5ODMyIGNtIDAgMCBtIC0xLjc3OSAwIGwgMC4wMzcgOC41MjYgbCAxLjgxNiA4LjUyNiBsIGggZiBRIHEgMS4wNjMyNiAwIDAgMS4wNjMyNiA0OS4yNzgzMTg1IDY0LjE2Mzg1MjEgY20gMCAwIG0gLTAuOTA4IC00LjI5NCBsIC0yLjUwMyAtNC4yOTQgbCAtMS42MTkgLTAuMTQ3IGwgLTEuNTcgMC4wODYgLTEuNTQ2IDAuMjU4IC0xLjU0NiAwLjM5MyBjIC0xLjU0NiAwLjY2MiAtMS42NTYgMC43NDggLTEuOTUxIDAuNzQ4IGMgLTIuMzggMC43NDggLTIuODgzIDAuMzgxIC0zLjI1MSAtMC4xOTYgYyAtNC4xMjIgLTQuMjk0IGwgLTUuNjggLTQuMjk0IGwgLTQuODA5IC0wLjIwOSBsIC00Ljc0OCAwLjA2MSAtNC43MjMgMC4yNTggLTQuNzIzIDAuNDA0IGMgLTQuNzIzIDAuNjYyIC00LjgzMyAwLjc0OCAtNS4xMTYgMC43NDggYyAtNS41NDUgMC43NDggLTUuOTk5IDAuNDA0IC02LjQ0MSAtMC4xOTYgYyAtNy4zMTIgLTQuMjk0IGwgLTguOTE5IC00LjI5NCBsIC03Ljk5OSAwIGwgLTcuOTUgMC4yMzIgLTcuOTI1IDAuNTAzIC03LjkyNSAwLjc0OCBjIC03LjkyNSAxLjA5MiAtNy45NjIgMS40MjMgLTguMDIzIDEuNTk1IGMgLTYuNTAyIDIuMTk1IGwgLTYuNDE2IDIgLTYuMzMgMS41MjEgLTYuMzU1IDEuMTg5IGMgLTUuNzQxIDEuODE1IC01LjA0MiAyLjEyMiAtNC4zNDMgMi4xMjIgYyAtMy43MDUgMi4xMjIgLTMuMjUxIDEuODQgLTMuMTg5IDEuMTg5IGMgLTIuNTE1IDEuODY1IC0xLjgyOCAyLjEyMiAtMS4xNjYgMi4xMjIgYyAtMC40NjYgMi4xMjIgMC4wOTggMS43NTQgMC4wOTggMC44MjIgYyAwLjA5OCAwLjU3NiAwLjA2MiAwLjI4MiAwIDAgYyBmIFEgcSAxLjA2MzI2IDAgMCAxLjA2MzI2IDYwLjAxNTc1NTkgNjYuNzcyMTM1MiBjbSAwIDAgbSAtMC41NTIgMC40MTggLTEuMTUzIDAuNjAyIC0xLjg5IDAuNjAyIGMgLTIuNjYyIDAuNjAyIC0zLjMxMyAwLjExMSAtMy4zMTMgLTAuNDc5IGMgLTMuMzEzIC0wLjgyMiAtMy4wOTIgLTEuMDkyIC0yLjUyNyAtMS4zIGMgLTEuNTQ2IC0xLjY2OCBsIC0wLjQ1NCAtMi4wNzIgMC4xMzUgLTIuNzExIDAuMTM1IC0zLjY4IGMgMC4xMzUgLTUuNTMzIC0xLjQ0OCAtNi45MzIgLTQgLTYuOTMyIGMgLTUuMjAyIC02LjkzMiAtNi4wOTcgLTYuNjEyIC02LjgwOSAtNi4xNTggYyAtNS45MDEgLTQuODQ2IGwgLTUuMTg5IC01LjI2MyAtNC41NTIgLTUuNTA4IC0zLjY5MyAtNS41MDggYyAtMi42MTMgLTUuNTA4IC0xLjkxNCAtNC45NDMgLTEuOTE0IC00LjA5OCBjIC0xLjkxNCAtMy42NjggLTIuMjA4IC0zLjM5OCAtMi44MjIgLTMuMTc4IGMgLTMuNzE3IC0yLjg0NiBsIC00LjY3NCAtMi40OSAtNS4yNzUgLTEuOTUgLTUuMjc1IC0wLjk1NyBjIC01LjI3NSAwLjc2MSAtMy42NTYgMi4wMzcgLTEuNjMyIDIuMD";
            string sFile = @"C:\Users\psturm\Downloads\Dynamics365 Authentification.pdf"; //Path
            byte[] bytes = File.ReadAllBytes(sFile);
            //bytes = Encoding.ASCII.GetBytes(pdfFromIl);

            //Console.WriteLine(Convert.ToBase64String(bytes));

            File.WriteAllBytes(@"C:\Temp\filename.PDF", bytes);
        }

        private static void HandleHashCode()
        {
            var testString1 = "Hallo Welt!";
            var hashCode = testString1.GetHashCode();
            Console.WriteLine($"String'{testString1}' hat HashCode {hashCode}");
            var stringFromHashCode = hashCode.ToString();
            Console.WriteLine($"Convert HashCode to string: {stringFromHashCode}");
            Console.ReadKey();
        }

        public bool IsEqual(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
            {
                return true;
            }

            return s1 != null && s1.Equals(s2, StringComparison.OrdinalIgnoreCase);
        }

        public void ImportCsvFile()
        {
            var csvFile = File.OpenRead(@"C:\Users\psturm\OneDrive - Cosmo Consult AG\PS\Kundenfiles\Harrer\Beispiel_Export_aus_Xoil_für_Import_CRM_200217.csv");

            var streamReader = new StreamReader(csvFile);


            var completeFileContent = streamReader.ReadToEnd();
            completeFileContent = completeFileContent.Replace("\n", string.Empty).Replace("\r", Environment.NewLine);

            var lines = completeFileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var x = lines.Select(line => line.Split(';').ToList()).Where(line => line.Count(content => !string.IsNullOrEmpty(content)) > 0).ToList();


            var table = x;


            var attributeLists = new List<List<KeyValuePair<string, object>>>();
            var titleKeys = table[0];
            var dt = new DataTable();

            // Start in line 2, line 1 is for the titles.
            for (var row = 1; row < table.Count; row++)
            {
                var currentRowAttributes = new List<KeyValuePair<string, object>>();

                for (var column = 0; column < titleKeys.Count; column++)
                {
                    // Only add colums with filled title.
                    if (!string.IsNullOrEmpty(titleKeys[column]))
                    {
                        currentRowAttributes.Add(new KeyValuePair<string, object>(titleKeys[column], table[row][column]));
                    }
                }

                attributeLists.Add(currentRowAttributes);
            }


            // Remove empty attributes-lists.
            var attr = attributeLists.Where(l => l.Any(list => !string.IsNullOrEmpty(list.Value.ToString()))).ToList();


            var result = attr;
        }


        public List<string> sortListByOptionSetListString()
        {
            int[] sortOrder = { 100000000, 100000002, 100000001, 100000003, 100000004, 100000006, 100000005 };
            var preferences = new List<int>();
            preferences.AddRange(sortOrder);

            var listToSort = new List<Tuple<int, string>>
                             {
                                 new Tuple<int, string>(100000000, "A"),
                                 new Tuple<int, string>(100000001, "B"),
                                 new Tuple<int, string>(100000002, "M"),
                                 new Tuple<int, string>(100000003, "E"),
                                 new Tuple<int, string>(100000004, "R"),
                                 new Tuple<int, string>(100000005, "1"),
                                 new Tuple<int, string>(100000006, "G")
                             };

            return listToSort.OrderBy(item => preferences.IndexOf(item.Item1)).ToList().Select(x => x.Item2).ToList();
        }

        public List<Tuple<int, string>> sortListByOptionSetListTuple()
        {
            int[] sortOrder = { 100000000, 100000002, 100000001, 100000003, 100000004, 100000006, 100000005 };
            var preferences = new List<int>();
            preferences.AddRange(sortOrder);

            var listToSort = new List<Tuple<int, string>>
                             {
                                 new Tuple<int, string>(100000000, "A"),
                                 new Tuple<int, string>(100000001, "B"),
                                 new Tuple<int, string>(100000002, "M"),
                                 new Tuple<int, string>(100000003, "E"),
                                 new Tuple<int, string>(100000004, "R"),
                                 new Tuple<int, string>(100000005, "1"),
                                 new Tuple<int, string>(100000006, "G")
                             };

            return listToSort.OrderBy(item => preferences.IndexOf(item.Item1)).ToList();
        }


        /// <summary>
        ///     Clears the calender rules.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        public static void ClearCalenderRules(IOrganizationService service, DateTime startDate, DateTime endDate)
        {
            //var startTest = DateTime.Parse("2019-02-21 00:00:00.000");
            //var endTest = DateTime.Parse("2019-02-21 08:30:00.000");


            //1. get calendar id
            //2. get calendar entity
            //3. removecalendarrules

            var calendar = service.Retrieve("calendar", new Guid("46EA1621-1774-4F0E-80FC-3F07C42CF8A9"), new ColumnSet(false));

            var en = default(Entity); // null
            var datetime = default(DateTime); // 01.01.0001 00:00:00
            var defaultGuid = default(Guid); // emptyGuid 
            var defaultEntityCollection = default(EntityCollection); // null
            var defaultEntityReference = default(EntityReference); //null
            var defaultList = default(List<Entity>); //null
            var defaultInt = default(int); //0
            var defaultString = default(string); //null
            var defaultDouble = default(double); //0
            var defaultQueryExpression = default(QueryExpression); // null


            var entityCollection = (EntityCollection)calendar.Attributes["calendarrules"];
            var clearedEntityCollection = new EntityCollection();
            clearedEntityCollection.Entities.AddRange(entityCollection.Entities);

            foreach (var current in entityCollection.Entities)
            {
                var start = Convert.ToDateTime(current["starttime"]);
                if (start.Date >= startDate.Date && start.Date <= endDate.Date)
                {
                    clearedEntityCollection.Entities.Remove(current);
                }
            }

            calendar.Attributes["calendarrules"] = clearedEntityCollection;

            service.Update(calendar);
        }


        private bool OnServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }

    public static class Extensions
    {
        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                   && Comparer<T>.Default.Compare(item, end) <= 0;
        }
    }


    public interface ITestClass
    {
        T GetValue2<T>(string b);
    }

    public class TestClass : ITestClass
    {
        public T GetValue2<T>(string b)
        {
            if (b.Equals("X"))
            {
                int ii = 49;
                return (T)Convert.ChangeType(ii, typeof(T));
            }

            if (b.Equals("u"))
            {
                decimal ii = 11.66m;
                return (T)Convert.ChangeType(ii, typeof(T));
            }

            return default(T);
        }
    }
}