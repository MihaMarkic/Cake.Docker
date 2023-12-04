using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with network remove command.
    partial class DockerAliases
    {
        /// <summary>
        /// Removes a network.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="network">The network.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerNetworkRemove(this ICakeContext context, string network, params string[] args)
        {
            context.DockerNetworkRemove(new string[] { network }, args);
        }
        /// <summary>
        /// Removes networks.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="network">The network.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerNetworkRemove(this ICakeContext context, string[] network, params string[] args)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            if (network == null || network.Any(n => string.IsNullOrEmpty(n)))
            {
                throw new ArgumentNullException(nameof(network));
            }
            var runner = new GenericDockerRunner<EmptySettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string>(network);
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("network rm", new EmptySettings(), arguments.ToArray());
        }
    }
}
