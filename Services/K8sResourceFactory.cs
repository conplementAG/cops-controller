using ConplementAG.CopsController.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConplementAG.CopsController.Services
{
    public class K8sResourceFactory
    {
        public static IList<object> Create(CopsResource resource, string namespaceAdminRole)
        {
            var source = Convert.ChangeType(resource, resource.GetType());

            var method = typeof(K8sResourceFactory).GetMethod("Create", BindingFlags.NonPublic | BindingFlags.Static);
            return (IList<object>)method.Invoke(null, new[] { source, namespaceAdminRole });
        }

        // Method used by reflection call
        private static IList<object> Create(CopsNamespace copsNamespace, string namespaceAdminRole)
        {
            return new List<object>
            {
                new K8sNamespace(copsNamespace.Metadata.Name, copsNamespace.Spec.Project?.Name, copsNamespace.Spec.Project?.CostCenter),
                K8sRoleBinding.NamespaceFullAccess(copsNamespace.Metadata.Name, copsNamespace.Spec.NamespaceAdminUsers,
                    copsNamespace.Spec.NamespaceAdminServiceAccounts ??  new List<CopsAdminServiceAccountSpec>().ToArray(),
                    namespaceAdminRole),
                K8sClusterRoleBinding.CopsNamespaceEditBinding(copsNamespace.Metadata.Name, copsNamespace.Spec.NamespaceAdminUsers,
                    copsNamespace.Spec.NamespaceAdminServiceAccounts ??  new List<CopsAdminServiceAccountSpec>().ToArray()),
                K8sClusterRole.CopsNamespaceEdit(copsNamespace.Metadata.Name),
                K8SLimitRange.Default(copsNamespace.Metadata.Name)
            };
        }
    }
}
