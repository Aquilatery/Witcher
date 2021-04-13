#region Imports

using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
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
            [DefaultValue(EdgeLocationType.BotRight)]
            public EdgeLocationType Location;

            [DefaultValue(Enums.NotifyType.Standard)]
            public Enums.NotifyType Type;

            [DefaultValue(Enums.AlertType.Success)]
            public Enums.AlertType Alert;

            [DefaultValue(Enums.ThemaType.Dark)]
            public Enums.ThemaType Theme;

            [DefaultValue(32)]
            public int Distance;

            [DefaultValue("Witcher Test Title")]
            public string Title;

            [DefaultValue("Witcher Test Notify!")]
            public string Text;

            [DefaultValue(typeof(Font), "Raleway SemiBold, 12pt, Bold, Point, 162")]
            public Font Font;

            [DefaultValue(true)]
            public bool Top;

            [DefaultValue(5000)]
            public int Time;
        }
        #endregion
    }
}