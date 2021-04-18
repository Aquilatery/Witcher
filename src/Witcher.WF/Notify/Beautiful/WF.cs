#region Imports

using System;
using System.Drawing;
using System.Windows.Forms;
using Witcher.Helper;
using Witcher.WF.Struct;
using Witcher.WF.Value;
using static Taskbar.Enum.Enums;
using static Taskbar.Taskbar.Advanced;
using static Witcher.Enum.Enums;
using static Witcher.WF.Witcher.Property;
using static Witcher.Witcher.Property;

#endregion

namespace Witcher.WF.Notify.Beautiful
{
    #region WitcherBeautifulWF

    /// <summary>
    /// 
    /// </summary>
    public partial class WitcherBeautifulWF : Form
    {
        private Structs.Data Local = Values.Data;
        private StateType Stage = StateType.Show;

        private bool Exit = true;
        private double TValue, BValue;

        public WitcherBeautifulWF(Structs.Data Data)
        {
            InitializeComponent();

            Text = NotifyName + ActiveOpen;

            Local = Data;

            TopMost = Local.Top;

            TITLE.Text = Local.Title;
            TITLE.Font = Local.Font;

            TEXT.Text = Local.Text;
            TEXT.Font = Local.Font;

            Width = Local.Size.Width;
            Height = Local.Size.Height;

            LEFT.Visible = Local.Close;
            TOP.Visible = Local.Close;
            RIGHT.Visible = Local.Close;
            BOT.Visible = Local.Close;

            if (Local.Theme == ThemeType.Dark || Local.Theme == ThemeType.Light)
            {
                if (Local.Theme == ThemeType.Dark)
                {
                    BackColor = Color.FromArgb(38, 38, 38);
                    TITLE.ForeColor = Color.FromArgb(217, 217, 217);
                    TEXT.ForeColor = Color.Gainsboro;
                }
                else
                {
                    BackColor = Color.Gainsboro;
                    TITLE.ForeColor = Color.FromArgb(35, 35, 35);
                    TEXT.ForeColor = Color.FromArgb(38, 38, 38);
                }

                switch (Local.Alert)
                {
                    case AlertType.Success:
                        LBAR.BackColor = Color.SeaGreen;
                        break;
                    case AlertType.Warning:
                        LBAR.BackColor = Color.FromArgb(255, 128, 0);
                        break;
                    case AlertType.Error:
                        LBAR.BackColor = Color.Crimson;
                        break;
                    case AlertType.Info:
                        LBAR.BackColor = Color.Gray;
                        break;
                }

                TBAR.BackColor = LBAR.BackColor;
                RBAR.BackColor = TBAR.BackColor;
                BBAR.BackColor = RBAR.BackColor;
            }
            else
            {
                BackColor = Values.CustomTheme.Background;
                TITLE.ForeColor = Values.CustomTheme.Title;
                TEXT.ForeColor = Values.CustomTheme.Text;
                LEFT.BackColor = Values.CustomTheme.Edge;
                LBAR.BackColor = Values.CustomTheme.Bar;
                TBAR.BackColor = LBAR.BackColor;
                RBAR.BackColor = TBAR.BackColor;
                BBAR.BackColor = RBAR.BackColor;
            }
        }

        private void BeautifulWF_Load(object sender, EventArgs e)
        {
            Location = SingleLocation(Local.Location, Width, Height, (ActiveOpen * Height) + Local.Distance);

            if (Local.Location == EdgeLocationType.BotRight)
            {
                Location = new Point(Location.X + (ActiveOpen * Height), Location.Y - Local.Distance);
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
            }
            else if (Local.Location == EdgeLocationType.TopCenter)
            {
                Location = new Point(Location.X, Location.Y + Local.Distance);
            }
            else if (Local.Location == EdgeLocationType.TopLeft)
            {
                Location = new Point(Location.X - (ActiveOpen * Height), Location.Y + Local.Distance);
            }
            else if (Local.Location == EdgeLocationType.LeftCenter)
            {
                Location = new Point(Location.X - (ActiveOpen * Height), Location.Y - (ActiveOpen * Height));
            }
            else if (Local.Location == EdgeLocationType.RightCenter)
            {
                Location = new Point(Location.X + (ActiveOpen * Height), Location.Y + (ActiveOpen * Height));
            }
            else if (Local.Location == EdgeLocationType.CalcCenter)
            {
                Location = new Point(Location.X, Location.Y + (ActiveOpen * Height));
            }
            else
            {
                Location = new Point(Location.X, Location.Y - (ActiveOpen * Height));
            }
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
                        General.Interval = 10;
                        Stage = StateType.Close;
                    }
                    break;
                case StateType.Close:
                    if (Text == NotifyName + "0")
                    {
                        if (Local.Close)
                        {
                            if (LBAR.Height < LEFT.Height || RBAR.Height < RIGHT.Height)
                            {
                                if (LBAR.Height < LEFT.Height)
                                {
                                    LBAR.Height += 2;
                                }

                                if (RBAR.Height < RIGHT.Height)
                                {
                                    RBAR.Height += 2;
                                    RBAR.Location = new(0, RBAR.Location.Y - 2);
                                }
                            }
                            else
                            {
                                if (General.Interval == 10)
                                {
                                    General.Interval = 50;
                                }

                                if (TBAR.Width < TOP.Width || BBAR.Width < BOT.Width)
                                {
                                    TValue += TOP.Width / (Local.Time / General.Interval);

                                    if (TBAR.Width < Convert.ToInt32(TValue))
                                    {
                                        TBAR.Width = Convert.ToInt32(TValue);
                                    }

                                    BValue += BOT.Width / (Local.Time / General.Interval);

                                    if (BBAR.Width < Convert.ToInt32(BValue))
                                    {
                                        BBAR.Width = Convert.ToInt32(BValue);
                                        BBAR.Location = new(BOT.Width - Convert.ToInt32(BValue), 0);
                                    }
                                }
                                else
                                {
                                    TBAR.Width = TOP.Width;
                                    BBAR.Width = BOT.Width;
                                    BBAR.Location = new(0, 0);
                                    CLOSE_Click(sender, e);
                                }
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
                        BeautifulWF_FormClosed(sender, e);
                        Dispose();
                    }
                    break;
            }
        }

        private void BeautifulWF_LocationChanged(object sender, EventArgs e)
        {
            if (General.Enabled && Stage == StateType.Close)
            {
                General.Enabled = false;
                General.Enabled = true;
            }
        }

        private void BeautifulWF_FormClosed(object sender, EventArgs e)
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