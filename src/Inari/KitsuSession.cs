using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security;
using System.Threading.Tasks;

namespace Inari
{
    //https://kitsu.docs.apiary.io/#

    public class KitsuSession: IDisposable
    {
        public string Access_Token { get; private set; }
        public int Created_At { get; private set; }
        public int Expires_In { get; private set; }
        public string Refresh_Token { get; private set; }
        public string Scope { get; private set; }
        public string Token_Type { get; private set; }

        internal KitsuSession(string access_token, int created_at, int expires_in, string refresh_token, string scope, string token_type)
        {
            //todo error check
            Access_Token = access_token;
            Created_At = created_at;
            Expires_In = expires_in;
            Refresh_Token = refresh_token;
            Scope = scope;
            Token_Type = token_type;
        }

        public static async Task<KitsuSession> BeginSession(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));

            //At the time of writing, Kitsu.io only supports username/password authentication.

            //Lets reinvent the wheel
            using (HttpClient httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://kitsu.io/api/oauth/token");

                request.Headers.TryAddWithoutValidation("client_id", KitsuAPI.ClientID);
                request.Headers.TryAddWithoutValidation("client_secret", KitsuAPI.ClientSecret);

                request.Content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });
                request.Headers.Add("Accept", "application/vnd.api+json");
                //request.Content.Headers.Add("Content-Type", "application/vnd.api+json");

                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                
                var responseObject = (Dictionary<string, object>)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(),typeof(Dictionary<string,object>));

                var resultSession = new KitsuSession(
                    responseObject["access_token"].ToString(), 
                    int.Parse(responseObject["created_at"].ToString()),
                    int.Parse(responseObject["expires_in"].ToString()),
                    responseObject["refresh_token"].ToString(),
                    responseObject["scope"].ToString(),
                    responseObject["token_type"].ToString());

                return resultSession;
            }

            return null;
        }

        public void Dispose()
        {
            return;
        }
    }
}
