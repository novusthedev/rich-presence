using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using Rich_Presence.ViewModels;
using static Rich_Presence.Views.MainPage;

namespace Rich_Presence.Views;

public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();

        AppTitle.Text = "Rich Presence";


    }


    private async Task ExploreFiles_ClickAsync(object sender, RoutedEventArgs e)
    {
        _ = await Windows.System.Launcher.LaunchFolderPathAsync(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

    }

    private void ExploreFiles_Click(object sender, RoutedEventArgs e)
    {

    }

    private void ExploreFiles_Click_1(object sender, RoutedEventArgs e)
    {

    }
}
