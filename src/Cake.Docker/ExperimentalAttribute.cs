using System;

namespace Cake.Docker
{
    /// <summary>
    /// Declares settings or command as experimental
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class ExperimentalAttribute : Attribute
    {
    }
}
