#region Imports

using System.Collections.Generic;
using System.Drawing;
using Witcher.Enum;
using Witcher.Struct;
using static Taskbar.Enum.Enums;

#endregion

namespace Witcher.Value
{
    /// <summary>
    /// 
    /// </summary>
    internal class Values
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
        internal static int Time = 100;

        /// <summary>
        /// 
        /// </summary>
        internal static string StandardForm = "WNM";

        /// <summary>
        /// 
        /// </summary>
        internal static Enums.NotifyType Type;

        /// <summary>
        /// 
        /// </summary>
        internal static EdgeLocationType Location;

        /// <summary>
        /// 
        /// </summary>
        internal static Structs.Data Data = new()
        {
            Location = EdgeLocationType.BotRight,
            System = Enums.SystemType.WindowsForms,
            Type = Enums.NotifyType.Standard,
            Alert = Enums.AlertType.Success,
            Theme = Enums.ThemaType.Dark,
            Distance = 32,
            Title = "Witcher Test Title",
            Text = "Witcher Test Notify!",
            Font = new Font("Raleway SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162),
            Top = true,
            Time = 5000
        };

        /// <summary>
        /// 
        /// </summary>
        internal static List<Structs.Data> Datas = new();
        #endregion
    }
}