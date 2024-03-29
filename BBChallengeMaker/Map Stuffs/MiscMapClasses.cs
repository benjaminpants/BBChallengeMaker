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
    public class NPCGeneric
    {
        public int weight;
        public string Character;
    }

    public class ItemGeneric
    {
        public int weight;
        public string Item;
        public ItemGeneric()
        {

        }

        public ItemGeneric(string name, int wayt)
        {
            weight = wayt;
            Item = name;
        }
    }

    public class EventGeneric
    {
        public int weight;
        public string Event;
        public EventGeneric()
        {

        }

        public EventGeneric(string name, int wayt)
        {
            weight = wayt;
            Event = name;
        }
    }

}
