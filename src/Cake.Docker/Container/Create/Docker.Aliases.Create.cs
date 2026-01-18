using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with create command.
    partial class DockerAliases
    {

        /// <summary>
        /// Creates a new container using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="image">The image.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="command">The command.</param>
        /// <returns>container ID or null</returns>
        [CakeMethodAlias]
        public static string? DockerCreate(this ICakeContext context, string image, string command, params string[] args)
        {
            return DockerCreate(context, new DockerContainerCreateSettings(), image, command, args);
        }

        /// <summary>
        /// Creates a new container given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="image">The image.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="command">The command.</param>
        /// <returns>container ID or null</returns>
        [CakeMethodAlias]
        public static string? DockerCreate(this ICakeContext context, DockerContainerCreateSettings? settings, string image, string command, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (string.IsNullOrEmpty(image))
            {
                throw new ArgumentNullException(nameof(image));
            }
            var runner = new GenericDockerRunner<DockerContainerCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { image };
            if (!string.IsNullOrEmpty(command))
            {
                arguments.Add(command);
                if (args.Length > 0)
                {
                    arguments.AddRange(args);
                }
            }

            return runner.RunWithResult("create", settings ?? new DockerContainerCreateSettings(), r => r.ToArray(), arguments.ToArray())
                .FirstOrDefault();
        }

    }
}
