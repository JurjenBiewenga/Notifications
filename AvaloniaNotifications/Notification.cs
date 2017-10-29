using System.Collections.Generic;
using Avalonia.Media.Imaging;

namespace AvaloniaNotifications
{
    public class Notification
    {
        public string xamlOverride = "";
        public Dictionary<string, string> text = new Dictionary<string, string>();
        public Dictionary<string, IBitmap> images = new Dictionary<string, IBitmap>();
        public List<string> buttons = new List<string>();
        public List<string> inputs = new List<string>();
    }
}