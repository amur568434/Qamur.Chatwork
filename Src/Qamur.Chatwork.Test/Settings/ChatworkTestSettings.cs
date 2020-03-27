// <copyright file="ChatworkTestSettings.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Test.Settings
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// The chatwork client test settings.
    /// </summary>
    public class ChatworkTestSettings : IChatworkTestSettings
    {
        /// <summary>
        /// Gets the API token.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; private set; }

        /// <summary>
        /// Gets the owner's chat room id.
        /// </summary>
        [JsonProperty("room")]
        public long Room { get; private set; }

        /// <summary>
        /// Gets the owner's account id.
        /// </summary>
        [JsonProperty("account_id")]
        public long AccountId { get; private set; }

        /// <summary>
        /// Gets the chat room ids.
        /// </summary>
        [JsonProperty("rooms")]
        public IReadOnlyCollection<long> RoomList { get; private set; }

        /// <summary>
        /// Gets the chat room member account ids.
        /// </summary>
        [JsonProperty("members")]
        public IReadOnlyCollection<long> MemberList { get; private set; }

        /// <summary>
        /// Creates settings object from json file.
        /// </summary>
        /// <param name="filepath">The json file path.</param>
        /// <returns>The settings.</returns>
        public static ChatworkTestSettings CreateFromJson(string filepath)
        {
            var jsonText = File.ReadAllText(filepath);
            var obj = JsonConvert.DeserializeObject<ChatworkTestSettings>(jsonText);
            return obj;
        }
    }
}
