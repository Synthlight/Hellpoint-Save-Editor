using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Save_Editor.Models {
    public class World {
        public Guid                  breach  { get; set; }
        public int                   level   { get; set; }
        public int                   hard    { get; set; }
        public bool                  dark    { get; set; }
        public Dictionary<Guid, int> sStates { get; set; }

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