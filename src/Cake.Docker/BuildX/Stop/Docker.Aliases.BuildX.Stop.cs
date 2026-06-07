using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker buildx stop command.
    partial class DockerAliases
    {
        /// <summary>
        /// Stop builder instance using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        [CakeMethodAlias]
        public static void DockerBuildXStop(this ICakeContext context, string? name = null)
        {
            context.DockerBuildXStop(new DockerBuildXStopSettings(), name);
        }

        /// <summary>
        /// Stop builder instance given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        [CakeMethodAlias]
        public static void DockerBuildXStop(this ICakeContext context, DockerBuildXStopSettings? settings = null, string? name = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerBuildXStopSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx stop", settings ?? new DockerBuildXStopSettings(), name != null ? new[] { name } : Array.Empty<string>());
        }
    }
}
