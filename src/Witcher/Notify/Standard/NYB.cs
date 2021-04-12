using System;
using System.Drawing;
using System.Windows.Forms;
using Witcher.Struct;
using static Taskbar.Enum.Enums;
using static Taskbar.Taskbar.Advanced;
using static Witcher.Enum.Enums;
using static Witcher.Witcher.Property;

namespace Witcher.Notify.Standard
{
    public partial class NYB : Form
    {
        private readonly int Time1;
        private int Time2 = 0;
        private int Count = 32;
        private readonly EdgeLocationType Type = EdgeLocationType.BotRight;

        public NYB(Structs.Data Data)
        {
            InitializeComponent();
            Type = Data.Location;
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
            BAR.BorderColor = BackColor;
            Time1 = Data.Time;
        }

        private void NYB_Load(object sender, EventArgs e)
        {
            Location = SingleLocation(Type, Width, Height, (ActiveOpen * Height) + Count);
            if (Type == EdgeLocationType.BotRight)
            {
                Location = new Point(Location.X + (ActiveOpen * Height), Location.Y + Count);
            }
            else if (Type == EdgeLocationType.BotLeft)
            {
                Location = new Point(Location.X - (ActiveOpen * Height), Location.Y + Count);
            }
            else if (Type == EdgeLocationType.TopRight)
            {
                Location = new Point(Location.X + (ActiveOpen * Height), Location.Y - Count);
                BAR.Dock = DockStyle.Top;
            }
            else
            {
                Location = new Point(Location.X - (ActiveOpen * Height), Location.Y - Count);
                BAR.Dock = DockStyle.Top;
            }
            StartForm.Enabled = true;
            Text += ActiveOpen;
            ActiveOpen++;
        }

        private void CLOSE_Click(object sender, EventArgs e)
        {
            FinishForm.Enabled = true;
        }

        private void CloseForm_Tick(object sender, EventArgs e)
        {
            if (Text == "NYS0")
            {
                if (Time2 <= Time1)
                {
                    Time2 += CloseForm.Interval;
                    if (BAR.Maximum > BAR.Value + 1)
                    {
                        BAR.Value++;
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
        }

        private void StartForm_Tick(object sender, EventArgs e)
        {
            if (Count > 0)
            {
                Count -= 2;
                if (Type == EdgeLocationType.BotRight || Type == EdgeLocationType.BotLeft)
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
                CloseForm.Enabled = true;
                StartForm.Enabled = false;
            }
        }

        private void FinishForm_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0)
            {
                Opacity -= 0.1;
            }
            else
            {
                NYB_FormClosed(sender, e);
                Dispose();
            }
        }

        private void ShowForm_Tick(object sender, EventArgs e)
        {
            if (Convert.ToDouble(Opacity) < 0.8)
            {
                Opacity += 0.1;
            }
            else
            {
                ShowForm.Enabled = false;
            }
        }

        private void NYB_LocationChanged(object sender, EventArgs e)
        {
            if (CloseForm.Enabled)
            {
                CloseForm.Enabled = false;
                CloseForm.Enabled = true;
            }
        }

        private void NYB_FormClosed(object sender, EventArgs e)
        {
            ActiveOpen--;
        }
    }
}