#region Imports

using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
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
        private readonly DispatcherTimer General = new() { Interval = TimeSpan.FromTicks(50), IsEnabled = true };

        private Structs.Data Local = Values.Data;
        private StateType Stage = StateType.Show;

        private double Value = 0;

        public WitcherStandardWPF(Structs.Data Data)
        {
            LocationChanged += StandardWF_LocationChanged;
            Closed += StandardWF_FormClosed;
            Loaded += StandardWPF_Loaded;

            InitializeComponent();

            Title = Values.StandardForm;

            Local = Data;

            General.Tick += General_Tick;

            Topmost = Local.Top;
        }

        private void StandardWPF_Loaded(object sender, RoutedEventArgs e)
        {
            System.Drawing.Point Location = SingleLocation(Local.Location, Convert.ToInt32(Width), Convert.ToInt32(Height), (ActiveOpen * Convert.ToInt32(Height)) + Local.Distance);
            Left = Location.X;
            Top = Location.Y;

            Title += ActiveOpen++;
        }

        private void CLOSE_MouseEnter(object sender, MouseEventArgs e)
        {
            CLOSE.Height += 2;
        }

        private void CLOSE_MouseLeave(object sender, MouseEventArgs e)
        {
            CLOSE.Height -= 2;
        }

        private void CLOSE_Click(object sender, EventArgs e)
        {
            Stage = StateType.Finish;
        }

        private void General_Tick(object sender, EventArgs e)
        {
            switch (Stage)
            {
                case StateType.Show:
                    if (Convert.ToDouble(Opacity) < 0.8)
                    {
                        Opacity += 0.1;
                    }
                    else
                    {
                        General.Interval = TimeSpan.FromTicks(10);
                        Stage = StateType.Start;
                    }
                    break;
                case StateType.Start:
                    if (Local.Distance > 0)
                    {
                        Local.Distance -= 2;
                        if (Local.Location == EdgeLocationType.BotRight || Local.Location == EdgeLocationType.BotCenter || Local.Location == EdgeLocationType.BotLeft || Local.Location == EdgeLocationType.LeftCenter || Local.Location == EdgeLocationType.FullCenter)
                        {
                            Top += 2;
                        }
                        else
                        {
                            Top -= 2;
                        }
                    }
                    else
                    {
                        General.Interval = TimeSpan.FromTicks(50);
                        Stage = StateType.Close;
                    }
                    break;
                case StateType.Close:
                    if (Title == Values.StandardForm + "0")
                    {
                        if (Local.Location == EdgeLocationType.BotRight || Local.Location == EdgeLocationType.TopRight || Local.Location == EdgeLocationType.RightCenter || Local.Location == EdgeLocationType.FullCenter)
                        {
                            Value += PANEL.Width / (Local.Time / General.Interval.Ticks);

                            if (PANEL.Width > Convert.ToInt32(Value))
                            {
                                BAR.Location = new(PANEL.Width - Convert.ToInt32(Value), 0);
                                BAR.Width = Convert.ToInt32(Value);
                            }
                            else
                            {
                                BAR.Location = new(0, 0);
                                BAR.Width = PANEL.Width;
                                CLOSE_Click(sender, e);
                            }
                        }
                        else
                        {
                            Value += PANEL.Width / (Local.Time / General.Interval.Ticks);

                            if (PANEL.Width > Convert.ToInt32(Value))
                            {
                                BAR.Width = Convert.ToInt32(Value);
                            }
                            else
                            {
                                BAR.Width = PANEL.Width;
                                CLOSE_Click(sender, e);
                            }
                        }
                    }
                    break;
                case StateType.Finish:
                    if (Opacity > 0)
                    {
                        Opacity -= 0.1;
                    }
                    else
                    {
                        StandardWF_FormClosed(sender, e);
                        Close();
                    }
                    break;
            }
        }

        private void StandardWF_LocationChanged(object sender, EventArgs e)
        {
            if (General.IsEnabled && Stage == StateType.Close)
            {
                General.IsEnabled = false;
                General.IsEnabled = true;
            }
        }

        private void StandardWF_FormClosed(object sender, EventArgs e)
        {
            ActiveOpen--;
        }
    }

    #endregion
}