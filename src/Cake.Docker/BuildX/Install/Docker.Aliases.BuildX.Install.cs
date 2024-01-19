using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    // Contains functionality for working with docker buildx install command.
    partial class DockerAliases
    {
        /// <summary>
        /// Install buildx as a ‘docker builder’ alias.
        /// </summary>
        /// <param name="context">The context.</param>
        [CakeMethodAlias]
        public static void DockerBuildXInstall(this ICakeContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerBuildXInstallSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run("buildx install", new DockerBuildXInstallSettings(), Array.Empty<string>());
        }
    }
}
