using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{
    public partial class K8sMetadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }
    }
}
