using System;
using System.IO;
using System.Threading.Tasks;

namespace SettingsGenerator
{
    class Program
    {
        const string root = @"D:\GitProjects\Righthand\Cake\Cake.Docker\src\Cake.Docker\";
        static Input[] inputs = new Input[] {
    //new Input(Path.Combine("Image", "Build")),
    //new Input(Path.Combine("Image", "Load")),
    //new Input(Path.Combine("Image", "Pull")),
    //new Input(Path.Combine("Image", "Push")),
    //new Input(Path.Combine("Image", "Remove")),
    //new Input(Path.Combine("Image", "Save")),
    //new Input(Path.Combine("Image", "Tag")),
    //new Input(Path.Combine("Container", "Cp"), "Copy"),
    //new Input(Path.Combine("Container", "Create"), additionalOptionsUrl: "opts", additionalOptionsTypeName: "container"),
    //new Input(Path.Combine("Container", "Exec")),
    //new Input(Path.Combine("Container", "Rm")),
    //new Input(Path.Combine("Container", "Run"), additionalOptionsUrl: "opts", additionalOptionsTypeName: "container"),
    //new Input(Path.Combine("Container", "Stop")),
    //new Input(Path.Combine("Registry", "Login")),
    //new Input(Path.Combine("Swarm", "Init"), inputTypeOptions: InputTypeOptions.Swarm),
    //new Input(Path.Combine("Swarm", "Join"), inputTypeOptions: InputTypeOptions.SwarmConsts),
    //new Input(Path.Combine("Swarm", "Leave")),
    new Input(Path.Combine("Swarm", "Update"), inputTypeOptions: InputTypeOptions.Swarm),
};

        public static void Main(string[] args)
        {
            var processor = new Processor(root);
            foreach (var input in inputs)
            {
                Console.WriteLine($"Processing ${input.Path}");
                processor.ProcessCommandAsync(input.Path, input.GoCommandName, input.OriginalCommandName,
                    input.InputTypeOptions).Wait();
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
