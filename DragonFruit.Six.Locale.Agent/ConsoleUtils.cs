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