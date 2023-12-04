using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker volume prune command.
    partial class DockerAliases
    {
        /// <summary>
        /// Remove all unused local volumes given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerVolumePrune(this ICakeContext context, DockerVolumePruneSettings settings)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            var runner = new GenericDockerRunner<DockerVolumePruneSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("volume prune", settings ?? new DockerVolumePruneSettings(), []);
        }

    }
}
