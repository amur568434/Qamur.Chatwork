// <copyright file="NewRoomTaskParameters.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Parameters
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Qamur.Chatwork.CustomJsonConverter;
    using Qamur.Chatwork.ObjectValues;

    /// <summary>
    /// The parameters for creating a new task.
    /// </summary>
    public class NewRoomTaskParameters
    {
        /// <summary>
        /// Gets or sets the task content body.
        /// </summary>
        [JsonProperty("body", Required = Required.Always)]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the limit datetime.
        /// </summary>
        [JsonProperty("limit")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset? Limit { get; set; }

        /// <summary>
        /// Gets or sets the limit type.
        /// <see cref="LimitTypeValue"/>.
        /// </summary>
        [JsonProperty("limit_type")]
        public LimitTypeValue LimitType { get; set; }

        /// <summary>
        /// Gets or sets the assignees.
        /// </summary>
        [JsonProperty("to_ids", Required = Required.Always)]
        public IReadOnlyCollection<long> ToIds { get; set; }
    }
}
