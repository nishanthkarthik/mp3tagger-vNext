using System.Collections.Generic;
using Newtonsoft.Json;
// ReSharper disable InconsistentNaming

namespace EasyTag.MVVM
{
    public class GaanaMeta
    {
        public int count { get; set; }

        public List<Track> tracks { get; set; }

        public int user_token_status { get; set; }

        [JsonProperty("user-token-status")]
        public int user_token_status_hyphen { get; set; }
    }
}