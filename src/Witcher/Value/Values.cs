#region Imports

using Witcher.Struct;
using static Taskbar.Enum.Enums;
using Witcher.Enum;

#endregion

namespace Witcher.Value
{
    /// <summary>
    /// 
    /// </summary>
    public class Values
    {
        #region Values
        /// <summary>
        /// 
        /// </summary>
        internal static int Time = 3000;

        /// <summary>
        /// 
        /// </summary>
        internal static int Max = 5;

        /// <summary>
        /// 
        /// </summary>
        internal static Structs.Data Data = new()
        {
            Location = EdgeLocationType.BotRight,
            Thema = Enums.ThemaType.Dark,
            Text = "Witcher"
        };
        #endregion
    }
}