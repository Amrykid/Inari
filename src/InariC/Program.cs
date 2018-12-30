using CommandLine;
using Inari;
using Inari.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace InariC
{
    class Program
    {
        private static string SessionFileName = null;
        private static string AppDataFolder = null;
        private static KitsuSession kitsuSession = null;

        [Verb("auth", HelpText = "Begins a new session with Kitsu.IO. Needed for commands that require you to be logged in.", Hidden = false)]
        public class AuthOptions
        {
            [Value(0, Required = true, HelpText = "Username to authenticate with.", MetaName = "username")]
            public string Username { get; set; }
            [Value(1, Required = true, HelpText = "Password to authenticate with.", MetaName = "password")]
            public string Password { get; set; }
        }

        [Verb("tr", HelpText = "Gets which anime|dramas|manga are trending.")]
        public class TrendingOptions
        {
            [Option('a')]
            public bool Anime { get; set; }
            [Option('d')]
            public bool Drama { get; set; }
            [Option('m')]
            public bool Manga { get; set; }
        }

        [Verb("get", HelpText = "Retrieves an anime|drama|manga by ID from Kitsu.IO")]
        public class GetOptions
        {
            [Option('a', SetName = "type", HelpText = "Retrieve an anime from Kitsu.")]
            public bool Anime { get; set; }
            [Option('d', SetName = "type", HelpText = "Retrieve a drama from Kitsu.")]
            public bool Drama { get; set; }
            [Option('m', SetName = "type", HelpText = "Retrieve a manga from Kitsu.")]
            public bool Manga { get; set; }


            [Value(1, Required = true, HelpText = "The ID of the media entity to be retrieved.", MetaName = "ID")]
            public int Id { get; set; }
        }

        static void Main(string[] args)
        {
            AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\InariC\\";
            SessionFileName = AppDataFolder + "Session.json";
            if (!Directory.Exists(AppDataFolder)) Directory.CreateDirectory(AppDataFolder);

            RunAsync(args).Wait();
        }

        private static async System.Threading.Tasks.Task RunAsync(string[] args)
        {
            if (File.Exists(SessionFileName)) kitsuSession = await KitsuSessionManager.RestoreSessionFromFileAsync(SessionFileName);

            Console.Title = string.Format("Inari for Kitsu.IO (v{0})", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            if (kitsuSession != null)
            {
                Console.Title += string.Format(" | Logged in as: {0}", kitsuSession.UserName);
            }

            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();

            Parser.Default.ParseArguments<AuthOptions, TrendingOptions, GetOptions>(args)
                .WithParsed<AuthOptions>(opts => AuthenicationCommand(opts, taskCompletionSource))
                .WithParsed<TrendingOptions>(opts => TrendingCommand(opts, taskCompletionSource))
                .WithParsed<GetOptions>(opts => GetCommand(opts, taskCompletionSource))
                .WithNotParsed(errs =>
                {
                    taskCompletionSource.SetResult(null);
                });

            await taskCompletionSource.Task;
        }

        private static async void GetCommand(GetOptions authOptions, TaskCompletionSource<object> taskCompletionSource)
        {
            try
            {
                IMedia media = null;

                if (authOptions.Anime)
                {
                    media = KitsuAPI.GetAnimeByIDAsync(authOptions.Id);
                }
                else if (authOptions.Manga)
                {
                    media = KitsuAPI.GetMangaByIDAsync(authOptions.Id);
                }

                taskCompletionSource.SetResult(media);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error occurred.");
                Console.Error.WriteLine(ex.ToString());

                taskCompletionSource.SetException(ex);
            }
        }

        private static async void AuthenicationCommand(AuthOptions authOptions, TaskCompletionSource<object> taskCompletionSource)
        {
            try
            {
                KitsuSession session = await KitsuSessionManager.BeginSession(authOptions.Username, authOptions.Password);

                await KitsuSessionManager.PersistSessionToFileAsync(session, SessionFileName);

                Console.WriteLine("Logged in as: {0}", session.UserName);

                taskCompletionSource.SetResult(session);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unable to log in.");
                Console.Error.WriteLine(ex.ToString());

                taskCompletionSource.SetException(ex);
            }
        }

        private static async void TrendingCommand(TrendingOptions trendingOptions, TaskCompletionSource<object> taskCompletionSource)
        {
            IEnumerable<ITrendingMedia> trendingMedia = null;
            if (trendingOptions.Anime)
            {
                trendingMedia = await KitsuAPI.GetTrendingAnimeAsync(kitsuSession);
            }
            else if (trendingOptions.Drama)
            {
                //not implemented
                trendingMedia = new ITrendingMedia[] { };
            }
            else if (trendingOptions.Manga)
            {
                trendingMedia = await KitsuAPI.GetTrendingMangaAsync(kitsuSession);
            }
            else
            {
                taskCompletionSource.SetResult(null);
                return;
            }

            foreach (var item in trendingMedia)
            {
                Console.WriteLine("-");
                Console.WriteLine("Title: {0}", item.Attributes.CanonicalTitle);
                Console.WriteLine("ID: {0}", item.Id);
                Console.WriteLine("--Synopsis:");
                Console.WriteLine(item.Attributes.Synopsis);
                Console.WriteLine("--");
                Console.WriteLine("-");
            }

            taskCompletionSource.SetResult(null);
        }
    }
}
