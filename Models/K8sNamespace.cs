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
        public K8sNamespaceMetadata Metadata { get; set; }

        public K8sNamespace(string name)
        {
            Kind = "Namespace";
            ApiVersion = "v1";
            Metadata = new K8sNamespaceMetadata { Name = name };
        }
    }

    public class K8sNamespaceMetadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}