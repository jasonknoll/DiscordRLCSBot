using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using Discord.Commands;

public class Bot
{
    public static Task Main(String[] args) => new Bot().MainAsync();

    private DiscordSocketClient _client;
    private string URL_TO_AUTH = "auth.json";

    public async Task MainAsync()
    {
        _client = new DiscordSocketClient();

        _client.Log += Log;

        // grab credentials
        var text = File.ReadAllText(URL_TO_AUTH);
        var tokenDict = JsonConvert.DeserializeObject<Dictionary<string,string>>(text);
        
        string token = tokenDict["token"].ToString();

        // turn on bot
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(Timeout.Infinite);
    }

    /**
    * Simple logging message
    */
    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}

