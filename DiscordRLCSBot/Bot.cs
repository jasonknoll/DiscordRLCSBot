// This uses Discord.NET
// I want to switch to DSharpPlus

/*
using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using Discord.Commands;
*/

using System;
using System.Threading.Tasks;
using DSharpPlus; // TODO still need to install from NuGet!
using Newtonsoft.Json;


public class Bot
{
    public static Task Main(String[] args) => new Bot().MainAsync().GetAwaiter().GetResult();

    // client object
    private DiscordClient _client;
    
    // grab auth file from directory
    private string URL_TO_AUTH = "auth.json";

    public async Task MainAsync()
    {
        

        // grab credentials
        var text = File.ReadAllText(URL_TO_AUTH);
        var tokenDict = JsonConvert.DeserializeObject<Dictionary<string,string>>(text);
        
        // create new client with auth token
        _client = new DiscordClient(
            {
                Token = tokenDict["token"].ToString();
                TokenType = TokenType.Bot 
            });
        
        // uses lambda method to handle event
        // Docs recommend creating handlers for each event
        // TODO - need to change this structure to handle diff modules
        _client.MessageCreated += async (s, e) =>
        {
            if (e.Message.Content.ToLower().StartsWith("ping")
                await e.Message.ResponseAsync("pong!");
        }

        // bot login
        await _client.ConnectAsync();

        // wait
        await Task.Delay(-1);
    }

}

