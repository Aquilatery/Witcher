#region Imports

using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using Witcher.Enum;
using Witcher.Struct;
using static Taskbar.Enum.Enums;
using FontStyle = System.Drawing.FontStyle;
using Brushes = System.Windows.Media.Brushes;

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
        internal static Enums.SystemType System;

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
            Theme = Enums.ThemeType.Dark,
            Distance = 32,
            Title = "Witcher Test Title",
            Text = "Witcher Test Notify!",
            FontWF = new Font("Raleway SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162),
            FontWPF = new()
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
        public static Structs.CustomThemeWF CustomThemeWF = new()
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
        public static Structs.CustomThemeWPF CustomThemeWPF = new()
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

        /// <summary>
        /// 
        /// </summary>
        internal static List<Window> Windows = new();
        #endregion
    }
}