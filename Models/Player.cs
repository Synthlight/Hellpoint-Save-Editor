using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Save_Editor.Models {
    public class Player {
        public int                        healingLevel { get; set; }
        public int                        currency     { get; set; }
        public float                      health       { get; set; }
        public float                      energy       { get; set; }
        public float                      healing      { get; set; }
        public int[]                      stats        { get; set; }
        public Guid                       covenant     { get; set; }
        public ObservableCollection<Item> items        { get; set; }
        public List<Slot>                 slots        { get; set; }

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