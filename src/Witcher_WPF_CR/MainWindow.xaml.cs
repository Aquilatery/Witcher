#region Imports

using System.Windows;
using Witcher.Enum;
using Witcher.WPF.Struct;
using static Taskbar.Enum.Enums;
using static Witcher.WPF.Witcher;

#endregion

namespace Witcher_WPF_CR
{
    public partial class MainWindow : Window
    {
        private static Structs.Data Data = new()
        {
            Location = EdgeLocationType.BotRight,
            Type = Enums.NotifyType.Standard,
            Alert = Enums.AlertType.Success,
            Theme = Enums.ThemeType.Dark,
            Distance = 32,
            Title = "Witcher Test Title",
            Text = "Witcher Test Notify!",
            Font = new()
            {
                Family = new("Raleway SemiBold"),
                Size = 12F,
                Stretch = FontStretches.Normal,
                Style = FontStyles.Normal,
                Weight = FontWeights.Bold,
            },
            Pause = true,
            Top = true,
            Time = 5000
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Notify.Show(Data);
        }
    }
}