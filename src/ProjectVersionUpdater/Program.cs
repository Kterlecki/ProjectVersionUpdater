using ProjectVersionUpdater;
using System;

var path = @"./src/ProjectVersionUpdater/AppVersionNumber.txt";
var versionFromFile = File.ReadAllText(path);
var versionService = new VersionService(path);
if (args.Length == 0)
{
    throw new Exception("Missing argument for which version Update to make");
}

var userInput = args[0];


if (userInput.ToLower() == "bugfix")
{
    versionService.UpdateMinorVersion(versionFromFile);
}
else if (userInput.ToLower() == "feature")
{
    versionService.UpdateMajorVersion(versionFromFile);
}
else
{
    Console.WriteLine("Argument provided doesn't match required values");
}

