using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static TunicVanillaChecklist.GameData;
using static TunicVanillaChecklist.FairyTargets;

namespace TunicVanillaChecklist {

    public class InventoryCounter : MonoBehaviour {

        private IEnumerator<bool> counterManager;
        private IEnumerator<bool> imageManager;

        private IEnumerator<bool> UpdateInventoryCounts() {
            while (true) {
                if (!InventoryDisplayPatches.Loaded) {
                    yield return true;
                    continue;
                }

                if (!PlayerCharacter.Instanced) {
                    yield return true;
                    continue;
                }
                string SceneName = SceneManager.GetActiveScene().name;
                int ObtainedItemCountInCurrentScene = 0;
                int TotalItemCountInCurrentScene = ChecksPerScene.ContainsKey(SceneName) ? ChecksPerScene[SceneName] : 0;
                int ObtainedItemCount = 0;
                int FairiesFound = 0;
                int PagesFound = 0;
                int TreasuresFound = 0;
                int CoinsTossed = SaveFile.GetInt("Trinket Coins Tossed");
                int i = 0;

                foreach (Check Check in ItemList.Values) {
                    if (SaveFile.GetInt(Check.Location.SaveFlag) >= Check.Location.SaveFlagValue) {
                        if (Check.Location.SceneName == SceneName) {
                            RemoveFairyTarget(Check.CheckId);
                            ObtainedItemCountInCurrentScene++;
                        }
                        if (Check.Reward.Name.Contains("GoldenTrophy")) {
                            TreasuresFound++;
                        }
                        if (Check.Reward.Type == "PAGE") {
                            PagesFound++;
                        }
                        if (Check.Reward.Type == "FAIRY") {
                            FairiesFound++;
                        }
                        ObtainedItemCount++;
                    }
                    i++;
                    if (i == 50) {
                        i = 0;
                        yield return true;
                    }
                }
                if (SaveFile.GetInt("chest open 19") == 1) {
                    ObtainedItemCount--;
                }
                InventoryDisplayPatches.CoinsTossed.GetComponent<TextMeshProUGUI>().text = $"Coins Tossed: {CoinsTossed}/17";
                InventoryDisplayPatches.CoinsTossed.GetComponent<TextMeshProUGUI>().color = CoinsTossed >= 17 ? InventoryDisplayPatches.Gold : Color.white;
                InventoryDisplayPatches.Fairies.GetComponent<TextMeshProUGUI>().text = $"Fairies:\t  {FairiesFound}/20";
                InventoryDisplayPatches.Fairies.GetComponent<TextMeshProUGUI>().color = FairiesFound == 20 ? InventoryDisplayPatches.Gold : Color.white;
                InventoryDisplayPatches.Pages.GetComponent<TextMeshProUGUI>().text = $"Pages:\t\t{PagesFound}/28";
                InventoryDisplayPatches.Pages.GetComponent<TextMeshProUGUI>().color = PagesFound == 28 ? InventoryDisplayPatches.Gold : Color.white;
                InventoryDisplayPatches.Treasures.GetComponent<TextMeshProUGUI>().text = $"Treasures:\t{TreasuresFound}/12";
                InventoryDisplayPatches.Treasures.GetComponent<TextMeshProUGUI>().color = TreasuresFound == 12 ? InventoryDisplayPatches.Gold : Color.white;
                InventoryDisplayPatches.ThisArea.GetComponent<TextMeshProUGUI>().text = $"This Area:\t{ObtainedItemCountInCurrentScene}/{TotalItemCountInCurrentScene}";
                InventoryDisplayPatches.ThisArea.GetComponent<TextMeshProUGUI>().color = (ObtainedItemCountInCurrentScene == TotalItemCountInCurrentScene) ? InventoryDisplayPatches.Gold : Color.white;
                InventoryDisplayPatches.Total.GetComponent<TextMeshProUGUI>().text = $"Total:\t\t  {ObtainedItemCount}/300";
                InventoryDisplayPatches.Total.GetComponent<TextMeshProUGUI>().color = (ObtainedItemCount >= 300) ? InventoryDisplayPatches.Gold : Color.white;
                yield return true;
            }
        }

