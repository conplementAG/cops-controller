using ConplementAG.CopsController.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConplementAG.CopsController.Services
{
    public class K8sResourceFactory
    {
        public static Tuple<IList<object>, object> Create(CopsResource resource)
        {
            var source = Convert.ChangeType(resource, resource.GetType());

            var method = typeof(K8sResourceFactory).GetMethod("Create", BindingFlags.NonPublic | BindingFlags.Static);
            return (Tuple<IList<object>, object>)method.Invoke(null, new[] { source });
        }

        // Methode used by reflection call
        private static Tuple<IList<object>, object> Create(CopsNamespace copsNamespace)
        {
            return Tuple.Create<IList<object>, object>(new List<object>
            {
                new K8sNamespace(copsNamespace.Metadata.Name),
                K8sRole.NamespaceFullAccess(copsNamespace.Metadata.Name),
                K8sRoleBinding.NamespaceFullAccess(copsNamespace.Metadata.Name, copsNamespace.Spec.NamespaceAdminUsers)
            }, copsNamespace.Status ?? new CopsStatus { Name = copsNamespace.Metadata.Name, Namespaces = 1 });
        }
    }
}
