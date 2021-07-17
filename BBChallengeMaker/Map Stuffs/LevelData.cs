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
using HarmonyLib.Tools;
using System.Linq;

namespace BBChallengeMaker.MapData
{
    public class LevelData //what half of these parameters mean i have ZERO clue
    {
        public LevelData()
        {

        }

        public string Name = "Floor Name";

        public string FloorName = "CF1";

        public int Seed = 0;

        public bool ForcesSeed = true;

        public IntVector2 minSize = new IntVector2(25, 25);

        public IntVector2 maxSize = new IntVector2(100, 100);

        public int minPlots = 5;

        public int maxPlots = 10;

        public int minPlotSize = 5;

        public int outerEdgeBuffer = 5;

        public int minHallsToRemove = 2;

        public int maxHallsToRemove = 5;

        public int minSideHallsToRemove = 0;

        public int maxSideHallsToRemove = 1;

        public int minReplacementHalls = 2;

        public int maxReplacementHalls = 5;

        public int bridgeTurnChance = 2;

        public int additionTurnChance = 5;

        public int maxHallAttempts = 3;

        public int deadEndBuffer = 6;

        public bool includeBuffers = true;

        public int maxLightDistance = 8;

        public int minSpecialBuilders = 2;

        public int maxSpecialBuilders = 5;

        public int minClassRooms = 5;

        public int maxClassRooms = 10;

        public int minFacultyRooms = 5;

        public int maxFacultyRooms = 10;

        public int minExtraRooms = 5;

        public int maxExtraRooms = 10;

        public int minOffices = 1;

        public int maxOffices = 1;

        public IntVector2 maxRoomSize = new IntVector2(3, 3);

        public IntVector2 minRoomSize = new IntVector2(6, 6);

        public float centerWeightMultiplier = 25f;

        public float perimeterBase = 4f;

        public float classDistanceWeightExponent = 1.5f;

        public int passThroughChance = 15;

        public int minSpecialRooms = 1;

        public int maxSpecialRooms = 2;

        public float windowChance = 0.5f;

        public LightMode lightMode = LightMode.Additive;

        public float standardLightChance = 10f;

        public int standardLightStrength = 10;

        public LightColor standardLightColor = new LightColor(1f,1f,1f);

        public LightColor standardDarkLevel = new LightColor(32f, 32f, 16f);

        public int additionalNPCs = 1;

        public float posterChance = 1f;

        public int baseRoomItemValue = 25;

        public int minGuaranteedItemValue = 40;

        public int itemChance = 50;

        public int singleEntranceItemVal = 10;

        public int facultyItemVal = 25;

        public int noHallItemVal = 15;

        public int minEvents = 1;

        public int maxEvents = 3;

        public float initialEventGap = 60f;

        public float minEventGap = 60f;

        public float maxEventGap = 210f;

        public int exitCount = 1;

        public int roomBuffer = 3;

        public int hallBuffer = 2;

        public int edgeBuffer = 3;

        public int mapPrice = 250;

        public int totalShopItems = 4;

        public float timeBonusLimit;

        public int timeBonusVal = 50;

        public List<HallBuilderGeneric> standardHallBuilders = new List<HallBuilderGeneric>();

        public List<ObjectBuilderGeneric> specialHallBuilders = new List<ObjectBuilderGeneric>();

        public List<NPCGeneric> potentialNPCs = new List<NPCGeneric>();

        public List<string> forcedNpcs = new List<string>();

