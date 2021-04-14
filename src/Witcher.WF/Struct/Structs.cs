#region Imports

using System.Drawing;
using System.Runtime.InteropServices;
using Witcher.Enum;
using static Taskbar.Enum.Enums;

#endregion

namespace Witcher.WF.Struct
{
    /// <summary>
    /// 
    /// </summary>
    public class Structs
    {
        #region Structs
        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Data
        {
            public EdgeLocationType Location;
            public Enums.NotifyType Type;
            public Enums.AlertType Alert;
            public Enums.ThemeType Theme;
            public int Distance;
            public string Title;
            public string Text;
            public Font Font;
            public bool Pause;
            public bool Top;
            public int Time;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CustomTheme
        {
            public Color Background;
            public Color Title;
            public Color Text;
            public Color Edge;
            public Color Bar;
        }
        #endregion
    }
}