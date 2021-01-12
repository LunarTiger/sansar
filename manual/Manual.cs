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
    [DisplayName("Avaliable Commands")]
    [DefaultValue("man, tk, g, lunar, destinations, places, studio, field, house, ctrl, void")]
    public readonly string AvaliableCommands;

    public override void Init()
    {
        // Set up a callback to listen to the default chat channel for all events
        ScenePrivate.Chat.Subscribe(Chat.DefaultChannel, OnChat, true);
    }

    private void OnChat(ChatData data)
    {
        // Parse the chat message into an array of strings and look for a "/g" command
        var cmds = data.Message.Split(new Char[] { ' ' });
        if (cmds[0] == "/man")
        {
            if (cmds.Length > 1)
            {
                // Lunar
                if (cmds[1] == "lunar" || cmds[1] == "/lunar")
                {
                    ScenePrivate.Chat.MessageAllUsers("/lunar\nGives a link to Lunar's linktree.");
                }
                // Gravity
                else if (cmds[1] == "g" || cmds[1] == "/g")
                {
                    ScenePrivate.Chat.MessageAllUsers("/g\nA command to set the gravity.\nAccepts values from 0-49.\n************\nArguments:\ndefault - resets to default gravity\nplanets - lists the planets avaliable to set the gravity\n************\nExamples:\n/g 3.14\n/g default\n/g planets\n************\nSource Code:  https://lunartiger.github.io/sansar/gravity");
                }
                // tk
                else if (cmds[1] == "tk" || cmds[1] == "/tk")
                {
                    ScenePrivate.Chat.MessageAllUsers("/tk\nPlays videos/displays webpages.\n************\nExamples:\n/tk https://lunartiger.gthub.io/tk\n/tk https://youtu.be/dQw4w9WgXcQ");
                }
                // destinations/places
                else if (cmds[1] == "destinations" || cmds[1] == "/destinations")
                {
                    ScenePrivate.Chat.MessageAllUsers("/destinations\nPrints out a list of the destinations within the world.");
                }
                else if (cmds[1] == "places" || cmds[1] == "/places")
                {
                    ScenePrivate.Chat.MessageAllUsers("/places\nPrints out a list of the destinations within the world.");
                }
                // in-world teleports
                else if (cmds[1] == "ctrl" || cmds[1] == "/ctrl")
                {
                    ScenePrivate.Chat.MessageAllUsers("/ctrl\nTeleports you to the control room.\nIn world teleport.");
                }
                else if (cmds[1] == "field" || cmds[1] == "/field")
                {
                    ScenePrivate.Chat.MessageAllUsers("/field\nTeleports you to a field where there is a large media screen.\nIn world teleport.");
                }
                else if (cmds[1] == "house" || cmds[1] == "/house")
                {
                    ScenePrivate.Chat.MessageAllUsers("/house\nTeleports you to a tiny house.\nIn world teleport.");
                }
                else if (cmds[1] == "studio" || cmds[1] == "/studio")
                {
                    ScenePrivate.Chat.MessageAllUsers("/studio\nTeleports you to the studio area. This is the main spawn point of the world.\nIn world teleport.");
                }
                // void
                else if (cmds[1] == "void" || cmds[1] == "/void")
                {
                    ScenePrivate.Chat.MessageAllUsers("/void\nTeleports you to the void.\n*This is another world.*");
                }
                // man
                else if (cmds[1] == "man" || cmds[1] == "/man")
                {
                    ScenePrivate.Chat.MessageAllUsers("/man\nThis is a helpful manual. Just use the command \"/man\" along with an avaliable command to find out more about it.\n************\nAvaliable Commands:\n" + AvaliableCommands + "\n************\nSource Code:  https://lunartiger.github.io/sansar/gravity");
                }
                // if no matches found
                else
                {
                    //($"Unknown command. Avaliable Commands:  {AvaliableCommands}");
                    //can't get that working so I'll continue messaging everyone I guess
                    ScenePrivate.Chat.MessageAllUsers("Unknown command. Avaliable Commands:  " + AvaliableCommands);
                }
            }
            // If no additional parameter was specified, print out the scene's current gravity
            else
            {
                ScenePrivate.Chat.MessageAllUsers("Avaliable Commands:  " + AvaliableCommands);
            }
        }
    }
}
