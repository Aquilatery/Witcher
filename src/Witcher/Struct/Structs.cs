#region Imports

using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using Witcher.Enum;
using static Taskbar.Enum.Enums;
using Brush = System.Windows.Media.Brush;

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
            public bool Pause;
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
        public struct CustomThemeWF
        {
            public Color Background;
            public Color Title;
            public Color Text;
            public Color Edge;
            public Color Bar;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CustomThemeWPF
        {
            public Brush Background;
            public Brush Title;
            public Brush Text;
            public Brush Edge;
            public Brush Bar;
        }
        #endregion
    }
}