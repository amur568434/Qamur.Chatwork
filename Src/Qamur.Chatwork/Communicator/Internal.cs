// <copyright file="Internal.cs" company="Kohei Oizumi">
// Copyright 2020 Kohei Oizumi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace Qamur.Chatwork.Communicator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using HeyRed.Mime;
    using Newtonsoft.Json;
    using Qamur.Chatwork.CustomAttribute;
    using Qamur.Chatwork.ObjectValues;
    using Qamur.Chatwork.Parameters;

    /// <summary>
    /// The internal utils.
    /// </summary>
    internal static class Internal
    {
        /// <summary>
        /// Gets a settings object.
        /// </summary>
        /// <typeparam name="T">The type of settings.</typeparam>
        /// <returns>The settings object.</returns>
        public static T GetSettings<T>()
            where T : IConnectionSettings
        {
            var configType = typeof(T);
            return (T)Activator.CreateInstance(configType);
        }

        /// <summary>
        /// Detects a MIME type.
        /// </summary>
        /// <param name="filename">The filename or extension.</param>
        /// <returns>The MIME Type.</returns>
        public static string DetectMimeType(string filename)
        {
            return MimeTypesMap.GetMimeType(filename ?? string.Empty);
        }

        /// <summary>
        /// Joins parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Joined parameters string.</returns>
        public static string JoinParameters(IReadOnlyCollection<KeyValuePair<string, string>> parameters)
        {
            if (parameters == null)
            {
                return string.Empty;
            }

            return parameters
                .Select(x => $"{WebUtility.UrlEncode(x.Key)}={WebUtility.UrlEncode(x.Value)}")
                .Aggregate((ret, x) => $"{ret}&{x}");
        }

        /// <summary>
        /// Converts to string pair list.
        /// </summary>
        /// <typeparam name="T">The object data type.</typeparam>
        /// <param name="obj">The target object.</param>
        /// <returns>The string pair list.</returns>
        public static IReadOnlyCollection<KeyValuePair<string, string>> ConvertParameters<T>(T obj)
            where T : class
        {
            if (obj == null)
            {
                return null;
            }

            var parameters = new List<KeyValuePair<string, string>>();
            var jsonAttrType = typeof(JsonPropertyAttribute);
            var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in properties)
            {
                var key = GetPropKey(prop);
                var value = GetPropValue(prop, obj);

                if (string.IsNullOrEmpty(value))
                {
                    if (prop.GetCustomAttribute(jsonAttrType) is JsonPropertyAttribute jsonAttr)
                    {
                        if (jsonAttr.Required == Required.Always)
                        {
                            throw new FormatException($"{obj.GetType().Name}.{prop.Name} is always required.");
                        }
                    }

                    if (value == null)
                    {
                        continue;
                    }
                }

                parameters.Add(new KeyValuePair<string, string>(key, value));
            }

            return parameters;
        }

        /// <summary>
        /// Gets a property's name.
        /// </summary>
        /// <param name="prop">The <see cref="PropertyInfo"/> object.</param>
        /// <returns>The name.</returns>
        public static string GetPropKey(PropertyInfo prop)
        {
            var jsonProperty = prop.GetCustomAttribute(typeof(JsonPropertyAttribute));
            if (jsonProperty != null)
            {
                var name = ((JsonPropertyAttribute)jsonProperty).PropertyName;
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
            }

            return prop.Name;
        }

        /// <summary>
        /// Gets a property's value.
        /// </summary>
        /// <param name="prop">The <see cref="PropertyInfo"/> object.</param>
        /// <param name="obj">The target object.</param>
        /// <returns>The string value.</returns>
        public static string GetPropValue(PropertyInfo prop, object obj)
        {
            var val = prop.GetValue(obj, null);

            if (val == null)
            {
                return null;
            }

            if (val is bool boolVal)
            {
                return boolVal ? "1" : "0";
            }

            if (val is Enum enumVal)
            {
                return StringValueAttribute.GetStringValue(enumVal);
            }

            if (val is IEnumerable<Enum> enumVals)
            {
                return enumVals.Select(x => StringValueAttribute.GetStringValue(x))
                    .Aggregate((ret, x) => $"{ret},{x}");
            }

            if (val is IEnumerable<string> strVals)
            {
                return strVals.Aggregate((ret, x) => $"{ret},{x}");
            }

            if (val is IEnumerable<int> intVals)
            {
                return intVals.Select(x => $"{x}")
                    .Aggregate((ret, x) => $"{ret},{x}");
            }

            if (val is IEnumerable<long> longVals)
            {
                return longVals.Select(x => $"{x}")
                    .Aggregate((ret, x) => $"{ret},{x}");
            }

            var converterAttrType = typeof(JsonConverterAttribute);
            if (prop.GetCustomAttribute(converterAttrType) is JsonConverterAttribute converterAttr)
            {
                var converters = new[]
                {
                    (JsonConverter)Activator.CreateInstance(converterAttr.ConverterType),
                };

                return JsonConvert.SerializeObject(val, converters);
            }

            return val.ToString();
        }

        /// <summary>
        /// Converts to multipart form parameter list.
        /// </summary>
        /// <typeparam name="T">The object data type.</typeparam>
        /// <param name="obj">The target object.</param>
        /// <returns>The multipart form item list.</returns>
        public static IReadOnlyCollection<MultipartFormItem> ConvertMultipartFormParameters<T>(T obj)
            where T : class
        {
            if (obj == null)
            {
                return null;
            }

            var parameters = new List<MultipartFormItem>();
            var jsonAttrType = typeof(JsonPropertyAttribute);
            var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var prop in properties)
            {
                var key = GetPropKey(prop);
                var val = prop.GetValue(obj, null);

                if (val == null)
                {
                    if (prop.GetCustomAttribute(jsonAttrType) is JsonPropertyAttribute jsonAttr)
                    {
                        if (jsonAttr.Required == Required.Always)
                        {
                            throw new FormatException($"{obj.GetType().Name}.{prop.Name} is always required.");
                        }
                    }

                    continue;
                }

                if (val is FileContent)
                {
                    var fileItem = new MultipartFormItem
                    {
                        Type = StreamType.File,
                        Name = key,
                        Value = val,
                    };

                    parameters.Add(fileItem);
                    continue;
                }

                var value = GetPropValue(prop, obj);
                var item = new MultipartFormItem
                {
                    Type = StreamType.Text,
                    Name = key,
                    Value = value,
                };

                parameters.Add(item);
            }

            return parameters;
        }

        /// <summary>
        /// Reads stream as byte[].
        /// </summary>
        /// <param name="stream">The input stream.</param>
        /// <returns>byte[].</returns>
        public static byte[] GetBytes(Stream stream)
        {
            if (stream == null)
            {
                return Array.Empty<byte>();
            }

            var length = stream.Length;
            var readSize = length < 100 ? 10 : 100;
            var bytes = new byte[length + readSize];
            var readLength = 0;

            while (readLength < length)
            {
                var readNum = stream.Read(bytes, readLength, readSize);

                if (readNum < 1)
                {
                    break;
                }

                readLength += readNum;

                if (readNum < readSize)
                {
                    break;
                }
            }

            Array.Resize(ref bytes, readLength);

            return bytes;
        }
    }
}
