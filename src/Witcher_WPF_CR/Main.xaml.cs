#region Imports

using System.Windows;
using System.Windows.Controls;
using Witcher.Enum;
using Witcher.WPF.Struct;
using static Taskbar.Enum.Enums;
using static Witcher.WPF.Witcher;

#endregion

namespace Witcher_WPF_CR
{
    public partial class Main : Window
    {
        private static Structs.Data Data = new()
        {
            Location = EdgeLocationType.BotRight,
            Type = Enums.NotifyType.Standard,
            Alert = Enums.AlertType.Success,
            Theme = Enums.ThemeType.Dark,
            Distance = 32,
            Title = "Soferity Witcher WPF",
            Text = "My Name Is Soferity Witcher WPF Sweetheart!",
            Font = new()
            {
                Family = new("Raleway SemiBold"),
                Size = 16F,
                Stretch = FontStretches.Normal,
                Style = FontStyles.Normal,
                Weight = FontWeights.Bold,
            },
            Size = new() { Width = 400, Height = 60 },
            Pause = true,
            Close = true,
            Top = true,
            Time = 5000
        };

        public Main()
        {
            InitializeComponent();
            Edge.SelectedIndex = 5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Notify.Show(Data);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.Location = (EdgeLocationType)Edge.SelectedIndex;
        }
    }
}