﻿using System;
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

    public class ObjectBuilderGeneric
    {

        public int weight;
        public string Name;
    }

    public class HallObjectBuilderGeneric : ObjectBuilderGeneric
    {
        public string Prefab;
    }

    public class SwingDoorBuilderGeneric : ObjectBuilderGeneric
    {
        public float spawnChance = 0.2f;
        public int minHallLength = 5;
    }

    public class RotoHallBuilderGeneric : ObjectBuilderGeneric
    {
        public int buttonRange = 6;
    }
    public class BeltBuilderGeneric : ObjectBuilderGeneric
    {
        public int buttonRange = 3;
        public int minHallSize = 6;
        public float buttonChance = 25f;
    }

    public class LockdownDoorBuilderGeneric : ObjectBuilderGeneric
    {
        public int buttonRange = 5;
    }

    public class RoomBuilderGeneric
    {
        public string Name;
        public int Weight;
    }

    public class LibraryBuilderGeneric : RoomBuilderGeneric
    {
        public int maxEndItems = 2;
        public List<ItemGeneric> Items = new List<ItemGeneric>();
    }

    public class OfficeBuilderGeneric : RoomBuilderGeneric
    {
        public float windowChance = 50f;
    }

    public class ClassBuilderGeneric : RoomBuilderGeneric
    {
        public float chairDistance = 0.2f;
    }

    public class LockerBuilderGeneric : HallBuilderGeneric
    {
        public int minLockers = 15;
        public int maxLockers = 40;
        public float hideableChance = 2f;
    }
}
