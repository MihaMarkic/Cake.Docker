using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    partial class DockerAliases
    {
        /// <summary>
        /// Tag an image into a repository.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="imageReference"></param>
        /// <param name="registryReference"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerTag(this ICakeContext context, string imageReference, string registryReference)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(imageReference))
            {
                throw new ArgumentNullException("imageReference");
            }
            if (string.IsNullOrEmpty(registryReference))
            {
                throw new ArgumentNullException("registryReference");
            }

            var runner = new GenericDockerRunner<DockerTagSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("tag", new DockerTagSettings(), new[] { imageReference, registryReference });
        }
    }
}
