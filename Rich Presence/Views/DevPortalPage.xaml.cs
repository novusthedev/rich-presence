using Microsoft.UI.Xaml.Controls;

using Rich_Presence.ViewModels;

namespace Rich_Presence.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class DevPortalPage : Page
{
    public DevPortalViewModel ViewModel
    {
        get;
    }

    public DevPortalPage()
    {
        ViewModel = App.GetService<DevPortalViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}
