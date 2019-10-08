using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.Contracts.Views
{
    public class PostTokenRequest
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }
        [JsonProperty("scope")]
        public string scope { get; set; }
        [JsonProperty("user")]
        public string user { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
    }
}
