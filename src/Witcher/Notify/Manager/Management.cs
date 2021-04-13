using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Witcher.Struct;
using Witcher.Value;
using static Taskbar.Enum.Enums;
using static Witcher.Witcher.Property;

namespace Witcher.Notify.Manager
{
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
                if (OpenForm.Text.Contains(Values.Form))
                {
                    int ID1 = Convert.ToInt32(OpenForm.Text.Replace(Values.Form, ""));

                    if (ID1 >= 1)
                    {
                        bool State = true;

                        foreach (Form CheckForm in Application.OpenForms)
                        {
                            if (CheckForm.Text.Contains(Values.Form))
                            {
                                int ID2 = ID1 - 1;
                                if (CheckForm.Text == Values.Form + ID2)
                                {
                                    State = false;
                                    break;
                                }
                            }
                        }

                        if (State)
                        {
                            if (Values.Data.Location == EdgeLocationType.BotRight || Values.Data.Location == EdgeLocationType.BotLeft)
                            {
                                OpenForm.Location = new Point(OpenForm.Location.X, OpenForm.Location.Y + OpenForm.Height);
                            }
                            else
                            {
                                OpenForm.Location = new Point(OpenForm.Location.X, OpenForm.Location.Y - OpenForm.Height);
                            }

                            OpenForm.Text = Values.Form + (ID1 - 1);
                            break;
                        }
                    }
                }
            }

            Control.Start();
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

        private void Management_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}