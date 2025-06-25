using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static TunicVanillaChecklist.GameData;

namespace TunicVanillaChecklist {
    public class FairyTargets {

        public static Il2CppSystem.Collections.Generic.List<FairyTarget> ItemTargets = new Il2CppSystem.Collections.Generic.List<FairyTarget> { };
        public static Il2CppSystem.Collections.Generic.List<FairyTarget> LoadZoneTargets = new Il2CppSystem.Collections.Generic.List<FairyTarget> { };

        public static void CreateFairyTargets() {
            ItemTargets.Clear();
            LoadZoneTargets.Clear();
            string scene = SceneManager.GetActiveScene().name;
            List<Check> Checks = ItemList.Values.Where(check => check.Location.SceneName == scene && SaveFile.GetInt(check.Location.SaveFlag) == 0).ToList();
            foreach (Check check in Checks) {
                ItemTargets.Add(CreateFairyTarget(check.CheckId, check.Location.Position));
            }
            if (ItemTargets.Count == 0) {
                CreateLoadZoneTargets();
            } else {
                FairyTarget.registered = ItemTargets;
            }
        }

        private static FairyTarget CreateFairyTarget(string name, string position) {
            GameObject target = new GameObject(name);
            target.transform.position = StringToVector3(position);
            target.AddComponent<FairyTarget>();
            target.GetComponent<FairyTarget>().stateVariable = StateVariable.GetStateVariableByName("false");
            target.SetActive(true);
            return target.GetComponent<FairyTarget>();
        }

        public static void CreateLoadZoneTargets() {
            HashSet<string> ScenesWithItems = new HashSet<string>();
            List<Check> Checks = ItemList.Values.Where(check => check.Location.SceneName != SceneManager.GetActiveScene().name
            && SaveFile.GetInt(check.Location.SaveFlag) == 0).ToList();

            foreach (Check Check in Checks) {
                ScenesWithItems.Add(Check.Location.SceneName);
            }

            foreach (ScenePortal ScenePortal in Resources.FindObjectsOfTypeAll<ScenePortal>()) {
                string sceneName = ScenePortal.destinationSceneName;
                if (ScenesWithItems.Contains(sceneName)) {
                    LoadZoneTargets.Add(CreateFairyTarget($"fairy target {ScenePortal.name}", ScenePortal.transform.position.ToString()));
                }
            }

            FairyTarget.registered = LoadZoneTargets;
        }

        public static void RemoveFairyTarget(string CheckId) {
            GameObject target = GameObject.Find(CheckId);
            if (target == null) {
                return;
            }

            FairyTarget fairyTarget = target.GetComponent<FairyTarget>();
            ItemTargets.Remove(fairyTarget);
            if (ItemTargets.Count == 0) {
                CreateLoadZoneTargets();
            } else {
                FairyTarget.registered = ItemTargets;
            }
        }

        public static Vector3 StringToVector3(string Position) {
            Position = Position.Replace("(", "").Replace(")", "");
            string[] coords = Position.Split(',');
            Vector3 vector = new Vector3(float.Parse(coords[0], CultureInfo.InvariantCulture), float.Parse(coords[1], CultureInfo.InvariantCulture), float.Parse(coords[2], CultureInfo.InvariantCulture));
            return vector;
        }
    }
}
