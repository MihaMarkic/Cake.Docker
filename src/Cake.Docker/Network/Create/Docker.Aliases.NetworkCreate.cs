using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    // Contains functionality for working with network create command.
    partial class DockerAliases
    {
        /// <summary>
        /// Creates a network using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerNetworkCreate(this ICakeContext context, params string[] args)
        {
            DockerNetworkCreate(context, new DockerNetworkCreateSettings(), args);
        }

        /// <summary>
        /// Creates a network given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerNetworkCreate(this ICakeContext context, DockerNetworkCreateSettings? settings, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerNetworkCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string>();
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("network create", settings ?? new DockerNetworkCreateSettings(), arguments.ToArray());
        }
    }
}
