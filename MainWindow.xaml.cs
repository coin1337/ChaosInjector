using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace MinecraftInjector
{
    public partial class MainWindow : Window
    {
        public static string ClientName { get; set; }
        public static string ClientDownload { get; set; }
        public static string AccentColor { get; set; }
        public static string DiscordUrl { get; set; }
        public MainWindow()
        {
            /// change settings here ////////////////////////////////
            ClientName = "Chaos Injector";
            ClientDownload = "https://horion.download/bin/Horion.dll";
            AccentColor = "#ffffff";
            DiscordUrl = "https://discord.gg/pznTqY7Mfb";
            /////////////////////////////////////////////////////////
            InitializeComponent();
            SetStatus("ready to inject!");
        }

        public void SetStatus(string text)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate{
                TextBlock textBlock = new TextBlock();
                textBlock.FontFamily = this.FindResource("Inter") as FontFamily;
                textBlock.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(AccentColor));
                textBlock.Text = text;
                StackPanel.Children.Add(textBlock);
            });
            
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = DiscordUrl,
                UseShellExecute = true
            });
        }

        private void ButtonBase_OnClick3(object sender, RoutedEventArgs e)
        {
            Credits win2 = new Credits();
            win2.Show();
        }
        
        private void InjectButton_Left(object sender, RoutedEventArgs e)
        {
            SetStatus("downloading DLL...");
            var file = Path.Combine(Path.GetTempPath(), "Horion.dll");
            using (var wc = new WebClient())
            {
                wc.DownloadFileCompleted += (_, __) => { Task.Run(() => Inject(file));};
                wc.DownloadFileAsync(new Uri(ClientDownload), file);
            }
        }
    }
}