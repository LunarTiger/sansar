/*******************
 *   Version 0.4   *
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
                    ScenePrivate.Chat.MessageAllUsers("Set gravity to: " + value + "m/s");
                    ScenePrivate.SetGravity(value);  // Assign the scene's gravity to the number
                }
                // Otherwise reset the scene to default gravity specified
                else if (cmds[1] == "default")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set gravity back to default. (" + default_gravity +"m/s)");
                    ScenePrivate.SetGravity(default_gravity);
                }
                // Gravity of different planets
                else if (cmds[1] == "planets")
                {
                    ScenePrivate.Chat.MessageAllUsers("The following planets' gravity can be set: mercury, venus, earth, moon, mars, jupiter, saturn, uranus, pluto");
                }
                else if (cmds[1] == "mercury")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Mercury gravity. (3.7m/s)");
                    ScenePrivate.SetGravity(3.7f);
                }
                else if (cmds[1] == "venus")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Venus gravity. (8.87m/s)");
                    ScenePrivate.SetGravity(8.87f);
                }
                else if (cmds[1] == "earth")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Earth gravity. (9.81m/s)");
                    ScenePrivate.SetGravity(9.81f);
                }
                else if (cmds[1] == "moon")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Moon gravity. (1.62m/s)");
                    ScenePrivate.SetGravity(1.62f);
                }
                else if (cmds[1] == "mars")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Mars gravity. (3.71m/s)");
                    ScenePrivate.SetGravity(3.71f);
                }
                else if (cmds[1] == "jupiter")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Jupiter gravity. (24.79m/s)");
                    ScenePrivate.SetGravity(24.79f);
                }
                else if (cmds[1] == "saturn")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Saturn gravity. (10.44m/s)");
                    ScenePrivate.SetGravity(10.44f);
                }
                else if (cmds[1] == "uranus")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Uranus gravity. (8.87m/s)");
                    ScenePrivate.SetGravity(8.87f);
                }
                else if (cmds[1] == "pluto")
                {
                    ScenePrivate.Chat.MessageAllUsers("Set Pluto gravity. (0.62m/s)");
                    ScenePrivate.SetGravity(0.62f);
                }
            }
            // If no additional parameter was specified, print out the scene's current gravity
            else
            {
                ScenePrivate.Chat.MessageAllUsers("Gravity is set to: " + ScenePrivate.GetGravity() + "m/s");
            }
        }
    }
}
