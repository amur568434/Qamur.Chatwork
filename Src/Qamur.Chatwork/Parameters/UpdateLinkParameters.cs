// <copyright file="UpdateLinkParameters.cs" company="Kohei Oizumi">
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

    /// <summary>
    /// The parameters for creating or updating a room link information.
    /// </summary>
    public class UpdateLinkParameters
    {
        /// <summary>
        /// Gets or sets the link code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the administrator determines the need for acceptance.
        /// </summary>
        [JsonProperty("need_acceptance")]
        public bool NeedAcceptance { get; set; }
    }
}
