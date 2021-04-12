#region Imports

using System.Runtime.InteropServices;
using static Taskbar.Enum.Enums;
using Witcher.Enum;

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
            public Enums.ThemaType Thema;
            public string Text;
        }
        #endregion
    }
}