using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with buildx du command.
    partial class DockerAliases
    {
        /// <summary>
        /// Disk usage given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static IEnumerable<string> DockerBuildXDu(this ICakeContext context, DockerBuildXDuSettings settings = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerBuildXDuSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return runner.RunWithResult("buildx du", settings ?? new DockerBuildXDuSettings(), r => r.ToArray());
        }

    }
}
