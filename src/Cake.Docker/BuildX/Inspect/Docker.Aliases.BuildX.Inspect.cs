using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with docker buildx inspect command.
    partial class DockerAliases
    {
        /// <summary>
        /// Inspect current builder instance using default settings..
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">Name</param>
        /// <returns>Output text.</returns>
        /// <remarks>Return value are the lines from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerBuildXInspect(this ICakeContext context, string? name = null)
        {
            return context.DockerBuildXInspect(new DockerBuildXInspectSettings(), name);
        }

        /// <summary>
        /// Inspect current builder instance given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="name">Name</param>
        /// <returns>Output text.</returns>
        /// <remarks>Return value are the lines from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerBuildXInspect(this ICakeContext context, DockerBuildXInspectSettings? settings, string? name = null)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerBuildXInspectSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("buildx inspect", settings ?? new DockerBuildXInspectSettings(), r => r.ToArray(), name != null ? new[] { name } : Array.Empty<string>());
        }

    }
}
