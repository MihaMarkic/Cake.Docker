using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Docker
{
    // Contains functionality for working with docker buildx imagetools inspect command.
    partial class DockerAliases
    {
        /// <summary>
        /// Show details of image in the registry using default settings..
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">Name</param>
        /// <returns>Output text.</returns>
        /// <remarks>Return value are the lines from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerBuildXImageToolsInspect(this ICakeContext context, string name)
        {
            return context.DockerBuildXImageToolsInspect(new DockerBuildXImageToolsInspectSettings(), name);
        }

        /// <summary>
        /// Show details of image in the registry given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="name">Name</param>
        /// <returns>Output text.</returns>
        /// <remarks>Return value are the lines from stdout. This method will redirect stdout and it won't be available for capture.</remarks>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerBuildXImageToolsInspect(this ICakeContext context, DockerBuildXImageToolsInspectSettings? settings, string name)
        {
            ArgumentNullException.ThrowIfNull(context);
            if (name.Length < 1)
            {
                throw new ArgumentNullException(nameof(name), "Name is required");
            }
            var runner = new GenericDockerRunner<DockerBuildXImageToolsInspectSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("buildx imagetools inspect", settings ?? new DockerBuildXImageToolsInspectSettings(), r => r.ToArray(), name);
        }

    }
}
