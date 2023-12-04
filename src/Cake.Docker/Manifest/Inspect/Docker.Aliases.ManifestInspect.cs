using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with manifest inspect command.
    /// </summary>
    partial class DockerAliases
    {
        /// <summary>
        /// Display an image manifest, or manifest list
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="manifest">MANIFEST</param>
        [CakeMethodAlias]
        [Experimental]
        public static void DockerManifestInspect(this ICakeContext context, string manifest)
        {
            DockerManifestInspect(context, new DockerManifestInspectSettings(), null, manifest);
        }

        /// <summary>
        /// Display an image manifest, or manifest list
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="manifestList">MANIFEST_LIST</param>
        /// <param name="manifest">MANIFEST</param>
        [CakeMethodAlias]
        [Experimental]
        public static void DockerManifestInspect(this ICakeContext context, string manifestList, string manifest)
        {
            DockerManifestInspect(context, new DockerManifestInspectSettings(), manifestList, manifest);
        }

        /// <summary>
        /// Display an image manifest, or manifest list
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="manifestList">MANIFEST_LIST</param>
        /// <param name="manifest">MANIFEST</param>
        [CakeMethodAlias]
        [Experimental]
        public static void DockerManifestInspect(this ICakeContext context, DockerManifestInspectSettings settings, string manifestList, string manifest)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            var runner = new GenericDockerRunner<DockerManifestInspectSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { manifestList, manifest };
            runner.Run("manifest inspect", settings ?? new DockerManifestInspectSettings(), arguments.ToArray());
        }
    }
}
