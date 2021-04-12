#region Imports

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
            public Enums.ThemaType Thema;
            public string Text;
        }
        #endregion
    }
}