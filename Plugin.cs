﻿using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ServerSync;
using UnityEngine;
using static Heightmap;

namespace BuildingOptimizer;

[BepInPlugin(ModGUID, ModName, ModVersion)]
internal class Plugin : BaseUnityPlugin
{
    #region values

    internal const string ModName = "BuildingOptimizer", ModVersion = "1.0.0", ModGUID = "com.Frogger." + ModName;
    internal static Harmony harmony = new(ModGUID);
    internal static Plugin _self;

    #endregion

    #region tools

    public static void Debug(object msg)
    {
        _self.Logger.LogInfo(msg);
    }

    public static void DebugError(object msg, bool showWriteToDev)
    {
        if (showWriteToDev)
        {
            msg += "Write to the developer and moderator if this happens often.";
        }

        _self.Logger.LogError(msg);
    }

    public static void DebugWarning(object msg, bool showWriteToDev)
    {
        if (showWriteToDev)
        {
            msg += "Write to the developer and moderator if this happens often.";
        }

        _self.Logger.LogWarning(msg);
    }

    #endregion

    // #region ConfigSettings
    //
    // #region tools
    //
    // static string ConfigFileName = "com.Frogger.BuildingOptimizer.cfg";
    // DateTime LastConfigChange;
    //
    // public static readonly ConfigSync configSync = new(ModName)
    //     { DisplayName = ModName, CurrentVersion = ModVersion, MinimumRequiredVersion = ModVersion };
    //
    // public static ConfigEntry<T> config<T>(string group, string name, T value, ConfigDescription description,
    //     bool synchronizedSetting = true)
    // {
    //     ConfigEntry<T> configEntry = _self.Config.Bind(group, name, value, description);
    //
    //     SyncedConfigEntry<T> syncedConfigEntry = configSync.AddConfigEntry(configEntry);
    //     syncedConfigEntry.SynchronizedConfig = synchronizedSetting;
    //
    //     return configEntry;
    // }
    //
    // private ConfigEntry<T> config<T>(string group, string name, T value, string description,
    //     bool synchronizedSetting = true)
    // {
    //     return config(group, name, value, new ConfigDescription(description), synchronizedSetting);
    // }
    //
    // void SetCfgValue<T>(Action<T> setter, ConfigEntry<T> config)
    // {
    //     setter(config.Value);
    //     config.SettingChanged += (_, _) => setter(config.Value);
    // }
    //
    // public enum Toggle
    // {
    //     On = 1,
    //     Off = 0
    // }
    //
    // #endregion
    //
    // #region configs
    //
    // //internal static ConfigEntry<Biome> MeadowsToConfig;
    //
    // #endregion
    //
    // #endregion

    // #region Config
    //
    // private void SetupWatcher()
    // {
    //     FileSystemWatcher fileSystemWatcher = new(Paths.ConfigPath, ConfigFileName);
    //     fileSystemWatcher.Changed += ConfigChanged;
    //     fileSystemWatcher.IncludeSubdirectories = true;
    //     fileSystemWatcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
    //     fileSystemWatcher.EnableRaisingEvents = true;
    // }
    //
    // void ConfigChanged(object sender, FileSystemEventArgs e)
    // {
    //     if ((DateTime.Now - LastConfigChange).TotalSeconds <= 5.0)
    //     {
    //         return;
    //     }
    //
    //     LastConfigChange = DateTime.Now;
    //     try
    //     {
    //         Config.Reload();
    //     }
    //     catch
    //     {
    //         DebugError("Can't reload Config", true);
    //     }
    // }
    //
    // private void UpdateConfiguration()
    // {
    //     Debug("Configuration Received");
    // }
    //
    // #endregion

    private void Awake()
    {
        _self = this;

        // #region Config
        //
        // configSync.AddLockingConfigEntry(config("Main", "Lock Configuration", Toggle.On,
        //     "If on, the configuration is locked and can be changed by server admins only."));
        //
        // // MeadowsToConfig =
        // //     config("Main", "Change Meadows to", Biome.Meadows, string.Empty);
        //
        // #endregion

        harmony.PatchAll();
    }
}