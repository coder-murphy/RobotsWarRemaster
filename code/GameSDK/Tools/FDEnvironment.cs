using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace FDGameSDK.Tools
{
    public static class FDEnvironment
    {
        [DllImport("gdi32.dll")]
        extern static int GetDeviceCaps(IntPtr hdc, int nIndex);

        /// <summary>
        /// 屏幕宽度
        /// </summary>
        public static int ScreenWidth => PhysicalSize.Width;

        /// <summary>
        /// 屏幕高度
        /// </summary>
        public static int ScreenHeight => PhysicalSize.Height;

        public static Size PhysicalSize
        {
            get
            {
                Graphics g = Graphics.FromHwnd(IntPtr.Zero);
                IntPtr desktop = g.GetHdc();
                int physicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.Desktopvertres);
                int physicalScreenWidth = GetDeviceCaps(desktop, (int)DeviceCap.Desktophorzres);
                return new Size(physicalScreenWidth, physicalScreenHeight);
            }
        }
    }

    public enum DeviceCap
    {
        Desktopvertres = 117,
        Desktophorzres = 118
    }
}
