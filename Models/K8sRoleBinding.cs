using System;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

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

        public static K8sRoleBinding NamespaceFullAccess(string namespacename, 
            ICollection<string> users, ICollection<CopsAdminServiceAccountSpec> serviceAccounts)
        {
            if (string.IsNullOrEmpty(namespacename))
            {
                throw new ArgumentException("Namespace was expected to be defined", nameof(namespacename));
            }

            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            if (serviceAccounts == null)
            {
                throw new ArgumentNullException(nameof(serviceAccounts));
            }

            if (!users.Any()) {
                throw new ArgumentException("Users collection should not be empty since this expected as a mandatory parameter!");
            }

            // this is the binding for admin users to get full access inside a cops namespace. The cluster role itself is 
            // not managed by the controller since it is a static resource deployed with rest of the static resources 
            // (check the Helm chart)
            var roleBinding = new K8sRoleBinding
            {
                Kind = "RoleBinding",
                ApiVersion = "rbac.authorization.k8s.io/v1",
                Metadata = new K8sMetadata { Name = $"copsnamespace-user", Namespace = namespacename },
                // the in-built clusterrole edit has all the api resources and CRDs aalways up to date,
                // so we use that clusterrole instead of writing our own which is far more brittle
                RoleRef = new K8sRoleRef("ClusterRole", "edit", "rbac.authorization.k8s.io")
            };

            var subjects = users.ToList()
                    .Select(user => { return new K8sUserSubjectItem(user, "rbac.authorization.k8s.io"); }).ToList<K8sSubjectBaseItem>()
                .Concat(serviceAccounts.ToList()
                    .Select(sa => 
                    {
                        return new K8sServiceAccountSubjectItem(sa.ServiceAccount, sa.Namespace); 
                    }).ToList<K8sSubjectBaseItem>()
                );

            roleBinding.Subjects = subjects.ToArray();

            return roleBinding;
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
}
