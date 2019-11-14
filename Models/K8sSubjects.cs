using Newtonsoft.Json;

namespace ConplementAG.CopsController.Models
{   
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
