using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    // Contains functionality for working with buildx build command.
    partial class DockerAliases
    {
        /// <summary>
        /// Start a build using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">Targets</param>
        [CakeMethodAlias]
        public static void DockerBuildXBuild(this ICakeContext context, string target)
        {
            DockerBuildXBuild(context, new DockerBuildXBuildSettings(), target);
        }

        /// <summary>
        /// Start a build given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">Targets</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerBuildXBuild(this ICakeContext context, DockerBuildXBuildSettings? settings, string target)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerBuildXBuildSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx build", settings ?? new DockerBuildXBuildSettings(), new[] { target });
        }

    }
}
