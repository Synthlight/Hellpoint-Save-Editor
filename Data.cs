using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Save_Editor.Assets;

namespace Save_Editor {
    public static class Data {
        public static readonly Dictionary<Guid, string> ALL_IDS   = new Dictionary<Guid, string>();
        public static readonly Dictionary<Guid, string> ALL_ITEMS = new Dictionary<Guid, string>();
        public static readonly Dictionary<Guid, string> ALL_ITEMS_SORTED;
        public static readonly Dictionary<Guid, string> MAIN_HAND = new Dictionary<Guid, string>();
        public static readonly Dictionary<Guid, string> OFF_HAND  = new Dictionary<Guid, string>();

        public static readonly Dictionary<Guid, string> MISC = new Dictionary<Guid, string> {
            // Particles
            {new Guid("4546e8b5-e663-4bdb-81b7-895e7cd8d136"), "Inselium Particles"},
            {new Guid("f79e260f-0c1f-47bd-b1c8-0058ebde6743"), "Carbon Particles"},
            {new Guid("e7595430-b9d8-41ee-8b0c-4b461c02c981"), "Anti-Carbon Particles"},
            // Scrap-able
            {new Guid("86d1979a-95f9-49ea-87dd-dbff7acf7136"), "Carbon Scraps"},
            {new Guid("5561bb6d-6abf-46f7-933b-44ebf488a386"), "Refined Carbon"},
            {new Guid("c0ade3d4-017b-4071-a92c-5aaced93ef6c"), "Inselium Ingot"},
            {new Guid("73407493-aed0-40d5-9706-cdb62b1293f1"), "Inselium Rod"},
            {new Guid("4d398af8-dc0d-4a38-b85f-f2feb69d5292"), "Raw Inselium"},
            {new Guid("2db0d906-182f-41c6-836a-08ccd2f48d47"), "Diamond Ingot"},
            {new Guid("ade350f7-3690-4fab-9f9f-4a6f515bdfdc"), "Nihl Shards"},
            {new Guid("43e1bf80-bb98-4aba-afe2-17b19cfa8821"), "Nihl Rock"},
            // Materials
            {new Guid("84b6a93c-0537-45ec-89ef-9406b8e79f69"), "Material: Hard Glass"},
            {new Guid("c999f573-1154-4794-aa05-8cbd8eb5d154"), "Material: Bones"},
            {new Guid("c3ea2cff-111c-4b84-b1a4-271e359192bb"), "Material: Alumina"},
            {new Guid("01b3b388-713c-482b-b85c-f8aef9989ff1"), "Material: Metallic Glass"},
            {new Guid("0e693901-c02e-482d-8829-3720768bc778"), "Material: Black Tempering"},
            {new Guid("173bf13a-aee0-48f2-b87c-18ed832d7e76"), "Material: White Tempering"},
            {new Guid("a24b9514-4a74-465c-94dc-004306200b6b"), "Material: Charged Prism"},
            {new Guid("54f4de82-a69d-4ef7-8a6e-2d62b68ad81a"), "Material: Antimatter Gyro"},
            {new Guid("9cc9f4ef-6e20-4aea-b047-92af4eeac6f8"), "Material: Accelerator"},
            {new Guid("944611be-6807-406f-a14b-a066fd3c0d38"), "Material: Crystal Lenses"},
            {new Guid("954e1ee1-2757-4e92-b5ca-4586ef18f7bf"), "Material: Earth Minerals"},
            {new Guid("f7e2092e-3efb-40d2-b522-b77513b9bffa"), "Material: Organic Fiber"},
            {new Guid("90b609e8-6956-4aed-a7f1-95d1dce5c2f7"), "Material: Beating Heart"},
            {new Guid("10e7b473-8914-4554-8d5a-975bca343235"), "Material: Pulse Mineral"},
            {new Guid("9d9323ea-66e1-43db-b5b1-726940828dd9"), "Material: Active Core"},
            {new Guid("bebb13c7-9ccb-421a-93a0-221fdee1aa06"), "Material: Thermal Seal"},
            {new Guid("4927564e-c644-42c6-b984-56be6e8a3185"), "Material: Pressure Motor"},
            {new Guid("cc7a87b1-a526-4183-9299-45c85277ec5d"), "Material: Solid Fuel"},
            {new Guid("aef0ceb6-0bc6-431c-9c59-c2bb7f0ff166"), "Material: Solid Plasma"},
            {new Guid("2e995b03-8624-43b9-9407-df0b261c3da2"), "Material: Alloy Frame"},
            {new Guid("329e6487-07a1-4a32-997b-e8e2b39ff2c5"), "Material: Inselium Slate"},
            {new Guid("bd84e302-8741-46bb-9c5a-f0bb5f14fb3b"), "Material: Nervous Wiring"},
            {new Guid("cc4a5b8d-0990-4368-97bc-838305de30c9"), "Material: Fragment of the Interface"},
            {new Guid("43bdc514-d406-4bea-9a43-5ee1fb461003"), "Material: Soul of the Sentient"},
            {new Guid("6050600a-e599-4ec9-8c00-d693c1ce5ab4"), "Fragment of Nemundis, the Undisturbed"},
            {new Guid("ddf2b203-0e04-4e9c-b3db-423a8c77698c"), "Fragment of Uthos, the Ashen Born"},
            {new Guid("b18fde07-a54d-43d9-bf4c-25c4532a91ba"), "Fragment of Ozyormy Goija"},
            {new Guid("bd1f2d9c-6551-446f-a317-c05d1bf36760"), "Fragment of a Daemon"},
            {new Guid("e69465e2-abfe-4287-9b2c-38dd1964ef8d"), "Fragment of a Thespian"},
            {new Guid("6722f802-1b9b-413d-89dc-ce2725d4cb8b"), "Fragment of an Archon"},
            // Axions
            {new Guid("17eccb8f-3f41-4372-8609-ebf5b8fd9687"), "Axions (11)"},
            {new Guid("052dd015-8324-4fd7-a561-36fc5db76ee1"), "Axions (22)"},
            {new Guid("9dc95948-aa73-485d-8cc1-3d308096a1be"), "Axions (33)"},
            {new Guid("a1420a1c-7567-4422-a48e-5610ccc1f77b"), "Axions (44)"},
            {new Guid("0388ddc9-bb4e-4969-bcd4-c461da22276f"), "Axions (55)"},
            {new Guid("daacef1e-8f7d-4b76-aa98-493d71842886"), "Axions (66)"},
            {new Guid("f336946e-02a5-4ee6-88be-16e92248860c"), "Axions (77)"},
            {new Guid("3a6d2cbb-ccfd-4d80-a802-639659c97b82"), "Axions (88)"},
            {new Guid("7261b12b-02ea-4fd0-8623-5d8c79e4d1a2"), "Axions (99)"},
            {new Guid("f166dfc8-0d87-4b0c-ae59-e864614fab9b"), "Axions (111)"},
            {new Guid("7323ebe8-30df-404a-b77b-4e99f03776dd"), "Axions (222)"},
            {new Guid("f5c361af-86d7-42ee-8ec3-9b80134c7eb7"), "Axions (333)"},
            {new Guid("36b70b4d-b052-4b11-8a53-8f039db28058"), "Axions (444)"},
            {new Guid("3b2dcfcf-1b17-4faa-988a-5e23d45f39a6"), "Axions (555)"},
            {new Guid("9d011059-8f11-47c0-b838-7b49f98aa1a6"), "Axions (666)"},
            {new Guid("ed236cda-9067-4f9e-b98b-ba59cc192df5"), "Axions (777)"},
            {new Guid("0b4d047f-3399-4571-b477-58adbe40f189"), "Axions (888)"},
            {new Guid("07696bf5-c714-400e-829a-19671a225d6d"), "Axions (999)"},
            {new Guid("12cde9d4-e2c1-43a8-a870-6940c4aa1cba"), "Axions (1111)"},
            {new Guid("901c55cc-b7f5-4876-843c-9e7753f25d1d"), "Axions (2222)"},
            {new Guid("44560c94-f800-4480-b22d-26e9e7f1d3c5"), "Axions (3333)"},
            {new Guid("88705099-83c5-4509-bcb5-aded3da41603"), "Axions (4444)"},
            {new Guid("2464418c-c467-4a32-a8e1-72f880ad387c"), "Axions (5555)"},
            {new Guid("2ed946cc-6a3b-443a-bc8e-33fc4faa35cc"), "Axions (7777)"},
            {new Guid("f6869995-24b5-4048-9772-51f8e2d0b8ae"), "Axions (9999)"},
            {new Guid("363d739b-9a36-4a9d-9dc1-2487b92eb475"), "Axions (11111)"},
            {new Guid("9e2b0cfd-79c2-4ea6-8286-167117682aaf"), "Axions (22222)"},
            {new Guid("7a8a27b8-d3aa-49bb-ae39-96304651ef39"), "Axions (33333)"},
            {new Guid("8747ecde-88fc-43c5-b245-ebf32dbaa7c9"), "Branch of Light"},
            // Misc
            {new Guid("f4379930-e1e0-4ae7-8ae7-85a37fb978f2"), "Coin"},
            {new Guid("c7315558-78f7-44ef-9971-091ac32b6077"), "Breach Synchronizer"},
            {new Guid("89ef7cde-5bc7-4cd1-8f40-998a7de0444f"), "Ration"},
            {new Guid("dfe19031-82b5-43aa-9a55-6e0ca1cb0c5a"), "Daring Effigy"},
            {new Guid("9914b3e7-ed47-4043-b544-a4635301af73"), "Fearful Effigy"},
            {new Guid("07f983ba-c6f3-4ecc-8a87-1c283bdcbc4a"), "Healing Proficiency"},
            {new Guid("04672521-dd4f-4a55-a92f-4c147600febe"), "Eye of the Patriarch"},
            // Conductors
            {new Guid("1e85dd57-6a9a-492e-b584-c11b0cccd657"), "Firearm Conductor"},
            {new Guid("e7dddd25-ddd1-409e-b3a9-0426365d4f19"), "Catalyst Conductor"},
            {new Guid("4e72e814-f27b-44e5-8dac-5da77a7500d0"), "Strength Melee Conductor"},
            {new Guid("ae0cad61-39e6-45c7-88ae-0fcef30aa413"), "Reflex Melee Conductor"},
            {new Guid("cd6bc32e-f81c-4040-a1df-b3b0f9e4a602"), "Martial Melee Conductor"},
            {new Guid("acaaf6f4-808e-477b-8ebb-ac1c88efd61d"), "Light Melee Conductor"},
            {new Guid("73c563d5-5327-447d-8eeb-71c55114709a"), "Entropic Melee Conductor"},
            {new Guid("fcdbe0c8-4743-4bc1-a89f-5eae9ec66824"), "Induction Melee Conductor"},
            {new Guid("4d68cace-e62c-4f28-b64b-352c2ab410ad"), "Light Shield Conductor"},
            {new Guid("c2b298f4-4691-44db-a73d-5211ac2c55a8"), "Entropic Shield Conductor"},
            {new Guid("929c36c9-e7b9-46c1-8450-3a6bfe68c638"), "Induction Shield Conductor"},
            // Quest
            {new Guid("4066d4b3-54fe-4d61-9264-2bf40069971c"), "Mass AI Patch Conductor (Don't add. Tied to quest.)"},
            // Omnicube Stuff
            {new Guid("dc15356a-af89-4ef7-8ec2-17b95cfa5c02"), "Omnicube Defense System"},
            {new Guid("ba749cc5-8b45-4234-a98e-a8bee3958602"), "Omnicube Jukebox (Program A)"},
            {new Guid("929bb05e-e679-4806-8e61-fda78b9aef37"), "Omnicube Jukebox (Program B)"},
            {new Guid("5033c340-a775-43b3-9511-7d2ace7090bc"), "Omnicube Jukebox (Program C)"},
            {new Guid("d0dfb1a4-2a0e-4847-b907-1a39424ebfd8"), "Omnicube Jukebox (Program D)"},
            {new Guid("41fc1b25-81a7-4565-87da-4e5101080f17"), "Omnicube Jukebox (Program E)"},
            {new Guid("c45acf5a-d721-4311-9eb3-65418aaa915f"), "Omnicube Auto-Heal"},
            {new Guid("7201926a-f100-4eec-9c65-478f3360e53c"), "Omnicube Heater"},
            {new Guid("cb106391-591b-4da1-b4d4-e4810f1685a3"), "Omnicube Light"},
            {new Guid("29ae1b08-7766-40a4-9d92-6bd5b4f63c4b"), "Omnicube Quantum Light"},
            {new Guid("1424c368-ccd2-4c88-98f9-40ecc9277c69"), "Omnicube Transposition"},
            // Data
            {new Guid("327434b9-5aa6-4aff-bdab-48f00eafdffb"), "Data: Arcology Elevator"},
            {new Guid("850b702c-4f89-4513-8243-6c05da344abf"), "Data: Uthos"},
            {new Guid("d4d5c189-6451-4d9d-b419-552ad82b3ed0"), "Data: Pad on floor beneath Belvedere breach."},
            {new Guid("afee9919-0485-4561-803b-e581c1cf5408"), "Data: Text on floor of Arisen Dominion entrance."},
            {new Guid("97559671-a540-4ac2-b492-acc6eac27bb1"), "Data: Arisen Dominion entrance, knowledge about AI."},
            {new Guid("08d08b45-d92b-4184-b14f-4c04d4eb23f4"), "Data: Arisen Dominion, secret entrance below Hall of Remembrance."},
            {new Guid("dd50cdfb-b7b4-4a7b-acda-337bf84a25ed"), "Data: From opening the shutters."},
            // Unk
            // 0e8f0ce3-598c-4036-af2a-ba8caf4996b0     On entering Alma Mater Atrium from Arcology?
            // b33651e1-e2b1-4c5f-8306-8809f27c0758     On entering Alma Mater via shanty entrance?
            // 2d86a618-769b-42c8-b6ff-4cba5fa64cb0     Ashen Born and his elevator? (added)
            // aef0ceb6-0bc6-431c-9c59-c2bb7f0ff166     Ashen Born and his elevator? (removed)
            // 559b9cc5-f8b4-40ef-89f0-875ded795bd9     Around activating the Union Park breach?
            // sStates
            {new Guid("521e4d7f-037d-459f-8173-19e69b2c7d0d"), "sState: Used Seal of the Anima."},
            {new Guid("e6e8c73a-3d87-4295-bf0a-7629e704ccd6"), "sState: Used Seal of the Snake."},
            {new Guid("460b67e6-fbbb-427d-85c6-0fdaa803bdc4"), "sState: Used Seal of Chaos."},
            {new Guid("aab272b7-b276-495a-856e-cadc95ac7d25"), "sState: Used Seal the Patriarch."}
        };

