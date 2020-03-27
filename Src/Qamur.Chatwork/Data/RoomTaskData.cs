// <copyright file="RoomTaskData.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Data
{
    using System;
    using Newtonsoft.Json;
    using Qamur.Chatwork.CustomJsonConverter;
    using Qamur.Chatwork.ObjectValues;

    /// <summary>
    /// Room task data.
    /// </summary>
    public class RoomTaskData
    {
        /// <summary>
        /// Gets or sets the task id.
        /// </summary>
        [JsonProperty("task_id")]
        public long TaskId { get; set; }

        /// <summary>
        /// Gets or sets the assignee.
        /// </summary>
        [JsonProperty("account")]
        public AccountData Account { get; set; }

        /// <summary>
        /// Gets or sets the assigner.
        /// </summary>
        [JsonProperty("assigned_by_account")]
        public AccountData AssignedByAccount { get; set; }

        /// <summary>
        /// Gets or sets the message id.
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        /// <summary>
        /// Gets or sets the task content body.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the limit datetime.
        /// </summary>
        [JsonProperty("limit_time")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset LimitTime { get; set; }

        /// <summary>
        /// Gets or sets the task status.
        /// </summary>
        [JsonProperty("status")]
        public TaskStatusValue Status { get; set; }

        /// <summary>
        /// Gets or sets the limit type.
        /// </summary>
        [JsonProperty("limit_type")]
        public LimitTypeValue LimitType { get; set; }
    }
}
