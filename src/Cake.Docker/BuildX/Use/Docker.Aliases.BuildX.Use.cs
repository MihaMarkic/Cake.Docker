using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with docker buildx use command.
    partial class DockerAliases
    {
        /// <summary>
        /// Set the current builder instance using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        [CakeMethodAlias]
        public static void DockerBuildXUse(this ICakeContext context, string name)
        {
            context.DockerBuildXUse(null, name);
        }
        /// <summary>
        /// Set the current builder instance given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="name">The name.</param>
        [CakeMethodAlias]
        public static void DockerBuildXUse(this ICakeContext context, DockerBuildXUseSettings? settings = null, string? name = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerBuildXUseSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx use", settings ?? new DockerBuildXUseSettings(), name != null ? new[] { name } : Array.Empty<string>());
        }
    }
}