        private IEnumerator<bool> UpdateInventoryImages() {

            while (true) {
                if (!InventoryDisplayPatches.Loaded) {
                    yield return true;
                    continue;
                }
                if (!InventoryDisplay.InventoryOpen) {
                    yield return true;
                    continue;
                }

                if (Inventory.GetItemByName("Hexagon Red").Quantity == 1 || SaveFile.GetInt("Placed Hexagon 1 Red") == 1) {
                    InventoryDisplay.instance.hexagonImages[0].enabled = true;
                    InventoryDisplayPatches.RedHexagon.GetComponent<Image>().color = InventoryDisplayPatches.RedMarkerColor;
                } else {
                    InventoryDisplay.instance.hexagonImages[0].enabled = false;
                    InventoryDisplayPatches.RedHexagon.GetComponent<Image>().color = Color.white;
                }

                yield return true;
                if (Inventory.GetItemByName("Hexagon Green").Quantity == 1 || SaveFile.GetInt("Placed Hexagon 2 Green") == 1) {
                    InventoryDisplay.instance.hexagonImages[1].enabled = true;
                    InventoryDisplayPatches.GreenHexagon.GetComponent<Image>().color = InventoryDisplayPatches.GreenMarkerColor;
                } else {
                    InventoryDisplay.instance.hexagonImages[1].enabled = false;
                    InventoryDisplayPatches.GreenHexagon.GetComponent<Image>().color = Color.white;
                }

                yield return true;
                if (Inventory.GetItemByName("Hexagon Blue").Quantity == 1 || SaveFile.GetInt("Placed Hexagon 3 Blue") == 1) {
                    InventoryDisplay.instance.hexagonImages[2].enabled = true;
                    InventoryDisplayPatches.BlueHexagon.GetComponent<Image>().color = Color.blue;
                } else {
                    InventoryDisplay.instance.hexagonImages[2].enabled = false;
                    InventoryDisplayPatches.BlueHexagon.GetComponent<Image>().color = Color.white;
                }

                yield return true;
                InventoryDisplayPatches.GuardCaptain.GetComponent<Image>().color = SaveFile.GetInt(BossStateVars[0]) == 1 ? InventoryDisplayPatches.GuardCaptainColor : Color.white;
                InventoryDisplayPatches.GardenKnight.GetComponent<Image>().color = SaveFile.GetInt(BossStateVars[1]) == 1 ? Color.cyan : Color.white;
                InventoryDisplayPatches.Ding.GetComponent<Image>().color = SaveFile.GetInt("Rung Bell 1 (East)") == 1 ? InventoryDisplayPatches.BellMarkerColor : Color.white;
                InventoryDisplayPatches.Dong.GetComponent<Image>().color = SaveFile.GetInt("Rung Bell 2 (West)") == 1 ? InventoryDisplayPatches.BellMarkerColor : Color.white;
                InventoryDisplayPatches.SiegeEngine.GetComponent<Image>().color = SaveFile.GetInt(BossStateVars[2]) == 1 ? InventoryDisplayPatches.RedMarkerColor : Color.white;
                InventoryDisplayPatches.Librarian.GetComponent<Image>().color = SaveFile.GetInt(BossStateVars[3]) == 1 ? InventoryDisplayPatches.GreenMarkerColor : Color.white;
                InventoryDisplayPatches.BossScavenger.GetComponent<Image>().color = SaveFile.GetInt(BossStateVars[4]) == 1 ? Color.blue : Color.white;
            }
        }

        public void Start() {
            counterManager = UpdateInventoryCounts();
            imageManager = UpdateInventoryImages();
        }

        public void Update() {
            if (counterManager != null) {
                counterManager.MoveNext();
            }
            if (imageManager != null) {
                imageManager.MoveNext();
            }
        }

