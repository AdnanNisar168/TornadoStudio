using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;


using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010;
using System.Threading.Tasks;
using System.Text;
using Dapper;
using tornadoStudio.Areas.Base.Models.ViewModels;

using System.Web.Http.Cors;
using System.Data;
using tornadoStudio.TornadoLibrary;
using System.Net;

namespace tornadoStudio.Areas.Base.Controllers
{
    public class WhatsAppController : ApiController
    {
        //public ActionResult Post([FromBody] string message)
        //{
        //    TwilioClient.Init();
        //    return Ok("ok");
        //}

        //static void Main()
        //{
        //    SendHttpPostRequest().Wait();
        //}
        //public ActionResult Index()
        //{
        //    await SendHttpPostRequest().Wait();
        //}

            //to be tested
        //
        static async Task SendHttpPostRequest()
        {
            // Define the URL and access token
            string url = "https://graph.facebook.com/v17.0/159326823940514/messages";
            string accessToken = "EAAPZAtRUS4pgBO61WeVsTeZCIFNdeHYIeMp8YiwZCfRLpKGmCzkpALXZBD3mMvkuZAJNODJZCughSylw6LSjPO3JUQGmlBCLjVqtaEoYKopS9gBugMR6fN3QTalZCUuAxZCfkzla42NwC6PZBSHPh1UpoKFTZAHQEO1ahNJ1bxISG80KGQjVtOjcuHbZBvdH9EkbZAiFFeMoAnakabAIJfkZD";

            // Define the JSON payload for the request
            string jsonPayload = "{\"messaging_product\": \"whatsapp\", \"to\": \"923164116593\", \"type\": \"template\", \"template\": { \"name\": \"hello_world\", \"language\": { \"code\": \"en_US\" } } }";

            // Create a new HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                // Add the Authorization header
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                // Add the Content-Type header
                httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

                // Create a StringContent from the JSON payload
                StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    // Request was successful
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + responseContent);
                }
                else
                {
                    // Request failed
                    Console.WriteLine("Request failed with status code: " + response.StatusCode);
                }
            }
        }

        


    }
}
