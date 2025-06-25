using UnityEngine.SceneManagement;

namespace TunicVanillaChecklist {
    public class SceneLoaderPatches {
        public static void SceneLoader_OnSceneLoaded_PostfixPatch(Scene loadingScene, LoadSceneMode mode, SceneLoader __instance) {
            FairyTargets.CreateFairyTargets();
        }
    }
}
