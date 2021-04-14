#region Imports

using System;
using System.Drawing;
using System.Windows.Forms;
using Witcher.Helper;
using Witcher.Struct;
using Witcher.Value;
using static Taskbar.Enum.Enums;
using static Taskbar.Taskbar.Advanced;
using static Witcher.Enum.Enums;
using static Witcher.Witcher.Property;

#endregion

namespace Witcher.Notify.Standard
{
    #region WitcherStandardWF

    /// <summary>
    /// 
    /// </summary>
    public partial class WitcherStandardWF : Form
    {
        private Structs.Data Local = Values.Data;
        private StateType Stage = StateType.Show;

        private double Value = 0;

        public WitcherStandardWF(Structs.Data Data)
        {
            InitializeComponent();

            Text = Values.StandardForm;

            Local = Data;

            TopMost = Local.Top;

            TEXT.Text = Local.Text;
            TEXT.Font = Local.FontWF;

            if (Local.Theme == ThemeType.Dark || Local.Theme == ThemeType.Light)
            {
                if (Local.Theme == ThemeType.Dark)
                {
                    BackColor = Color.FromArgb(38, 38, 38);
                    TEXT.ForeColor = Color.Gainsboro;
                }
                else
                {
                    BackColor = Color.Gainsboro;
                    TEXT.ForeColor = Color.FromArgb(38, 38, 38);
                }

                switch (Local.Alert)
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

                BAR.BackColor = LEFT.BackColor;
            }
            else
            {
                BackColor = Values.CustomThemeWF.Background;
                TEXT.ForeColor = Values.CustomThemeWF.Text;
                LEFT.BackColor = Values.CustomThemeWF.Edge;
                BAR.BackColor = Values.CustomThemeWF.Bar;
            }
        }

        private void StandardWF_Load(object sender, EventArgs e)
        {
            Location = SingleLocation(Local.Location, Width, Height, (ActiveOpen * Height) + Local.Distance);

            if (Local.Location == EdgeLocationType.BotRight)
            {
                Location = new Point(Location.X + (ActiveOpen * Height), Location.Y - Local.Distance);
                LEFT.Dock = DockStyle.Right;
            }
            else if (Local.Location == EdgeLocationType.BotCenter)
            {
                Location = new Point(Location.X, Location.Y - Local.Distance);
            }
            else if (Local.Location == EdgeLocationType.BotLeft)
            {
                Location = new Point(Location.X - (ActiveOpen * Height), Location.Y - Local.Distance);
            }
            else if (Local.Location == EdgeLocationType.TopRight)
            {
                Location = new Point(Location.X + (ActiveOpen * Height), Location.Y + Local.Distance);
                PANEL.Dock = DockStyle.Top;
                LEFT.Dock = DockStyle.Right;
            }
            else if (Local.Location == EdgeLocationType.TopCenter)
            {
                Location = new Point(Location.X, Location.Y + Local.Distance);
                PANEL.Dock = DockStyle.Top;
            }
            else if (Local.Location == EdgeLocationType.TopLeft)
            {
                Location = new Point(Location.X - (ActiveOpen * Height), Location.Y + Local.Distance);
                PANEL.Dock = DockStyle.Top;
            }
            else if (Local.Location == EdgeLocationType.LeftCenter)
            {
                Location = new Point(Location.X - (ActiveOpen * Height), Location.Y - (ActiveOpen * Height));
                PANEL.Dock = DockStyle.Top;
            }
            else if (Local.Location == EdgeLocationType.RightCenter)
            {
                Location = new Point(Location.X + (ActiveOpen * Height), Location.Y + (ActiveOpen * Height));
                LEFT.Dock = DockStyle.Right;
            }
            else if (Local.Location == EdgeLocationType.CalcCenter)
            {
                Location = new Point(Location.X, Location.Y + (ActiveOpen * Height));
            }
            else
            {
                Location = new Point(Location.X, Location.Y - (ActiveOpen * Height));
                PANEL.Dock = DockStyle.Top;
                LEFT.Dock = DockStyle.Right;
            }

            Text += ActiveOpen++;
        }

        private void CLOSE_MouseEnter(object sender, EventArgs e)
        {
            CLOSE.Size = new(CLOSE.Width + 2, CLOSE.Height + 2);
            CLOSE.Location = new(CLOSE.Location.X - 1, CLOSE.Location.Y - 1);
        }

        private void CLOSE_MouseLeave(object sender, EventArgs e)
        {
            CLOSE.Size = new(CLOSE.Width - 2, CLOSE.Height - 2);
            CLOSE.Location = new(CLOSE.Location.X + 1, CLOSE.Location.Y + 1);
        }

        private void CLOSE_Click(object sender, EventArgs e)
        {
            Stage = StateType.Finish;
        }

        private void General_Tick(object sender, EventArgs e)
        {
            if (Local.Pause && (Stage == StateType.Close || Stage == StateType.Unknown))
            {
                if (Helpers.Contains(MousePosition.X, MousePosition.Y, Location.X, Location.Y, Width, Height))
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
                        General.Interval = 10;
                        Stage = StateType.Start;
                    }
                    break;
                case StateType.Start:
                    if (Local.Distance > 0)
                    {
                        Local.Distance -= 2;
                        if (Local.Location == EdgeLocationType.BotRight || Local.Location == EdgeLocationType.BotCenter || Local.Location == EdgeLocationType.BotLeft || Local.Location == EdgeLocationType.LeftCenter || Local.Location == EdgeLocationType.FullCenter)
                        {
                            Location = new Point(Location.X, Location.Y + 2);
                        }
                        else
                        {
                            Location = new Point(Location.X, Location.Y - 2);
                        }
                    }
                    else
                    {
                        General.Interval = 50;
                        Stage = StateType.Close;
                    }
                    break;
                case StateType.Close:
                    if (Text == Values.StandardForm + "0")
                    {
                        if (Local.Location == EdgeLocationType.BotRight || Local.Location == EdgeLocationType.TopRight || Local.Location == EdgeLocationType.RightCenter || Local.Location == EdgeLocationType.FullCenter)
                        {
                            Value += PANEL.Width / (Local.Time / General.Interval);

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
                            Value += PANEL.Width / (Local.Time / General.Interval);

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
                        General.Stop();
                        StandardWF_FormClosed(sender, e);
                        Dispose();
                    }
                    break;
            }
        }

        private void StandardWF_LocationChanged(object sender, EventArgs e)
        {
            if (General.Enabled && Stage == StateType.Close)
            {
                General.Enabled = false;
                General.Enabled = true;
            }
        }

        private void StandardWF_FormClosed(object sender, EventArgs e)
        {
            ActiveOpen--;
        }
    }

    #endregion
}