using DbUp;
using System;
using System.Configuration;
using System.Reflection;
namespace Application.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = ConfigurationManager.AppSettings["DbConnectionString"];
            //args.FirstOrDefault()
            //?? "Server=(local)\\SqlExpress; Database=MyApp; Trusted_connection=true";

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
#if DEBUG
            Console.ReadLine();
#endif
            return 0;
        }
    }
}
