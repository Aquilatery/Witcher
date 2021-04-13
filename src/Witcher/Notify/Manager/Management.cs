#region Imports

using System;
using System.Drawing;
using System.Linq;
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

            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.Text.StartsWith(Values.StandardForm))
                {
                    if (Standard_Control(OpenForm))
                    {
                        break;
                    }
                }
            }

            Control.Start();
        }

        private static bool Standard_Control(Form OpenForm)
        {
            int ID1 = Convert.ToInt32(OpenForm.Text.Replace(Values.StandardForm, ""));

            if (ID1 >= 1)
            {
                bool State = true;

                foreach (Form CheckForm in Application.OpenForms)
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
                        OpenForm.Location = new Point(OpenForm.Location.X, OpenForm.Location.Y + OpenForm.Height);
                    }
                    else
                    {
                        OpenForm.Location = new Point(OpenForm.Location.X, OpenForm.Location.Y - OpenForm.Height);
                    }

                    OpenForm.Text = Values.StandardForm + (ID1 - 1);
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