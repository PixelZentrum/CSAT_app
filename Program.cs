using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CRMConn
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                /* Just replace all parameters with yours and run the function directly */

                /* About 2.8s */
                // fileUpload();

                /* About 580ms */
                // sdkConn();String token = Authenticate().Result.AccessToken;
                String token = Authenticate().Result.AccessToken;

                Console.WriteLine(token);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();

        }

        //private static void sdkConn()
        //{
        //    //string ConnectionString = "AuthType = OAuth; " +
        //    //              "Username = chris@dodoanorg.onmicrosoft.com; " +
        //    //              "Password = TekErp@123; " +
        //    //              "Url = https://jacktran.crm.dynamics.com/; " +
        //    //              "AppId=51f81489-12ee-4a9e-aaae-a2591f45987d; " +
        //    //              "RedirectUri=https://asyouwish; " +
        //    //              "LoginPrompt=Auto";

        //    string higerConnectionString = "AuthType = OAuth; " +
        //                  "Username = v-almao@microsoft.com; " +
        //                  "Password = Orewa8866!; " +
        //                  "Url = https://888ab24912fa48179542b1bc36e031.crm5.dynamics.com/; " +
        //                  "AppId=51f81489-12ee-4a9e-aaae-a2591f45987d; " +
        //                  "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97; " +
        //                  "LoginPrompt=Auto";

        //    Stopwatch sw0 = new Stopwatch();

        //    Console.WriteLine("Waiting for connection...");
        //    //sw0.Start();
        //    CrmServiceClient svc = new CrmServiceClient(higerConnectionString);
        //    //sw0.Stop();
        //    //Console.WriteLine("Time eplapsed for connection: " + sw0.ElapsedMilliseconds);

        //    if (svc.IsReady)
        //    {
        //        Console.WriteLine("Ready!");

        //        OrganizationRequest request = new OrganizationRequest("ExportPdfDocument");
        //        request["EntityTypeCode"] = 1;
        //        request["SelectedTemplate"] = new EntityReference("documenttemplate", new Guid("391f28be-3dd9-eb11-bacb-000d3ac82f0a"));
        //        request["SelectedRecords"] = "[\'{" + "dfe0265d-5d02-4f0e-bd4d-734c249af1e9" + "}\']";
        //        OrganizationResponse response = (OrganizationResponse)svc.Execute(request);
        //        String b64 = Convert.ToBase64String((byte[])response["PdfFile"]);
        //        Console.WriteLine("result is: \n" + b64.Substring(1, 100));

        //        //QueryExpression qe = new QueryExpression("account");
        //        //qe.ColumnSet = new ColumnSet(true);
        //        //qe.PageInfo = new PagingInfo()
        //        //{
        //        //    Count = 20,
        //        //    PageNumber = 1
        //        //};
        //        ////Stopwatch sw = new Stopwatch();
        //        ////sw.Start();
        //        //var entity = svc.RetrieveMultiple(qe);
        //        ////sw.Stop();
        //        ////Console.WriteLine("time elapsed " + sw.ElapsedMilliseconds);
        //        //string name = entity.Entities[1].GetAttributeValue<string>("name");
        //        //Console.WriteLine("Name is " + name);
        //        //Console.WriteLine("Done!");
        //    }
        //    else
        //    {
        //        Console.WriteLine(svc.LastCrmError);
        //    }
        //}

        //private static async Task fileUpload()
        //{
        //    try
        //    {

        //        var accessToken = await AccessTokenGenerator();

        //        String fileRootPath = "D:\\Download\\test.pdf";

        //        String uploadFileName = "bec%E6%88%90%E7%BB%A9.pdf";

        //        String urlPrefix = "https://orgb4a9b304.crm.dynamics.com/api/data/v9.1/";

        //        // var filePath = Path.Combine(fileRootPath, uploadFileName);
        //        var fileStream = File.OpenRead(fileRootPath);
        //        var url = new Uri(new System.Uri(urlPrefix), "cr862_countries(cf4d890e-2230-ec11-b6e5-00224804c756)/cr862_data?x-ms-file-name=测试文件.pdf");

        //        using (var client = new HttpClient())
        //        {
        //            using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), url))
        //            {
        //                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        //                request.Content = new StreamContent(fileStream);
        //                request.Content.Headers.Add("Content-Type", "application/octet-stream");
        //                //request.Headers.Add("x-ms-file-name", uploadFileName);
        //                request.Headers.Add("accept-language", "en-US,en;q=0.9,zh-CN;q=0.8,zh;q=0.7");
        //                request.Headers.Add("accept-encoding", "gzip, deflate, br");

        //                using (var response = await client.SendAsync(request))
        //                {
        //                    if (response.IsSuccessStatusCode)
        //                    {
        //                        Console.WriteLine("Done");
        //                    }
        //                }
        //            }
        //        }

        //        //using (HttpClient client = new HttpClient())
        //        //{
        //        //    client.BaseAddress = new Uri("https://orgb4a9b304.crm.dynamics.com");
        //        //    client.Timeout = new TimeSpan(0, 2, 0);  //2 minutes  
        //        //    client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
        //        //    client.DefaultRequestHeaders.Add("OData-Version", "4.0");
        //        //    client.DefaultRequestHeaders.Accept.Add(
        //        //        new MediaTypeWithQualityHeaderValue("application/json"));
        //        //    HttpRequestMessage request =
        //        //        new HttpRequestMessage(HttpMethod.Get, "/api/data/v9.1/cr862_countries(cf4d890e-2230-ec11-b6e5-00224804c756)/cr862_data");
        //        //    //Set the access token
        //        //    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //        //    HttpResponseMessage response = client.SendAsync(request).Result;
        //        //    if (response.IsSuccessStatusCode)
        //        //    {
        //        //        //Get the response content and parse it.  
        //        //        JObject body = JObject.Parse(response.Content.ReadAsStringAsync().Result);
        //        //        //Guid userId = (Guid)body["UserId"];
        //        //        //sw.Stop();
        //        //        //Console.WriteLine("time elapsed " + sw.ElapsedMilliseconds);
        //        //        Console.WriteLine("Your system user ID is: {0}", body["name"]);
        //        //        Console.WriteLine("Done!");
        //        //    }

        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }

        //}

        //private static async Task webAPIConnAsync()
        //{
        //    try
        //    {
        //        //Stopwatch sw = new Stopwatch();
        //        //sw.Start();

        //        var accessToken = await AccessTokenGenerator();

        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://orgb4a9b304.crm.dynamics.com");
        //            client.Timeout = new TimeSpan(0, 2, 0);  //2 minutes  
        //            client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
        //            client.DefaultRequestHeaders.Add("OData-Version", "4.0");
        //            client.DefaultRequestHeaders.Accept.Add(
        //                new MediaTypeWithQualityHeaderValue("application/json"));
        //            HttpRequestMessage request =
        //                new HttpRequestMessage(HttpMethod.Get, "/api/data/v9.2/accounts(d9671363-04f4-eb11-94ef-0022480a78f6)");
        //            //Set the access token
        //            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        //            HttpResponseMessage response = client.SendAsync(request).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                //Get the response content and parse it.  
        //                JObject body = JObject.Parse(response.Content.ReadAsStringAsync().Result);
        //                //Guid userId = (Guid)body["UserId"];
        //                //sw.Stop();
        //                //Console.WriteLine("time elapsed " + sw.ElapsedMilliseconds);
        //                Console.WriteLine("Your system user ID is: {0}", body["name"]);
        //                Console.WriteLine("Done!");
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }

        //}

        // Obtain MS token using credential directly
        private static async Task<AuthenticationResult> Authenticate()
        {
            string userName = "admin@CRM302072.OnMicrosoft.com";
            string password = "8k583mH6XH";
            string clientId = "9f04b76a-dd2a-48ef-99ac-c9fdc17330ad";
            var credentials = new UserPasswordCredential(userName, password);
            var authenticationContext = new AuthenticationContext("https://login.microsoftonline.com/common/");
            var result = await authenticationContext.AcquireTokenAsync("https://org639ab8b4.crm5.dynamics.com/", clientId, credentials);
            return result;
        }

        // Obtain MS token using client secret
        //public static async Task<string> AccessTokenGenerator()
        //{
        //    string clientId = "508a9c5b-7e72-4b79-a4ee-f562b97b281a";
        //    string clientSecret = "BOr7Q~O-ymjLzauymQSm~iF.HiQ3Yw_VAW6Ei";
        //    string authority = "https://login.microsoftonline.com/cc8bc80a-53ee-4936-b275-7d5878405bb0";
        //    string resourceUrl = "https://orgb4a9b304.crm.dynamics.com"; // Org URL  

        //    ClientCredential credentials = new ClientCredential(clientId, clientSecret);
        //    var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authority);
        //    var result = await authContext.AcquireTokenAsync(resourceUrl, credentials);
        //    return result.AccessToken;
        //}
    }
}