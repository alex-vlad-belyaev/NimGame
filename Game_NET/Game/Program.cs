// See https://aka.ms/new-console-template for more information

using BundlesEngine;
using System;
using System.Security.Cryptography;
using System.Text.Json;

bool IsDebug = false;
Console.WriteLine("Shall I start in DEBUG mode?");

Console.WriteLine("Input execution mode (2-3)");
var modeNumber = Console.ReadLine();
var modeNumberInt = int.Parse(modeNumber);
GameModes mode;
switch (modeNumberInt)
{
    //case 1:
    //    mode = GameModes.ManVsMan;
    //    break;
    case 2:
        mode = GameModes.ManVsProgram;
        break;
    case 3:
        mode = GameModes.ProgramVsProgram;
        break;
    default:
        throw new Exception("mode was not selected");
}

GameTriplex[] triplexes = null;

triplexes = await Engine.ReadExistingTriplexes(triplexes);

GameTriplex newTriplexToWrite = Engine.PlayGame(triplexes, mode);

await Engine.WriteWinTriplexes(triplexes, newTriplexToWrite);