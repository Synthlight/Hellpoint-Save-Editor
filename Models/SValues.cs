using System.Collections.Generic;

namespace Save_Editor.Models {
    public class SValues {
        private readonly Dictionary<string, int> source;

        public SValues(Dictionary<string, int> source, string key) {
            this.source = source;
            Id          = key;
        }

        public string Id   { get; }
        public string Name => Data.S_VALUES.ContainsKey(Id) ? Data.S_VALUES[Id] : "";
        public int Value {
            get => source[Id];
            set => source[Id] = value;
        }
    }
}