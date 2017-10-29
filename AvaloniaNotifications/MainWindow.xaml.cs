using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaNotifications
{
    public class MainWindow : Window
    {
        public MainWindow(Notification notification)
        {
            InitializeComponent(notification.xamlOverride);
        }

        private void InitializeComponent(string xamlOverride)
        {
            if (string.IsNullOrWhiteSpace(xamlOverride))
                AvaloniaXamlLoader.Load(this);
            else
                AvaloniaXamlLoader.Parse(xamlOverride);  
        }
    }
}