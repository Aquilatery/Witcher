#region Imports

using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Witcher.Struct;
using Witcher.Value;
using static Taskbar.Enum.Enums;
using static Witcher.Witcher.Property;

#endregion

namespace Witcher.Notify.Manager
{
    #region Management

    public partial class WitcherManagement : Form
    {
        public WitcherManagement()
        {
            InitializeComponent();
        }

        private void Control_Tick(object sender, EventArgs e)
        {
            Control.Stop();

            if (ActiveOpen > 0)
            {
                foreach (Form Form in System.Windows.Forms.Application.OpenForms)
                {
                    if (Form.Text.StartsWith(Values.StandardForm))
                    {
                        if (Standard_Control(Form))
                        {
                            break;
                        }
                    }
                }

                if (Values.Windows.Any())
                {
                    foreach (Window Window in Values.Windows)
                    {
                        if (Window.Title.StartsWith(Values.StandardForm))
                        {
                            if (Standard_Control(Window))
                            {
                                break;
                            }
                        }
                    }
                }
            }

            Control.Start();
        }

        private static bool Standard_Control(Form Form)
        {
            int ID1 = Convert.ToInt32(Form.Text.Replace(Values.StandardForm, ""));

            if (ID1 >= 1)
            {
                bool State = true;

                foreach (Form CheckForm in System.Windows.Forms.Application.OpenForms)
                {
                    if (CheckForm.Text.StartsWith(Values.StandardForm))
                    {
                        int ID2 = ID1 - 1;
                        if (CheckForm.Text == Values.StandardForm + ID2)
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
                        Form.Location = new System.Drawing.Point(Form.Location.X, Form.Location.Y + Form.Height);
                    }
                    else
                    {
                        Form.Location = new System.Drawing.Point(Form.Location.X, Form.Location.Y - Form.Height);
                    }

                    Form.Text = Values.StandardForm + (ID1 - 1);
                    return true;
                }
            }

            return false;
        }

        private static bool Standard_Control(Window Window)
        {
            int ID1 = Convert.ToInt32(Window.Title.Replace(Values.StandardForm, ""));

            if (ID1 >= 1)
            {
                bool State = true;

                foreach (Window CheckWindow in Values.Windows)
                {
                    if (CheckWindow.Title.StartsWith(Values.StandardForm))
                    {
                        int ID2 = ID1 - 1;
                        if (CheckWindow.Title == Values.StandardForm + ID2)
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

                    Window.Title = Values.StandardForm + (ID1 - 1);
                    return true;
                }
            }

            return false;
        }

        private void Notification_Tick(object sender, EventArgs e)
        {
            Notification.Stop();

            try
            {
                if (Values.Datas.Any() && ActiveOpen < MaxOpen)
                {
                    foreach (Structs.Data Data in Values.Datas)
                    {
                        Witcher.Notify.Show(Data);
                        Values.Datas.Remove(Data);
                        break;
                    }
                }
            }
            catch
            {
                //throw;
            }

            Notification.Start();
        }

        private void Management_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }

    #endregion
}