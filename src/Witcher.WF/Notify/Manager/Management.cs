#region Imports

using System;
using System.Linq;
using System.Windows.Forms;
using Witcher.WF.Struct;
using Witcher.WF.Value;
using static Taskbar.Enum.Enums;
using static Witcher.WF.Witcher.Property;
using static Witcher.Witcher.Property;

#endregion

namespace Witcher.WF.Notify.Manager
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
                foreach (Form Form in Application.OpenForms)
                {
                    if (Form.Text.StartsWith(StandardForm))
                    {
                        if (Standard_Control(Form))
                        {
                            break;
                        }
                    }
                }
            }

            Control.Start();
        }

        private static bool Standard_Control(Form Form)
        {
            int ID1 = Convert.ToInt32(Form.Text.Replace(StandardForm, ""));

            if (ID1 >= 1)
            {
                bool State = true;

                foreach (Form CheckForm in Application.OpenForms)
                {
                    if (CheckForm.Text.StartsWith(StandardForm))
                    {
                        int ID2 = ID1 - 1;
                        if (CheckForm.Text == StandardForm + ID2)
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

                    Form.Text = StandardForm + (ID1 - 1);
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