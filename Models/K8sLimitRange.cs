using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{
    public class K8SLimitRange
    {
        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("metadata")]
        public K8sMetadata Metadata { get; set; }

        [JsonProperty("spec")]
        public K8sSpec Spec { get; set; }

        public static K8SLimitRange Default(string namespacename)
        {
            return new K8SLimitRange
            {
                Kind = "LimitRange",
                ApiVersion = "v1",
                Metadata = new K8sMetadata { Name = "copsnamespace-default-limitrange", Namespace = namespacename },
                Spec = new K8sSpec
                {
                    Limits = new[]
                    {
                        new K8sLimit{
                            Default = new K8sDefault {Cpu = "20m", Memory = "50Mi"},
                            DefaultRequest = new K8sDefault {Cpu = "10m", Memory = "25Mi"},
                            Type = "Container"
                        }
                    }
                }
            };
        }
    }

    public class K8sSpec
    {
        [JsonProperty("limits")]
        public K8sLimit[] Limits { get; set; }
    }

    public class K8sLimit
    {
        [JsonProperty("default")]
        public K8sDefault Default { get; set; }

        [JsonProperty("defaultRequest")]
        public K8sDefault DefaultRequest { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class K8sDefault
    {
        [JsonProperty("cpu")]
        public string Cpu { get; set; }

        [JsonProperty("memory")]
        public string Memory { get; set; }
    }
}
