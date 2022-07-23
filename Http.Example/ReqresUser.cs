﻿namespace Http.Example
{
    using Newtonsoft.Json;

    internal sealed class ReqresUser
    {
        public int Id { get; set; }

        public string Email { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Avatar { get; set; }
    }
}
