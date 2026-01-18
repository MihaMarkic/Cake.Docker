using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with buildx imagetools create command.
    partial class DockerAliases
    {
        /// <summary>
        /// Create a new image based on source images using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">Targets</param>
        [CakeMethodAlias]
        public static void DockerBuildXImageToolsCreate(this ICakeContext context, IEnumerable<string>? target = null)
        {
            DockerBuildXImageToolsCreate(context, new DockerBuildXImageToolsCreateSettings(), target);
        }

        /// <summary>
        /// Create a new image based on source images given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">Targets</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DockerBuildXImageToolsCreate(this ICakeContext context, DockerBuildXImageToolsCreateSettings? settings, IEnumerable<string>? target = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerBuildXImageToolsCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx imagetools create", settings ?? new DockerBuildXImageToolsCreateSettings(), target?.ToArray() ?? Array.Empty<string>());
        }

    }
}
