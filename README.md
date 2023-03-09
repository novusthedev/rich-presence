# Rich Presence UWP

A basic UWP rich presence client for Discord.

Created using WinUI 3, UWP & Lachee's Discord RPC for C# (https://github.com/Lachee/discord-rpc-csharp).

# Features
* Fluent design with WinUI 3 (Best for Windows 11)
* Full image & button support
* Discord Developer Portal inside the app! (Microsoft Edge WebView 2 required)

# Do i need Windows 11 to run Rich Presence?
No, You don't. You need Windows 10 1903 or later to run the app. Windows 11 is optional for full theme support (like Mica and Acrylic).

# How to install

In order to install this app, you need to also install the certificate required.

Download the cert in the Releases tab. Any version will work as it uses the same certificate.

* Install the cert by opening "Cert required to install.cer"
* Press Install certificate
* Check Local Machine
* Press "Yes" to UAC if prompted
* Check Place all certificates in store & select "Trusted Root Certfication Authorites"
* Press OK & Click next.
The cert should install itself. You should see a popup when the installations complete.


# Install using App Installer
* Open the .msix file bundled in the release
* And press "Install"!

# How to use
* You must create an app on the Discord Developer Portal. You can use the dev portal within the app. (Microsoft Edge WebView 2 must be installed)
* Provide an ID, and provide the rest of the RPC yourself. (Buttons & images are optional.)
* If you wanna save your presence for later, Press the save button! Then load it back up by pressing open.
* And lastly, press ▶️ Start Presence to start it up! You'll need to close the app to stop it.