using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with manifest create command.
    /// </summary>
    partial class DockerAliases
    {
        /// <summary>
        /// Create a local manifest list for annotating and pushing to a registry
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="manifestList">MANIFEST_LIST</param>
        /// <param name="manifest">MANIFEST</param>
        /// <param name="manifests">[MANIFEST...]</param>
        [CakeMethodAlias]
        [Experimental]
        public static void DockerManifestCreate(this ICakeContext context, string manifestList, string manifest, params string[] manifests)
        {
            DockerManifestCreate(context, new DockerManifestCreateSettings(), manifestList, manifest, manifests);
        }

        /// <summary>
        /// Create a local manifest list for annotating and pushing to a registry
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="manifestList">MANIFEST_LIST</param>
        /// <param name="manifest">MANIFEST</param>
        /// /// <param name="manifests">[MANIFEST...]</param>
        [CakeMethodAlias]
        [Experimental]
        public static void DockerManifestCreate(this ICakeContext context, DockerManifestCreateSettings? settings, string manifestList,
            string manifest, params string[] manifests)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerManifestCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { manifestList, manifest };
            if (manifests?.Length > 0)
            {
                arguments.AddRange(manifests);
            }
            runner.Run("manifest create", settings ?? new DockerManifestCreateSettings(), arguments.ToArray());
        }
    }
}