        public static bool InteractionTrigger_Interact_PrefixPatch(Item item, InteractionTrigger __instance) {

            if (__instance.name == "Mailbox (1)" && __instance.GetComponent<Signpost>() != null) {
                __instance.GetComponent<Signpost>().message.text = GetItemCountsByRegion();
                NPCDialogue.DisplayDialogue(__instance.GetComponent<Signpost>().message, true);
                return false;
            }
            return true;
        }
        public static string GetItemCountsByRegion() {
            string title = $"\"- - - - - -\"  gAm Jehklist\" - - - - - -\"\n";
            string displayText = title;
            int TotalAreaChecks = 0;
            int AreaChecksFound = 0;
            List<Check> Checklist = ItemList.Values.ToList();
            foreach (string Area in MainAreasToSubAreas.Keys) {
                TotalAreaChecks = 0;
                AreaChecksFound = 0;
                foreach (string SubArea in MainAreasToSubAreas[Area]) {
                    TotalAreaChecks += Checklist.Where(check => check.Location.SceneName == SubArea).Count();
                    AreaChecksFound += Checklist.Where(check => check.Location.SceneName == SubArea && SaveFile.GetInt(check.Location.SaveFlag) >= check.Location.SaveFlagValue).Count();
                }
                displayText += $"\"{(AreaChecksFound == TotalAreaChecks ? "<#eaa614>" : "<#ffffff>")}{Area.PadRight(24, '.')}{$"{AreaChecksFound}/{TotalAreaChecks}".PadLeft(9, '.')}\"\n";
                if (Area == "Rooted Ziggurat") {
                    displayText += "---" + title;
                }
            }

            int TotalChecksFound = Checklist.Where(check => SaveFile.GetInt(check.Location.SaveFlag) >= check.Location.SaveFlagValue).Count();
            if (SaveFile.GetInt("chest open 19") == 1) {
                TotalChecksFound--;
            }

            displayText += $"\"{(TotalChecksFound == 300 ? "<#eaa614>" : "<#ffffff>")}{"Total".PadRight(24, '.')}{$"{TotalChecksFound}/300".PadLeft(9, '.')}\"";
            return displayText;
        }
    }

    public class InventoryDisplayPatches {

        public static bool Loaded = false;
        public static GameObject Stats;
        public static GameObject Title;
        public static GameObject Pages;
        public static GameObject Fairies;
        public static GameObject Treasures;
        public static GameObject CoinsTossed;
        public static GameObject ThisArea;
        public static GameObject Total;

        public static GameObject GuardCaptain;
        public static GameObject Ding;
        public static GameObject GardenKnight;
        public static GameObject Dong;
        public static GameObject SiegeEngine;
        public static GameObject RedHexagon;
        public static GameObject Librarian;
        public static GameObject GreenHexagon;
        public static GameObject BossScavenger;
        public static GameObject BlueHexagon;

        public static GameObject EquipmentRoot;

        public static Color BellMarkerColor = new Color(1f, 0.84f, 0f);
        public static Color GuardCaptainColor = new Color(.627f, .125f, .941f);
        public static Color RedMarkerColor = new Color(1f, 0f, 0f, 0.75f);
        public static Color GreenMarkerColor = new Color(0f, 1f, 0f, 0.75f);
        public static Color Gold = new Color(0.917f, 0.65f, .08f);

