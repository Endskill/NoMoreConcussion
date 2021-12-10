using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;

namespace NoMoreConcussion
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class BepinExLoader : BasePlugin
    {
        public const string
       MODNAME = "NoMoreConcussion",
       AUTHOR = "Endskill",
       GUID = AUTHOR + "." + MODNAME,
       VERSION = "1.0.0";

        public override void Load()
        {
            new Harmony(GUID).PatchAll();
        }
    }

    [HarmonyPatch(typeof(FPS_RecoilSystem))]
    public class NoMoreConclussionPatch
    {
        [HarmonyPatch(nameof(FPS_RecoilSystem.ApplyRecoil))]
        [HarmonyPostfix]
        public static void ApplyRecoilPostfix(FPS_RecoilSystem __instance)
        {
            __instance.m_concussionShakeIntensity = 0f;
            __instance.m_concussionShakeFrequency = 0f;
            __instance.m_concussionShakeOffset = 0f;
            __instance.m_concussionShakeDuration = 0f;
            __instance.m_concussionShakeTimer = 0f;
        }
    }
}
