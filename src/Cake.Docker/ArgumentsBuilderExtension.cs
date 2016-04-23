using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cake.Docker
{
    public static class ArgumentsBuilderExtension
    {
        public static void AppendAll<TSettings>(this ProcessArgumentBuilder builder, string command, TSettings settings, string[] arguments)
            where TSettings: AutoToolSettings, new()
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            if (arguments == null)
            {
                throw new ArgumentNullException("arguments");
            }
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command");
            }
            if (settings == null)
            {
                settings = new TSettings();
            }
            builder.Append(command);
            foreach (var property in typeof(TSettings).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                foreach (string argument in GetArgumentFromProperty(property, settings))
                {
                    if (!string.IsNullOrEmpty(argument))
                    {
                        builder.Append(argument);
                    }
                }
            }
            if (arguments != null)
            {
                foreach (string argument in arguments)
                {
                    builder.Append(argument);
                }
            }
        }

        public static IEnumerable<string> GetArgumentFromProperty<TSettings>(PropertyInfo property, TSettings settings)
            where TSettings : AutoToolSettings, new()
        {
            if (property.PropertyType == typeof(bool))
            {
                yield return GetArgumentFromBoolProperty(property, (bool)property.GetValue(settings));
            }
            else if (property.PropertyType == typeof(int?))
            {
                yield return GetArgumentFromNullableIntProperty(property, (int?)property.GetValue(settings));
            }
            else if (property.PropertyType == typeof(string))
            {
                yield return GetArgumentFromStringProperty(property, (string)property.GetValue(settings));
            }
            else if (property.PropertyType == typeof(string[]))
            {
                foreach (string arg in GetArgumentFromStringArrayProperty(property, (string[])property.GetValue(settings)))
                {
                    yield return arg;
                }
            }
        }

        public static string GetArgumentFromBoolProperty(PropertyInfo property, bool value)
        {
            return value ? $"--{GetPropertyName(property.Name)}" : null;
        }

        public static string GetArgumentFromNullableIntProperty(PropertyInfo property, int? value)
        {
            return value.HasValue ? $"--{GetPropertyName(property.Name)}={value.Value}" : null;
        }

        public static IEnumerable<string> GetArgumentFromDictionaryProperty(PropertyInfo property, Dictionary<string, string> values)
        {
            if (values != null)
            {
                foreach (var kp in values)
                {
                    yield return GetArgumentFromStringProperty(property, $"{kp.Key}={kp.Value}");
                }
            }
        }

        public static IEnumerable<string> GetArgumentFromStringArrayProperty(PropertyInfo property, string[] values)
        {
            if (values != null)
            {
                foreach (string value in values)
                {
                    yield return GetArgumentFromStringProperty(property, value);
                }
            }
        }

        public static string GetArgumentFromStringProperty(PropertyInfo property, string value)
        {
            return !string.IsNullOrEmpty(value) ? $"--{GetPropertyName(property.Name)}=\"{value}\"" : null;
        }

        /// <summary>
        /// Converts property name to docker arguments format
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <example>NoForce -> no-force</example>
        public static string GetPropertyName(string name)
        {
            string result = null;
            if (!string.IsNullOrEmpty(name))
            {
                result = name.Substring(0, 1).ToLower();
                if (name.Length > 1)
                {
                    foreach (char c in name.Substring(1))
                    {
                        if (char.IsUpper(c))
                        {
                            result += "-" + char.ToLower(c);
                        }
                        else
                        {
                            result += c;
                        }
                    }
                }
            }
            return result;
        }
    }
}
