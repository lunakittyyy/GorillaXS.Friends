using BepInEx;
using System;

namespace GorillaXS.Friends
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void Start() => gameObject.AddComponent<PlayerPUN>();
    }
}
