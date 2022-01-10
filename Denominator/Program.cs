using Fclp;
using System;
using Denominator.Service;

namespace Denominator
{
    class Program
    {
        static void Main(string[] args)
        {
            var denominatorService = new DenominatorService();

            var result = denominatorService.GetChange(ConfigureArguments(args));

            Console.WriteLine(result);

            Console.ReadLine();
        }

        private static ApplicationArguments ConfigureArguments(string[] args)
        {
            var p = new FluentCommandLineParser<ApplicationArguments>();

            p.Setup(arg => arg.Cost)
                .As('c', "cost")
                .Required();

            p.Setup(arg => arg.Tendered)
                .As('t', "tendered")
                .Required();

            p.SetupHelp("?", "help")
                .Callback(text => Console.WriteLine(text));

            var parsed = p.Parse(args);

            return p.Object;
        }
    }
}
