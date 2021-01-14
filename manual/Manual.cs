/********************************************
 * This script is for Lunar's Chill Hangout *
 ********************************************
 ********************************************************************
 * Register for the event that occurs when chat messages happen.    *
 * Listens for a "/man" command that will either print the commands *
 * avaliable in the world or give an explination of a command.      *
 ********************************************************************/
using Sansar.Simulation;
using Sansar.Script;
using System;


// To get full access to the Object API a script must extend from ObjectScript
public class Manual : SceneObjectScript
{
    //I know this isn't how you're supposed to declare variables for a script, but it works, so fuck it
    [DisplayName("Avaliable Commands")]
    [DefaultValue("man, tk, g, lunar, destinations, places, afk, brb, studio, field, house, ctrl, void")]
    public readonly string AvaliableCommands;

    public override void Init()
    {
        // Set up a callback to listen to the default chat channel for all events
        ScenePrivate.Chat.Subscribe(Chat.DefaultChannel, OnChat, true);
    }

    private void OnChat(ChatData data)
    {
        SessionId ssid = data.SourceId;
        AgentPrivate agent = ScenePrivate.FindAgent(ssid);
        // Parse the chat message into an array of strings and look for a "/man" command
        var cmds = data.Message.Split(new Char[] { ' ' });
        if (cmds[0] == "/man")
        {
            if (cmds.Length > 1)
            {
                // Lunar
                if (cmds[1] == "lunar" || cmds[1] == "/lunar")
                {
                    agent.SendChat("/lunar\n-Displays \"Lunar: https://linktr.ee/lunar69\" which is a link to Lunar's linktree.");
                }
                // Gravity
                else if (cmds[1] == "g" || cmds[1] == "/g")
                {
                    agent.SendChat("/g\n-A command to set the gravity.\n-Accepts values from 0-49.\n************\nArguments:\nhelp - displays help\ndefault - resets to default gravity\nreset - resets to default gravity\nplanets - lists the planets avaliable to set the gravity\n************\nExamples:\n/g 3.14\n/g default\n/g planets\n************\nSource Code:  https://lunartiger.github.io/sansar/gravity");
                }
                // tk
                else if (cmds[1] == "tk" || cmds[1] == "/tk")
                {
                    agent.SendChat("/tk\n-Plays videos/displays webpages.\n************\nExamples:\n/tk https://lunartiger.gthub.io/tk\n/tk https://youtu.be/dQw4w9WgXcQ");
                }
                // destinations/places
                else if (cmds[1] == "destinations" || cmds[1] == "/destinations")
                {
                    agent.SendChat("/destinations\n-Prints out a list of the destinations within the world.\n~Same as /places");
                }
                else if (cmds[1] == "places" || cmds[1] == "/places")
                {
                    agent.SendChat("/places\n-Prints out a list of the destinations within the world.\n~Same as /destinations");
                }
                // in-world teleports
                else if (cmds[1] == "ctrl" || cmds[1] == "/ctrl")
                {
                    agent.SendChat("/ctrl\n-Teleports you to the control room.\n~In world teleport.");
                }
                else if (cmds[1] == "field" || cmds[1] == "/field")
                {
                    agent.SendChat("/field\n-Teleports you to a field where there is a large media screen.\n~In world teleport.");
                }
                else if (cmds[1] == "house" || cmds[1] == "/house")
                {
                    agent.SendChat("/house\n-Teleports you to a tiny house.\n~In world teleport.");
                }
                else if (cmds[1] == "studio" || cmds[1] == "/studio")
                {
                    agent.SendChat("/studio\n-Teleports you to the studio area.\n-This is the main spawn point of the world.\n~In world teleport.");
                }
                // void
                else if (cmds[1] == "void" || cmds[1] == "/void")
                {
                    agent.SendChat("/void\n-Teleports you to the void.\n~*This is another world.*");
                }
                // man
                else if (cmds[1] == "man" || cmds[1] == "/man")
                {
                    agent.SendChat("/man\n-This is a helpful manual.\n-Just use the command \"/man\" along with an avaliable command to find out more about it.\n************\nAvaliable Commands:  " + AvaliableCommands + "\n************\nSource Code:  https://lunartiger.github.io/sansar/manual");
                }
                //afk/brb
                else if (cmds[1] == "afk" || cmds[1] == "/afk")
                {
                    agent.SendChat("afk\n-Typing \"afk\" in chat will make you do an emote, making it obvious you're not available.\n-Works with or without \"/\"\n~Same as brb");
                }
                else if (cmds[1] == "brb" || cmds[1] == "/brb")
                {
                    agent.SendChat("brb\n-Typing \"brb\" in chat will make you do an emote, making it obvious you're not available.\n-Works with or without \"/\"\n~Same as afk");
                }
                // if no matches found
                else
                {
                    //($"Unknown command. Avaliable Commands:  {AvaliableCommands}");
                    agent.SendChat("Unknown command ¯\\_(ツ)_/¯\n************\nAvaliable Commands:  " + AvaliableCommands);
                }
            }
            // If no additional parameter was specified, print out the avaliable commands.
            else
            {
                agent.SendChat("Avaliable Commands:  " + AvaliableCommands);
            }
        }
    }
}
