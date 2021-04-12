#region Imports

using System.Collections.Generic;
using Witcher.Enum;
using Witcher.Struct;
using static Taskbar.Enum.Enums;

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
        internal static int Active = 0;

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
            Type = Enums.NotifyType.Standard,
            Alert = Enums.AlertType.Success,
            Theme = Enums.ThemaType.Dark,
            Text = "Witcher",
            Time = 5000
        };

        /// <summary>
        /// 
        /// </summary>
        internal static List<Structs.Data> Datas = new();
        #endregion
    }
}