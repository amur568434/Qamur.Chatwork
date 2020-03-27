// <copyright file="MembersSummaryData.cs" company="Kohei Oizumi">
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
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Members summary data.
    /// </summary>
    public class MembersSummaryData
    {
        /// <summary>
        /// Gets or sets the administrator accound id list.
        /// </summary>
        [JsonProperty("admin")]
        public IReadOnlyCollection<long> Admin { get; set; }

        /// <summary>
        /// Gets or sets the member account id list.
        /// </summary>
        [JsonProperty("member")]
        public IReadOnlyCollection<long> Member { get; set; }

        /// <summary>
        /// Gets or sets the readonly member account id list.
        /// </summary>
        [JsonProperty("readonly")]
        public IReadOnlyCollection<long> Readonly { get; set; }
    }
}