        public static readonly Dictionary<Guid, string> HEALING_METHOD = new Dictionary<Guid, string> {
            {new Guid("01612f56-703f-42ca-b429-c180fd6eb11f"), "Healing Injection"},
            {new Guid("a78f1e58-a0dd-4668-8867-7802e6e6cf62"), "Anti-Rad Injection"},
            {new Guid("fcd05171-fef8-49c6-8bf9-bf1cdb30d478"), "Regenerative Nanobots"},
            {new Guid("9884f89c-3235-4c0f-ba60-6a345d4489f9"), "Purging Ritual"},
            {new Guid("07fcffa1-79ee-4376-b674-1bbef6459482"), "Blood Ritual"}
        };

        public static readonly Dictionary<Guid, string> KEY_ITEMS = new Dictionary<Guid, string> {
            {new Guid("066fb260-cb1f-4007-b64f-8373306a08ab"), "Cabaret Key"},
            {new Guid("9d069855-1833-4fd5-b8c2-011ac6300998"), "Tram Activation Key"},
            {new Guid("fb19473e-2744-47e0-be9c-52ad8c1d0b50"), "Observatory Gallery Key"},
            {new Guid("8473087a-fb2e-40c6-9578-89357b83b6c0"), "Union Condos Key"},
            {new Guid("08a468bd-6b59-4bf1-bff1-af8a08e4497b"), "Eye Tower Two Activation"},
            {new Guid("11278a7d-1ce0-4a56-b8eb-4050f6ff36ea"), "Seal of Chaos"},
            {new Guid("df429df4-6b4b-494a-8de8-df63cb55238d"), "Seal of the Anima"},
            {new Guid("e5ada95d-b4c3-4e03-b249-4d9bf173a353"), "Seal of the Snake"},
            {new Guid("f0a65ce4-10c7-4f7f-9dc2-4c07800b94cc"), "Seal of the Patriarch"},
            {new Guid("2052946f-8f14-4577-93e3-27920b2a968f"), "Sun Hall Access"},
            {new Guid("353570d4-5018-48d3-80f9-2db0f4af8fd7"), "INB Vault Key (Embassy)"},
            {new Guid("f70e6353-e5ad-47cf-abb5-219ac60599a5"), "INB Vault Key (Alma Mater)"},
            {new Guid("34d37879-e1b6-4404-ac05-baed8635e865"), "Port Issoudun Credentials"},
            {new Guid("4b9b3fab-7be3-41cb-a31d-76b1cd467db8"), "Ministry Credentials"},
            {new Guid("8f61dbe1-7305-499a-9d18-e5639cd7e50e"), "Ministry Key"},
            {new Guid("5aa596b0-2600-4ba9-89c7-3c33eb1f6c45"), "Arisen Dominion Credentials"},
            {new Guid("ba8da887-37ea-49a8-80c8-4a4f3621d38b"), "Alma Mater Institute Credentials"},
            {new Guid("0964446b-ae2c-426d-aa3d-f49873671ff0"), "Architect Credentials"},
            {new Guid("5b501bdc-5526-485f-abab-62e871a55424"), "Key to Ortega Tower"},
            {new Guid("81df69a3-560e-46cb-85b0-867b0b5d127d"), "Key to Dargass Tower (Sohn District)"},
            {new Guid("5fda1cd4-dd8e-4a7b-8629-45f327311661"), "Freight Credentials (Issoudun)"},
            {new Guid("c597398b-91e1-4524-b33e-79d4afda1640"), "Silo Key (Issoudun)"},
            {new Guid("793f087b-2c40-4fc5-bb31-8e63b7560eaf"), "Vault Credentials A (Issoudun)"},
            {new Guid("797866ca-cfaa-470b-8017-2e737c5115db"), "Vault Credentials B (Issoudun)"},
            {new Guid("94084927-470a-4d0b-82bb-68ffc48d2fa9"), "Ateliers Lab Key (High Ateliers)"},
            {new Guid("c011625e-0c3f-485c-8502-cb230bb11d52"), "Arcology Limited Access Passport"}
        };

