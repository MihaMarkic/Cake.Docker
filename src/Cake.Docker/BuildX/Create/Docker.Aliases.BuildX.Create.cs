using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with buildx create command.
    partial class DockerAliases
    {
        /// <summary>
        /// Create a new builder instance using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">Targets</param>
        [CakeMethodAlias]
        public static void DockerBuildXCreate(this ICakeContext context, string? target = null)
        {
            DockerBuildXCreate(context, new DockerBuildXCreateSettings(), target);
        }

        /// <summary>
        /// Create a new builder instance given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">Targets</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerBuildXCreate(this ICakeContext context, DockerBuildXCreateSettings? settings, string? target = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerBuildXCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx create", settings ?? new DockerBuildXCreateSettings(), target != null ? new[] { target } : Array.Empty<string>());
        }

    }
}
