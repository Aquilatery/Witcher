#region Imports

using System;
using System.Windows;
using Witcher.Struct;
using Witcher.Value;
using static Taskbar.Taskbar.Advanced;
using static Witcher.Witcher.Property;

#endregion

namespace Witcher.Notify.Test
{
    public partial class WIDGET : Window
    {
        private Structs.Data Local = Values.Data;

        public WIDGET(Structs.Data Data)
        {
            InitializeComponent();

            Title = Values.StandardForm;

            Local = Data;

            Topmost = Local.Top;

            Test_Loaded();
        }

        private void Test_Loaded()
        {
            System.Drawing.Point Location = SingleLocation(Local.Location, Convert.ToInt32(Width), Convert.ToInt32(Height), (ActiveOpen * Convert.ToInt32(Height)) + Local.Distance);
            Left = Location.X;
            Top = Location.Y;

            Title += ActiveOpen++;
        }
    }
}