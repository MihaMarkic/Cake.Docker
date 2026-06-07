using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with manifest annotate command.
    /// </summary>
    partial class DockerAliases
    {
        /// <summary>
        /// Add additional information to a local image manifest
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="manifestList">MANIFEST_LIST</param>
        /// <param name="manifest">MANIFEST</param>
        [CakeMethodAlias]
        [Experimental]
        public static void DockerManifestAnnotate(this ICakeContext context, string manifestList, string manifest)
        {
            DockerManifestAnnotate(context, new DockerManifestAnnotateSettings(), manifestList, manifest);
        }

        /// <summary>
        /// Add additional information to a local image manifest
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="manifestList">MANIFEST_LIST</param>
        /// <param name="manifest">MANIFEST</param>
        [CakeMethodAlias]
        [Experimental]
        public static void DockerManifestAnnotate(this ICakeContext context, DockerManifestAnnotateSettings? settings, string manifestList, string manifest)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerManifestAnnotateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { manifestList, manifest };
            runner.Run("manifest annotate", settings ?? new DockerManifestAnnotateSettings(), arguments.ToArray());
        }
    }
}
