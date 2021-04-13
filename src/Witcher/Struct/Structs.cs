#region Imports

using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using Witcher.Enum;
using static Taskbar.Enum.Enums;

#endregion

namespace Witcher.Struct
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
            public Enums.SystemType System;
            public Enums.NotifyType Type;
            public Enums.AlertType Alert;
            public Enums.ThemeType Theme;
            public int Distance;
            public string Title;
            public string Text;
            public Font FontWF;
            public FontWPF FontWPF;
            public bool Top;
            public int Time;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FontWPF
        {
            public System.Windows.Media.FontFamily Family;
            public double Size;
            public FontStretch Stretch;
            public System.Windows.FontStyle Style;
            public FontWeight Weight;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CustomTheme
        {
            public Color Back;
            public Color Text;
            public Color Left;
            public Color Bar;
        }
        #endregion
    }
}