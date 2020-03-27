// <copyright file="StringValueAttribute.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.CustomAttribute
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The attribute to set a string value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttribute"/> class.
        /// </summary>
        /// <param name="value">The string value.</param>
        public StringValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the string value.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <param name="value">The target Enum object.</param>
        /// <returns>The string value.</returns>
        public static string GetStringValue(Enum value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var type = value.GetType();
            var field = type.GetField(value.ToString());

            return field.GetCustomAttribute(typeof(StringValueAttribute), false) is StringValueAttribute attr
                ? attr.Value
                : value.ToString();
        }
    }
}
