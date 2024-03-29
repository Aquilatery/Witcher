﻿#region Imports

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Witcher.Helper;
using Witcher.WPF.Struct;
using Witcher.WPF.Value;
using static Taskbar.Enum.Enums;
using static Taskbar.Taskbar.Advanced;
using static Witcher.Enum.Enums;
using static Witcher.Witcher.Property;
using static Witcher.WPF.Witcher.Property;
using Control = System.Windows.Forms.Control;

#endregion

namespace Witcher.WPF.Notify.Standard
{
    #region WitcherStandardWPF

    /// <summary>
    /// 
    /// </summary>
    public partial class WitcherStandardWPF : Window
    {
        private Structs.Data Local = Values.Data;
        private StateType Stage = StateType.Show;

        private bool Exit = true;
        private bool Enabled = true;
        private double Value;
        private int Time = 50;

        public WitcherStandardWPF(Structs.Data Data)
        {
            LocationChanged += StandardWF_LocationChanged;
            Closed += StandardWF_FormClosed;
            Loaded += StandardWPF_Loaded;

            InitializeComponent();

            Title = NotifyName + ActiveOpen;

            Local = Data;

            Topmost = Local.Top;

            TEXT.Text = Local.Text;
            TEXT.FontFamily = Local.Font.Family;
            TEXT.FontSize = Local.Font.Size;
            TEXT.FontStretch = Local.Font.Stretch;
            TEXT.FontStyle = Local.Font.Style;
            TEXT.FontWeight = Local.Font.Weight;

            Width = Local.Size.Width;
            Height = Local.Size.Height;

            if (!Local.Close)
            {
                TOP.Height += 2;
                PANEL.Visibility = Visibility.Hidden;
            }

            if (Local.Theme is ThemeType.Dark or ThemeType.Light)
            {
                if (Local.Theme == ThemeType.Dark)
                {
                    Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                    TEXT.Foreground = Brushes.Gainsboro;
                }
                else
                {
                    Background = Brushes.Gainsboro;
                    TEXT.Foreground = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                }

                switch (Local.Alert)
                {
                    case AlertType.Success:
                        LEFT.Background = Brushes.SeaGreen;
                        break;
                    case AlertType.Warning:
                        LEFT.Background = new SolidColorBrush(Color.FromRgb(255, 128, 0));
                        break;
                    case AlertType.Error:
                        LEFT.Background = Brushes.Crimson;
                        break;
                    case AlertType.Info:
                        LEFT.Background = Brushes.Gray;
                        break;
                }

                BAR.Background = LEFT.Background;
            }
            else
            {
                Background = Values.CustomTheme.Background;
                TEXT.Foreground = Values.CustomTheme.Text;
                LEFT.Background = Values.CustomTheme.Edge;
                BAR.Background = Values.CustomTheme.Bar;
            }

            _ = General_Work();
        }

