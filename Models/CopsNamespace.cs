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
        [JsonProperty("namespaceAdminUsers")]
        public string[] NamespaceAdminUsers { get; set; }

        [JsonProperty("namespaceAdminServiceAccounts")]
        public CopsAdminServiceAccountSpec[] NamespaceAdminServiceAccounts { get; set; }
    }

    public class CopsAdminServiceAccountSpec
    {
        [JsonProperty("serviceAccount")]
        public string ServiceAccount { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }
    }
}