namespace SignalRChat
{
    public class ProgramBase
    {

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<SignalRChat>();
                });
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}