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
            //File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "test.json"), JsonConvert.SerializeObject(__instance.ld.ToData(),Formatting.Indented,BaldiChallengeMaker.settings));
            //MapData.LevelData data = JsonConvert.DeserializeObject<MapData.LevelData>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "test.json")));
            BaldiChallengeMaker.LevelDatas[BaldiChallengeMaker.SelectedMap].SendToData(ref __instance.ld);
            
            return true;
        }
    }

    [HarmonyPatch(typeof(Directions))]
    [HarmonyPatch("All")]
    class AllowStuff
    {
        static bool Prefix(ref List<Direction> __result)
        {
            System.Reflection.MethodBase fo = (new System.Diagnostics.StackTrace()).GetFrame(2).GetMethod(); //gets the thing that called it
            if (fo.Name == "MoveNext")
            {
                UnityEngine.Debug.Log("Got the generator shits, probably");

                List<Direction> directions = new List<Direction>
                {
                    Direction.North,
                    Direction.East,
                    Direction.South,
                    Direction.West,
                };
                __result = new List<Direction>
                {
                    Direction.North,
                    Direction.East,
                    Direction.South,
                    Direction.West,
                };
                if (BaldiChallengeMaker.LevelDatas[0].exitCount <= 4) return false;
                for (int i = 0; i < BaldiChallengeMaker.LevelDatas[BaldiChallengeMaker.SelectedMap].exitCount; i++)
                {
                    __result.Add(directions[i % 4]); //this make it look pretty :D
                }
                return false;
            }

            return true;
        }
    }


    [HarmonyPatch(typeof(BaseGameManager))]
    [HarmonyPatch("Initialize")]
    class BaseGameOverride
    {
        static bool Prefix(BaseGameManager __instance)
        {
            __instance.Ec.map.CompleteMap();
            //BaldiChallengeMaker.DumpAll(null);
            return true;
        }
    }
}
