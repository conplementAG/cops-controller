using ConplementAG.CopsController.Models;
using Newtonsoft.Json.Linq;
using System;

namespace ConplementAG.CopsController.Services
{
    public static class CopsResourceFactory
    {
        public static CopsResource Create(JObject value)
        {
            var kind = value["parent"]["kind"];

            switch (kind.ToString().ToLower())
            {
                case "copsnamespace":
                    return CopsNamespace.FromJson(value["parent"].ToString());
                default:
                    throw new ArgumentException($"Unknown CopsResource of kind {kind}");
            }
        }
    }
}
