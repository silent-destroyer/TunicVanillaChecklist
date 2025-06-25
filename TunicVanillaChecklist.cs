using System.IO;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TunicVanillaChecklist.GameData;

namespace TunicVanillaChecklist {


    [BepInPlugin(PluginInfo.GUID, PluginInfo.NAME, PluginInfo.VERSION)]
    public class TunicVanillaChecklist : BasePlugin{

        public override void Load() {
            TunicLogger.SetLogger(Log);
            TunicLogger.LogInfo($"{PluginInfo.NAME} v{PluginInfo.VERSION} loaded!");

            RegisterTypeAndCreateObject(typeof(InventoryCounter), "inventory counter");

            Setup();

            Harmony Harmony = new Harmony(PluginInfo.GUID);
            Harmony.Patch(AccessTools.Method(typeof(InventoryDisplay), "Update"), new HarmonyMethod(AccessTools.Method(typeof(InventoryDisplayPatches), "InventoryDisplay_Update_PrefixPatch")));
            Harmony.Patch(AccessTools.Method(typeof(SceneLoader), "OnSceneLoaded"), null, new HarmonyMethod(AccessTools.Method(typeof(SceneLoaderPatches), "SceneLoader_OnSceneLoaded_PostfixPatch")));
            Harmony.Patch(AccessTools.Method(typeof(InteractionTrigger), "Interact"), new HarmonyMethod(AccessTools.Method(typeof(InventoryCounter), "InteractionTrigger_Interact_PrefixPatch")));

        }

        public void Setup() {
            ChecksPerScene.Clear();
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
                string SceneName = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                ChecksPerScene.Add(SceneName, 0);
            }
            foreach (Check check in ItemList.Values) {
                if (!ChecksPerScene.ContainsKey(check.Location.SceneName)) {
                    ChecksPerScene.Add(check.Location.SceneName, 0);
                }
                ChecksPerScene[check.Location.SceneName]++;
            }
        }

        private static void RegisterTypeAndCreateObject(System.Type type, string name) {
            ClassInjector.RegisterTypeInIl2Cpp(type);
            UnityEngine.Object.DontDestroyOnLoad(new GameObject(name, new Il2CppSystem.Type[]
            {
                Il2CppType.From(type)
            }) {
                hideFlags = HideFlags.HideAndDontSave
            });
        }
    }
}