        public static void Initialize() {
            if (!Loaded) {
                TMP_FontAsset FontAsset = Resources.FindObjectsOfTypeAll<TMP_FontAsset>().Where(Font => Font.name == "Latin Rounded").ToList()[0];
                Material FontMaterial = Resources.FindObjectsOfTypeAll<Material>().Where(Material => Material.name == "Latin Rounded - Quantity Outline").ToList()[0];
                Stats = new GameObject("game stats");
                Stats.transform.parent = GameObject.Find("_GameGUI(Clone)/HUD Canvas/Scaler/Inventory/Inventory Subscreen/").transform;

                GameObject Backing = new GameObject("backing");
                Backing.AddComponent<Image>().sprite = Resources.FindObjectsOfTypeAll<Sprite>().Where(Sprite => Sprite.name == "UI_offeringBacking").ToList()[0];
                Backing.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.8f);
                Backing.transform.localScale = new Vector3(5f, 3.75f, 0f);
                Backing.transform.position = new Vector3(220f, -35f, 0);
                Backing.layer = 5;
                Backing.transform.parent = Stats.transform;
                GameObject.DontDestroyOnLoad(Backing);

                Title = SetupText("title", new Vector3(290f, 35f, 0f), Stats.transform, 24f, FontAsset, FontMaterial);
                Title.GetComponent<TextMeshProUGUI>().text = $"Game Checklist";
                Sprite SepLine = Resources.FindObjectsOfTypeAll<Sprite>().Where(Sprite => Sprite.name == "UI_separator_line_single").ToList()[0];
                GameObject SepLine1 = new GameObject("sep line");
                SepLine1.AddComponent<Image>().sprite = SepLine;
                SepLine1.transform.parent = Stats.transform;
                SepLine1.transform.localScale = new Vector3(1.0337f, -0.0155f, 0.05f);
                SepLine1.transform.position = new Vector3(97.41f, 29.9839f, 0f);
                GameObject SepLine2 = new GameObject("sep line");
                SepLine2.AddComponent<Image>().sprite = SepLine;
                SepLine2.transform.parent = Stats.transform;
                SepLine2.transform.localScale = new Vector3(3.4464f, -0.0155f, 0.05f);
                SepLine2.transform.position = new Vector3(217.3751f, 27.471f, 0f);

                Pages = SetupText("pages", new Vector3(195f, 0f, 0f), Stats.transform, 20f, FontAsset, FontMaterial);
                Fairies = SetupText("fairies", new Vector3(370f, 0f, 0f), Stats.transform, 20f, FontAsset, FontMaterial);
                Treasures = SetupText("treasures", new Vector3(195f, -30f, 0f), Stats.transform, 20f, FontAsset, FontMaterial);
                CoinsTossed = SetupText("coins tossed", new Vector3(370f, -30f, 0f), Stats.transform, 20f, FontAsset, FontMaterial);
                ThisArea = SetupText("this area", new Vector3(195f, -60f, 0f), Stats.transform, 20f, FontAsset, FontMaterial);
                Total = SetupText("total", new Vector3(370f, -60f, 0f), Stats.transform, 20f, FontAsset, FontMaterial);
                Pages.GetComponent<TextMeshProUGUI>().text = $"Pages:\t\t0/28";
                Fairies.GetComponent<TextMeshProUGUI>().text = $"Fairies:\t  0/20";
                Treasures.GetComponent<TextMeshProUGUI>().text = $"Treasures:\t0/12";
                CoinsTossed.GetComponent<TextMeshProUGUI>().text = $"Coins Tossed: 0/15";
                ThisArea.GetComponent<TextMeshProUGUI>().text = $"This Area:\t0/0";
                Total.GetComponent<TextMeshProUGUI>().text = $"Total:\t\t  0/302";
                GameObject.DontDestroyOnLoad(Title);
                GameObject.DontDestroyOnLoad(SepLine1);
                GameObject.DontDestroyOnLoad(SepLine2);
                GameObject.DontDestroyOnLoad(Pages);
                GameObject.DontDestroyOnLoad(Fairies);
                GameObject.DontDestroyOnLoad(Treasures);
                GameObject.DontDestroyOnLoad(CoinsTossed);
                GameObject.DontDestroyOnLoad(ThisArea);
                GameObject.DontDestroyOnLoad(Total);


                Material ImageMaterial = Resources.FindObjectsOfTypeAll<Material>().Where(mat => mat.name == "UI Add").ToList()[0];

                GuardCaptain = SetupImage("guard captain", "Alphabet New_91", Stats.transform, new Vector3(57.5f, -85f, 0f), ImageMaterial);
                Ding = SetupImage("ding", "Alphabet New_93", Stats.transform, new Vector3(92.5f, -85f, 0f), ImageMaterial);
                GardenKnight = SetupImage("garden knight", "Alphabet New_91", Stats.transform, new Vector3(127.5f, -85f, 0f), ImageMaterial);
                //Dong = SetupImage("dong", "Alphabet New_93", Stats.transform, new Vector3(162.5f, -85f, 0f), ImageMaterial);
                SiegeEngine = SetupImage("siege engine", "Alphabet New_91", Stats.transform, new Vector3(197.5f, -85f, 0f), ImageMaterial);
                RedHexagon = SetupImage("red hexagon", "Alphabet New_98", Stats.transform, new Vector3(232.5f, -84f, 0f), ImageMaterial);
                Librarian = SetupImage("librarian", "Alphabet New_91", Stats.transform, new Vector3(267.5f, -85f, 0f), ImageMaterial);
                GreenHexagon = SetupImage("green hexagon", "Alphabet New_98", Stats.transform, new Vector3(302.5f, -84f, 0f), ImageMaterial);
                BossScavenger = SetupImage("boss scavenger", "Alphabet New_91", Stats.transform, new Vector3(337.5f, -85f, 0f), ImageMaterial);
                BlueHexagon = SetupImage("blue hexagon", "Alphabet New_98", Stats.transform, new Vector3(372.5f, -84f, 0f), ImageMaterial);

                RedHexagon.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                GreenHexagon.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                BlueHexagon.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                GameObject D = SetupImage("d", "Alphabet New_24", Ding.transform, new Vector3(87f, -110f, 0f), ImageMaterial);
                D.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                GameObject I = SetupImage("i", "Alphabet New_2", D.transform, new Vector3(87f, -110f, 0f), ImageMaterial);
                I.transform.localScale = Vector3.one;
                GameObject NG = SetupImage("ng", "Alphabet New_20", Ding.transform, new Vector3(98f, -110f, 0f), ImageMaterial);
                NG.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                Dong = GameObject.Instantiate(Ding, Stats.transform);
                Dong.transform.position = new Vector3(162.5f, -85f, 0f);
                Dong.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.FindObjectsOfTypeAll<Sprite>().Where(sprite => sprite.name == "Alphabet New_1").ToList()[0];
                Dong.transform.GetChild(1).transform.position = new Vector3(167f, -110f, 0f);

                Stats.transform.SetAsFirstSibling();
                if ((float)Screen.width / Screen.height < 1.7f) {
                    Stats.transform.localScale = new Vector3(3.6f, 3.6f, 3.6f);
                }
            }
            Loaded = true;
        }

