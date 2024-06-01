using BepInEx;
using HarmonyLib;

namespace ValheimBrighterSwamp
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private static Plugin Instance;
        private static bool IsInit = false;

        void Awake()
        {
            Plugin.Instance = this;

            Harmony.CreateAndPatchAll(typeof(Plugin));
            Instance.Logger.LogInfo("Plugin is awake. Waiting for EnvMan to become available...");
        }

        void OnDestroy()
        {
            Plugin.Instance = null;
        }

        [HarmonyPatch(typeof(EnvMan), "Awake")]
        [HarmonyPostfix]
        static void EnvMan_Awake_Patch(EnvMan __instance)
        {
            Instance.Logger.LogInfo("EnvMan initialized. Changing Swamp lighting parameters...");

            if (!IsInit)
            {
                bool changed = false;
                BiomeEnvSetup swampBiome =
                    EnvMan.instance.m_biomes.Find(x => x.m_name == "Swamp");

                if (swampBiome != default(BiomeEnvSetup))
                {
                    EnvEntry swampRainEnvEntry =
                        swampBiome.m_environments.Find(x => x.m_environment == "SwampRain");

                    if (swampRainEnvEntry != default(EnvEntry))
                    {
                        swampRainEnvEntry.m_env.m_lightIntensityNight = 1;
                        swampRainEnvEntry.m_env.m_lightIntensityDay = 1.7f;

                        changed = true;
                    }
                }

                if (changed)
                {
                    Instance.Logger.LogInfo("Swamp lighting increased successfully.");
                }
                else
                {
                    Instance.Logger.LogInfo("Couldn't update Swamp lighting.");
                }

                IsInit = true;
            }
        }
    }

}
