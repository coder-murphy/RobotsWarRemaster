using FDGameSDK.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDGameSDK
{
    public static class FDGameSettings
    {
        /// <summary>
        /// 游戏配置ini文件名
        /// </summary>
        public const string GameSettingsFileName = "gamesettings.ini";

        /// <summary>
        /// 游戏名
        /// </summary>
        public const string GameName = "战棋大战复刻";

        public const string SettingsSectionNameWindow = "Window";
        public const string SettingsSectionNameGame = "GameSetting";

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            if (File.Exists(GameSettingsFileName) == false)
            {
                using var s = File.Create(GameSettingsFileName);
                s.Close();
                FDIniFile.PutSetting(SettingsSectionNameWindow, "Width", "800", GameSettingsFileName);
                FDIniFile.PutSetting(SettingsSectionNameWindow, "Height", "600", GameSettingsFileName);
                FDIniFile.PutSetting(SettingsSectionNameGame, "RenderFrequency", "60", GameSettingsFileName);
                FDIniFile.PutSetting(SettingsSectionNameGame, "UpdateFrequency", "60", GameSettingsFileName);
            }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="settingTypes"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetValue(SettingTypes? settingTypes,string key,string value)
        {
            if (!settingTypes.HasValue) return;
            var type = settingTypes.Value;
            if(type == SettingTypes.Window)
            {
                FDIniFile.PutSetting(SettingsSectionNameWindow, key, value, GameSettingsFileName);
            }
            else if (type == SettingTypes.Game)
            {
                FDIniFile.PutSetting(SettingsSectionNameGame, key, value, GameSettingsFileName);
            }
        }

        /// <summary>
        /// 获取配置的值
        /// </summary>
        /// <param name="settingTypes"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(SettingTypes? settingTypes, string key)
        {
            if (!settingTypes.HasValue) return "Without Value";
            var type = settingTypes.Value;
            if (type == SettingTypes.Window)
                return FDIniFile.GetSettingValue(SettingsSectionNameWindow, key, GameSettingsFileName);
            else if(type == SettingTypes.Game)
                return FDIniFile.GetSettingValue(SettingsSectionNameGame, key, GameSettingsFileName);
            return "Without Value";
        }
    }

    /// <summary>
    /// 配置类型枚举
    /// </summary>
    public enum SettingTypes
    {
        Window,
        Game,
    }
}
