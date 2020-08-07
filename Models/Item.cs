using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Save_Editor.Models {
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Need to match json.")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class Item {
        public Item() {
        }

        public Item(Guid guid) {
            id        = guid;
            count     = 1;
            selection = 0;
            values    = new[] {0, 0, 0, 0, 0, 0, 0, 0};
            sockets   = new[] {-1, -1, -1, -1, -1, -1, -1, -1};
        }

        [JsonIgnore]
        public int index;

        [JsonIgnore]
        public int Index => index;

        public Guid id { get; set; }

        [JsonIgnore]
        public string nameOverride = "";

        [JsonIgnore]
        public string name => Data.ALL_IDS.ContainsKey(id) ? Data.ALL_IDS[id] : nameOverride;

        [JsonIgnore]
        public string nameOrId => name == "" ? id.ToString() : name;

        public uint  count     { get; set; }
        public int   selection { get; set; }
        public int[] values    { get; set; }
        public int[] sockets   { get; set; }

        [JsonExtensionData]
#pragma warning disable 169
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0051 // Remove unused private members
        private IDictionary<string, JToken> extraStuff;
#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning restore 169
    }
}