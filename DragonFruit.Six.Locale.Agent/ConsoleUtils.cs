// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under MIT. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Locale.Agent
{
    internal static class ConsoleUtils
    {
        public static void WriteLine(string text, ConsoleColor color = default) => Write($"{text}\n", color);

        public static void Write(string text, ConsoleColor color = default)
        {
            var oldColour = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = oldColour;
        }
    }
}
