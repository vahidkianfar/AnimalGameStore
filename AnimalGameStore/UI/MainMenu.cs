﻿using Spectre.Console;
namespace AnimalGameStore.UI;

public static class MainMenu
{
    public static async Task Start()
    {
        AnsiConsole.Progress()
            .Start(ctx => 
            {
                var task1 = ctx.AddTask("[blue]Loading[/]");
                while(!ctx.IsFinished)
                    task1.Increment(0.00007);
            });
        while (true)
        {
            Console.Clear();
            var selectInstructionOption =
                ConsoleHelper.MultipleChoice(true, "1. Art", "2. Fossil",
                    "3. Exit");
            switch (selectInstructionOption)
            {
                case 0:
                    await ArtMenu.Start();
                    break;
                case 1:
                    await FossilMenu.Start();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}