using System.IO;
using System.Reflection;
using Microsoft.Web.WebView2.Core;

namespace WebView2HostObjectExample
{
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            WebView.CoreWebView2InitializationCompleted += WebView2_CoreWebView2Ready;
            OpenContent();
        }

        private void WebView2_CoreWebView2Ready(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            WebView.CoreWebView2.AddHostObjectToScript("bridge", new WebViewHostModel());
        }

        private void OpenContent()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "WebView2HostObjectExample.test.html";

            var result = "";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            
            WebView.Dispatcher.Invoke(async () =>
            {
                await WebView.EnsureCoreWebView2Async().ConfigureAwait(true);
                WebView.CoreWebView2.NavigateToString(result);
            });
        }
    }
}