        public static readonly Dictionary<Guid, string> WEAPONS_MELEE = new Dictionary<Guid, string> {
            {new Guid("88ca6a94-47aa-464e-9ffc-1b13f82e24de"), "Pipe"},
            {new Guid("8e7aa059-e38a-416c-b3c3-2f83811044b5"), "Officer Tule's Glaive"},
            {new Guid("df6eb4a3-95cd-4836-b416-39611c7e2ceb"), "Officer Glaive"},
            {new Guid("fe574e4f-6a0b-4275-b4e4-944b888e5374"), "Antiquated Officer Glaive"},
            {new Guid("f7121f72-8166-46ef-8762-57d63d77334c"), "Column"},
            {new Guid("80db466c-2745-48d8-ba76-6c23dfe3136a"), "Infused Column"},
            {new Guid("6bf3c025-61d5-4279-a476-7a41150f765c"), "Victim's Poker"},
            {new Guid("687fb257-07a9-480d-8e89-eb899d7050f4"), "Shard"},
            {new Guid("277a61bd-6210-44fe-9dbd-d9a0670997ca"), "Lost Hatchet"},
            {new Guid("ebe866af-5c88-4ad3-a760-8ec25aeff4ff"), "Daemon Scythe"},
            {new Guid("a4fda017-0360-4193-a8e0-976e817ad3d1"), "Wasteland Saber"},
            {new Guid("916135ef-3cc2-40b6-a234-7d3b7d24fbbb"), "Shredding Saber"},
            {new Guid("18590b57-474a-498c-a3d2-29d69b5f35fc"), "Red Saber"},
            {new Guid("2a72d818-c9de-482e-be6b-84976ff52c6a"), "Thespian Hook"},
            {new Guid("a49674e5-bcf5-46c8-b6ef-1291d4bcbe19"), "Thespian Mace"},
            {new Guid("b57cb048-7c6d-437b-825f-4e07f0b4c5cb"), "Heater Spear"},
            {new Guid("0cdb275f-f00a-4447-ba79-3d2f9bfd7ab1"), "Rail Poignard"},
            {new Guid("c0bccd8c-f22f-4dbe-88e4-9728079a8389"), "Whale Bone Halberd"},
            {new Guid("a11353ec-d947-4b1c-b698-6d51141f27d7"), "Disciple Ferula"},
            {new Guid("537edb22-09d8-4c4b-8cf3-4016201b8649"), "Ferula of the Prodigal Spawn"},
            {new Guid("60e90378-d451-46a8-a797-6c746d74feb5"), "Linked Espadon"},
            {new Guid("ad16f15a-0f4d-4856-9bec-b906db88c95f"), "Deliberate Burden"},
            {new Guid("fcbd8540-0069-4290-8654-9f5d7f81e416"), "Ozy's Hand"},
            {new Guid("a3950477-e7ad-4a9d-8130-b50dcc62398d"), "Ceremonial Dagger"},
            {new Guid("2ea0fb7d-f71f-4e58-9084-3917a0f4be39"), "Archon Spear"},
            {new Guid("5a6ad367-fb00-448a-a8a1-79043de5ba2a"), "Prying Tool"},
            {new Guid("ee34e8d4-6fc2-4cbc-8239-4d7e63a12c18"), "Nemundis Oculus"},
            {new Guid("522976a5-b3e2-4308-825e-1c998ea914bf"), "Uthos Gavel"},
            {new Guid("7a819a2f-c4fa-49f1-80ea-49470235fccb"), "Light Striker"},
            {new Guid("c3226882-2ed8-47ed-90c7-29b9993957f3"), "Tomahawk"}
        };

