using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with manifest push command.
    /// </summary>
    partial class DockerAliases
    {
        /// <summary>
        /// Push a manifest list to a repository
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="manifestList">MANIFEST_LIST</param>
        [CakeMethodAlias]
        [Experimental]
        public static void DockerManifestPush(this ICakeContext context, string manifestList)
        {
            DockerManifestPush(context, new DockerManifestPushSettings(), manifestList);
        }

        /// <summary>
        /// Push a manifest list to a repository
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="manifestList">MANIFEST_LIST</param>
        [CakeMethodAlias]
        [Experimental]
        public static void DockerManifestPush(this ICakeContext context, DockerManifestPushSettings? settings, string manifestList)
        {
            ArgumentNullException.ThrowIfNull(context);
            var runner = new GenericDockerRunner<DockerManifestPushSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            List<string> arguments = new List<string> { manifestList };
            runner.Run("manifest push", settings ?? new DockerManifestPushSettings(), arguments.ToArray());
        }
    }
}
