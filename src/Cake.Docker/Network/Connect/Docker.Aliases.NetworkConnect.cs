using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    // Contains functionality for working with network connect command.
    partial class DockerAliases
    {
        /// <summary>
        /// Connects a container to a network using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="network">The network.</param>
        /// <param name="container">The container.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerNetworkConnect(this ICakeContext context, string network, string container, params string[] args)
        {
            DockerNetworkConnect(context, new DockerNetworkConnectSettings(), network, container, args);
        }

        /// <summary>
        /// Connects a container to a network given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="network">The network.</param>
        /// <param name="container">The container.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerNetworkConnect(this ICakeContext context, DockerNetworkConnectSettings? settings, string network, string container, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (string.IsNullOrEmpty(network))
            {
                throw new ArgumentNullException(nameof(network));
            }
            if (string.IsNullOrEmpty(container))
            {
                throw new ArgumentNullException(nameof(container));
            }
            var runner = new GenericDockerRunner<DockerNetworkConnectSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { network, container };
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("network connect", settings ?? new DockerNetworkConnectSettings(), arguments.ToArray());
        }
    }
}
