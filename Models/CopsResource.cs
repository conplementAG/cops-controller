using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{
    public abstract class CopsResource
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("status")]
        public CopsStatus Status { get; set; }

    }

    public class CopsStatus
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("namespaces")]
        public int Namespaces { get; set; }
    }

}