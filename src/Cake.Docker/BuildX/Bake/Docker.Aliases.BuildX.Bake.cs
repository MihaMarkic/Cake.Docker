using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with buildx bake command.
    partial class DockerAliases
    {
        /// <summary>
        /// Build from a file using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">Targets</param>
        [CakeMethodAlias]
        public static void DockerBuildXBake(this ICakeContext context, IEnumerable<string>? target = null)
        {
            DockerBuildXBake(context, new DockerBuildXBakeSettings(), target);
        }

        /// <summary>
        /// Build from a file given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">Targets</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerBuildXBake(this ICakeContext context, DockerBuildXBakeSettings? settings, IEnumerable<string>? target = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerBuildXBakeSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx bake", settings ?? new DockerBuildXBakeSettings(), target?.ToArray() ?? Array.Empty<string>());
        }

    }
}
