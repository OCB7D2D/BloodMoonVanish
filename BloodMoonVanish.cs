using System.Reflection;
using HarmonyLib;
using UnityEngine;

public class BloodMoonVanish : IModApi
{
    public void InitMod(Mod mod)
    {
        Debug.Log("Loading Blood Moon Vanish Patch: " + GetType().ToString());
        var harmony = new Harmony(GetType().ToString());
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    [HarmonyPatch(typeof (WeatherManager))]
    [HarmonyPatch("SpectrumsFrameUpdate")]
    public class WeatherManager_SpectrumsFrameUpdate
    {
        public static bool Prefix(SpectrumWeatherType ___spectrumTargetType)
        {
            return ___spectrumTargetType != SpectrumWeatherType.BloodMoon;
        }
    }

    [HarmonyPatch(typeof (SkyManager))]
    [HarmonyPatch("BloodMoonVisiblePercent")]
    public class WeatherManager_BloodMoonVisiblePercent
    {
        public static bool Prefix(ref float __result)
        {
            __result = 0f;
            return false;
        }
    }

    [HarmonyPatch(typeof (SkyManager))]
    [HarmonyPatch("IsBloodMoonVisible")]
    public class SkyManager_IsBloodMoonVisible
    {
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof (DynamicMusic.Section))]
    [HarmonyPatch("Play")]
    public class DynamicMusicSection_Play
    {
        public static bool Prefix(DynamicMusic.Section __instance)
        {
            return !(__instance is DynamicMusic.Bloodmoon);
        }
    }
}
