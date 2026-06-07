using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker volume create command.
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker volume create with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="volume">Volume to create.</param>
        [CakeMethodAlias]
        public static void DockerVolumeCreate(this ICakeContext context, string volume)
        {
            DockerVolumeCreate(context, new DockerVolumeCreateSettings(), volume);
        }

        /// <summary>
        /// Runs docker volume create given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="volume">Volume to create.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerVolumeCreate(this ICakeContext context, DockerVolumeCreateSettings? settings, string volume)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerVolumeCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("volume create", settings ?? new DockerVolumeCreateSettings(), new[] { volume });
        }

    }
}
