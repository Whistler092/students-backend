using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            try
            {
                return Ok(SendNotification("/notificaciones-de60c/", "Hola", value));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
                //return InternalServerError(ex);
            }

        }

        public async Task<bool> SendNotification(string to, string title, string body)
        {
            string serverKey = "AAAA6OALt28:APA91bGizasrXHcGFTeivMcY8zj9h-JGM7nzifPBogWtlzONcmh21lbGc7qFsWAWynnMa6rykMxewvpyCNfxBoPH0OlwwlaQa-G3AAjuC4gh1Xc2NJQRdTIjAlvJrSgjatXLqFxbpiQ2";
            string senderId = "1000191276911";
            string webAddr = "https://fcm.googleapis.com/fcm/send";

            try
            {
                // Get the server key from FCM console
                serverKey = string.Format("key={0}", serverKey);

                // Get the sender id from FCM console
                senderId = string.Format("id={0}", senderId);

                var data = new
                {
                    to, // Recipient device token
                    notification = new { title, body }
                };

                // Using Newtonsoft.Json
                var jsonBody = JsonConvert.SerializeObject(data);

                using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, webAddr))
                {
                    httpRequest.Headers.TryAddWithoutValidation("Authorization", serverKey);
                    httpRequest.Headers.TryAddWithoutValidation("Sender", senderId);
                    httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient())
                    {
                        var result = await httpClient.SendAsync(httpRequest);

                        if (result.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {
                            // Use result.StatusCode to handle failure
                            // Your custom error handler here
                            throw new ArgumentException($"Error sending notification. Status Code: {result.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Exception thrown in Notify Service: {ex}");
            }
            return false;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
