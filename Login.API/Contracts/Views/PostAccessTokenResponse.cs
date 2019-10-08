
using System;
using Newtonsoft.Json;

namespace Login.API.Contracts.Views {
    public class PostAccessTokenResponse {
        [JsonProperty("access_token")]
        public string AccessToken {get;set;}
        [JsonProperty("expires")]
        public long Expires { get; set; }
    }
}