        public void SendToData(ref LevelObject obj)
        {
            obj.minSize = minSize;
            obj.maxSize = maxSize;
            obj.minPlots = minPlots;
            obj.maxPlots = maxPlots;
            obj.minPlotSize = minPlotSize;
            obj.outerEdgeBuffer = outerEdgeBuffer;
            obj.minHallsToRemove = minHallsToRemove;
            obj.maxHallsToRemove = maxHallsToRemove;
            obj.minSideHallsToRemove = minSideHallsToRemove;
            obj.maxSideHallsToRemove = maxSideHallsToRemove;
            obj.minReplacementHalls = minReplacementHalls;
            obj.maxReplacementHalls = maxReplacementHalls;
            obj.bridgeTurnChance = bridgeTurnChance;
            obj.additionTurnChance = additionTurnChance;
            obj.maxHallAttempts = maxHallAttempts;
            obj.deadEndBuffer = deadEndBuffer;
            obj.includeBuffers = includeBuffers;
            obj.maxLightDistance = maxLightDistance;
            obj.minSpecialBuilders = minSpecialBuilders;
            obj.maxSpecialBuilders = maxSpecialBuilders;
            obj.minClassRooms = minClassRooms;
            obj.maxClassRooms = maxClassRooms;
            obj.minFacultyRooms = minFacultyRooms;
            obj.maxFacultyRooms = maxFacultyRooms;
            obj.minExtraRooms = minExtraRooms;
            obj.maxExtraRooms = maxExtraRooms;
            obj.minOffices = minOffices;
            obj.maxOffices = maxOffices;
            obj.minRoomSize = minRoomSize;
            obj.maxRoomSize = maxRoomSize;
            obj.centerWeightMultiplier = centerWeightMultiplier;
            obj.perimeterBase = perimeterBase;
            obj.classDistanceWeightExponent = classDistanceWeightExponent;
            obj.passThroughChance = passThroughChance;
            obj.minSpecialRooms = minSpecialRooms;
            obj.maxSpecialRooms = maxSpecialRooms;
            obj.windowChance = windowChance;
            obj.lightMode = lightMode;
            obj.standardLightChance = standardLightChance;
            obj.standardLightStrength = standardLightStrength;
            obj.standardLightColor = new Color(standardLightColor.r, standardLightColor.g, standardLightColor.b);
            obj.standardDarkLevel = new Color(standardDarkLevel.r, standardDarkLevel.g, standardDarkLevel.b);
            obj.additionalNPCs = additionalNPCs;
            obj.posterChance = posterChance;
            obj.baseRoomItemValue = baseRoomItemValue;
            obj.minGuaranteedItemValue = minGuaranteedItemValue;
            obj.itemChance = itemChance;
            obj.singleEntranceItemVal = singleEntranceItemVal;
            obj.facultyItemVal = facultyItemVal;
            obj.noHallItemVal = noHallItemVal;
            obj.minEvents = minEvents;
            obj.maxEvents = maxEvents;
            obj.initialEventGap = initialEventGap;
            obj.minEventGap = minEventGap;
            obj.maxEventGap = maxEventGap;
            obj.exitCount = exitCount;
            obj.roomBuffer = roomBuffer;
            obj.hallBuffer = hallBuffer;
            obj.edgeBuffer = edgeBuffer;
            obj.mapPrice = mapPrice;
            obj.totalShopItems = totalShopItems;
            obj.timeBonusLimit = timeBonusLimit;
            obj.timeBonusVal = timeBonusVal;
            HallBuilder[] allhallgenericbuilders = Resources.FindObjectsOfTypeAll<HallBuilder>();

            List<RandomHallBuilder> hallbuilds = new List<RandomHallBuilder>();
            foreach (HallBuilderGeneric hbg in standardHallBuilders)
            {

                HallBuilder build = allhallgenericbuilders.ToList().Find(x => x.GetType().Name == hbg.Name);

                if (build == null)
                {
                    UnityEngine.Debug.LogWarning("Type:\"" + hbg.Name + "\" not found!");
                    continue;
                }
                build = GameObject.Instantiate(build);
                if (hbg.Name == "LockerBuilder")
                {
                    LockerBuilder lockbuild = (LockerBuilder)build;
                    LockerBuilderGeneric gnbuild = (LockerBuilderGeneric)hbg;
                    FieldInfo minLockers = AccessTools.Field(typeof(LockerBuilder), "minLockers");
                    minLockers.SetValue(lockbuild, gnbuild.minLockers);
                    FieldInfo maxLockers = AccessTools.Field(typeof(LockerBuilder), "maxLockers");
                    maxLockers.SetValue(lockbuild, gnbuild.maxLockers);
                    FieldInfo hideableChance = AccessTools.Field(typeof(LockerBuilder), "hideableChance");
                    hideableChance.SetValue(lockbuild, gnbuild.hideableChance);
                }
                RandomHallBuilder rngbuild = new RandomHallBuilder();
                rngbuild.chance = hbg.chance;
                rngbuild.selectable = build;
                hallbuilds.Add(rngbuild);

            }
            obj.standardHallBuilders = hallbuilds.ToArray();
            ObjectBuilder[] allobjectgenericbuilders = Resources.FindObjectsOfTypeAll<ObjectBuilder>();

            List<WeightedObjectBuilder> objectbuilds = new List<WeightedObjectBuilder>();

            foreach (ObjectBuilderGeneric whb in specialHallBuilders)
            {

                ObjectBuilder build = allobjectgenericbuilders.ToList().Find(x => x.GetType().Name == whb.Name);
                
                if (build == null)
                {
                    UnityEngine.Debug.LogWarning("Type:\"" + whb.Name + "\" not found!");
                    continue;
                }
                build = GameObject.Instantiate(build);
                try
                {

                    if (whb.Name == "SwingDoorBuilder")
                    {
                        SwingDoorBuilderGeneric gen = (SwingDoorBuilderGeneric)whb;
                        FieldInfo spawnChance = AccessTools.Field(typeof(SwingDoorBuilder), "spawnChance");
                        spawnChance.SetValue(build, gen.spawnChance);
                        FieldInfo minHallLength = AccessTools.Field(typeof(SwingDoorBuilder), "minHallLength");
                        minHallLength.SetValue(build, gen.minHallLength);
                    }
                    else if (whb.Name == "RotoHallBuilder")
                    {
                        RotoHallBuilderGeneric gen = (RotoHallBuilderGeneric)whb;
                        FieldInfo buttonRange = AccessTools.Field(typeof(RotoHallBuilder), "buttonRange");
                        buttonRange.SetValue(build, gen.buttonRange);
                    }
                    else if (whb.Name == "BeltBuilder")
                    {
                        BeltBuilderGeneric gen = (BeltBuilderGeneric)whb;
                        FieldInfo buttonRange = AccessTools.Field(typeof(BeltBuilder), "buttonRange");
                        buttonRange.SetValue(build, gen.buttonRange);
                        FieldInfo minHallSize = AccessTools.Field(typeof(BeltBuilder), "minHallSize");
                        minHallSize.SetValue(build, gen.minHallSize);
                    }
                    else if (whb.Name == "LockdownDoorBuilder")
                    {
                        LockdownDoorBuilderGeneric gen = (LockdownDoorBuilderGeneric)whb;
                        FieldInfo buttonRange = AccessTools.Field(typeof(LockdownDoorBuilder), "buttonRange");
                        buttonRange.SetValue(build, gen.buttonRange);
                    }
                    else if (whb.Name == "GenericHallBuilder")
                    {
                        HallObjectBuilderGeneric gen = (HallObjectBuilderGeneric)whb;
                        FieldInfo objectPlacer = AccessTools.Field(typeof(GenericHallBuilder), "objectPlacer");
                        FieldInfo prefab = AccessTools.Field(typeof(ObjectPlacer), "prefab");
                        
                        try
                        {
                            build = GameObject.Instantiate(Resources.FindObjectsOfTypeAll<GenericHallBuilder>().ToList().Find(x => (prefab.GetValue((objectPlacer.GetValue(x) as ObjectPlacer)) as GameObject).name == gen.Prefab)); //if the variables where public the predicate would just be: x.objectPlacer.prefab.name == gen.Prefab
                        }
                        catch (Exception E)
                        {
                            UnityEngine.Debug.LogWarning("Exception Caught while trying to find prefab!");
                            UnityEngine.Debug.LogException(E);
                            GameObject.Destroy(build);
                            continue;
                        }
                    }
                }
                catch(Exception E)
                {
                    UnityEngine.Debug.LogError("Error encountered while trying to parse specialHallBuilders!");
                    UnityEngine.Debug.LogException(E);
                    continue;
                }

                WeightedObjectBuilder wob = new WeightedObjectBuilder();
                wob.selection = build;
                wob.weight = whb.weight;
                objectbuilds.Add(wob);
            }

            obj.specialHallBuilders = objectbuilds.ToArray();
            List<NPC> allnpcs = Resources.FindObjectsOfTypeAll<NPC>().ToList(); //get all NPCs that exist in the game
            List<NPC> npcstoforce = new List<NPC>();
            foreach (string npctype in forcedNpcs)
            {
                NPC npctoadd = allnpcs.Find(x => x.Character.ToString() == npctype);
                if (npctoadd == null)
                {
                    UnityEngine.Debug.LogWarning("Invalid NPC:" + npctype + "\nNPC will not be added to forcedNpcs!");
                    continue;
                }
                npcstoforce.Add(npctoadd);
            }
            obj.forcedNpcs = npcstoforce.ToArray();
            List<WeightedNPC> weightednpcs = new List<WeightedNPC>();
            foreach (NPCGeneric npc in potentialNPCs)
            {
                NPC npcval = allnpcs.Find(x => x.Character.ToString() == npc.Character);
                if (npcval == null)
                {
                    UnityEngine.Debug.LogWarning("Invalid NPC:" + npc.Character + "\nNPC will not be added to potentialNPCs!");
                    continue;
                }
                WeightedNPC npctoadd = new WeightedNPC();
                npctoadd.weight = npc.weight;
                npctoadd.selection = npcval;
                weightednpcs.Add(npctoadd);
            }
            obj.potentialNPCs = weightednpcs;
            


            
        }




    }

