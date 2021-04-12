#region Imports

using System;
using System.Windows.Forms;
using static Taskbar.Enum.Enums;
using static Witcher.Enum.Enums;
using static Witcher.Struct.Structs;
using static Witcher.Witcher.Property;

#endregion

namespace Witcher_CR
{
    public partial class Main : Form
    {
        private static Data Data = new()
        {
            Location = EdgeLocationType.TopRight,
            Thema = ThemaType.Dark,
            Text = "Witcher_CR"
        };

        public Main()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 5;
        }

        private void MaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox1.Text) || string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                MaxOpen = 5;
            }
            else
            {
                MaxOpen = Convert.ToInt32(maskedTextBox1.Text);
            }
        }

        private void MaskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox2.Text) || string.IsNullOrWhiteSpace(maskedTextBox2.Text))
            {
                Time = 3000;
            }
            else
            {
                Time = Convert.ToInt32(maskedTextBox2.Text);
            }
        }

        private void Thema_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton RB = sender as RadioButton;

            if (RB.Checked)
            {
                if (RB.Text == "Dark")
                {
                    Data.Thema = ThemaType.Dark;
                }
                else
                {
                    Data.Thema = ThemaType.Light;
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.Location = (EdgeLocationType)comboBox1.SelectedIndex;
        }
    }
}