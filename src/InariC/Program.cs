using CommandLine;
using Inari;
using System;
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

        [Verb("auth",HelpText = "Begins a new session with Kitsu.IO. Needed for commands that require you to be logged in.", Hidden = false)]
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

            Console.Title = "Inari for Kitsu.IO";

            Console.WriteLine("Inari for Kitsu.IO (v{0})", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            if (kitsuSession != null)
            {
                Console.WriteLine("Logged in as: {0}", kitsuSession.UserName);
            }

            TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();

            Parser.Default.ParseArguments<AuthOptions, TrendingOptions>(args)
                .WithParsed<AuthOptions>(opts => AuthenicationCommand(opts, taskCompletionSource))
                .WithParsed<TrendingOptions>(opts => TrendingCommand(opts, taskCompletionSource))
                .WithNotParsed(errs =>
                {
                    taskCompletionSource.SetResult(null);
                });

            await taskCompletionSource.Task;
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
            if (trendingOptions.Anime)
            {
                await KitsuAPI.GetTrendingAnimeAsync(kitsuSession);
            }
            else if (trendingOptions.Drama)
            {

            }
            else if (trendingOptions.Manga)
            {

            }
            else
            {

            }

            taskCompletionSource.SetResult(null);
        }
    }
}
