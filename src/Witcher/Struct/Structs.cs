#region Imports

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
            public EdgeLocationType Location;
            public Enums.NotifyType Type;
            public Enums.AlertType Alert;
            public Enums.ThemaType Theme;
            public int Distance;
            public string Text;
            public Font Font;
            public int Time;
        }
        #endregion
    }
}