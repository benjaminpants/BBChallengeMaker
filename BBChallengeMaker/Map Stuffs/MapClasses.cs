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
using Newtonsoft.Json;

namespace BBChallengeMaker.MapData
{
    public class HallBuilderGeneric
    {

        public float chance;
        public string Name;
    }
    public class LockerBuilderGeneric : HallBuilderGeneric
    {
        public int minLockers = 15;
        public int maxLockers = 40;
        public float hideableChance = 2f;
    }
}
