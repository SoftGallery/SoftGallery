using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftGallery.Dominio.Entidades
{
    public class AuthResponse
    {
        [JsonProperty("data")]
        public AuthData Data { get; set; }
    }

    public class AuthData
    {
        [JsonProperty("data")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("expire_date")]
        public DateTime ExpireDate { get; set; }

        [JsonProperty("gmt_offset")]
        public DateTime GmtOffset { get; set; }
    }
}
