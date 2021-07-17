using System;
using System.Diagnostics;
using System.Collections;
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
using BBChallengeMaker.MapData;


//This entire codebase will probably be re-used for a future project ;)
namespace BBChallengeMaker
{
    [BepInPlugin("mtm101.rulerp.bbplus.challengemaker", "BB+ Challenge Maker", "0.0.0.0")]

    public class BaldiChallengeMaker : BaseUnityPlugin
    {

        public static JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        public static List<MapData.LevelData> LevelDatas = new List<MapData.LevelData>();

        private static Texture TextureFromBase64(string base64)
        {
            byte[] array = Convert.FromBase64String(base64);
            Texture2D texture2D = new Texture2D(1, 1, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(texture2D, array);
            texture2D.filterMode = 0;
            return texture2D;
        }


        private static bool HasAlreadyLoaded = false;
        private static void Load()
        {
            if (HasAlreadyLoaded)
            {
                return;
            }
            HasAlreadyLoaded = true;
            string pathtoload = Path.Combine(Application.persistentDataPath, "Mods", "BBChallengeMaker", "data.dat");
            if (File.Exists(pathtoload))
            {
                FileStream stream = File.OpenRead(pathtoload);
                BinaryReader reader = new BinaryReader(stream);
                try
                {
                    //SlotsPriv = reader.ReadByte();
                }
                catch (Exception E)
                {
                    UnityEngine.Debug.LogError(E.Message);
                }
                reader.Close();
            }
            else
            {
                Save();
            }
        }

        private static void Save()
        {
            string pathtosave = Path.Combine(Application.persistentDataPath, "Mods", "BBChallengeMaker");
            if (!Directory.Exists(pathtosave))
            {
                Directory.CreateDirectory(pathtosave);
            }
            DirectoryInfo fo = new DirectoryInfo(pathtosave);
            FileInfo[] filefo = fo.GetFiles("data.dat");
            if (filefo.Length != 0)
            {
                filefo[0].Delete();
            }
            FileStream stream = File.Create(Path.Combine(pathtosave, "data.dat"));
            BinaryWriter writer = new BinaryWriter(stream);

            //writer.Write((byte)SlotsPriv);

            writer.Close();
        }

        /*public static byte Slots
        {
            get
            {
                Load();
                return SlotsPriv;
            }

            set
            {
                SlotsPriv = value;
                Save();
            }


        }*/



        public static void DumpAll(Name_MenuObject obj)
        {
            SceneObject[] objs = Resources.FindObjectsOfTypeAll<SceneObject>().Reverse().ToArray(); //copied from the mod menu
            UnityEngine.Debug.Log(objs.Length);
            foreach (SceneObject obej in objs)
            {
                if (obej.levelObject == null) continue;
                File.WriteAllText(Path.Combine(Application.streamingAssetsPath, obej.levelTitle + "_dump.json"), JsonConvert.SerializeObject(obej.levelObject.ToData(), Formatting.Indented, BaldiChallengeMaker.settings));
            }
            File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "TestLevel_dump.json"), JsonConvert.SerializeObject(Resources.FindObjectsOfTypeAll<LevelObject>()[0].ToData(), Formatting.Indented, BaldiChallengeMaker.settings));
        }


        void Awake()
        {
            Harmony harmony = new Harmony("mtm101.rulerp.bbplus.challengemaker");
            NameMenuManager.AddPage("challengemakeroptions","options");
            NameMenuManager.AddToPage("options", new Name_MenuFolder("gotocmo","BB+ Challenge Maker","challengemakeroptions"));
            NameMenuManager.AddToPage("challengemakeroptions",new Name_MenuGeneric("dumpall","Dump Data for All Floors",DumpAll));

            string pathtosearch = Path.Combine(Application.streamingAssetsPath,"Custom Challenges");
            foreach (string FoDir in Directory.GetFiles(pathtosearch,"*.json"))
            {
                MapData.LevelData dat = null;
                try
                {
                    dat = JsonConvert.DeserializeObject<MapData.LevelData>(File.ReadAllText(FoDir), BaldiChallengeMaker.settings);
                }
                catch(Exception E)
                {
                    UnityEngine.Debug.LogError("File failed to load:" + FoDir);
                    UnityEngine.Debug.LogError(E.Message);
                    continue;
                }
                LevelDatas.Add(dat);
            }

            harmony.PatchAll();
        }


        public static ItemObject CreateObject(string localizedtext, string desckey, Sprite smallicon, Sprite largeicon, Items type, int price, int cost)
        {
            ItemObject obj = ScriptableObject.CreateInstance<ItemObject>();
            obj.nameKey = localizedtext;
            obj.itemSpriteSmall = smallicon;
            obj.itemSpriteLarge = largeicon;
            obj.itemType = type;
            obj.descKey = desckey;
            obj.cost = cost;
            obj.price = price;

            return obj;
        }
    }
}
