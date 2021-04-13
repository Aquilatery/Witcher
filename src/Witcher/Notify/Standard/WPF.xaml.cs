#region Imports

using System;
using System.Drawing;
using System.Windows;
using Witcher.Struct;
using Witcher.Value;
using static Taskbar.Enum.Enums;
using static Taskbar.Taskbar.Advanced;
using static Witcher.Enum.Enums;
using static Witcher.Witcher.Property;

#endregion

namespace Witcher.Notify.Standard
{
    #region WitcherStandardWPF

    /// <summary>
    /// 
    /// </summary>
    public partial class WitcherStandardWPF : Window
    {
        private Structs.Data Local = Values.Data;
        private StateType Stage = StateType.Show;

        private double Value = 0;

        public WitcherStandardWPF(Structs.Data Data)
        {
            InitializeComponent();

            Title = Values.StandardForm;

            Local = Data;

            Topmost = Local.Top;

            WPF_Loaded();
        }

        private void WPF_Loaded()
        {
            System.Drawing.Point Location = SingleLocation(Local.Location, Convert.ToInt32(Width), Convert.ToInt32(Height), (ActiveOpen * Convert.ToInt32(Height)) + Local.Distance);
            Left = Location.X;
            Top = Location.Y;

            Title += ActiveOpen++;
        }
    }

    #endregion
}