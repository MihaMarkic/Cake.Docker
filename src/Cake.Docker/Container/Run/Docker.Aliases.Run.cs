using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with run command.
    partial class DockerAliases
    {

        /// <summary>
        /// Creates a new container using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="image">The image.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="command">The command.</param>
        /// <returns>Container ID or null</returns>
        /// <remarks>Return value is first line from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static string? DockerRun(this ICakeContext context, string image, string command, params string[] args)
        {
            return DockerRun(context, new DockerContainerRunSettings(), image, command, args);
        }

        /// <summary>
        /// Creates a new container given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="image">The image.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="command">The command.</param>
        /// <returns>Container ID or null</returns>
        /// <remarks>Return value is first line from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static string? DockerRun(this ICakeContext context, DockerContainerRunSettings? settings, string image, string command, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (string.IsNullOrEmpty(image))
            {
                throw new ArgumentNullException(nameof(image));
            }
            var runner = new GenericDockerRunner<DockerContainerRunSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { image };
            if (!string.IsNullOrEmpty(command))
            {
                arguments.Add(command);
                if (args.Length > 0)
                {
                    arguments.AddRange(args);
                }
            }
            return runner.RunWithResult("run", settings ?? new DockerContainerRunSettings(), r => r.ToArray(), arguments.ToArray()).FirstOrDefault();
        }

        /// <summary>
        /// Creates a new container using default settings. and doesn't return the output like 
        /// <see cref="DockerRun(ICakeContext, string, string, string[])"/> does.
        /// This way one can capture stdout.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="image">The image.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="command">The command.</param>
        [CakeMethodAlias]
        public static void DockerRunWithoutResult(this ICakeContext context, string image, string command, params string[] args)
        {
            DockerRunWithoutResult(context, new DockerContainerRunSettings(), image, command, args);
        }

        /// <summary>
        /// Creates a new container given <paramref name="settings"/> and doesn't return the output like 
        /// <see cref="DockerRun(ICakeContext, DockerContainerRunSettings, string, string, string[])"/> does.
        /// This way one can capture stdout.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="image">The image.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="command">The command.</param>
        [CakeMethodAlias]
        public static void DockerRunWithoutResult(this ICakeContext context, DockerContainerRunSettings? settings, string image, string command, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (string.IsNullOrEmpty(image))
            {
                throw new ArgumentNullException(nameof(image));
            }
            var runner = new GenericDockerRunner<DockerContainerRunSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { image };
            if (!string.IsNullOrEmpty(command))
            {
                arguments.Add(command);
                if (args.Length > 0)
                {
                    arguments.AddRange(args);
                }
            }
            runner.Run("run", settings ?? new DockerContainerRunSettings(), arguments.ToArray());
        }
    }
}
