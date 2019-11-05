using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using Cake.Core.Tooling;

namespace Cake.Docker
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public class GenericDockerRunner<TSettings> : DockerTool<TSettings>
        where TSettings: AutoToolSettings, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <param name="processRunner"></param>
        /// <param name="tools"></param>
        public GenericDockerRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools) 
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
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            if (additional == null)
            {
                throw new ArgumentNullException(nameof(additional));
            }
            // checks whether method is experimental based on ExperimentalAttribute decoration
            if (IsExperimental)
            {
                // when experimental, applies proper environmental variable to runner process
                var processSettings = CreateExperimentalProcessSettings();
                Run(settings, GetArguments(command, settings, additional), processSettings, postAction: null);
            }
            else
            {
                Run(settings, GetArguments(command, settings, additional));
            }
        }
        static bool IsExperimental => typeof(TSettings).GetCustomAttributes(typeof(ExperimentalAttribute), inherit: true)?.Length > 0;
        static ProcessSettings CreateExperimentalProcessSettings()
        {
            var processSettings = new ProcessSettings();
            processSettings.EnvironmentVariables = new Dictionary<string, string> { { "DOCKER_CLI_EXPERIMENTAL", "enabled" } };
            return processSettings;
        }
        private ProcessArgumentBuilder GetArguments(string command, TSettings settings, string[] additional)
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll(command, settings, additional);
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
            ProcessSettings processSettings = IsExperimental ? CreateExperimentalProcessSettings(): new ProcessSettings();
            processSettings.RedirectStandardOutput = true;
            Run(settings, GetArguments(command, settings, arguments),
                processSettings, 
                proc => {
                    result = processOutput(proc.GetStandardOutput());
                });
            return result;
        }
    }
}