        public static readonly Dictionary<Guid, string> WEAPONS_RANGED = new Dictionary<Guid, string> {
            {new Guid("7832f8f5-b6bc-4584-87a4-edf7a5650a77"), "Railgun"},
            {new Guid("eb4dc0e9-3c61-44fa-9f2b-e980a2bb1f25"), "Entropic Railgun"},
            {new Guid("289fd48a-911e-44d0-96d0-2847d06da080"), "Artillery OTX"},
            {new Guid("b68f4183-0be9-4cce-a7a5-87e14977f3ba"), "Artillery P17"},
            {new Guid("931b4e5a-b5d9-4e40-99f6-c1b63d8ddfa9"), "Channeler of Hell"},
            {new Guid("16d14c9c-b5b1-402e-b90d-8375666d6cde"), "Channeler of Light"},
            {new Guid("2a3187db-35bd-4104-8661-cc79b8b38f9a"), "Daemon Cannon"},
            {new Guid("4c261ead-1173-4e10-b663-521cd62920ee"), "Mouth of Filth"},
            {new Guid("66812c79-afa9-48e8-b98c-7b5ab131692d"), "Hedron of Light"},
            {new Guid("a4494bb0-d499-4182-bf77-00b887ab4174"), "Hedron of Entropy"},
            {new Guid("8a12ec6a-7cd7-4da3-b366-d6b7cec3d409"), "Nihl Prophet Hand"},
            {new Guid("d77c6e26-185a-4510-be18-2f612c6293c2"), "White Prophet Hand"},
            {new Guid("b78e2bed-66d2-4fb5-87e1-9edbc19e326c"), "Amber Prophet Hand"},
            {new Guid("47a054e8-f209-41a0-9494-796625ea6b99"), "Etek Aveos"}
        };

