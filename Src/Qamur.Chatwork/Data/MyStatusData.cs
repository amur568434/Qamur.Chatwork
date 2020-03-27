// <copyright file="MyStatusData.cs" company="Kohei Oizumi">
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
    using Newtonsoft.Json;

    /// <summary>
    /// My status data.
    /// </summary>
    public class MyStatusData
    {
        /// <summary>
        /// Gets or sets the number of rooms with unread messages.
        /// </summary>
        [JsonProperty("unread_room_num")]
        public long UnreadRoomNum { get; set; }

        /// <summary>
        /// Gets or sets the number of rooms where mentions left.
        /// </summary>
        [JsonProperty("mention_room_num")]
        public long MentionRoomNum { get; set; }

        /// <summary>
        /// Gets or sets the number of rooms where tasks remain.
        /// </summary>
        [JsonProperty("mytask_room_num")]
        public long MytaskRoomNum { get; set; }

        /// <summary>
        /// Gets or sets the number of unread messages.
        /// </summary>
        [JsonProperty("unread_num")]
        public long UnreadNum { get; set; }

        /// <summary>
        /// Gets or sets the number of mentions.
        /// </summary>
        [JsonProperty("mention_num")]
        public long MentionNum { get; set; }

        /// <summary>
        /// Gets or sets the number of owner's tasks.
        /// </summary>
        [JsonProperty("mytask_num")]
        public long MytaskNum { get; set; }
    }
}
