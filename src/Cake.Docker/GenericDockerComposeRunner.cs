using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Docker
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public class GenericDockerComposeRunner<TSettings> : DockerComposeTool<TSettings>
        where TSettings : AutoToolSettings, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="processRunner"></param>
        /// <param name="tools"></param>
        public GenericDockerComposeRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs given <paramref name="command"/> using given <paramref name=" settings"/> and <paramref name="additional"/>.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="settings">The settings.</param>
        /// <param name="additional"></param>
        public void Run(string command, TSettings settings, string[] additional)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command));
            }

            ArgumentNullException.ThrowIfNull(settings);
            ArgumentNullException.ThrowIfNull(additional);

            Run(settings, GetArguments(command, settings, additional));
        }

        private static ProcessArgumentBuilder GetArguments(string command, TSettings settings, string[] containers)
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll(command, settings, containers);
            return builder;
        }

        /// <summary>
        /// Runs a command and returns a result based on processed output.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="settings">The settings.</param>
        /// <param name="processOutput"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public T[] RunWithResult<T>(string command, TSettings settings,
            Func<IEnumerable<string>, T[]> processOutput,
            params string[] arguments)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command));
            }

            ArgumentNullException.ThrowIfNull(settings);
            ArgumentNullException.ThrowIfNull(processOutput);

            T[] result = [];
            Run(settings, GetArguments(command, settings, arguments),
                new ProcessSettings { RedirectStandardOutput = true },
                proc =>
                {
                    result = processOutput(proc.GetStandardOutput());
                });
            return result;
        }
    }
}
