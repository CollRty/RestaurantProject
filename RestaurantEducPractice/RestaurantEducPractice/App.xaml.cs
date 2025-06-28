using System.Configuration;
using System.Data;
using System.Windows;
using Supabase;

namespace RestaurantEducPractice;

public partial class App : Application
{
    public static Supabase.Client SupabaseClient;

    public async Task InitializeSupabaseAsync()
    {
        string url = "https://mfconwtdycwjqjigdqfj.supabase.co";
        string anonKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im1mY29ud3RkeWN3anFqaWdkcWZqIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTEwMzY1MjEsImV4cCI6MjA2NjYxMjUyMX0.QmdWZOWDg7q6uW7CWcclQqwe4IWaHELWPPgwVxjX7vM";

        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = false
        };

        SupabaseClient = new Supabase.Client(url, anonKey, options);
        await SupabaseClient.InitializeAsync();
    }
    private async void App_OnStartup(object sender, StartupEventArgs e)
    {
        await InitializeSupabaseAsync();
    }

}

