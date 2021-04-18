#region Imports

using System;
using System.Linq;
using System.Windows;
using Witcher.WPF.Struct;
using Witcher.WPF.Value;
using static Taskbar.Enum.Enums;
using static Witcher.Witcher.Property;
using static Witcher.WPF.Witcher.Property;
using WF = System.Windows.Forms;

#endregion

namespace Witcher.WPF.Notify.Manager
{
    #region Management

    public partial class WitcherManagement : WF.Form
    {
        public WitcherManagement()
        {
            InitializeComponent();
            Text = ManagementName;
        }

        private void Control_Tick(object sender, EventArgs e)
        {
            Control.Stop();

            if (ActiveOpen > 0)
            {
                foreach (Window Window in Application.Current.Windows)
                {
                    if (Window.Title.StartsWith(NotifyName))
                    {
                        if (Notify_Control(Window))
                        {
                            break;
                        }
                    }
                }
            }

            Control.Start();
        }

        private static bool Notify_Control(Window Window)
        {
            int ID = Convert.ToInt32(Window.Title.Replace(NotifyName, ""));

            if (ID >= 1)
            {
                bool State = true;

                foreach (Window CheckWindow in Application.Current.Windows)
                {
                    if (CheckWindow.Title.StartsWith(NotifyName))
                    {
                        if (CheckWindow.Title == NotifyName + (ID - 1))
                        {
                            State = false;
                            break;
                        }
                    }
                }

                if (State)
                {
                    if (Values.Location == EdgeLocationType.BotRight || Values.Location == EdgeLocationType.BotCenter || Values.Location == EdgeLocationType.BotLeft || Values.Location == EdgeLocationType.LeftCenter || Values.Location == EdgeLocationType.FullCenter)
                    {
                        Window.Top += Window.Height;
                    }
                    else
                    {
                        Window.Top -= Window.Height;
                    }

                    Window.Title = NotifyName + (ID - 1);
                    return true;
                }
            }

            return false;
        }

        private void Notification_Tick(object sender, EventArgs e)
        {
            Notification.Stop();

            if (Values.Datas.Any() && ActiveOpen < MaxOpen)
            {
                foreach (Structs.Data Data in Values.Datas)
                {
                    Witcher.Notify.Show(Data);
                    Values.Datas.Remove(Data);
                    break;
                }
            }

            Notification.Start();
        }

        private void Management_FormClosing(object sender, WF.FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }

    #endregion
}