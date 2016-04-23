using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    public class GenericDockerRunner<TSettings> : DockerTool<TSettings>
        where TSettings: AutoToolSettings, new()
    {
        public GenericDockerRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) 
            : base(fileSystem, environment, processRunner, globber)
        {
        }

        public void Run(string command, TSettings settings, string[] containers)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            if (containers == null || containers.Length == 0)
            {
                throw new ArgumentNullException("containers");
            }
            Run(settings, GetArguments(command, settings, containers));
        }

        private ProcessArgumentBuilder GetArguments(string command, TSettings settings, string[] containers)
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll(command, settings, containers);
            return builder;
        }

        public T[] RunWithResult<T>(string command, TSettings settings, 
            Func<IEnumerable<string>, T[]> processOutput,
            params string[] arguments)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            if (processOutput == null)
            {
                throw new ArgumentNullException("processOutput");
            }
            T[] result = new T[0];
            Run(settings, GetArguments(command, settings, arguments), 
                new ProcessSettings { RedirectStandardOutput = true }, 
                proc => {
                    result = processOutput(proc.GetStandardOutput());
                });
            return result;
        }
    }
}
