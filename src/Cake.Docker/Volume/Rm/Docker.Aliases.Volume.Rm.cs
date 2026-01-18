using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker volume rm command.
    partial class DockerAliases
    {
        /// <summary>
        /// Remove one or more volumes given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="volumes">Volumes</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerVolumeRm(this ICakeContext context, DockerVolumeRmSettings? settings, string[] volumes)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (volumes == null || volumes.Length < 1)
            {
                throw new ArgumentNullException(nameof(volumes), "At least one volume is required");
            }
            var runner = new GenericDockerRunner<DockerVolumeRmSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("volume rm", settings ?? new DockerVolumeRmSettings(), volumes);
        }

        /// <summary>
        /// Remove one or more volumes.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="volumes">Volumes</param>
        [CakeMethodAlias]
        public static void DockerVolumeRm(this ICakeContext context, string[] volumes)
        {
            context.DockerVolumeRm(null, volumes);
        }
    }
}
