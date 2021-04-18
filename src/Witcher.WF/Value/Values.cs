#region Imports

using System.Collections.Generic;
using System.Drawing;
using Witcher.Enum;
using Witcher.WF.Struct;
using static Taskbar.Enum.Enums;

#endregion

namespace Witcher.WF.Value
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
        internal static Enums.NotifyType Type;

        /// <summary>
        /// 
        /// </summary>
        internal static EdgeLocationType Location;

        /// <summary>
        /// 
        /// </summary>
        internal static int Distance;

        /// <summary>
        /// 
        /// </summary>
        internal static Structs.Size Size;

        /// <summary>
        /// 
        /// </summary>
        internal static Structs.Data Data = new()
        {
            Location = EdgeLocationType.BotRight,
            Type = Enums.NotifyType.Standard,
            Alert = Enums.AlertType.Success,
            Theme = Enums.ThemeType.Dark,
            Distance = 32,
            Title = "Witcher Test Title",
            Text = "Witcher Test Notify!",
            Font = new Font("Raleway SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162),
            Pause = true,
            Top = true,
            Time = 5000
        };

        /// <summary>
        /// 
        /// </summary>
        public static Structs.CustomTheme CustomTheme = new()
        {
            Background = Color.Black,
            Title = Color.Black,
            Text = Color.Black,
            Edge = Color.Black,
            Bar = Color.Black,
        };

        /// <summary>
        /// 
        /// </summary>
        internal static List<Structs.Data> Datas = new();
        #endregion
    }
}