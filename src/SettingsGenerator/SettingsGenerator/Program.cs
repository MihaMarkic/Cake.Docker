using System;
using System.IO;
using System.Threading.Tasks;

namespace SettingsGenerator
{
    class Program
    {
        const string root = @"D:\GitProjects\Righthand\Cake\Cake.Docker\src\Cake.Docker\";
        static Input[] inputs = new Input[] {
    new Input(Path.Combine("Image", "Build")),
    new Input(Path.Combine("Image", "Load")),
    new Input(Path.Combine("Image", "Pull")),
    new Input(Path.Combine("Image", "Push")),
    new Input(Path.Combine("Image", "Remove")),
    new Input(Path.Combine("Image", "Save")),
    new Input(Path.Combine("Image", "Tag")),
    new Input(Path.Combine("Container", "Cp"), "Copy"),
    new Input(Path.Combine("Container", "Create"), additionalOptionsUrl: "opts", additionalOptionsTypeName: "container"),
    new Input(Path.Combine("Container", "Exec")),
    new Input(Path.Combine("Container", "Rm")),
    new Input(Path.Combine("Container", "Run"), additionalOptionsUrl: "opts", additionalOptionsTypeName: "container"),
    new Input(Path.Combine("Container", "Stop")),
};

        public static void Main(string[] args)
        {
            var processor = new Processor(root);
            foreach (var input in inputs)
            {
                Console.WriteLine($"Processing ${input.Path}");
                processor.ProcessCommandAsync(input.Path, input.GoCommandName, input.OriginalCommandName,
                    input.AdditionalOptionsUrl, input.AdditionalOptionsTypeName).Wait();
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