        public static readonly Dictionary<Guid, string> SHIELDS = new Dictionary<Guid, string> {
            {new Guid("5bc3ab7f-e158-474a-a2b8-a2d14ccde10f"), "Victim's Shield"},
            {new Guid("82fdbcc2-bd0e-46c2-86fa-8844431df19f"), "Heat Shield"},
            {new Guid("bf60b459-6c71-4554-972c-302a0b135a0c"), "Old Heat Shield"},
            {new Guid("e785046b-4f1f-47d1-a05c-4a2cf13558ae"), "Scrapped Heat Shield"},
            {new Guid("2697a4a2-e5f5-4587-9128-c1c4e13e8cbb"), "Scrap Shield"},
            {new Guid("3ca2102b-3969-4056-95dc-590ff761030e"), "Sohn Bulwark"},
            {new Guid("6b9b2671-4a3d-4eb7-ae56-e5db925ede5b"), "Sentinel Cross"},
            {new Guid("e4e4a855-d9f7-4b34-9015-777b29660124"), "Ancient Warrior Shield"},
            {new Guid("bcb8af0f-5b02-431b-82e5-63d6273c315e"), "Decrepit Warrior Shield"},
            {new Guid("f442ddc6-a350-4fea-b47e-ae1f1f8759ec"), "Artillery Shield"},
            {new Guid("0ae41428-623a-4b4b-82a1-6018a2727aab"), "Disciple Shield"},
            {new Guid("5b90699e-658f-4ec6-b921-ddbf6deca64a"), "Dark Disciple Shield"},
            {new Guid("701817c9-c11a-46a1-81da-f5b3787157c7"), "Torture Board"},
            {new Guid("9922fc20-9e7b-45c3-ac23-dd313d0454ea"), "Archon Shield"}
        };

