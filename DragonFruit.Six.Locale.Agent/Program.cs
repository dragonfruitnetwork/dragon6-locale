using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using DragonFruit.Common.Data;
using DragonFruit.Six.Locale.Agent.Crowdin;
using DragonFruit.Six.Locale.Agent.Crowdin.Requests;
using DragonFruit.Six.Locale.Agent.Project;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Locale.Agent
{
    class Program
    {
        private static readonly string LocaleBase =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos",
                "DragonFruit.Six.Locale", "DragonFruit.Six.Locale");

        private static readonly CrowdinApiClient Client = new CrowdinApiClient();

        static void Main(string[] args)
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
                ConsoleUtils.WriteLine($"Expected 2 segments of the login string, but found {Client.Login.Length}",
                    ConsoleColor.Red);
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
                ConsoleUtils.Write($"Processing {locale} files", ConsoleColor.Cyan);

                var folder = Path.Combine(targetDir, locale);

                if (!Directory.Exists(folder))
                {
                    ConsoleUtils.WriteLine(" Failed - folder not present", ConsoleColor.DarkRed);
                    continue;
                }

                // decide if the files needs renaming
                if (ProjectInfo.LocaleMapping.ContainsKey(locale))
                {
                    foreach (var file in Directory.GetFiles(folder, "*.resx", SearchOption.AllDirectories))
                    {
                        var newFileName = file.Replace($".{locale}", $".{ProjectInfo.LocaleMapping[locale]}");
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
                        ? Path.Combine(new[] {LocaleBase}.Concat(ProjectFiles.PathMapping[fileName]).ToArray())
                        : LocaleBase;

                    File.Copy(file, Path.Combine(destination, $"{fileName}.{locale}.resx"), true);
                }

                OperationComplete();
            }
        }

        private static void OperationComplete() => ConsoleUtils.WriteLine(" Complete", ConsoleColor.Green);
    }
}