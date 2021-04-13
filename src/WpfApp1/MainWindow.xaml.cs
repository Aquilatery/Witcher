using System.Drawing;
using System.Windows;
using Witcher.Enum;
using Witcher.Struct;
using static Taskbar.Enum.Enums;
using static Witcher.Witcher;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Structs.Data Data = new Structs.Data()
            {
                Location = EdgeLocationType.BotRight,
                Type = Enums.NotifyType.Standard,
                Alert = Enums.AlertType.Success,
                Theme = Enums.ThemaType.Dark,
                Distance = 32,
                Title = "Witcher Test Title",
                Text = "Witcher Test Notify!",
                Font = new Font("Raleway SemiBold", 12F, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 162),
                Top = true,
                Time = 100
            };

            Notify.Show(Data);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Notify.ClearAll();
        }
    }
}