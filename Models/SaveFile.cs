using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Save_Editor.Models {
    public class SaveFile {
        public Guid   id        { get; set; }
        public bool   erased    { get; set; }
        public string user      { get; set; }
        public string name      { get; set; }
        public long   time      { get; set; }
        public long   totalTime { get; set; }
        public World  world     { get; set; }
        public Player player    { get; set; }
        public Player ghost     { get; set; }

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