using System;

namespace Cake.Docker
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoPropertyAttribute : Attribute
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
        /// <summary>
        /// Whether it appears before command
        /// </summary>
        public bool PreCommand { get; set; }
        /// <summary>
        /// Array representation in command line
        /// </summary>
        /// <remarks>Default is <see cref=" AutoArrayType.MultipleInstances"/>.</remarks>
        public AutoArrayType AutoArrayType { get; set; } = AutoArrayType.MultipleInstances;
    }

    /// <summary>
    /// Array representation in command line
    /// </summary>
    public enum AutoArrayType
    {
        /// <summary>
        /// A key-value pair for each value
        /// </summary>
        /// <example>--property=value1 --property=value2</example>
        MultipleInstances,
        /// <summary>
        /// A single property with multiple values
        /// </summary>
        /// <example>--property=value1,value2</example>
        List
    }
}