        private void StandardWPF_Loaded(object sender, RoutedEventArgs e)
        {
            System.Drawing.Point Location = SingleLocation(Local.Location, Convert.ToInt32(Width), Convert.ToInt32(Height), (ActiveOpen * Convert.ToInt32(Height)) + Local.Distance);
            Left = Location.X;
            Top = Location.Y;

            switch (Local.Location)
            {
                case EdgeLocationType.BotRight:
                    Left += ActiveOpen * Height;
                    Top -= Local.Distance;
                    DockPanel.SetDock(LEFT, Dock.Right);
                    BAR.HorizontalAlignment = HorizontalAlignment.Right;
                    break;
                case EdgeLocationType.BotCenter:
                    Top -= Local.Distance;
                    break;
                case EdgeLocationType.BotLeft:
                    Left -= ActiveOpen * Height;
                    Top -= Local.Distance;
                    break;
                case EdgeLocationType.TopRight:
                    Left += ActiveOpen * Height;
                    Top += Local.Distance;
                    DockPanel.SetDock(TOP, Dock.Bottom);
                    DockPanel.SetDock(LEFT, Dock.Right);
                    BAR.HorizontalAlignment = HorizontalAlignment.Right;
                    break;
                case EdgeLocationType.TopCenter:
                    Top += Local.Distance;
                    DockPanel.SetDock(TOP, Dock.Bottom);
                    break;
                case EdgeLocationType.TopLeft:
                    Left -= ActiveOpen * Height;
                    Top += Local.Distance;
                    DockPanel.SetDock(TOP, Dock.Bottom);
                    break;
                case EdgeLocationType.LeftCenter:
                    Left -= ActiveOpen * Height;
                    Top -= ActiveOpen * Height;
                    DockPanel.SetDock(TOP, Dock.Bottom);
                    break;
                case EdgeLocationType.RightCenter:
                    Left += ActiveOpen * Height;
                    Top += ActiveOpen * Height;
                    DockPanel.SetDock(LEFT, Dock.Right);
                    BAR.HorizontalAlignment = HorizontalAlignment.Right;
                    break;
                case EdgeLocationType.CalcCenter:
                    Top += ActiveOpen * Height;
                    break;
                default:
                    Top -= ActiveOpen * Height;
                    DockPanel.SetDock(TOP, Dock.Bottom);
                    DockPanel.SetDock(LEFT, Dock.Right);
                    BAR.HorizontalAlignment = HorizontalAlignment.Right;
                    break;
            }
        }

        private void CLOSE_MouseEnter(object sender, MouseEventArgs e)
        {
            CLOSE.Height += 2;
        }

        private void CLOSE_MouseLeave(object sender, MouseEventArgs e)
        {
            CLOSE.Height -= 2;
        }

        private void CLOSE_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Stage = StateType.Finish;
        }

        private async Task General_Work()
        {
            try
            {
                if (Enabled)
                {
                    _ = General_Tick();
                    await Task.Delay(Time);
                    _ = General_Work();
                }
            }
            catch
            {
                _ = General_Work();
            }
            finally
            {
                await Task.CompletedTask;
            }
        }

        private Task General_Tick()
        {
            if (Local.Pause && (Stage == StateType.Close || Stage == StateType.Unknown))
            {
                if (Helpers.Contains(Control.MousePosition.X, Control.MousePosition.Y, Left, Top, Width, Height))
                {
                    Stage = StateType.Unknown;
                }
                else
                {
                    Stage = StateType.Close;
                }
            }

            switch (Stage)
            {
                case StateType.Show:
                    if (Opacity < 0.8)
                    {
                        Opacity += 0.1;
                    }
                    else
                    {
                        Time = 10;
                        Stage = StateType.Start;
                    }
                    break;
                case StateType.Start:
                    if (Local.Distance > 0)
                    {
                        Local.Distance -= 2;
                        if (Local.Location is EdgeLocationType.BotRight or EdgeLocationType.BotCenter or EdgeLocationType.BotLeft or EdgeLocationType.LeftCenter or EdgeLocationType.FullCenter)
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
                        Time = 50;
                        Stage = StateType.Close;
                    }
                    break;
                case StateType.Close:
                    if (Title == NotifyName + "0")
                    {
                        if (Local.Close)
                        {
                            Value += PANEL.ActualWidth / (Local.Time / Time);

                            if (PANEL.ActualWidth > Value)
                            {
                                BAR.Width = Value;
                            }
                            else
                            {
                                BAR.Width = PANEL.Width;
                                CLOSE_MouseLeftButtonUp(null, null);
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
                        Enabled = false;
                        StandardWF_FormClosed(null, null);
                        Close();
                    }
                    break;
            }

            return Task.CompletedTask;
        }

        private void StandardWF_LocationChanged(object sender, EventArgs e)
        {
            if (Enabled && Stage == StateType.Close)
            {
                Enabled = false;
                Enabled = true;
            }
        }

        private void StandardWF_FormClosed(object sender, EventArgs e)
        {
            if (Exit)
            {
                Exit = false;
                ActiveOpen--;
            }
        }
    }

    #endregion
}