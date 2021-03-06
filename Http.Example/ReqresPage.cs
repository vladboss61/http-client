namespace Http.Example
{
    using Newtonsoft.Json;

    internal sealed class ReqresPage
    {
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }
        
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public ReqresUser[] Data { get; set; }

        public override string ToString()
        {
            return $"Page: {Page} | PerPage: {PerPage} | Total: {Total} | TotalPages: {TotalPages}";
        }
    }
}