        public static GameObject SetupText(string name, Vector3 position, Transform parent, float fontSize, TMP_FontAsset fontAsset, Material fontMaterial) {
            GameObject Counter = new GameObject(name);
            Counter.AddComponent<TextMeshProUGUI>().text = $"";
            Counter.GetComponent<TextMeshProUGUI>().fontMaterial = fontMaterial;
            Counter.GetComponent<TextMeshProUGUI>().font = fontAsset;
            Counter.GetComponent<TextMeshProUGUI>().fontSize = fontSize;
            Counter.layer = 5;
            Counter.transform.parent = parent;
            Counter.GetComponent<RectTransform>().sizeDelta = new Vector2(300f, 50f);
            Counter.transform.position = position;
            Counter.transform.localScale = Vector3.one;
            return Counter;
        }

        public static GameObject SetupImage(string objectName, string spriteName, Transform parent, Vector3 position, Material material) {
            GameObject Image = new GameObject(objectName);
            Sprite Sprite = Resources.FindObjectsOfTypeAll<Sprite>().Where(sprite => sprite.name == spriteName).ToList()[0];
            Image.AddComponent<Image>().sprite = Sprite;
            Image.GetComponent<Image>().material = material;
            Image.transform.parent = parent;
            Image.layer = 5;
            Image.transform.position = position;
            Image.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            GameObject.DontDestroyOnLoad(Image);
            return Image;
        }

        public static bool InventoryDisplay_Update_PrefixPatch(InventoryDisplay __instance) {
            try {
                Initialize();
            } catch (Exception e) {
                TunicLogger.LogError(e + " " + e.Message);
            }

            Stats.SetActive(InventoryDisplay.InventoryOpen);
            return true;
        }
    }
}
