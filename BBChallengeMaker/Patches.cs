using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Net;
using System.IO;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;
using HarmonyLib;
using BepInEx.Configuration;
using BBPlusNameAPI;
using System.Collections.Generic;
using System.Linq;
using BBChallengeMaker.MapData;
using Newtonsoft.Json;

namespace BBChallengeMaker
{
    [HarmonyPatch(typeof(LevelGenerator))]
    [HarmonyPatch("StartGenerate")]
    class LoadCustomData
    {
        static bool Prefix(LevelGenerator __instance)
        {
            //File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "test.json"), JsonConvert.SerializeObject(__instance.ld.ToData()));
            //MapData.LevelData data = JsonConvert.DeserializeObject<MapData.LevelData>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "test.json")));
            BaldiChallengeMaker.LevelDatas[0].SendToData(ref __instance.ld);
            return true;
        }
    }
}
