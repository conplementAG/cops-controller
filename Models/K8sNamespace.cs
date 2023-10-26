using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{
    public class K8sNamespace
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("metadata")]
        public K8sNamespaceMetadata Metadata { get; set; }

        public K8sNamespace(string name, string projectName, string projectCostCenter)
        {
            Kind = "Namespace";
            ApiVersion = "v1";
            Metadata = new K8sNamespaceMetadata(name, projectName, projectCostCenter);
        }
    }

    public class K8sNamespaceMetadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("labels")]
        public Dictionary<string, string> Labels { get; set; }

        public K8sNamespaceMetadata(string name, string projectName, string projectCostCenter)
        {
            Name = name;
            Labels = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(projectName))
            {
                Labels.Add("conplement.de/project-name", projectName);
            }

            if (!string.IsNullOrWhiteSpace(projectName))
            {
                Labels.Add("conplement.de/project-cost-center", projectCostCenter);
            }
        }
    }
}