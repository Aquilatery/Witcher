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
        private double Value;

        public WitcherBeautifulWF(Structs.Data Data)
        {
            InitializeComponent();

            Text = NotifyName + ActiveOpen;

            Local = Data;

            TopMost = Local.Top;

            TEXT.Text = Local.Text;
            TEXT.Font = Local.Font;

            //Width = Local.Size.Width;
            //Height = Local.Size.Height;
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