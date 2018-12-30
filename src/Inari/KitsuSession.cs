using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security;
using System.Threading.Tasks;

namespace Inari
{
    //https://kitsu.docs.apiary.io/#

    [DataContract]
    public class KitsuSession: IDisposable
    {
        [DataMember]
        public string UserName { get; private set; }
        [DataMember]
        public string Access_Token { get; private set; }
        [DataMember]
        public int Created_At { get; private set; }
        [DataMember]
        public int Expires_In { get; private set; }
        [DataMember]
        public string Refresh_Token { get; private set; }
        [DataMember]
        public string Scope { get; private set; }
        [DataMember]
        public string Token_Type { get; private set; }

        [JsonConstructor]
        internal KitsuSession(string userName, string access_token, int created_at, int expires_in, string refresh_token, string scope, string token_type)
        {
            //todo error check
            UserName = userName;
            Access_Token = access_token;
            Created_At = created_at;
            Expires_In = expires_in;
            Refresh_Token = refresh_token;
            Scope = scope;
            Token_Type = token_type;
        }

        public void Dispose()
        {
            return;
        }
    }
}
