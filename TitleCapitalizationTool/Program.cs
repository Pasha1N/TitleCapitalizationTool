using System;

using TitleCapitalizationTool.String;

namespace TitleCapitalizationTool
{
    internal class Program
    {
        static void Main(string[] arguments)
        {
            int y = Console.CursorLeft; 
            int x = Console.CursorTop;

            bool shouldWork = true;
            while (shouldWork)
            {
                if (arguments.Length != 0)
                {
                    StringCorrection stringCorrection = new StringCorrection();

                    for (int i = 0; i < arguments.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        stringCorrection.SetString(arguments[i]);
                        Console.WriteLine("Enter title to capitalize: " + arguments[i]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Capitalized title: " + stringCorrection.StringCorrectioN());
                        Console.ResetColor();
                    }
                    shouldWork = false;
                }
                else
                {
                    string stringForCorrection = null;
                    bool result = true;
                    while (result)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Enter title to capitalize: ");
                        stringForCorrection = Console.ReadLine();

                        if (!string.IsNullOrEmpty(stringForCorrection))
                        {
                            result = false;
                        }
                        else
                        {
                            Console.SetCursorPosition(y, x);
                        }

                    }
                    StringCorrection stringCorrection = new StringCorrection(stringForCorrection);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Capitalized title: " + stringCorrection.StringCorrectioN());

                    y = Console.CursorLeft;
                    x = Console.CursorTop;
                    Console.SetCursorPosition(y, x);
                }
            }
        }
    }
}