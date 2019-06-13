using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{
    public class K8sClusterRole
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("metadata")]
        public K8sMetadata Metadata { get; set; }

        [JsonProperty("rules")]
        public K8sRule[] Rules { get; set; }

        public static K8sClusterRole NamespaceCopsResourceEdit(string namespacename)
        {
            return new K8sClusterRole
            {
                Kind = "ClusterRole",
                ApiVersion = "rbac.authorization.k8s.io/v1beta1",
                Metadata = new K8sMetadata { Name = $"{namespacename}-copsnamespace-edit-role", Namespace = namespacename },
                Rules = new K8sRule[]
                {
                    new K8sRule(new[]{ "coreops.conplement.cloud" }, new[]{ "CopsNamespace" }, new[] { namespacename }, new[]{ "get", "list", "update", "delete" })
                }
            };
        }
    }

    public partial class K8sRule
    {
        [JsonProperty("apiGroups")]
        public string[] ApiGroups { get; set; }

        [JsonProperty("resources")]
        public string[] Resources { get; set; }

        [JsonProperty("resourceNames")]
        public string[] ResourceNames { get; set; }

        [JsonProperty("verbs")]
        public string[] Verbs { get; set; }

        public K8sRule(string[] apiGroups, string[] resources, string[] resourceNames, string[] verbs)
        {
            ApiGroups = apiGroups;
            Resources = resources;
            ResourceNames = resourceNames;
            Verbs = verbs;
        }
    }
}