        public static readonly Dictionary<Guid, string> ARMOR = new Dictionary<Guid, string> {
            {new Guid("3dee108e-acfc-4b5c-afb1-1638fb9deb2f"), "Magnifier Goggles"},
            {new Guid("e606d95a-ea54-41b2-b884-6cc83027e773"), "Research Goggles"},
            {new Guid("40479cfd-7217-4772-93bc-dc0076af2044"), "Embalmer Goggles"},
            {new Guid("c6429b35-2ff8-434a-8fc5-5bb78c40de60"), "Sandstorm Goggles"},
            {new Guid("9436a5b9-0841-4609-9e23-c744c9940c67"), "Filter Goggles"},
            {new Guid("357b67a4-1541-467d-a31e-6dd058cc02c5"), "Hostess's Mask"},
            {new Guid("812111a3-92be-4660-8d61-9d0e49a17e6f"), "Facial Hair"},
            {new Guid("10ae8498-bd07-482c-9fed-4b6f894608f6"), "Crown of Subversion"},
            {new Guid("d0b95529-c47f-4b4d-a943-10b97002bf42"), "Crown of Cowardice"},
            {new Guid("ebe27d06-89b0-43d3-97b4-c977d4917307"), "Crown of Appetite"},
            {new Guid("3c1290da-27e8-434a-b1f9-c6af43456f81"), "Crown of Guilt"},
            {new Guid("b508e878-3cb7-4c5c-9f9a-a03c10d1be4e"), "Daemon Robe"},
            {new Guid("57df98f3-7ba3-45b8-8bbc-f63ac4428746"), "Interface Headgear"},
            {new Guid("98f2d22c-741e-4520-9b67-1df68cc62b61"), "Victim Headgear"},
            {new Guid("71844929-7604-49f7-97dc-2e4460694c82"), "Victim Leg Clasps"},
            {new Guid("d461e28f-2c7d-4904-abe1-d5f5eb267d5a"), "Ancient Warrior Helm"},
            {new Guid("e4821775-c99d-4b22-b36b-9e667781d60b"), "Ancient Warrior Armor"},
            {new Guid("76297871-c3ca-416d-b0f3-c0a139f462ec"), "Ancient Warrior Gauntlets"},
            {new Guid("31615816-4a14-4183-a1c0-bd9a5997e7f3"), "Ancient Warrior Boots"},
            {new Guid("87d7864e-67a7-424c-9a7d-fc6c1fbe8248"), "Revolute Warrior Helm"},
            {new Guid("5c3cce36-f355-43e9-895a-c02f44b0f477"), "Revolute Warrior Armor"},
            {new Guid("91f0805b-0960-4378-97f3-ccd9f6c4b44c"), "Revolute Warrior Gauntlets"},
            {new Guid("38bede9d-efa4-46fe-a46b-673f7423ac45"), "Revolute Warrior Boots"},
            {new Guid("1a12128c-8756-4a9a-999f-7cf42233c43c"), "Arisen Coat"},
            {new Guid("f3328dd0-52cb-4a11-b27d-fb2817bf0337"), "Arisen Robe"},
            {new Guid("4cd06126-4508-4476-a4cb-815155d1ce92"), "Major Thespian Armor"},
            {new Guid("c8840753-515a-469b-bf03-28b0432d2372"), "Major Thespian Gloves"},
            {new Guid("84469c82-f311-466e-9dd6-7d17efcf7e24"), "Major Thespian Leggings"},
            {new Guid("da6e81e0-d124-424e-b77f-cd3b325b0a82"), "Minor Thespian Armor"},
            {new Guid("aefbca70-0586-416e-87f2-0e453d584a80"), "Minor Thespian Gloves"},
            {new Guid("83920ecf-d099-414a-8220-8617ece5a8eb"), "Minor Thespian Leggings"},
            {new Guid("9230014e-3582-44e7-bc20-4be321b5afb1"), "Tool Victim Crown"},
            {new Guid("ed997adf-e8ab-43cf-9a39-a699397802ba"), "Tool Victim Chest (A)"},
            {new Guid("50e1acdf-0d87-430a-8289-64821983c8fd"), "Tool Victim Chest (B)"},
            {new Guid("42f28f30-502c-46b4-a7ae-421887af3c6e"), "Tool Victim Leggings"},
            {new Guid("61feeacf-1199-4b2e-b21f-397af1ed0dc5"), "Preterhuman Headgear"},
            {new Guid("9dd96dc0-e68c-47c0-b91a-3e3c779cc2ec"), "Preterhuman Chest Piece"},
            {new Guid("ca0373f1-2233-48c2-bdf2-409989348f43"), "Preterhuman Gauntlets"},
            {new Guid("3ef8bf2e-5cc0-4a01-aefc-b7dcd099bb66"), "Preterhuman Legs"},
            {new Guid("82b4dfac-60b1-477f-8c75-f1a632cb151f"), "Theurgist Vest"},
            {new Guid("0ea500ff-0bde-471f-bb82-f917919fc740"), "Theurgist Gloves"},
            {new Guid("f13a9b3f-7fa9-4762-bd35-66008c927871"), "Theurgist Robe"},
            {new Guid("3942df8f-bbb7-41d1-9e1a-6d54360d5138"), "Theurgist Scribe Vest"},
            {new Guid("a4b4d34f-a292-4487-bdde-e6cd9d03c69c"), "Theurgist Scribe Gloves"},
            {new Guid("d54470e4-adc6-402c-9641-28b65cbc57b8"), "Theurgist Scribe Robe"},
            {new Guid("66ac0ed1-aeb5-41f3-94b9-d011b351cd96"), "Underworld Sentinel Crown"},
            {new Guid("7e062c5f-e2e2-4435-8238-78c5dceb93fc"), "Underworld Sentinel Armor"},
            {new Guid("ed158ecc-76a6-42ab-8e75-b90808e3ed84"), "Underworld Sentinel Arms"},
            {new Guid("1a5ac258-83cb-4ffa-9a37-1babb7ce196a"), "Underworld Sentinel Leggings"},
            {new Guid("2abd77c2-c4a8-43c1-8475-775c91b9dc4f"), "Sentinel Crown"},
            {new Guid("563c2aa7-0f03-427d-a952-e1b1fc0d7e40"), "Sentinel Armor"},
            {new Guid("70ef3100-b4a5-400a-ba41-60a7eb55eed8"), "Sentinel Gauntlets"},
            {new Guid("d538aedb-405c-4b7e-a35c-db67c1bc86d1"), "Sentinel Boots"},
            {new Guid("3bd5903e-d7f4-4c1d-a44c-a2d139e2a146"), "Athletic Nerve Suit Helmet"},
            {new Guid("ca6dd6fb-efdd-4486-a3b0-99588bbf8715"), "Athletic Nerve Suit Torso"},
            {new Guid("ef51dc28-6757-48cb-95bd-355553854f71"), "Athletic Nerve Suit Gloves"},
            {new Guid("46b6a860-0d2e-4dea-832a-1a8588619138"), "Athletic Nerve Suit Leggings"},
            {new Guid("c9793d37-3c1d-46b7-bd6f-fcf72a8aafd3"), "Nerve Suit Helmet"},
            {new Guid("6f8b7856-de80-43fc-89f5-2e7c684c6531"), "Nerve Suit Torso"},
            {new Guid("249f9545-6249-4fde-984f-08e10ace6345"), "Nerve Suit Gloves"},
            {new Guid("a09e59de-f7fd-4fa4-b752-3d58f61b01ec"), "Nerve Suit Leggings"},
            {new Guid("6dc1cc58-9295-4aea-b581-ba734e151690"), "Prodigal Spawn Tiara"},
            {new Guid("5334902a-d746-4abe-90a0-97436ce70bdc"), "Disciple Chest"},
            {new Guid("18e07887-c213-470b-b1db-1ce79dacaae7"), "Prodigal Spawn Gloves"},
            {new Guid("85cceb95-635a-4a0d-ad37-4ef2f233f08a"), "Disciple Robe"},
            {new Guid("64501992-00d9-4d23-89f1-dcd8ad3d0f0e"), "Bloodied Disciple Tiara"},
            {new Guid("0cd710ee-ba97-493d-aa79-bf64a01eaf41"), "Bloodied Disciple Chest"},
            {new Guid("c37e8e31-98df-4dab-be52-6310099153d1"), "Bloodied Disciple Gloves"},
            {new Guid("9f87616e-8365-48d2-9d5f-8e03dbcf9330"), "Bloodied Disciple Robe"},
            {new Guid("44508439-2116-4fab-b1f0-8d1b3a8d2836"), "Prodigal Spawn Tiara (Dark)"},
            {new Guid("a464675e-9e52-4f78-8684-3ca6ab6a3aab"), "Prodigal Spawn Chest (Dark)"},
            {new Guid("63511385-ecde-4d95-b59f-bd1874d1e6b6"), "Prodigal Spawn Gloves (Dark)"},
            {new Guid("cef80072-4260-45b2-bfe4-eb1e3309d0a1"), "Prodigal Spawn Robe (Dark)"},
            {new Guid("721c2127-c8b9-4320-bdae-9b0033e1bfe6"), "Architect Helm"},
            {new Guid("c7552e5e-d656-43c5-9688-a20dd9ee42c7"), "Architect Exosuit"},
            {new Guid("e827b2ce-5443-4ae1-bb03-2f060fbea117"), "Architect Gauntlets"},
            {new Guid("9be8a858-e366-44fc-9870-ef85b7ce93ba"), "Architect Leg Support"},
            {new Guid("7915a85d-25aa-4c82-bee0-35485a5b56d5"), "Bloodied Architect Helm"},
            {new Guid("55ca647c-e9df-4942-9650-bfb6a09fb50d"), "Bloodied Architect Exosuit"},
            {new Guid("ed9eb532-3bbb-49b3-af86-5462359d3388"), "Bloodied Architect Gauntlets"},
            {new Guid("962863ef-e827-4c28-b903-cd34b8b87c4c"), "Bloodied Architect Leg Support"},
            {new Guid("d8821584-3786-4da9-b33e-8b2bcc508c0b"), "EVA Outfit Helmet"},
            {new Guid("7f5b698a-1f07-4f36-8d87-16b02683ad6d"), "EVA Outfit Chest"},
            {new Guid("7b6a29b5-b0b8-47fe-b8bf-d0bcab131340"), "EVA Outfit Gloves"},
            {new Guid("7483453f-ef75-49c1-9ff2-601cea3569c5"), "EVA Outfit Leggings"},
            {new Guid("65751c4d-cf6b-493a-8322-d0693e563e0b"), "Broken EVA Outfit Helmet"},
            {new Guid("1d25c623-fbdf-4e51-bdc0-0bf02c8cc618"), "Broken EVA Outfit Chest"},
            {new Guid("084a26cf-db16-47c2-8b07-76a3108c5b99"), "Broken EVA Outfit Gloves"},
            {new Guid("e1b6e6a7-148a-4430-b011-53960db1722b"), "Broken EVA Outfit Leggings"},
            {new Guid("fac1cd12-2881-4898-b5c7-deb3485f6035"), "Aegis Armature Helmet"},
            {new Guid("b33c7bde-9456-47be-9488-ee57817d714c"), "Aegis Armature Chest"},
            {new Guid("611c53ec-1aee-4ad6-98fd-8c6cca00bdaa"), "Aegis Armature Gauntlets"},
            {new Guid("391abd51-8c68-465a-ad4c-014d7c0fd3b2"), "Aegis Armature Legs"},
            {new Guid("79a0361d-2124-4b99-ad2c-ad9e473468a8"), "Depraved Mask"},
            {new Guid("0fb11604-df4b-4f14-9a08-ad3a1201e0b6"), "Depraved Torso"},
            {new Guid("22079e5d-f4bd-41e8-9cae-151430e98f14"), "Depraved Gauntlets"},
            {new Guid("b6d54762-023f-4ca4-aa1c-cc51b5090e32"), "Depraved Legs"}
        };

