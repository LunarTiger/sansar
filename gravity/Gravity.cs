/*******************
 *   Version 1.0  *
 *******************

 * This content is licensed under the terms of the Creative Commons Attribution 4.0 International License.
 * When using this content, you must:
 * •    Acknowledge that the content is from the Sansar Knowledge Base.
 * •    Include our copyright notice: "© 2018 Linden Research, Inc."
 * •    Indicate that the content is licensed under the Creative Commons Attribution-Share Alike 4.0 International License.
 * •    Include the URL for, or link to, the license summary at https://creativecommons.org/licenses/by-sa/4.0/deed.hi (and, if possible, to the complete license terms at https://creativecommons.org/licenses/by-sa/4.0/legalcode.
 * For example:
 * "This work uses content from the Sansar Knowledge Base. © 2018 Linden Research, Inc. Licensed under the Creative Commons Attribution 4.0 International License (license summary available at https://creativecommons.org/licenses/by/4.0/ and complete license terms available at https://creativecommons.org/licenses/by/4.0/legalcode)."

 * Register for the event that occurs when chat messages happen.
 * Listens for a "/g" command that will either print the scene's current gravity or attempts
 * to set the gravity to the specified value, such as "/g 9.81" for normal earth gravity.
 */
using Sansar.Simulation;
using Sansar.Script;
using System;

// To get full access to the Object API a script must extend from ObjectScript
public class Gravity : SceneObjectScript
{
    [DisplayName("Default Gravity")]
    [DefaultValue(9.81f)]
    public float default_gravity;

    public override void Init()
    {
        // Set up a callback to listen to the default chat channel for all events
        ScenePrivate.Chat.Subscribe(Chat.DefaultChannel, OnChat, true);
    }

