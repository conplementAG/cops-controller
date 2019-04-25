using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{
    public class K8sRole
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("metadata")]
        public K8sMetadata Metadata { get; set; }

        [JsonProperty("rules")]
        public K8sRule[] Rules { get; set; }

        public static K8sRole NamespaceFullAccess(string namespacename)
        {
            return new K8sRole
            {
                Kind = "Role",
                ApiVersion = "rbac.authorization.k8s.io/v1beta1",
                Metadata = new K8sMetadata { Name = $"{namespacename}-user-full-access-role", Namespace = namespacename },
                Rules = new K8sRule[]
                {
                    new K8sRule(new[]{ "rbac.authorization.k8s.io" }, new[]{ "rolebindings", "roles" },new[]{ "list", "get" }),
                    new K8sRule(new[]{ "autoscaling" }, new[]{ "*" },new[]{ "*" }),
                    new K8sRule(new[]{ "", "extensions", "apps", "batch" }, new[]{ "*" },new[]{ "*" }),
                    new K8sRule(new[]{ "monitoring.coreos.com" }, new[]{ "servicemonitors" },new[]{ "*" })
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

        [JsonProperty("verbs")]
        public string[] Verbs { get; set; }

        public K8sRule(string[] apiGroups, string[] resources, string[] verbs)
        {
            ApiGroups = apiGroups;
            Resources = resources;
            Verbs = verbs;
        }
    }
}
