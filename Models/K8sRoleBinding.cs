using Newtonsoft.Json;
using System.Linq;

namespace ConplementAG.CopsController.Models
{
    public class K8sRoleBinding
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

        public static K8sRoleBinding NamespaceFullAccess(string namespacename, string[] users)
        {
            var roleBinding = new K8sRoleBinding
            {
                Kind = "RoleBinding",
                ApiVersion = "rbac.authorization.k8s.io/v1",
                Metadata = new K8sMetadata { Name = $"copsnamespace-full-access-rolebinding", Namespace = namespacename },
                RoleRef = new K8sRoleRef("ClusterRole", "copsnamespace-full-access-role", "rbac.authorization.k8s.io")
            };

            var subjects = users.ToList().Select(user => { return new K8sUserSubjectItem(user, "rbac.authorization.k8s.io"); }).ToList<K8sSubjectBaseItem>();
            subjects.Add(new K8sServiceAccountSubjectItem("default", namespacename));
            roleBinding.Subjects = subjects.ToArray();

            return roleBinding;
        }

        public static K8sRoleBinding CopsNamespaceEdit(string namespacename, string[] users)
        {
            return new K8sRoleBinding
            {
                Kind = "RoleBinding",
                ApiVersion = "rbac.authorization.k8s.io/v1",
                Metadata = new K8sMetadata { Name = $"{namespacename}-copsnamespace-edit-rolebinding", Namespace = namespacename },
                RoleRef = new K8sRoleRef("ClusterRole", $"{namespacename}-copsnamespace-edit-role", "rbac.authorization.k8s.io"),
                Subjects = users.ToList().Select(user => { return new K8sUserSubjectItem(user, "rbac.authorization.k8s.io"); }).ToList<K8sSubjectBaseItem>().ToArray()
            };
        }
    }

    public class K8sRoleRef
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("apiGroup")]
        public string ApiGroup { get; set; }

        public K8sRoleRef(string kind, string name, string apigroup)
        {
            Kind = kind;
            Name = name;
            ApiGroup = apigroup;
        }
    }

    public abstract class K8sSubjectBaseItem
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public K8sSubjectBaseItem(string kind, string name)
        {
            Kind = kind;
            Name = name;
        }
    }

    public class K8sUserSubjectItem : K8sSubjectBaseItem
    {
        [JsonProperty("apiGroup")]
        public string ApiGroup { get; set; }

        public K8sUserSubjectItem(string name, string apigroup) : base("User", name)
        {
            ApiGroup = apigroup;
        }
    }

    public class K8sServiceAccountSubjectItem : K8sSubjectBaseItem
    {
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        public K8sServiceAccountSubjectItem(string name, string @namespace) : base("ServiceAccount", name)
        {
            Namespace = @namespace;
        }
    }
}