    private void OnChat(ChatData data)
    {
        SessionId ssid = data.SourceId;
        AgentPrivate agent = ScenePrivate.FindAgent(ssid);
        // Parse the chat message into an array of strings and look for a "/g" command
        var cmds = data.Message.Split(new Char[] { ' ' });
        if (cmds[0] == "/g")
        {
            if (cmds.Length > 1)
            {
                // Attempt to interpret the text after the command as a number
                float value;
                if (float.TryParse(cmds[1], out value))
                {
                    // Dont accept values that are too high or too low.
                    if (0f >= value || value > 49f)
                    {
                        agent.SendChat("You tried to set the gravity to " + value + ", but the gravity can only be set 0-49");
                    }
                    else
                    {
                        ScenePrivate.Chat.MessageAllUsers("Set gravity to: " + value + "m/s²");
                        ScenePrivate.SetGravity(value);  // Assign the scene's gravity to the number
                    }
                }
                // help
                else if (cmds[1] == "help")
                {
                    agent.SendChat("/g\n-A command to set the gravity.\n-Accepts values from 0-49.\n************\nArguments:\n-help - displays this help\n-default - displays the default gravity\n-reset - resets to default gravity\n-planets - lists the planets available to set the gravity to\n************\nExamples:\n/g 3.14\n/g default\n/g planets\n************\nSource Code:  https://lunartiger.github.io/sansar/gravity");
                }
                // reset to default gravity
                else if (cmds[1] == "reset")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set gravity back to default. (" + default_gravity +"m/s²)");
                    ScenePrivate.SetGravity(default_gravity);
                }
                // display the default gravity
                else if (cmds[1] == "default")
                {
                    agent.SendChat("The default gravity for this place is " + default_gravity +"m/s²");
                }
                // Gravity of different planets
                else if (cmds[1] == "planets")
                {
                    agent.SendChat("The following planets' gravity can be set: \n-mercury \n-venus \n-earth, moon \n-mars, phobos, deimos \n-jupiter, europa, io, ganymede, callisto, amalthea \n-saturn, enceladus, titan, dione, mimas, tethys, iapetus, hyperon, rhea, janus \n-uranus, umbriel, oberon, titania, ariel, miranda, puck, desdemona \n-pluto, charon");
                }
                else if (cmds[1] == "mercury")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Mercury gravity. (3.7m/s²)");
                    ScenePrivate.SetGravity(3.7f);
                }
                else if (cmds[1] == "venus")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Venus gravity. (8.87m/s²)");
                    ScenePrivate.SetGravity(8.87f);
                }
                else if (cmds[1] == "earth")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Earth gravity. (9.81m/s²)");
                    ScenePrivate.SetGravity(9.81f);
                }
                else if (cmds[1] == "moon")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Moon gravity. (1.62m/s²)");
                    ScenePrivate.SetGravity(1.62f);
                }
                // mars&moons - phobos, deimos
                else if (cmds[1] == "mars")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Mars gravity. (3.71m/s²)");
                    ScenePrivate.SetGravity(3.71f);
                }
                else if (cmds[1] == "phobos")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Phobos gravity. (0.0057m/s²)");
                    ScenePrivate.SetGravity(0.0057f);
                }
                else if (cmds[1] == "deimos")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Deimos gravity. (0.003m/s²)");
                    ScenePrivate.SetGravity(0.003f);
                }
                // jupiter&moons - europa, io, ganymede, callisto, amalthea
                else if (cmds[1] == "jupiter")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Jupiter gravity. (24.79m/s²)");
                    ScenePrivate.SetGravity(24.79f);
                }
                else if (cmds[1] == "europa")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Europa gravity. (1.315m/s²)");
                    ScenePrivate.SetGravity(1.315f);
                }
                else if (cmds[1] == "io")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Io gravity. (1.796m/s²)");
                    ScenePrivate.SetGravity(1.796f);
                }
                else if (cmds[1] == "ganymede")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Ganymede gravity. (1.428m/s²)");
                    ScenePrivate.SetGravity(1.428f);
                }
                else if (cmds[1] == "callisto")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Callisto gravity. (1.236m/s²)");
                    ScenePrivate.SetGravity(1.236f);
                }
                else if (cmds[1] == "amalthea")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Amalthea gravity. (0.02m/s²)");
                    ScenePrivate.SetGravity(0.02f);
                }
                // saturn&moons - enceladus, titan, dione, mimas, tethys, iapetus, hyperon, rhea, janus
                else if (cmds[1] == "saturn")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Saturn gravity. (10.44m/s²)");
                    ScenePrivate.SetGravity(10.44f);
                }
                else if (cmds[1] == "enceladus")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Enceladus gravity. (0.113m/s²)");
                    ScenePrivate.SetGravity(0.113f);
                }
                else if (cmds[1] == "titan")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Titan gravity. (1.352m/s²)");
                    ScenePrivate.SetGravity(1.352f);
                }
                else if (cmds[1] == "dione")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Dione gravity. (0.232m/s²)");
                    ScenePrivate.SetGravity(0.232f);
                }
                else if (cmds[1] == "mimas")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Mimas gravity. (0.064m/s²)");
                    ScenePrivate.SetGravity(0.064f);
                }
                else if (cmds[1] == "tethys")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Tethys gravity. (0.145m/s²)");
                    ScenePrivate.SetGravity(0.145f);
                }
                else if (cmds[1] == "iapetus")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Iapetus gravity. (0.223m/s²)");
                    ScenePrivate.SetGravity(0.223f);
                }
                else if (cmds[1] == "hyperon")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Hyperon gravity. (0.02m/s²)");
                    ScenePrivate.SetGravity(0.02f);
                }
                else if (cmds[1] == "rhea")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Rhea gravity. (0.264m/s²)");
                    ScenePrivate.SetGravity(0.264f);
                }
                else if (cmds[1] == "janus")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Janus gravity. (0.016m/s²)");
                    ScenePrivate.SetGravity(0.016f);
                }
                // uranus&moons - umbriel, oberon, titania, ariel, miranda, puck, desdemona
                else if (cmds[1] == "uranus")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Uranus gravity. (8.87m/s²)");
                    ScenePrivate.SetGravity(8.87f);
                }
                else if (cmds[1] == "umbriel")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Umbriel gravity. (0.2m/s²)");
                    ScenePrivate.SetGravity(0.2f);
                }
                else if (cmds[1] == "oberon")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Oberon gravity. (0.346m/s²)");
                    ScenePrivate.SetGravity(0.346f);
                }
                else if (cmds[1] == "titania")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Titania gravity. (0.367m/s²)");
                    ScenePrivate.SetGravity(0.367f);
                }
                else if (cmds[1] == "ariel")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Ariel gravity. (0.269m/s²)");
                    ScenePrivate.SetGravity(0.269f);
                }
                else if (cmds[1] == "miranda")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Miranda gravity. (0.079m/s²)");
                    ScenePrivate.SetGravity(0.079f);
                }
                else if (cmds[1] == "puck")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Puck gravity. (0.028m/s²)");
                    ScenePrivate.SetGravity(0.028f);
                }
                else if (cmds[1] == "desdemona")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Desdemona gravity. (0.011m/s²)");
                    ScenePrivate.SetGravity(0.011f);
                }
                // pluto&charon
                else if (cmds[1] == "pluto")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Pluto gravity. (0.62m/s²)");
                    ScenePrivate.SetGravity(0.62f);
                }
                else if (cmds[1] == "charon")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Charon gravity. (0.288m/s²)");
                    ScenePrivate.SetGravity(0.288f);
                }
                // command unknown
                else
                {
                    agent.SendChat("¯\\_(ツ)_/¯ huh");
                }
            }
            // If no additional parameter was specified, print out the current gravity
            else
            {
                agent.SendChat("Gravity is set to: " + ScenePrivate.GetGravity() + "m/s²");
            }
        }
        // help
        else if (cmds[0] == "/help")
        {
            agent.SendChat("\n************\n/g\n-A command to set the gravity.\n-Accepts values from 0-49.\n************\nArguments:\n-help - displays this help\n-default - displays the default gravity\n-reset - resets to default gravity\n-planets - lists the planets available to set the gravity to\n************\nExamples:\n/g 3.14\n/g default\n/g planets\n************");
        }
    }
}
