// <copyright file="UnixTimeConverter.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.CustomJsonConverter
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts a <see cref="DateTime"/> or <see cref="DateTimeOffset"/> to and from Unix epoch time.
    /// </summary>
    /// <remarks>
    /// Use this class instead of Newtonsoft.Json.Converters.UnixDateTimeConverter
    /// because of Newtonsoft.Json v9.0.1 does not cantain UnixDateTimeConverter.
    /// </remarks>
    public class UnixTimeConverter : JsonConverter
    {
        /// <summary>
        /// The type of the <see cref="System.DateTime"/> class.
        /// </summary>
        private static readonly Type DateTimeType = typeof(DateTime);

        /// <summary>
        /// The type of the <see cref="System.DateTimeOffset"/> class.
        /// </summary>
        private static readonly Type DateTimeOffsetType = typeof(DateTimeOffset);

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>true if this instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == DateTimeType || objectType == DateTimeOffsetType;
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="Newtonsoft.Json.JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null || reader.TokenType != JsonToken.Integer)
            {
                return existingValue;
            }

            var seconds = reader.Value as long?;
            if (seconds.HasValue)
            {
                if (objectType == DateTimeType)
                {
                    return DateTimeOffset.FromUnixTimeSeconds(seconds.Value).LocalDateTime;
                }

                if (objectType == DateTimeOffsetType)
                {
                    return DateTimeOffset.FromUnixTimeSeconds(seconds.Value);
                }
            }

            return existingValue;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="Newtonsoft.Json.JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (writer == null)
            {
                return;
            }

            if (value is DateTime dt)
            {
                var dtlocal = new DateTimeOffset(dt);
                var seconds = dtlocal.ToUnixTimeSeconds();
                writer.WriteValue(seconds);
                return;
            }

            if (value is DateTimeOffset dtoffset)
            {
                var seconds = dtoffset.ToUnixTimeSeconds();
                writer.WriteValue(seconds);
                return;
            }

            writer.WriteValue(0);
            return;
        }
    }
}
