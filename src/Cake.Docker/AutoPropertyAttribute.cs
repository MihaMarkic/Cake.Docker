using System;

namespace Cake.Docker
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoPropertyAttribute: Attribute
    {
        /// <summary>
        /// Format of the output, i.e. "-s {1}"
        /// where {0} is property name and {1} is value.
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// Outputs only when given value is true.
        /// </summary>
        public bool OnlyWhenTrue { get; set; }
    }
}
