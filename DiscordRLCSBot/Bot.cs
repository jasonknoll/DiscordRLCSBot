// This uses Discord.NET
// I want to switch to DSharpPlus

using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using Discord.Commands;

public class Bot
{
    public static Task Main(String[] args) => new Bot().MainAsync();

    // client object
    private DiscordSocketClient _client;
    
    // grab auth file from directory
    private string URL_TO_AUTH = "auth.json";

    public async Task MainAsync()
    {
        _client = new DiscordSocketClient();

        _client.Log += Log;

        // grab credentials
        var text = File.ReadAllText(URL_TO_AUTH);
        var tokenDict = JsonConvert.DeserializeObject<Dictionary<string,string>>(text);
        
        string token = tokenDict["token"].ToString();

        // bot login
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        // wait
        await Task.Delay(Timeout.Infinite);
    }

    /**
    * Simple logging message -- following Discord.NET tutorial
    */
    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}