        public static readonly Dictionary<Guid, string> MODULES_BODY = new Dictionary<Guid, string> {
            {new Guid("4d0a928e-8f90-42a6-b73a-5dc28f35719c"), "Health Module"},
            {new Guid("97471ecf-6291-4e84-a153-305207f56ec9"), "Photon Amplifier"},
            {new Guid("512c392e-2c17-4845-93dd-af5d9a5f7ca9"), "Sinew Reinforcement"},
            {new Guid("15bc8935-e04d-4d62-9c50-1ef28452a9ac"), "Axion Condenser"},
            {new Guid("9038bf7f-f8c3-44c1-8a81-a508b11ffd51"), "Reflex Module"},
            {new Guid("ff977a36-0101-42e2-b47f-08f400ce8c73"), "Strength Module"},
            {new Guid("3f726db0-f8c7-4866-8e73-f1be0b10ff9c"), "Leech Enhancer"},
            {new Guid("6f9f13dd-539b-4ef7-b6aa-7c05206862ea"), "Antigravity Module"},
            {new Guid("6b32ebf8-92c2-4ec1-9fe2-f63a3bf00293"), "Heavy Delivery"},
            {new Guid("65b786d0-014e-4982-99bb-76840f50cdcd"), "Stamina Module"},
            {new Guid("fc262491-aa7c-40a9-937b-857c3bb3ecbc"), "Protective Energy Module"},
            {new Guid("da447d0a-63ed-4dc9-9f02-5a4f078ffa68"), "Radiogardase"}
        };

        public static readonly Dictionary<Guid, string> MODULES_MIND = new Dictionary<Guid, string> {
            {new Guid("f0b3bb3f-bbf9-4874-846f-6b2cf61dae10"), "Conjuring Optimizer"},
            {new Guid("153feaab-6270-4803-868b-a69e9108b82b"), "Cognition Module"},
            {new Guid("6aa8f814-7255-4710-a8b7-7d8f023e5430"), "Sanity Puppet"},
            {new Guid("25a79ace-4bb0-442f-a033-b0e43674364c"), "Vacuum Isolator"},
            {new Guid("2b60b9d1-a1bc-4459-aee8-c52243bbd0c1"), "Foresight Channeler"}
        };

