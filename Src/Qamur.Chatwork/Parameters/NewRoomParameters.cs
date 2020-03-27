// <copyright file="NewRoomParameters.cs" company="Kohei Oizumi">
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
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Qamur.Chatwork.ObjectValues;

    /// <summary>
    /// The parameters for creating a new room.
    /// </summary>
    public class NewRoomParameters
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the icon preset.
        /// <see cref="IconPresetValue"/>.
        /// </summary>
        [JsonProperty("icon_preset")]
        public IconPresetValue? IconPreset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to create an invitation link.
        /// </summary>
        [JsonProperty("link")]
        public bool? Link { get; set; }

        /// <summary>
        /// Gets or sets the link code.
        /// </summary>
        [JsonProperty("link_code")]
        public string LinkCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the administrator determines the need for acceptance.
        /// </summary>
        [JsonProperty("link_need_acceptance")]
        public bool? LinkNeedAcceptance { get; set; }

        /// <summary>
        /// Gets or sets the administrator members.
        /// </summary>
        [JsonProperty("members_admin_ids", Required = Required.Always)]
        public IReadOnlyCollection<long> MembersAdminIds { get; set; }

        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        [JsonProperty("members_member_ids")]
        public IReadOnlyCollection<long> MembersMemberIds { get; set; }

        /// <summary>
        /// Gets or sets the readonly members.
        /// </summary>
        [JsonProperty("members_readonly_ids")]
        public IReadOnlyCollection<long> MembersReadonlyIds { get; set; }

        /// <summary>
        /// Gets or sets the chat room name.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }
}
