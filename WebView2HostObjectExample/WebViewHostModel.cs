using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebView2HostObjectExample;

/**
 * @see https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.core.corewebview2.addhostobjecttoscript?view=webview2-dotnet-1.0.1189-prerelease
 */
[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]
public class WebViewHostModel
{
    public void MyFunction()
    {
        Debug.WriteLine("test");
    }
}