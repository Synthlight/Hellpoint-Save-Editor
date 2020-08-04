using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Save_Editor.Models {
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Need to match json.")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class Slot {
        public int       index { get; set; }
        public bool      used  { get; set; }
        public List<int> items { get; set; }

        [JsonExtensionData]
#pragma warning disable 169
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0051 // Remove unused private members
        private IDictionary<string, JToken> extraStuff;
#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning restore 169

        public enum Index {
            Off_Hand       = 0,
            Main_Hand      = 1,
            Helm           = 2,
            Chest          = 3,
            Arms           = 4,
            Legs           = 5,
            Healing_Method = 7,
            Body_Module    = 8,
            Mind_Module    = 9,
            Omnicube       = 10,
        }
    }
}