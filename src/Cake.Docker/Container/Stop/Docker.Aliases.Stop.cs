﻿using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with stop command.
    partial class DockerAliases
    {
        /// <summary>
        /// Stops an array of <paramref name="containers"/> using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        [CakeMethodAlias]
        public static void DockerStop(this ICakeContext context, params string[] containers)
        {
            DockerStop(context, new DockerContainerStopSettings(), containers);
        }

        /// <summary>
        /// Stops an array of <paramref name="containers"/> using the give <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="containers">The list of containers.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerStop(this ICakeContext context, DockerContainerStopSettings settings, params string[] containers)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (containers == null || containers.Length == 0)
            {
                throw new ArgumentNullException(nameof(containers));
            }
            var runner = new GenericDockerRunner<DockerContainerStopSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("stop", settings ?? new DockerContainerStopSettings(), containers);
        }
    }
}
