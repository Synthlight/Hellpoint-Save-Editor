using System;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using Save_Editor.Models;

namespace Save_Editor {
    public partial class MainWindow {
        private static readonly string TARGET_FOLDER = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%Low\Cradle Games\Hellpoint\");
        private const           string CMP_FILE      = @"R:\Games\Hellpoint\Save Compare\S1.json";

        public SaveFile saveFile { get; private set; }
        public string   targetFile;

        public MainWindow() {
            if (!LoadFile()) {
                Application.Current.Shutdown();
                return;
            }

            if (!Data.BREACHES.ContainsKey(saveFile.world.breach)) {
                Data.BREACHES.Add(saveFile.world.breach, $"Unknown ({saveFile.world.breach})");
            }

            if (!Data.COVENANTS.ContainsKey(saveFile.player.covenant)) {
                Data.COVENANTS.Add(saveFile.player.covenant, $"Unknown ({saveFile.player.covenant})");
            }

            InitializeComponent();

            // Setup App-wide Ctrl+S.
            var saveAll = new RoutedCommand();
            var ib      = new InputBinding(saveAll, new KeyGesture(Key.S, ModifierKeys.Control));
            InputBindings.Add(ib);
            // Bind handler.
            var cb = new CommandBinding(saveAll);
            cb.Executed += (sender, args) => SaveFile();
            CommandBindings.Add(cb);

            //var f = Global.ToHexString(new Guid("363d739b-9a36-4a9d-9dc1-2487b92eb475").ToByteArray());
            //var s = "B8 27 8A 7A AA D3 BB 49 AE 39 96 30 46 51 EF 39".FromHexStringToGuidString();

            ExtractData();
        }

        private void ExtractData() {
            try {
                var toWrite = $"Breach: {Data.GetNameOrId(saveFile.world.breach)},\r\n";

                toWrite += $"Covenant: {Data.GetNameOrId(saveFile.player.covenant)},\r\n";

                var index = -1;
                foreach (var slot in saveFile.player.slots) {
                    index++;
                    if (!slot.used) continue;
                    toWrite += $"Slot {(Slot.Index) index}:\r\n";
                    foreach (var item in slot.items) {
                        if (item == -1) continue;
                        toWrite += $"    {saveFile.player.items[item].nameOrId},\r\n";
                    }
                }

                toWrite += JsonConvert.SerializeObject(saveFile.world.sStates, Formatting.Indented) + "\r\n";

                foreach (var item in saveFile.player.items) {
                    if (Data.ALL_IDS.ContainsKey(item.id)) continue;
                    toWrite += ("{\r\n" +
                                $"    \"id\": \"{item.id}\",\r\n" +
                                $"    \"count\": {item.count},\r\n" +
                                $"    \"selection\": {item.selection},\r\n" +
                                $"    \"values\": [{string.Join(", ", item.values)}],\r\n" +
                                $"    \"sockets\": [{string.Join(", ", item.sockets)}]\r\n" +
                                "},\r\n");
                }

                File.WriteAllText(CMP_FILE, toWrite);
            } catch (Exception) {
                // ignored
            }
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private bool LoadFile() {
            var target = GetOpenTarget();
            if (string.IsNullOrEmpty(target)) {
                Application.Current.Shutdown();
                return false;
            }

            targetFile = target;

            var json = File.ReadAllText(targetFile, Encoding.UTF8);
            saveFile = JsonConvert.DeserializeObject<SaveFile>(json);
            ReIndexItems();

            saveFile.player.items.CollectionChanged += Items_CollectionChanged;
            return true;
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private void SaveFile() {
            var target = GetSaveTarget();
            if (string.IsNullOrEmpty(target)) return;

            var json = JsonConvert.SerializeObject(saveFile, Formatting.None);
            File.WriteAllText(target, json);
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.Action == NotifyCollectionChangedAction.Remove) {
                var position = e.OldStartingIndex;

                foreach (var slot in saveFile.player.slots) {
                    for (var i = 0; i < slot.items.Count; i++) {
                        var item = slot.items[i];
                        if (item == position) throw new InvalidOperationException("Cannot remove an item in use.");
                        if (item > position) slot.items[i] -= 1;
                    }
                }

                foreach (var item in saveFile.player.items) {
                    for (var i = 0; i < item.sockets.Length; i++) {
                        var socketItem = item.sockets[i];
                        if (socketItem == position) throw new InvalidOperationException("Cannot remove an item in use.");
                        if (socketItem > position) item.sockets[i] -= 1;
                    }
                }
            }
        }

        private string GetOpenTarget() {
            var ofdResult = new OpenFileDialog {
                Filter           = "JSON(HP)|*.hp",
                Multiselect      = false,
                InitialDirectory = targetFile == null ? TARGET_FOLDER : Path.GetDirectoryName(targetFile) ?? TARGET_FOLDER
            };
            ofdResult.ShowDialog();

            return ofdResult.FileName;
        }

        private string GetSaveTarget() {
            var sfdResult = new SaveFileDialog {
                Filter           = "JSON(HP)|*.hp",
                FileName         = $"{Path.GetFileNameWithoutExtension(targetFile)}",
                InitialDirectory = targetFile == null ? TARGET_FOLDER : Path.GetDirectoryName(targetFile) ?? TARGET_FOLDER,
                AddExtension     = true
            };
            return sfdResult.ShowDialog() == true ? sfdResult.FileName : null;
        }

        private void AddItem_OnClick(object sender, RoutedEventArgs e) {
            if (cb_item_to_add.SelectedValue == null) return;
            var itemToAdd = (Guid) cb_item_to_add.SelectedValue;

            saveFile.player.items.Add(new Item(itemToAdd));

            ReIndexItems();
        }

        private void ReIndexItems() {
            for (var i = 0; i < saveFile.player.items.Count; i++) {
                saveFile.player.items[i].index = i;
            }
            CollectionViewSource.GetDefaultView(saveFile.player.items).Refresh();
        }

        private void DgItems_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            switch (e.PropertyName) {
                case nameof(Item.nameOverride):
                case nameof(Item.nameOrId):
                    e.Cancel = true;
                    break;
            }
        }
    }
}