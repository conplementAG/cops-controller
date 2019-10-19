using System.Linq;
using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{
    public class K8sClusterRoleBinding
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("metadata")]
        public K8sMetadata Metadata { get; set; }

        [JsonProperty("subjects")]
        public K8sSubjectBaseItem[] Subjects { get; set; }

        [JsonProperty("roleRef")]
        public K8sRoleRef RoleRef { get; set; }

        public static K8sClusterRoleBinding CopsNamespaceEditBinding(string namespacename, string[] users)
        {
            return new K8sClusterRoleBinding
            {
                Kind = "ClusterRoleBinding",
                ApiVersion = "rbac.authorization.k8s.io/v1",
                Metadata = new K8sMetadata { Name = $"{namespacename}-copsnamespace-edit-clusterrolebinding" },
                RoleRef = new K8sRoleRef("ClusterRole", $"{namespacename}-copsnamespace-edit-role", "rbac.authorization.k8s.io"),
                Subjects = users.ToList().Select(user => { return new K8sUserSubjectItem(user, "rbac.authorization.k8s.io"); }).ToList<K8sSubjectBaseItem>().ToArray()
            };
        }
    }
}
