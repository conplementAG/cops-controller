using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{
    public class CopsNamespace : CopsResource
    {
        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("metadata")]
        public CopsNamespaceMetadata Metadata { get; set; }

        [JsonProperty("spec")]
        public CopsSpec Spec { get; set; }

        public static CopsNamespace FromJson(string json) => JsonConvert.DeserializeObject<CopsNamespace>(json, Converter.Settings);
    }

    public class CopsNamespaceMetadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class CopsSpec
    {
        [JsonProperty("namespace-admin-users")]
        public string[] NamespaceAdminUsers { get; set; }
    }
}