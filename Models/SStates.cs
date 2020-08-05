using System;
using System.Collections.Generic;

namespace Save_Editor.Models {
    public class SStates {
        private readonly Dictionary<Guid, int> source;

        public SStates(Dictionary<Guid, int> source, Guid key) {
            this.source = source;
            Id          = key;
        }

        public Guid   Id   { get; }
        public string Name => Data.ALL_IDS.ContainsKey(Id) ? Data.ALL_IDS[Id] : "";
        public int Value {
            get => source[Id];
            set => source[Id] = value;
        }
    }
}