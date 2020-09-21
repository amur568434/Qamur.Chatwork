// <copyright file="RoomTasksParameters.cs" company="Kohei Oizumi">
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
    using Newtonsoft.Json;
    using Qamur.Chatwork.ObjectValues;

    /// <summary>
    /// The parameters for getting task information list.
    /// </summary>
    public class RoomTasksParameters
    {
        /// <summary>
        /// Gets or sets the assignee's account id.
        /// </summary>
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        /// <summary>
        /// Gets or sets the assigner's account id.
        /// </summary>
        [JsonProperty("assigned_by_account_id")]
        public long? AssignedByAccontId { get; set; }

        /// <summary>
        /// Gets or sets the task status.
        /// </summary>
        [JsonProperty("status")]
        public TaskStatusValue? Status { get; set; }
    }
}
