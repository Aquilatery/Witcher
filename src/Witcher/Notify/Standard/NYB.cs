using System;
using System.Drawing;
using System.Windows.Forms;
using Witcher.Struct;
using Witcher.Value;
using static Taskbar.Enum.Enums;
using static Taskbar.Taskbar.Advanced;
using static Witcher.Enum.Enums;
using static Witcher.Witcher.Property;

namespace Witcher.Notify.Standard
{
    public partial class NYB : Form
    {
        private Structs.Data Local = Values.Data;
        private StateType Stage = StateType.Show;

        private int Time = 0;

        public NYB(Structs.Data Data)
        {
            InitializeComponent();

            Text = Values.Form;

            Local = Data;

            if (Data.Theme == ThemaType.Dark)
            {
                BackColor = Color.FromArgb(38, 38, 38);
                TEXT.ForeColor = Color.Gainsboro;
            }
            else
            {
                BackColor = Color.Gainsboro;
                TEXT.ForeColor = Color.FromArgb(38, 38, 38);
            }

            TEXT.Text = Data.Text;
            TEXT.Font = Data.Font;

            switch (Data.Alert)
            {
                case AlertType.Success:
                    LEFT.BackColor = Color.SeaGreen;
                    break;
                case AlertType.Warning:
                    LEFT.BackColor = Color.FromArgb(255, 128, 0);
                    break;
                case AlertType.Error:
                    LEFT.BackColor = Color.Crimson;
                    break;
                case AlertType.Info:
                    LEFT.BackColor = Color.Gray;
                    break;
            }

            BAR.ProgressColor = LEFT.BackColor;
        }

        private void NYB_Load(object sender, EventArgs e)
        {
            Location = SingleLocation(Local.Location, Width, Height, (ActiveOpen * Height) + Local.Distance);

            if (Local.Location == EdgeLocationType.BotRight)
            {
                LEFT.Dock = DockStyle.Right;
                Location = new Point(Location.X + (ActiveOpen * Height), Location.Y + Local.Distance);
            }
            else if (Local.Location == EdgeLocationType.BotLeft)
            {
                Location = new Point(Location.X - (ActiveOpen * Height), Location.Y + Local.Distance);
            }
            else if (Local.Location == EdgeLocationType.TopRight)
            {
                LEFT.Dock = DockStyle.Right;
                Location = new Point(Location.X + (ActiveOpen * Height), Location.Y - Local.Distance);
                BAR.Dock = DockStyle.Top;
            }
            else
            {
                Location = new Point(Location.X - (ActiveOpen * Height), Location.Y - Local.Distance);
                BAR.Dock = DockStyle.Top;
            }

            Text += ActiveOpen;
            ActiveOpen++;
        }

        private void CLOSE_MouseEnter(object sender, EventArgs e)
        {
            CLOSE.Size = new(CLOSE.Width + 4, CLOSE.Height + 4);
            CLOSE.Location = new(CLOSE.Location.X - 2, CLOSE.Location.Y - 2);
        }

        private void CLOSE_MouseLeave(object sender, EventArgs e)
        {
            CLOSE.Size = new(CLOSE.Width - 4, CLOSE.Height - 4);
            CLOSE.Location = new(CLOSE.Location.X + 2, CLOSE.Location.Y + 2);
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
                        General.Interval = 50;
                        Stage = StateType.Start;
                    }
                    break;
                case StateType.Start:
                    if (Local.Distance > 0)
                    {
                        Local.Distance -= 2;
                        if (Local.Location == EdgeLocationType.BotRight || Local.Location == EdgeLocationType.BotLeft)
                        {
                            Location = new Point(Location.X, Location.Y - 2);
                        }
                        else
                        {
                            Location = new Point(Location.X, Location.Y + 2);
                        }
                    }
                    else
                    {
                        Stage = StateType.Close;
                    }
                    break;
                case StateType.Close:
                    if (Text == Values.Form + "0")
                    {
                        if (Time <= Local.Time)
                        {
                            Time += General.Interval;
                            int Value = 100 / (Local.Time / General.Interval) + BAR.Value;
                            if (BAR.Maximum > Value)
                            {
                                BAR.Value = Value;
                            }
                            else
                            {
                                BAR.Value = BAR.Maximum;
                            }
                        }
                        else
                        {
                            CLOSE_Click(sender, e);
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
                        NYB_FormClosed(sender, e);
                        Dispose();
                    }
                    break;
            }
        }

        private void NYB_LocationChanged(object sender, EventArgs e)
        {
            if (General.Enabled && Stage == StateType.Close)
            {
                General.Enabled = false;
                General.Enabled = true;
            }
        }

        private void NYB_FormClosed(object sender, EventArgs e)
        {
            ActiveOpen--;
        }
    }
}