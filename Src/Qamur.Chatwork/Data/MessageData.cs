// <copyright file="MessageData.cs" company="Kohei Oizumi">
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

    /// <summary>
    /// Message data.
    /// </summary>
    public class MessageData
    {
        /// <summary>
        /// Gets or sets the message id.
        /// </summary>
        [JsonProperty("message_id")]
        public string MessasgeId { get; set; }

        /// <summary>
        /// Gets or sets the account data.
        /// </summary>
        [JsonProperty("account")]
        public AccountData Account { get; set; }

        /// <summary>
        /// Gets or sets the message body.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the message sent datetime.
        /// </summary>
        [JsonProperty("send_time")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset SendTime { get; set; }

        /// <summary>
        /// Gets or sets the message update datetime.
        /// </summary>
        [JsonProperty("update_time")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset UpdateTime { get; set; }
    }
}