    public class LightColor
    {
        public float r;
        public float b;
        public float g;
        public LightColor()
        {

        }

        public LightColor(float R, float G, float B)
        {
            r = R;
            g = G;
            b = B;
        }
    }

    public static class ExtensionMethod
    {

        public static LevelData ToData(this LevelObject me)
        {
            LevelData obj = new LevelData();
            obj.minSize = me.minSize;
            obj.maxSize = me.maxSize;
            obj.minPlots = me.minPlots;
            obj.maxPlots = me.maxPlots;
            obj.minPlotSize = me.minPlotSize;
            obj.outerEdgeBuffer = me.outerEdgeBuffer;
            obj.minHallsToRemove = me.minHallsToRemove;
            obj.maxHallsToRemove = me.maxHallsToRemove;
            obj.minSideHallsToRemove = me.minSideHallsToRemove;
            obj.maxSideHallsToRemove = me.maxSideHallsToRemove;
            obj.minReplacementHalls = me.minReplacementHalls;
            obj.maxReplacementHalls = me.maxReplacementHalls;
            obj.bridgeTurnChance = me.bridgeTurnChance;
            obj.additionTurnChance = me.additionTurnChance;
            obj.maxHallAttempts = me.maxHallAttempts;
            obj.deadEndBuffer = me.deadEndBuffer;
            obj.includeBuffers = me.includeBuffers;
            obj.maxLightDistance = me.maxLightDistance;
            obj.minSpecialBuilders = me.minSpecialBuilders;
            obj.maxSpecialBuilders = me.maxSpecialBuilders;
            obj.minClassRooms = me.minClassRooms;
            obj.maxClassRooms = me.maxClassRooms;
            obj.minFacultyRooms = me.minFacultyRooms;
            obj.maxFacultyRooms = me.maxFacultyRooms;
            obj.minExtraRooms = me.minExtraRooms;
            obj.maxExtraRooms = me.maxExtraRooms;
            obj.minOffices = me.minOffices;
            obj.maxOffices = me.maxOffices;
            obj.minRoomSize = me.minRoomSize;
            obj.maxRoomSize = me.maxRoomSize;
            obj.centerWeightMultiplier = me.centerWeightMultiplier;
            obj.perimeterBase = me.perimeterBase;
            obj.classDistanceWeightExponent = me.classDistanceWeightExponent;
            obj.passThroughChance = me.passThroughChance;
            obj.minSpecialRooms = me.minSpecialRooms;
            obj.maxSpecialRooms = me.maxSpecialRooms;
            obj.windowChance = me.windowChance;
            obj.lightMode = me.lightMode;
            obj.standardLightChance = me.standardLightChance;
            obj.standardLightStrength = me.standardLightStrength;
            obj.standardLightColor = new LightColor(me.standardLightColor.r, me.standardLightColor.g, me.standardLightColor.b);
            obj.standardDarkLevel = new LightColor(me.standardDarkLevel.r, me.standardLightColor.g, me.standardLightColor.b);
            obj.additionalNPCs = me.additionalNPCs;
            obj.posterChance = me.posterChance;
            obj.baseRoomItemValue = me.baseRoomItemValue;
            obj.minGuaranteedItemValue = me.minGuaranteedItemValue;
            obj.itemChance = me.itemChance;
            obj.singleEntranceItemVal = me.singleEntranceItemVal;
            obj.facultyItemVal = me.facultyItemVal;
            obj.noHallItemVal = me.noHallItemVal;
            obj.minEvents = me.minEvents;
            obj.maxEvents = me.maxEvents;
            obj.initialEventGap = me.initialEventGap;
            obj.minEventGap = me.minEventGap;
            obj.maxEventGap = me.maxEventGap;
            obj.exitCount = me.exitCount;
            obj.roomBuffer = me.roomBuffer;
            obj.hallBuffer = me.hallBuffer;
            obj.edgeBuffer = me.edgeBuffer;
            obj.mapPrice = me.mapPrice;
            obj.totalShopItems = me.totalShopItems;
            obj.timeBonusLimit = me.timeBonusLimit;
            obj.timeBonusVal = me.timeBonusVal;
            foreach (RandomHallBuilder whb in me.standardHallBuilders)
            {
                HallBuilderGeneric hbg = null;
                if (whb.selectable.GetType() == typeof(LockerBuilder))
                {
                    hbg = new LockerBuilderGeneric();
                    LockerBuilderGeneric buld = hbg as LockerBuilderGeneric;
                    LockerBuilder buil = (LockerBuilder)whb.selectable;
                    FieldInfo minLockers = AccessTools.Field(typeof(LockerBuilder), "minLockers");
                    buld.minLockers = (int)minLockers.GetValue(buil);
                    FieldInfo maxLockers = AccessTools.Field(typeof(LockerBuilder), "maxLockers");
                    buld.maxLockers = (int)maxLockers.GetValue(buil);
                    FieldInfo hideableChance = AccessTools.Field(typeof(LockerBuilder), "hideableChance");
                    buld.hideableChance = (float)hideableChance.GetValue(buil);
                }
                else
                {
                    hbg = new HallBuilderGeneric();
                }
                hbg.Name = whb.selectable.GetType().Name;
                hbg.chance = whb.chance;
                obj.standardHallBuilders.Add(hbg);
            }

            foreach (WeightedObjectBuilder whb in me.specialHallBuilders)
            {
                ObjectBuilderGeneric hbg = null;
                if (whb.selection.GetType() == typeof(SwingDoorBuilder))
                {
                    hbg = new SwingDoorBuilderGeneric();
                    SwingDoorBuilderGeneric buld = hbg as SwingDoorBuilderGeneric;
                    SwingDoorBuilder buil = (SwingDoorBuilder)whb.selection;
                    FieldInfo spawnChance = AccessTools.Field(typeof(SwingDoorBuilder), "spawnChance");
                    buld.spawnChance = (float)spawnChance.GetValue(buil);
                    FieldInfo minHallLength = AccessTools.Field(typeof(SwingDoorBuilder), "minHallLength");
                    buld.minHallLength = (int)minHallLength.GetValue(buil);
                }
                else if (whb.selection.GetType() == typeof(RotoHallBuilder))
                {
                    hbg = new RotoHallBuilderGeneric();
                    RotoHallBuilderGeneric buld = hbg as RotoHallBuilderGeneric;
                    RotoHallBuilder buil = (RotoHallBuilder)whb.selection;
                    FieldInfo buttonRange = AccessTools.Field(typeof(RotoHallBuilder), "buttonRange");
                    buld.buttonRange = (int)buttonRange.GetValue(buil);
                }
                else if (whb.selection.GetType() == typeof(BeltBuilder))
                {
                    hbg = new BeltBuilderGeneric();
                    BeltBuilderGeneric buld = hbg as BeltBuilderGeneric;
                    BeltBuilder buil = (BeltBuilder)whb.selection;
                    FieldInfo buttonRange = AccessTools.Field(typeof(BeltBuilder), "buttonRange");
                    buld.buttonRange = (int)buttonRange.GetValue(buil);
                    FieldInfo minHallSize = AccessTools.Field(typeof(BeltBuilder), "minHallSize");
                    buld.minHallSize = (int)minHallSize.GetValue(buil);
                }
                else if (whb.selection.GetType() == typeof(LockdownDoorBuilder))
                {
                    hbg = new LockdownDoorBuilderGeneric();
                    LockdownDoorBuilderGeneric buld = hbg as LockdownDoorBuilderGeneric;
                    LockdownDoorBuilder buil = (LockdownDoorBuilder)whb.selection;
                    FieldInfo buttonRange = AccessTools.Field(typeof(LockdownDoorBuilder), "buttonRange");
                    buld.buttonRange = (int)buttonRange.GetValue(buil);
                }
                else if (whb.selection.GetType() == typeof(GenericHallBuilder))
                {
                    hbg = new HallObjectBuilderGeneric();
                    HallObjectBuilderGeneric buld = hbg as HallObjectBuilderGeneric;
                    GenericHallBuilder buil = (GenericHallBuilder)whb.selection;
                    FieldInfo objectPlacer = AccessTools.Field(typeof(GenericHallBuilder), "objectPlacer");
                    FieldInfo prefab = AccessTools.Field(typeof(ObjectPlacer), "prefab");
                    buld.Prefab = (prefab.GetValue(objectPlacer.GetValue(buil) as ObjectPlacer) as GameObject).name;
                }
                else
                {
                    hbg = new ObjectBuilderGeneric();
                }
                hbg.Name = whb.selection.GetType().Name;
                hbg.weight = whb.weight;
                obj.specialHallBuilders.Add(hbg);
            }
            foreach (NPC npc in me.forcedNpcs)
            {

                obj.forcedNpcs.Add(npc.Character.ToString());
            }
            foreach (WeightedNPC npc in me.potentialNPCs)
            {
                NPCGeneric npcgen = new NPCGeneric();
                npcgen.Character = npc.selection.Character.ToString();
                npcgen.weight = npc.weight;
                obj.potentialNPCs.Add(npcgen);
            }

            return obj;
        }
    }

}
