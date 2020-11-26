using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Save_Editor.Models {
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Need to match json.")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
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

        [JsonIgnore]
        public int characterLevel => computeLevel(stats);

        [JsonIgnore]
        public Slot slotMainHand => slots[(int) Slot.Index.Main_Hand];

        [JsonIgnore]
        public Slot slotOffHand => slots[(int) Slot.Index.Off_Hand];

        [JsonIgnore]
        public Slot slotHead => slots[(int) Slot.Index.Head];

        [JsonIgnore]
        public Slot slotChest => slots[(int) Slot.Index.Chest];

        [JsonIgnore]
        public Slot slotArms => slots[(int) Slot.Index.Arms];

        [JsonIgnore]
        public Slot slotLegs => slots[(int) Slot.Index.Legs];

        [JsonIgnore]
        public Slot slotBodyModule => slots[(int) Slot.Index.Body_Module];

        [JsonIgnore]
        public Slot slotMindModule => slots[(int) Slot.Index.Mind_Module];

        [JsonIgnore]
        public Slot slotHealingMethod => slots[(int) Slot.Index.Healing_Method];

        [JsonIgnore]
        public Slot slotOmnicube => slots[(int) Slot.Index.Omnicube];

        [JsonIgnore]
        public Dictionary<int, Item> mainHandWithNegativeOne => GetDataOfTypeWithNegativeOne(Data.MAIN_HAND);

        [JsonIgnore]
        public Dictionary<int, Item> offHandWithNegativeOne => GetDataOfTypeWithNegativeOne(Data.OFF_HAND);

        [JsonIgnore]
        public Dictionary<int, Item> armorWithNegativeOne => GetDataOfTypeWithNegativeOne(Data.ARMOR);

        [JsonIgnore]
        public Dictionary<int, Item> bodyModuleWithNegativeOne => GetDataOfTypeWithNegativeOne(Data.MODULES_BODY);

        [JsonIgnore]
        public Dictionary<int, Item> mindModuleWithNegativeOne => GetDataOfTypeWithNegativeOne(Data.MODULES_MIND);

        [JsonIgnore]
        public Dictionary<int, Item> healingMethodWithNegativeOne => GetDataOfTypeWithNegativeOne(Data.HEALING_METHOD);

        [JsonIgnore]
        public Dictionary<int, Item> omnicubeWithNegativeOne => GetDataOfTypeWithNegativeOne(Data.OMNICUBE);

        private Dictionary<int, Item> GetDataOfTypeWithNegativeOne(IReadOnlyDictionary<Guid, string> dataSource) {
            var dict     = new Dictionary<int, Item> {{-1, new Item(Guid.Empty) {nameOverride = "[None]"}}};
            var dictTemp = new Dictionary<int, Item>();

            for (var i = 0; i < items.Count; i++) {
                if (dataSource.ContainsKey(items[i].id)) {
                    dictTemp.Add(i, items[i]);
                }
            }

            dictTemp.OrderBy(pair => pair.Value.nameOrId).CopyTo(dict);

            return dict;
        }

        private int computeLevel(int[] statsArray) {
            int cLevel = 0, i;

            for (i = 0; i < stats.Length; i++) {
                cLevel += statsArray[i];
            }

            cLevel -= 7;

            return cLevel;
        }

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