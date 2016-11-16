using Cake.Core;
using Cake.Core.Annotations;
using System;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with docker-compose scale command.
    /// </summary>
    [CakeAliasCategory("Docker")]
    partial class DockerAliases
    {
        /// <summary>
        /// Runs docker-compose scale.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="numbers">The numbers.</param>
        [CakeMethodAlias]
        public static void DockerComposeScale(this ICakeContext context, params string[] numbers)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (numbers?.Length == 0)
            {
                throw new ArgumentOutOfRangeException("at least one service-number pair has to be specified");
            }
            var runner = new GenericDockerComposeRunner<EmptySettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            runner.Run("scale", new EmptySettings(), numbers);
        }
    }
}