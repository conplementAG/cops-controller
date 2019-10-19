using ConplementAG.CopsController.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConplementAG.CopsController.Services
{
    public class K8sResourceFactory
    {
        public static IList<object> Create(CopsResource resource)
        {
            var source = Convert.ChangeType(resource, resource.GetType());

            var method = typeof(K8sResourceFactory).GetMethod("Create", BindingFlags.NonPublic | BindingFlags.Static);
            return (IList<object>)method.Invoke(null, new[] { source });
        }

        // Methode used by reflection call
        private static IList<object> Create(CopsNamespace copsNamespace)
        {
            return new List<object>
            {
                new K8sNamespace(copsNamespace.Metadata.Name),
                K8sRoleBinding.NamespaceFullAccess(copsNamespace.Metadata.Name, copsNamespace.Spec.NamespaceAdminUsers),
                K8sClusterRoleBinding.CopsNamespaceEditBinding(copsNamespace.Metadata.Name, copsNamespace.Spec.NamespaceAdminUsers),
                K8sClusterRole.CopsNamespaceEdit(copsNamespace.Metadata.Name)
            };
        }
    }
}
