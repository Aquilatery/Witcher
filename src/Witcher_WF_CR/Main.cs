#region Imports

using System;
using System.Drawing;
using System.Windows.Forms;
using static Taskbar.Enum.Enums;
using static Witcher.Enum.Enums;
using static Witcher.WF.Struct.Structs;
using static Witcher.WF.Witcher;
using static Witcher.WF.Witcher.Property;
using static Witcher.Witcher.Property;

#endregion

namespace Witcher_WF_CR
{
    public partial class Main : Form
    {
        private static Data Data = new()
        {
            Location = EdgeLocationType.TopRight,
            Type = NotifyType.Standard,
            Alert = AlertType.Success,
            Theme = ThemeType.Dark,
            Distance = 32,
            Title = "Soferity Witcher WF",
            Text = "My Name Is Soferity Witcher WF Sweetheart!",
            Font = new Font("Raleway SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162),
            Size = new() { Width = 400, Height = 60 },
            Pause = true,
            Close = true,
            Top = true,
            Time = 5000
        };

        public Main()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 5;
            comboBox2.SelectedIndex = 0;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                Data.Text = "My Name Is Soferity Witcher WF Sweetheart!";
            }
            else
            {
                Data.Text = textBox1.Text;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Data.Title = "Soferity Witcher WF";
            }
            else
            {
                Data.Title = textBox2.Text;
            }
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
                Data.Time = 5000;
            }
            else
            {
                Data.Time = Convert.ToInt32(maskedTextBox2.Text);
            }
        }

        private void MaskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox3.Text) || string.IsNullOrWhiteSpace(maskedTextBox3.Text))
            {
                Data.Distance = 32;
            }
            else
            {
                Data.Distance = Convert.ToInt32(maskedTextBox3.Text);
            }
        }

        private void MaskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox4.Text) || string.IsNullOrWhiteSpace(maskedTextBox4.Text))
            {
                Data.Size.Height = 60;
            }
            else
            {
                Data.Size.Height = Convert.ToInt32(maskedTextBox4.Text);
            }
        }

        private void MaskedTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox5.Text) || string.IsNullOrWhiteSpace(maskedTextBox5.Text))
            {
                Data.Size.Width = 400;
            }
            else
            {
                Data.Size.Width = Convert.ToInt32(maskedTextBox5.Text);
            }
        }

        private void Thema_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton RB = sender as RadioButton;

            if (RB.Checked)
            {
                if (RB.Text == "Dark")
                {
                    Data.Theme = ThemeType.Dark;
                }
                else if (RB.Text == "Light")
                {
                    Data.Theme = ThemeType.Light;
                }
                else
                {
                    Data.Theme = ThemeType.Custom;
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.Location = (EdgeLocationType)comboBox1.SelectedIndex;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.Type = (NotifyType)comboBox2.SelectedIndex;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            Button B = sender as Button;

            Data.Alert = B.Text switch
            {
                "Error" => AlertType.Error,
                "Warning" => AlertType.Warning,
                "Info" => AlertType.Info,
                _ => AlertType.Success,
            };

            Notify.Show(Data);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Notify.ClearAll();
        }

        private void Status_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Active: " + ActiveOpen;
            toolStripStatusLabel2.Text = "Deactive: " + DeactiveOpen;
            toolStripStatusLabel3.Text = "Total: " + TotalOpen;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            FontDialog FD = new();

            FD.Font = Data.Font;
            FD.MaxSize = 40;
            FD.MinSize = 4;

            if (FD.ShowDialog() == DialogResult.OK)
            {
                Data.Font = FD.Font;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Data.Pause = checkBox1.Checked;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Data.Top = checkBox2.Checked;
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            Data.Close = checkBox3.Checked;
        }
    }
}