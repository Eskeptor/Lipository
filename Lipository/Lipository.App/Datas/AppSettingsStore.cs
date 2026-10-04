// ======================================================================================================
// File Name        : AppSettingsStore.cs
// Project          : Lipository.App
// Last Update      : 2026.10.04 - yc.jeon (Eskeptor)
// ======================================================================================================

using System;
using System.IO;
using System.Text.Json;

using Lipository.App.Globals;

namespace Lipository.App.Datas
{
    internal static class AppSettingsStore
    {
        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        public static AppSettingsData Load()
        {
            try
            {
                if (!File.Exists(Constants.Settings.FullPath))
                {
                    return new AppSettingsData();
                }

                string json = File.ReadAllText(Constants.Settings.FullPath);
                return JsonSerializer.Deserialize<AppSettingsData>(json, SerializerOptions) ?? new AppSettingsData();
            }
            catch
            {
                return new AppSettingsData();
            }
        }

        public static void Save(AppSettingsData data)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Constants.Settings.FullPath)!);
            string json = JsonSerializer.Serialize(data, SerializerOptions);
            File.WriteAllText(Constants.Settings.FullPath, json);
        }
    }
}
