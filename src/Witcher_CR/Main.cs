#region Imports

using System;
using System.Windows.Forms;

#endregion

namespace Witcher_CR
{
    public partial class Main : Form
    {
        private static int Count = 5;

        public Main()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 5;
        }

        private void MaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox1.Text) || string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                Count = 5;
            }
            else
            {
                Count = Convert.ToInt32(maskedTextBox1.Text);
            }
        }
    }
}