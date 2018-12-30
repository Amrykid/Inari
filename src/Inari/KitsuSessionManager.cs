using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Inari
{
    public static class KitsuSessionManager
    {
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

                var responseObject = (Dictionary<string, object>)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), typeof(Dictionary<string, object>));

                var resultSession = new KitsuSession(
                    username,
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

        public static async Task PersistSessionToFileAsync(KitsuSession kitsuSession, string fileName)
        {
            if (kitsuSession == null) throw new ArgumentNullException(nameof(kitsuSession));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));

            string sessionJson = JsonConvert.SerializeObject(kitsuSession);
            await File.WriteAllTextAsync(fileName, sessionJson);
        }

        public static async Task<KitsuSession> RestoreSessionFromFileAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));
            if (!File.Exists(fileName)) throw new FileNotFoundException("File not found.", fileName: fileName);

            string sessionJson = await File.ReadAllTextAsync(fileName);
            KitsuSession kitsuSession = JsonConvert.DeserializeObject(sessionJson, typeof(KitsuSession)) as KitsuSession;

            if (kitsuSession == null) throw new Exception("Unable to restore session from file.");

            return kitsuSession;
        }
    }
}
