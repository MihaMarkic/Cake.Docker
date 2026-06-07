using Cake.Core.Tooling;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// Base class for tooling that is used for autogeneration of command line arguments.
    /// </summary>
    public abstract class AutoToolSettings : ToolSettings
    {
        /// <summary>
        /// Values of these properties shouldn't be displayed in the output.
        /// </summary>
        public readonly HashSet<string> SecretProperties;
        /// <summary>
        /// Initializer. Handles secret properties collection.
        /// </summary>
        protected AutoToolSettings()
        {
            SecretProperties = new HashSet<string>(CollectSecretProperties() ?? Array.Empty<string>());
        }
        /// <summary>
        /// Collects secret properties.
        /// </summary>
        /// <returns></returns>
        protected virtual string[]? CollectSecretProperties()
        {
            return null;
        }
    }
}
