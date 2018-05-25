using System;
using System.IO;
using PhentrixGames.NewColonyAPI.Helpers;
using PhentrixGames.NewColonyAPI;

public static class ModEntry
{
    public static string ModFolder;
    public static string ModGameDataDirectory;
    public static string LocalizationFolder;
    public static Version APIVersion = new Version(0, 0, 0, 1);

    [ModLoader.ModCallback(ModLoader.EModCallbackType.OnAssemblyLoaded, "phentrixgames.newcolonyapi.assemblyload")]
    [ModLoader.ModCallbackProvidesFor("pipliz.blocknpcs.assemblyload")]
    public static void OnAssemblyLoaded(string path)
    {
        ModFolder = Path.GetDirectoryName(path);
        ModGameDataDirectory = Path.Combine(Path.GetDirectoryName(path), "gamedata/").Replace("\\", "/");

        LocalizationFolder = Path.Combine(ModGameDataDirectory, "localization/").Replace("\\", "/");
        Utilities.CreateLogs("PracticeMod");
        PhentrixGames.NewColonyAPI.Managers.ConfigManager.registerConfig("Magikaas/PracticeMod");
    }

    [ModLoader.ModCallbackDependsOn("pipliz.server.localization.waitforloading")]
    [ModLoader.ModCallbackProvidesFor("pipliz.server.localization.convert")]
    public static void Localize()
    {
        PhentrixGames.NewColonyAPI.Managers.LocalizationManager.Localize("PracticeMod", LocalizationFolder);
        Utilities.WriteLog("PracticeMod", "Test log", Utilities.LogType.Error, true, Chat.ChatStyle.bolditalic);
        PhentrixGames.NewColonyAPI.Helpers.Chat.sendToAll("Chat message", Chat.ChatColour.brown, Chat.ChatStyle.bold, Pipliz.Chatting.ChatSenderType.Server);
    }

    [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterStartup, "phentrixgames.newcolonyapi.AfterStartup")]
    public static void AfterStartup()
    {
        PhentrixGames.NewColonyAPI.Managers.VersionManager.runVersionCheck("PracticeMod", APIVersion, "")
    }
}