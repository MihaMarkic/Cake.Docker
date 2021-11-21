using System;
using System.IO;

namespace SettingsGenerator
{
    partial class Program
    {
        const string root = @"D:\GitProjects\Righthand\Cake\Cake.Docker\src\Cake.Docker\";

        public static void Main(string[] args)
        {
            string root = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), @"../../../../../Cake.Docker");
            var processor = new Processor(root);
            foreach (var input in inputs)
            {
                Console.WriteLine($"Processing ${input.Path}");
                processor.ProcessCommandAsync(input.Path, input.GoCommandName, input.OriginalCommandName,
                    input.InputTypeOptions, input.Options).Wait();
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
