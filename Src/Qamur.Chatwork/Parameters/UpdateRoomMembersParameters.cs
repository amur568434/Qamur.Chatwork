// <copyright file="UpdateRoomMembersParameters.cs" company="Kohei Oizumi">
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

    /// <summary>
    /// The parameters for updating a members.
    /// </summary>
    public class UpdateRoomMembersParameters
    {
        /// <summary>
        /// Gets or sets the administrator member list.
        /// </summary>
        [JsonProperty("members_admin_ids", Required = Required.Always)]
        public IReadOnlyCollection<long> MembersAdminIds { get; set; }

        /// <summary>
        /// Gets or sets the member list.
        /// </summary>
        [JsonProperty("members_member_ids")]
        public IReadOnlyCollection<long> MembersMemberIds { get; set; }

        /// <summary>
        /// Gets or sets the readonly member list.
        /// </summary>
        [JsonProperty("members_readonly_ids")]
        public IReadOnlyCollection<long> MembersReadonlyIds { get; set; }
    }
}
