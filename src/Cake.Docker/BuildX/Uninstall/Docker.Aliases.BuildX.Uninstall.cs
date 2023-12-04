using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker buildx uninstall command.
    partial class DockerAliases
    {
        /// <summary>
        /// Uninstall the ‘docker builder’ alias.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static void DockerBuildXUninstall(this ICakeContext context)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            var runner = new GenericDockerRunner<DockerBuildXUninstallSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx uninstall", new DockerBuildXUninstallSettings(), []);
        }
    }
}
