using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cake.Docker
{
    /// <summary>
    /// Arguments builder
    /// </summary>
    public static class ArgumentsBuilderExtension
    {
        /// <summary>
        /// Appends all arguments from <paramref name="settings"/> and <paramref name="arguments"/>.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="builder"></param>
        /// <param name="command"></param>
        /// <param name="settings">The settings.</param>
        /// <param name="arguments"></param>
        public static void AppendAll<TSettings>(this ProcessArgumentBuilder builder, string command, TSettings settings, string[] arguments)
            where TSettings : AutoToolSettings, new()
        {
            ArgumentNullException.ThrowIfNull(builder);
            ArgumentNullException.ThrowIfNull(arguments);

            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException(nameof(command));
            }
            settings ??= new TSettings();
            AppendArguments(builder, settings, preCommand: true);
            builder.Append(command);
            AppendArguments(builder, settings, preCommand: false);

            foreach (string argument in arguments)
            {
                builder.Append(argument);
            }
        }

        /// <summary>
        /// Appends pre or post command arguments.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="builder"></param>
        /// <param name="settings"></param>
        /// <param name="preCommand"></param>
        public static void AppendArguments<TSettings>(ProcessArgumentBuilder builder, TSettings settings, bool preCommand)
            where TSettings : AutoToolSettings, new()
        {
            foreach (var property in typeof(TSettings).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                bool isSecret = IsPropertyValueSecret(property, settings);
                var query = from a in GetArgumentFromProperty(property, settings, preCommand: preCommand, isSecret: isSecret)
                            where a.HasValue
                            select a.Value;

                foreach (var argument in query)
                {
                    if (!string.IsNullOrEmpty(argument.Key))
                    {
                        builder.Append(argument.Key);
                    }
                    if (!string.IsNullOrEmpty(argument.Value))
                    {
                        switch (argument.Quoting)
                        {
                            case DockerArgumentQuoting.Unquoted:
                                builder.Append(argument.Value);
                                break;
                            case DockerArgumentQuoting.QuotedSecret:
                                builder.AppendQuotedSecret(argument.Value);
                                break;
                            default:
                                builder.AppendQuoted(argument.Value);
                                break;

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets and processes <paramref name="property"/> value from <paramref name="settings"/>.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="property"></param>
        /// <param name="settings">The settings.</param>
        /// <param name="preCommand">Pre or post command.</param>
        /// <param name="isSecret"></param>
        /// <returns></returns>
        public static IEnumerable<DockerArgument?> GetArgumentFromProperty<TSettings>(PropertyInfo property, TSettings settings, bool preCommand, bool isSecret)
            where TSettings : AutoToolSettings, new()
        {
            var autoPropertyAttribute = GetAutoPropertyAttributeOrNull(property);
            if (autoPropertyAttribute?.Format != null)
            {
                if (autoPropertyAttribute.PreCommand == preCommand)
                {
                    yield return new DockerArgument(null, GetArgumentFromAutoProperty(autoPropertyAttribute, property, property.GetValue(settings)), DockerArgumentQuoting.Unquoted);
                }
            }
            else if (!preCommand && (autoPropertyAttribute == null || !autoPropertyAttribute.PreCommand)
                || (autoPropertyAttribute != null && autoPropertyAttribute.PreCommand && preCommand))
            {
                if (property.PropertyType == typeof(bool))
                {
                    yield return new DockerArgument(null, GetArgumentFromBoolProperty(property, (bool?)property.GetValue(settings) == true), DockerArgumentQuoting.Unquoted);
                }
                else if (property.PropertyType == typeof(bool?))
                {
                    yield return new DockerArgument(null, GetArgumentFromNullableBoolProperty(property, (bool?)property.GetValue(settings)), DockerArgumentQuoting.Unquoted);
                }
                else if (property.PropertyType == typeof(int?))
                {
                    yield return new DockerArgument(null, GetArgumentFromNullableIntProperty(property, (int?)property.GetValue(settings)), DockerArgumentQuoting.Unquoted);
                }
                else if (property.PropertyType == typeof(Int64?))
                {
                    yield return new DockerArgument(null, GetArgumentFromNullableInt64Property(property, (Int64?)property.GetValue(settings)), DockerArgumentQuoting.Unquoted);
                }
                else if (property.PropertyType == typeof(UInt64?))
                {
                    yield return new DockerArgument(null, GetArgumentFromNullableUInt64Property(property, (UInt64?)property.GetValue(settings)), DockerArgumentQuoting.Unquoted);
                }
                else if (property.PropertyType == typeof(UInt16?))
                {
                    yield return new DockerArgument(null, GetArgumentFromNullableUInt16Property(property, (UInt16?)property.GetValue(settings)), DockerArgumentQuoting.Unquoted);
                }
                else if (property.PropertyType == typeof(string))
                {
                    yield return GetArgumentFromStringProperty(property, (string)property.GetValue(settings), isSecret);
                }
                else if (property.PropertyType == typeof(TimeSpan?))
                {
                    yield return new DockerArgument(null, GetArgumentFromNullableTimeSpanProperty(property, (TimeSpan?)property.GetValue(settings)), DockerArgumentQuoting.Unquoted);
                }
                else if (property.PropertyType == typeof(string[]))
                {
                    foreach (var arg in GetArgumentFromStringArrayProperty(property, (string[])property.GetValue(settings), isSecret))
                    {
                        yield return arg;
                    }
                }
            }
        }
        /// <summary>
        /// Checks out whether given <paramref name="property"/> is a secret.
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="property"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static bool IsPropertyValueSecret<TSettings>(PropertyInfo property, TSettings settings)
            where TSettings : AutoToolSettings
        {
            return settings.SecretProperties.Contains(property.Name);
        }
        /// <summary>
        /// Uses format specified in attribute to format the argument.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetArgumentFromAutoProperty(AutoPropertyAttribute attribute, PropertyInfo property, object? value)
        {
            if (value == null || property == null)
            {
                return null;
            }

            string result = string.Format(attribute.Format, GetPropertyName(property.Name), value);
            if (attribute.OnlyWhenTrue)
            {
                bool boolvalue = (bool)value;
                return boolvalue ? result : string.Empty;
            }
            else
            {
                if (property.PropertyType == typeof(string[]))
                {
                    var strings = (string[])value;
                    result = string.Join(" ", strings.Select(s => string.Format(attribute.Format, GetPropertyName(property.Name), s)));
                }
            }
            return result;
        }
        /// <summary>
        /// Retrieve <see cref="AutoPropertyAttribute"/> from property or null if there isn't one.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static AutoPropertyAttribute? GetAutoPropertyAttributeOrNull(PropertyInfo property)
        {
            return property.GetCustomAttribute<AutoPropertyAttribute>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetArgumentFromBoolProperty(PropertyInfo property, bool value)
        {
            return value ? $"--{GetPropertyName(property.Name)}" : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetArgumentFromNullableIntProperty(PropertyInfo property, int? value)
        {
            return value.HasValue ? $"--{GetPropertyName(property.Name)} {value.Value}" : null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetArgumentFromNullableInt64Property(PropertyInfo property, Int64? value)
        {
            return value.HasValue ? $"--{GetPropertyName(property.Name)} {value.Value}" : null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetArgumentFromNullableUInt64Property(PropertyInfo property, UInt64? value)
        {
            return value.HasValue ? $"--{GetPropertyName(property.Name)} {value.Value}" : null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetArgumentFromNullableUInt16Property(PropertyInfo property, UInt16? value)
        {
            return value.HasValue ? $"--{GetPropertyName(property.Name)} {value.Value}" : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetArgumentFromNullableBoolProperty(PropertyInfo property, bool? value)
        {
            if (value ?? false)
            {
                return $"--{GetPropertyName(property.Name)}";
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="values"></param>
        /// <param name="isSecret"></param>
        /// <returns></returns>
        public static IEnumerable<DockerArgument?> GetArgumentFromDictionaryProperty(PropertyInfo property, Dictionary<string, string> values, bool isSecret)
        {
            if (values != null)
            {
                foreach (var kp in values)
                {
                    yield return GetArgumentFromStringProperty(property, $"{kp.Key}={kp.Value}", isSecret);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="values"></param>
        /// <param name="isSecret"></param>
        /// <returns></returns>
        public static IEnumerable<DockerArgument?> GetArgumentFromStringArrayProperty(PropertyInfo property, string[] values, bool isSecret)
        {
            if (values != null)
            {
                foreach (string value in values)
                {
                    yield return GetArgumentFromStringProperty(property, value, isSecret);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="values"></param>
        /// <param name="isSecret"></param>
        /// <returns></returns>
        public static DockerArgument? GetArgumentFromStringArrayListProperty(PropertyInfo property, string[] values, bool isSecret)
        {
            if (values?.Length > 0)
            {
                return GetArgumentFromStringProperty(property, string.Join(",", values), isSecret);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <param name="isSecret"></param>
        /// <returns></returns>
        public static DockerArgument? GetArgumentFromStringProperty(PropertyInfo property, string? value, bool isSecret)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return new DockerArgument($"--{GetPropertyName(property.Name)}", value, isSecret ? DockerArgumentQuoting.QuotedSecret : DockerArgumentQuoting.Quoted);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? GetArgumentFromNullableTimeSpanProperty(PropertyInfo property, TimeSpan? value)
        {
            return value.HasValue ? $"--{GetPropertyName(property.Name)} {ConvertTimeSpan(value.Value)}" : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertTimeSpan(TimeSpan source)
        {
            return $"{Math.Floor(source.TotalHours)}h{source.Minutes}m{source.Seconds}s";
        }

        /// <summary>
        /// Converts property name to docker arguments format
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <example>NoForce -> no-force</example>
        public static string? GetPropertyName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var builder = new StringBuilder();
                builder.Append(name.Substring(0, 1).ToLower());
                if (name.Length > 1)
                {
                    foreach (char c in name.Substring(1))
                    {
                        if (char.IsUpper(c))
                        {
                            builder.Append("-" + char.ToLower(c));
                        }
                        else
                        {
                            builder.Append(c);
                        }
                    }
                }

                return builder.ToString();
            }

            return null;
        }
    }
}
