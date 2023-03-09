using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using Rich_Presence.ViewModels;

using DiscordRPC;
using Windows.Media.Protection.PlayReady;
using DiscordRPC.Logging;
using Microsoft.UI.Xaml.Controls.Primitives;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.Storage;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Rich_Presence.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }

    public class RPCData
    {
        public string? AppID
        {
            get; set;
        }

        public string? Details
        {
            get; set;
        }

        public string? State
        {
            get; set;
        }

        public string? LargeKey
        {
            get; set;
        }

        public string? SmallKey
        {
            get; set;
        }

        public string? LargeText
        {
            get; set;
        }

        public string? SmallText
        {
            get; set;
        }

        public bool? Button1Enabled
        {
            get; set;
        }

        public string? Button1Label
        {
            get; set;
        }

        public string? Button1URL
        {
            get; set;
        }

        public bool? Button2Enabled
        {
            get; set;
        }

        public string? Button2Label
        {
            get; set;
        }

        public string? Button2URL
        {
            get; set;
        }

    }

    // Save & Open

    private void SaveToFile_Click(object sender, RoutedEventArgs e)
    {
        var RichData = new RPCData
        {
            AppID = AppID.Text.ToString(),
            Details = RPC_Details.Text.ToString(),
            State = RPC_State.Text.ToString(),
            LargeKey = RPC_LargeKey.Text.ToString(),
            SmallKey = RPC_SmallKey.Text.ToString(),
            LargeText = RPC_LargeText.Text.ToString(),
            SmallText = RPC_SmallText.Text.ToString(),
            Button1Enabled = (bool)Button1Switch.IsOn,
            Button1Label = Button1Label.Text.ToString(),
            Button1URL = Button1URL.Text.ToString(),
            Button2Enabled = (bool)Button2Switch.IsOn,
            Button2Label = Button2Label.Text.ToString(),
            Button2URL = Button2URL.Text.ToString(),
        };

        var jsonString = JsonSerializer.Serialize(RichData);

        var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        var filepath = Path.Combine(path, "SavedRPC.json");

        File.WriteAllText(filepath, jsonString);

    }

    private void OpenFromFile_Click(object sender, RoutedEventArgs e)
    {

        var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        var filepath = Path.Combine(path, "SavedRPC.json");

        var jsonString = File.ReadAllText(filepath);
        RPCData RichData = JsonSerializer.Deserialize<RPCData>(jsonString)!;

        AppID.Text = RichData.AppID;
        RPC_Details.Text = RichData.Details;
        RPC_State.Text = RichData.State;
        RPC_LargeKey.Text = RichData.LargeKey;
        RPC_SmallKey.Text = RichData.SmallKey;
        RPC_LargeText.Text = RichData.LargeText;
        RPC_SmallText.Text = RichData.SmallText;
        Button1Switch.IsOn = (bool)RichData.Button1Enabled;
        Button1Label.Text = RichData.Button1Label;
        Button1URL.Text = RichData.Button1URL;
        Button2Switch.IsOn = (bool)RichData.Button2Enabled;
        Button2Label.Text = RichData.Button2Label;
        Button2URL.Text = RichData.Button2URL;


        File.WriteAllText(filepath, jsonString);

    }

    private void Button1Switch_Toggled(object sender, RoutedEventArgs e)
    {
        if (Button1Switch.IsOn == true)
        {
            Button1Label.IsEnabled = true;
            Button1URL.IsEnabled = true;
            Button2Switch.IsEnabled = true;
        }
        else
        {
            Button1Label.IsEnabled = false;
            Button1URL.IsEnabled = false;
            Button2Switch.IsEnabled = false;
            Button2Switch.IsOn = false;
            Button2Label.IsEnabled = false;
            Button2URL.IsEnabled = false;
        }

    }

    private void Button2Switch_Toggled(object sender, RoutedEventArgs e)
    {
        if (Button2Switch.IsOn == true)
        {
            Button2Label.IsEnabled = true;
            Button2URL.IsEnabled = true;
        }
        else
        {
            Button2Label.IsEnabled = false;
            Button2URL.IsEnabled = false;
        }

    }

    private void ToggleButton_Click(object sender, RoutedEventArgs e)
    {

        ToggleButton.Content = "ℹ️ Starting...";

        var client = new DiscordRpcClient(AppID.Text.ToString());

        client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

        client.Initialize();

        if (Button1Switch.IsOn == false)
        {

            if (Button2Switch.IsOn == false)
            {

                client.SetPresence(new RichPresence()
                {
                    Details = RPC_Details.Text.ToString(),
                    State = RPC_State.Text.ToString(),

                    Assets = new Assets()
                    {
                        LargeImageKey = RPC_LargeKey.Text.ToString(),
                        LargeImageText = RPC_LargeText.Text.ToString(),
                        SmallImageKey = RPC_SmallKey.Text.ToString(),
                        SmallImageText = RPC_SmallText.Text.ToString(),
                    },

                }); ; ;

            }
        }

            if (Button1Switch.IsOn == true)
        {

            if (Button2Switch.IsOn == false)
            {

                client.SetPresence(new RichPresence()
                {
                    Details = RPC_Details.Text.ToString(),
                    State = RPC_State.Text.ToString(),

                    Assets = new Assets()
                    {
                        LargeImageKey = RPC_LargeKey.Text.ToString(),
                        LargeImageText = RPC_LargeText.Text.ToString(),
                        SmallImageKey = RPC_SmallKey.Text.ToString(),
                        SmallImageText = RPC_SmallText.Text.ToString(),
                    },

                    Buttons = new DiscordRPC.Button[]
            {
                new DiscordRPC.Button()
                {
                     Label = Button1Label.Text.ToString(),
                     Url = Button1URL.Text.ToString(),
                },

            }

                }); ; ;

            }

        }

        if (Button2Switch.IsOn == true)
        {

            client.SetPresence(new RichPresence()
            {
                Details = RPC_Details.Text.ToString(),
                State = RPC_State.Text.ToString(),

                Assets = new Assets()
                {
                    LargeImageKey = RPC_LargeKey.Text.ToString(),
                    LargeImageText = RPC_LargeText.Text.ToString(),
                    SmallImageKey = RPC_SmallKey.Text.ToString(),
                    SmallImageText = RPC_SmallText.Text.ToString(),
                },

                Buttons = new DiscordRPC.Button[]
            {
                new DiscordRPC.Button()
                {
                     Label = Button1Label.Text.ToString(),
                     Url = Button1URL.Text.ToString(),
                },

                new DiscordRPC.Button()
                {
                     Label = Button2Label.Text.ToString(),
                     Url = Button2URL.Text.ToString(),
                },

            }

            }); ; ;

        }


        ToggleButton.IsEnabled = false;
        ToggleButton.Visibility = Visibility.Collapsed;
        OpenFromFile.IsEnabled = false;
        OpenFromFile.Visibility = Visibility.Collapsed;

     new ToastContentBuilder()
    .AddText("Rich presence started!")
    .AddText("Check your Discord profile to see the new presence! You need to close the app to stop the presence. You can save your presence for next time.")
    .Show();

    }
}