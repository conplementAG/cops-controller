using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{
    public class K8sNamespace
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        public K8sNamespace(string name)
        {
            Kind = "Namespace";
            ApiVersion = "v1";
            Metadata = new Metadata { Name = name };
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Converter.Settings);
    }

    public partial class Metadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}