using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleApp1
{
    public class GetTokenApp
    {
        public async Task<string> ObtenerTokenAsync()
        {
            string token = string.Empty;

            OperaCloud.Oauth.Client.Client client = new OperaCloud.Oauth.Client.Client("https://mtucn1uat.hospitality-api.us-ashburn-1.ocs.oc-test.com/oauth/v1/");

            OperaCloud.Oauth.Client.OAuth2TokenResponse response = await client.GetTokenAsync(OperaCloud.Oauth.Client.Grant_type.Password, "RVILCHES", "Rosa101226aa.q", null, "742e1293-ce33-4d25-83d3-3f17af0a415b");

            if (response == null)
                throw new Exception("Respuesta en null");
            else
            {
                token = response.Access_token;
                //Console.WriteLine($"Access_token = {response.Access_token}");
                //Console.WriteLine($"Token_type = {response.Token_type}");
                //Console.WriteLine($"Oracle_tk_context = {response.Oracle_tk_context}");
                //Console.WriteLine($"Expires_in = {response.Expires_in}");

                return token;
            }
        }

        //public async Task ObtenerTokenAsync()
        //{
        //    var baseAddress = new Uri("https://mtucn1uat.hospitality-api.us-ashburn-1.ocs.oc-test.com/");

        //    using (var httpClient = new HttpClient { BaseAddress = baseAddress })
        //    {


        //        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

        //        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("x-app-key", "742e1293-ce33-4d25-83d3-3f17af0a415b");

        //        var byteAuth = Encoding.ASCII.GetBytes("RA_Client:vlcSn-8m-jfVfP68bW7v7jXK");
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteAuth));

        //        using (var content = new StringContent("grant_type=password&username=RVILCHES&password=Rosa101226aa.q", System.Text.Encoding.Default, "application/x-www-form-urlencoded"))
        //        {
        //            using (var response = await httpClient.PostAsync("oauth/v1/tokens", content))
        //            {
        //                string responseData = await response.Content.ReadAsStringAsync();
        //            }
        //        }
        //    }

        //}
    }
}
