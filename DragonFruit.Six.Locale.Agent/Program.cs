// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under MIT. Please refer to the LICENSE file for more info

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using DragonFruit.Six.Locale.Agent.Crowdin;
using DragonFruit.Six.Locale.Agent.Crowdin.Requests;
using DragonFruit.Six.Locale.Agent.Project;

namespace DragonFruit.Six.Locale.Agent
{
    internal static class Program
    {
        private static readonly string LocaleBase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "DragonFruit.Six.Locale",
            "DragonFruit.Six.Locale");

        private static readonly CrowdinApiClient Client = new CrowdinApiClient();

        private static void Main(string[] args)
        {
            ConsoleUtils.WriteLine("Dragon6 Locale Transfer Agent v0.1\n", ConsoleColor.Magenta);

            var loginInfo = Environment.GetEnvironmentVariable("dragon6_crowdin_auth", EnvironmentVariableTarget.User);

            if (string.IsNullOrEmpty(loginInfo))
            {
                ConsoleUtils.WriteLine("Failed to find Crowdin Auth Data", ConsoleColor.Red);
                Environment.Exit(-1);
            }

            Client.Login = loginInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

            if (Client.Login.Length != 2)
            {
                ConsoleUtils.WriteLine($"Expected 2 segments of the login string, but found {Client.Login.Length}", ConsoleColor.Red);
                Environment.Exit(-1);
            }

            ConsoleUtils.Write("Requesting Project Build... ", ConsoleColor.Cyan);
            var buildResult = Client.Perform<CrowdinProjectBuildResult>(new CrowdinProjectBuildRequest());
            ConsoleUtils.WriteLine(buildResult.Status.ToString(), ConsoleColor.Green);

            ConsoleUtils.Write("Requesting Project Files...", ConsoleColor.Cyan);
            var downloadRequest = new CrowdinProjectDownloadRequest();
            Client.Perform<CrowdinProjectErrorResult>(downloadRequest, true, (progress, total) =>
            {
                if (!total.HasValue)
                {
                    return;
                }

                var percentage = Convert.ToSingle(progress) / Convert.ToSingle(total.Value) * 100;

                ConsoleUtils.Write("\rRequesting Project Files...", ConsoleColor.Cyan);
                ConsoleUtils.Write($"{percentage:F2}%", ConsoleColor.DarkGreen);
            });

            OperationComplete();

            ConsoleUtils.Write("Extracting Files...", ConsoleColor.Cyan);

            var targetDir = Path.Combine(Path.GetTempPath(),
                Path.GetFileNameWithoutExtension(downloadRequest.Destination)!);
            ZipFile.ExtractToDirectory(downloadRequest.Destination, targetDir);

            OperationComplete();

            foreach (var locale in ProjectInfo.SupportedLocales)
            {
                string localeOverride = null;
                ConsoleUtils.Write($"Processing {locale} files".PadRight(20), ConsoleColor.Cyan);

                var folder = Path.Combine(targetDir, locale);

                if (!Directory.Exists(folder))
                {
                    ConsoleUtils.WriteLine(" Failed - folder not present", ConsoleColor.DarkRed);
                    continue;
                }

                // decide if the files needs renaming
                if (ProjectInfo.LocaleMapping.ContainsKey(locale))
                {
                    localeOverride = ProjectInfo.LocaleMapping[locale];

                    foreach (var file in Directory.GetFiles(folder, "*.resx", SearchOption.AllDirectories))
                    {
                        var newFileName = file.Replace($".{locale}", $".{localeOverride}");
                        File.Move(file, newFileName);
                    }
                }

                foreach (var file in Directory.GetFiles(folder, "*.resx", SearchOption.AllDirectories))
                {
                    // we're assuming default locale (english) isn't included here...
                    var fileNameSegments = Path.GetFileNameWithoutExtension(file).Split('.');

                    if (fileNameSegments.Length == 1)
                    {
                        continue;
                    }

                    var fileName = string.Join('.', fileNameSegments.Take(fileNameSegments.Length - 1));

                    var destination = ProjectFiles.PathMapping.ContainsKey(fileName)
                        ? Path.Combine(new[] { LocaleBase }.Concat(ProjectFiles.PathMapping[fileName]).ToArray())
                        : LocaleBase;

                    File.Copy(file, Path.Combine(destination, $"{fileName}.{localeOverride ?? locale}.resx"), true);
                }

                OperationComplete();
            }

            ConsoleUtils.WriteLine("\nFile transfer Complete", ConsoleColor.Green);
        }

        private static void OperationComplete() => ConsoleUtils.WriteLine(" Complete", ConsoleColor.Green);
    }
}