        public static readonly Dictionary<Guid, string> BREACHES = new Dictionary<Guid, string> {
            {new Guid("30e36844-0de2-4bcc-b4e7-6aa69a6a0482"), "Embassy: Pond"},
            {new Guid("c249af1b-bbd1-4a23-8c98-cc2b3e20057b"), "Embassy: Great Halls"},
            {new Guid("7a9ec96c-6510-44aa-8420-b0d0bb6f4070"), "Embassy: Admission"},
            {new Guid("df5e9690-21f9-47e8-8243-800ab7647483"), "Observatory: Podium"},
            {new Guid("8c31c03f-91dc-4a71-8786-5ffc0e95efac"), "Arcology: Funicular"},
            {new Guid("5ffd8b7b-7a29-4156-a439-5930e407b1ac"), "Arcology: Customs Bridge"},
            {new Guid("0e532ea1-1f31-4073-a282-117ef3e93efb"), "Arcology: West Square"},
            {new Guid("ab722f87-af91-4a67-bf5e-3abf7f5e0722"), "Arcology: Condo Ruins"},
            {new Guid("6e9fecec-7d42-4c32-8323-50c6fb5175fa"), "Arcology: Celestial Workshop"},
            {new Guid("7b354477-add2-45c4-85bc-93afcf82dbde"), "Arcology Underside: Central Mall"},
            {new Guid("1a00253b-a4cf-4239-a7a8-72b0c85656f4"), "Arcology Underside: SAS"},
            {new Guid("3b0e6a2d-39c2-4c26-acab-c5cf4bdc86c6"), "Arcology Underside: Outside Platform"},
            {new Guid("a50705f6-1a4a-45d7-9431-6a851b6cbf24"), "Sohn District: Corpse Pit"},
            {new Guid("e621f055-605e-4217-a23d-b670108ae72a"), "Sohn District: Balcony"},
            {new Guid("6d74af07-1235-4029-9bf4-6d2f3ff0dc37"), "Sohn District: Control Center"},
            {new Guid("bca89215-a138-4c0b-bff5-2247b8d67b47"), "Alma Mater Atrium: Otsego Mansion"},
            {new Guid("f3b44437-3104-4eec-b583-04f201eaec4d"), "Alma Mater Atrium: Shanty Entrance"},
            {new Guid("896f071e-79aa-4da9-a16a-a9c1cbe43d6d"), "Alma Mater Atrium: Western Skybridge"},
            {new Guid("66f0edb0-666b-47cc-97e9-de4b8cd465b7"), "Alma Mater Atrium: Tenements"},
            {new Guid("8fc1cb26-1a9a-4574-8a28-6f9de2c1dbaa"), "Alma Mater Atrium: Union Park"},
            {new Guid("e348b3ea-ffbc-4948-86fb-26c2e1a6dfcb"), "Alma Mater Atrium: Cabaret Cellar"},
            {new Guid("2d86fe23-be6a-408e-8dab-6a4178d37eca"), "Alma Mater Atrium: Athaneum"},
            {new Guid("a45477b9-b5b1-4ee4-a791-f883d5ad6847"), "Alma Mater: Uthos's Agora"},
            {new Guid("aa0a0a87-ec09-4e3b-b324-3f74d3773bf4"), "Alma Mater: Offices"},
            {new Guid("6036ecc0-ba2f-4076-9b3b-a908e191f66d"), "Alma Mater: Belvedere"},
            {new Guid("73247f9e-1100-4378-93c8-9e570581893b"), "Alma Mater: Lobby"},
            {new Guid("20ca797c-f276-4297-8bda-f63c05cd3862"), "Ikari Walkways: East Square"},
            {new Guid("82320c2a-7016-4766-adc4-fd91f254a481"), "Ikari Walkways: Crashed Tram"},
            {new Guid("608e6243-79a8-4d44-bf95-9393c7912c90"), "Ikari Walkways: Underail"},
            {new Guid("5abbb532-1020-4be3-83bb-a01a79f49eb9"), "Port Issoudun: Docking Bay"},
            {new Guid("852cd917-4ab5-4b4a-bea8-24906b1a3772"), "Port Issoudun: Silos"},
            {new Guid("e89c7c93-9271-4eb6-a6bc-12e635a5baea"), "Port Issoudun: Ozy's Pit"},
            {new Guid("ffccc8e3-3014-43c0-b6db-8a803285d1ac"), "Arisen Dominion: Solar Promenade"},
            {new Guid("9a1ee79f-4654-47e8-9f7d-82c8fc2124e5"), "Arisen Dominion: Hall of Remembrance"},
            {new Guid("b286f14e-58cf-46d1-ac65-16cfe789954e"), "Arisen Dominion: Grand Gallery"},
            {new Guid("9fe18611-57ee-4b86-a96c-c3882bd7851f"), "Arisen Dominion: Undisturbed Defas Nemundis"},
            {new Guid("43a77f53-4d01-4f75-b8d1-c91a75d7d0e9"), "Arisen Dominion: Mine Mausoleum"},
            {new Guid("1d290a89-62a4-4a4c-bb1f-c71e13d9a694"), "Arisen Dominion: Tram Station"}
        };

        public static readonly Dictionary<Guid, string> COVENANTS = new Dictionary<Guid, string> {
            {new Guid("6630e491-557e-4753-bbe6-256cc8406e69"), "Nemundis"},
            {new Guid("1581accc-4075-43b0-9a8f-e3ea10b1342f"), "Uthos"},
            {new Guid("1348938d-286a-4d2a-8850-0212225f2b52"), "Ozyormy Goija"}
        };

        public static readonly Dictionary<Guid, string> OMNICUBE = new Dictionary<Guid, string> {
            {new Guid("9c22deff-da77-47dd-8635-17333731134b"), "Omnicube"}
        };

        public static readonly Dictionary<Guid, string> S_CHARACTERS = new Dictionary<Guid, string> {
            {new Guid("b67e9444-24c6-43e2-a3d9-a7df237ca243"), "Architect"},
            {new Guid("a5e0542b-5b5d-49fe-b9cd-7440d8f53afe"), "Archon Slaver"},    // First boss
            {new Guid("0311441a-7570-45a5-9c87-ebf95678ef16"), "Celestial Beast"}   // Second boss
        };

        public static readonly Dictionary<string, string> S_VALUES = new Dictionary<string, string>();

        static Data() {
            MISC           = MISC.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            HEALING_METHOD = HEALING_METHOD.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            KEY_ITEMS      = KEY_ITEMS.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            WEAPONS_MELEE  = WEAPONS_MELEE.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            WEAPONS_RANGED = WEAPONS_RANGED.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            SHIELDS        = SHIELDS.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            ARMOR          = ARMOR.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            MODULES_BODY   = MODULES_BODY.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            MODULES_MIND   = MODULES_MIND.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            BREACHES       = BREACHES.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            COVENANTS      = COVENANTS.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            MISC.CopyTo(ALL_IDS);
            HEALING_METHOD.CopyTo(ALL_IDS);
            KEY_ITEMS.CopyTo(ALL_IDS);
            WEAPONS_MELEE.CopyTo(ALL_IDS);
            WEAPONS_RANGED.CopyTo(ALL_IDS);
            SHIELDS.CopyTo(ALL_IDS);
            ARMOR.CopyTo(ALL_IDS);
            MODULES_BODY.CopyTo(ALL_IDS);
            MODULES_MIND.CopyTo(ALL_IDS);
            OMNICUBE.CopyTo(ALL_IDS);

            var json   = Encoding.UTF8.GetString(Res.Id_Dump);
            var idDump = JsonConvert.DeserializeObject<Dictionary<Guid, string>>(json);
            idDump.CopyTo(ALL_IDS, true);

            ALL_IDS.CopyTo(ALL_ITEMS);

            BREACHES.CopyTo(ALL_IDS);
            COVENANTS.CopyTo(ALL_IDS);
            S_CHARACTERS.CopyTo(ALL_IDS);

            ALL_ITEMS_SORTED = ALL_ITEMS.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            WEAPONS_MELEE.CopyTo(MAIN_HAND);
            WEAPONS_RANGED.CopyTo(MAIN_HAND);

            WEAPONS_RANGED.CopyTo(OFF_HAND);
            SHIELDS.CopyTo(OFF_HAND);

            COVENANTS.Add(Guid.Empty, "[None]");
        }

        public static string GetNameOrId(Guid guid) {
            return ALL_IDS.ContainsKey(guid) ? ALL_IDS[guid] : guid.ToString();
        }
    }
}