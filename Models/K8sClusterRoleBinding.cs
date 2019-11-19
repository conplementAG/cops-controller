using System.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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

        public static K8sClusterRoleBinding CopsNamespaceEditBinding(string namespacename, ICollection<string> users, ICollection<CopsAdminServiceAccountSpec> serviceAccounts)
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

            var subjects = users.ToList()
                    .Select(user => { return new K8sUserSubjectItem(user, "rbac.authorization.k8s.io"); }).ToList<K8sSubjectBaseItem>()
                .Concat(serviceAccounts.ToList()
                    .Select(sa => 
                    { 
                        return new K8sServiceAccountSubjectItem(sa.ServiceAccount, sa.Namespace); 
                    }).ToList<K8sSubjectBaseItem>()
                );

            // this is the concrete binding of admin users to the cops namespace edit role (which allows for the edit / delete of own namespaces)
            return new K8sClusterRoleBinding
            {
                Kind = "ClusterRoleBinding",
                ApiVersion = "rbac.authorization.k8s.io/v1",
                Metadata = new K8sMetadata { Name = $"copsnamespace-editor-{namespacename}" },
                RoleRef = new K8sRoleRef("ClusterRole", $"copsnamespace-editor-{namespacename}", "rbac.authorization.k8s.io"),
                Subjects = subjects.ToArray()
            };
        }
    }
}
