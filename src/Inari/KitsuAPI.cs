using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inari
{
    public static class KitsuAPI
    {
        //from https://kitsu.docs.apiary.io/#reference/authentication
        internal const string ClientID = "dd031b32d2f56c990b1425efe6c42ad847e7fe3ab46bf1299f05ecd856bdb7dd";
        internal const string ClientSecret = "54d7307928f63414defd96399fc31ba847961ceaecef3a5fd93144e960c0e151";

        public static Task<object> GetTrendingAnimeAsync()
        {

        }

        public static Task<object> GetTrendingAnimeAsync(KitsuSession kitsuSession)
        {

        }
    }
}
