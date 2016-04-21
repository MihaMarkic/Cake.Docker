using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    partial class DockerAliases
    {

        /// <summary>
        /// Creates a new container using default settings.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")] 
        public static void DockerCreate(this ICakeContext context, string image, string command, params string[] args)
        {
            DockerCreate(context, new DockerCreateSettings(), image, command, args);
        }

        /// <summary>
        /// Creates a new container given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        /// <param name="settings"></param>
        [CakeMethodAlias]
        [CakeAliasCategory("Docker")]
        public static void DockerCreate(this ICakeContext context, DockerCreateSettings settings, string image, string command, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(image))
            {
                throw new ArgumentNullException("image");
            }
            var runner = new GenericDockerRunner<DockerCreateSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string> { image };
            if (!string.IsNullOrEmpty(command))
            {
                arguments.Add(command);
                if (args.Length > 0)
                {
                    arguments.AddRange(args);
                }
            }
            runner.Run("create", settings ?? new DockerCreateSettings(), arguments.ToArray());
        }

    }
}
