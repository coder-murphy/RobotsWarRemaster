using FDGameSDK;
using FDGameSDK.Tools;
using OpenTK;
using OpenTK.Windowing.Desktop;

namespace GameEntry
{
    public class Game : GameWindow
    {
        private Game() : 
            base(GetGameWindowSettings(),
            GetNativeWindowSettings()
            )
        {

        }

        /// <summary>
        /// 启动游戏进程
        /// </summary>
        /// <returns></returns>
        public static bool RunGame()
        {
            FDGameSettings.Init();
            if (mainProc != null) return false;
            using(mainProc = new Game())
            {
                //mainProc.IsVisible = true;
                mainProc.Run(); 
            }
            return true;
        }

        private static GameWindowSettings GetGameWindowSettings()
        {
            GameWindowSettings settings = new GameWindowSettings();
            settings.RenderFrequency = FDConv.O2D(FDGameSettings.GetValue(SettingTypes.Game, "RenderFrequency"));
            settings.IsMultiThreaded = true;
            settings.UpdateFrequency = FDConv.O2D(FDGameSettings.GetValue(SettingTypes.Game, "UpdateFrequency"));
            return settings;
        }

        private static NativeWindowSettings GetNativeWindowSettings()
        {
            NativeWindowSettings nativeWindowSettings = new NativeWindowSettings();
            int sw = FDEnvironment.ScreenWidth;
            int sh = FDEnvironment.ScreenHeight;
            int w = FDConv.O2I(FDGameSettings.GetValue(SettingTypes.Window, "Width"));
            int h = FDConv.O2I(FDGameSettings.GetValue(SettingTypes.Window, "Height"));
            nativeWindowSettings.Location = new OpenTK.Mathematics.Vector2i(
                (sw - w) / 2,
                (sh - h) / 2);
            nativeWindowSettings.Size = new OpenTK.Mathematics.Vector2i(w, h);
            nativeWindowSettings.Title = FDGameSettings.GameName;
            return nativeWindowSettings;
        }

        private static Game? mainProc;
    }
}
