#region Imports

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Witcher.Enum;
using Witcher.WPF.Struct;
using static Taskbar.Enum.Enums;

#endregion

namespace Witcher.WPF.Value
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
        internal static Structs.Data Data = new()
        {
            Location = EdgeLocationType.BotRight,
            Type = Enums.NotifyType.Standard,
            Alert = Enums.AlertType.Success,
            Theme = Enums.ThemeType.Dark,
            Distance = 32,
            Title = "Witcher Test Title",
            Text = "Witcher Test Notify!",
            Font = new()
            {
                Family = new("Raleway SemiBold"),
                Size = 12F,
                Stretch = FontStretches.Normal,
                Style = FontStyles.Normal,
                Weight = FontWeights.Bold,
            },
            Pause = true,
            Top = true,
            Time = 5000
        };

        /// <summary>
        /// 
        /// </summary>
        public static Structs.CustomTheme CustomTheme = new()
        {
            Background = Brushes.Black,
            Title = Brushes.Black,
            Text = Brushes.Black,
            Edge = Brushes.Black,
            Bar = Brushes.Black,
        };

        /// <summary>
        /// 
        /// </summary>
        internal static List<Structs.Data> Datas = new();
        #endregion
    }
}