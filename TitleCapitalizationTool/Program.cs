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
                        stringCorrection.SetString(arguments[i]);

                        Console.Write("Enter title to capitalize: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine( arguments[i]);
                        Console.ResetColor();

                        Console.WriteLine("Capitalized title: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine( stringCorrection.Correction());
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    shouldWork = false;
                }
                else
                {
                    string stringForCorrection = null;
                    bool askAgain = true;
                    while (askAgain)
                    {
                        Console.Write("Enter title to capitalize: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        stringForCorrection = Console.ReadLine();
                        Console.ResetColor();

                        if (!string.IsNullOrEmpty(stringForCorrection))
                        {
                            askAgain = false;
                        }
                        else
                        {
                            Console.SetCursorPosition(y, x);
                        }

                    }
                    StringCorrection stringCorrection = new StringCorrection(stringForCorrection);
                    
                    Console.Write("Capitalized title: " );
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(stringCorrection.Correction());
                    Console.ResetColor();
                    Console.WriteLine();

                    y = Console.CursorLeft;
                    x = Console.CursorTop;
                    Console.SetCursorPosition(y, x);
                }
            }
        }
    }
}