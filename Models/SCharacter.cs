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
    public class SCharacter {
        public Guid id { get; set; }

        [JsonIgnore]
        public string name => Data.ALL_IDS.ContainsKey(id) ? Data.ALL_IDS[id] : "";

        [JsonIgnore]
        public string factionName => Data.COVENANTS.ContainsKey(id) ? Data.COVENANTS[id] : "";

        [JsonIgnore]
        public string factionNameOrId => factionName == "" ? factionId.ToString() : factionName;

        public Guid  factionId { get; set; }
        public float x         { get; set; }
        public float y         { get; set; }
        public float z         { get; set; }
        public float rotation  { get; set; }
        public bool  alive     { get; set; }
        public long  deathTime { get; set; }
        public bool  looted    { get; set; }
        public long  seed      { get; set; }

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