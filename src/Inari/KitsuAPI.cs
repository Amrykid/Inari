using Inari.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using System;

namespace Inari
{
    public static class KitsuAPI
    {
        //from https://kitsu.docs.apiary.io/#reference/authentication
        internal const string ClientID = "dd031b32d2f56c990b1425efe6c42ad847e7fe3ab46bf1299f05ecd856bdb7dd";
        internal const string ClientSecret = "54d7307928f63414defd96399fc31ba847961ceaecef3a5fd93144e960c0e151";
        internal const string APIPath = "https://kitsu.io/api/edge";

        private static async Task<string> GetJsonAsync(string path, KitsuSession kitsuSession = null)
        {
            HttpClient httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, APIPath + path);

            request.Headers.TryAddWithoutValidation("client_id", KitsuAPI.ClientID);
            request.Headers.TryAddWithoutValidation("client_secret", KitsuAPI.ClientSecret);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.api+json");

            if (kitsuSession != null)
                request.Headers.TryAddWithoutValidation("Authorization", "Bearer" + kitsuSession.Access_Token);

            var response = await httpClient.SendAsync(request);
            httpClient.Dispose();

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<IEnumerable<TrendingAnime>> GetTrendingAnimeAsync(KitsuSession kitsuSession = null)
        {
            var jsonResponse = await GetJsonAsync("/trending/anime", kitsuSession);

            var responseObject = (TrendingAnimeContainer)JsonConvert.DeserializeObject(jsonResponse, typeof(TrendingAnimeContainer));

            return responseObject.Data;
        }

        public static async Task<IEnumerable<TrendingManga>> GetTrendingMangaAsync(KitsuSession kitsuSession = null)
        {
            var jsonResponse = await GetJsonAsync("/trending/manga", kitsuSession);

            var responseObject = (TrendingMangaContainer)JsonConvert.DeserializeObject(jsonResponse, typeof(TrendingMangaContainer));

            return responseObject.Data;
        }

        public static Task<Anime> GetMangaByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public static Task<Manga> GetAnimeByIDAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
