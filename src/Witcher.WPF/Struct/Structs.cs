#region Imports

using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using Witcher.Enum;
using static Taskbar.Enum.Enums;

#endregion

namespace Witcher.WPF.Struct
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
            public Size Size;
            public bool Pause;
            public bool Close;
            public bool Top;
            public int Time;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Size
        {
            public double Width;
            public double Height;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Font
        {
            public FontFamily Family;
            public double Size;
            public FontStretch Stretch;
            public FontStyle Style;
            public FontWeight Weight;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CustomTheme
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