// <copyright file="RoomData.cs" company="Kohei Oizumi">
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
    /// Room data.
    /// </summary>
    public class RoomData
    {
        /// <summary>
        /// Gets or sets the room id.
        /// </summary>
        [JsonProperty("room_id")]
        public long RoomId { get; set; }

        /// <summary>
        /// Gets or sets the chat room name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the chat room type.
        /// </summary>
        [JsonProperty("type")]
        public RoomTypeValue Type { get; set; }

        /// <summary>
        /// Gets or sets the owner's role.
        /// <see cref="RoleValue"/>.
        /// </summary>
        [JsonProperty("role")]
        public RoleValue Role { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the owner is pinned.
        /// </summary>
        [JsonProperty("sticky")]
        public bool Sticky { get; set; }

        /// <summary>
        /// Gets or sets the number of owner's unread messages.
        /// </summary>
        [JsonProperty("unread_num")]
        public long UnreadNum { get; set; }

        /// <summary>
        /// Gets or sets the number of owner's mentions.
        /// </summary>
        [JsonProperty("mention_num")]
        public long MentionNum { get; set; }

        /// <summary>
        /// Gets or sets the number of owner's tasks.
        /// </summary>
        [JsonProperty("mytask_num")]
        public long MytaskNum { get; set; }

        /// <summary>
        /// Gets or sets the number of messages.
        /// </summary>
        [JsonProperty("message_num")]
        public long MessageNum { get; set; }

        /// <summary>
        /// Gets or sets the number of files.
        /// </summary>
        [JsonProperty("file_num")]
        public long FileNum { get; set; }

        /// <summary>
        /// Gets or sets the number of tasks.
        /// </summary>
        [JsonProperty("task_num")]
        public long TaskNum { get; set; }

        /// <summary>
        /// Gets or sets the icon image path.
        /// </summary>
        [JsonProperty("icon_path")]
        public string IconPath { get; set; }

        /// <summary>
        /// Gets or sets the last update datetime.
        /// </summary>
        [JsonProperty("last_update_time")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset LasUpdateTime { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
