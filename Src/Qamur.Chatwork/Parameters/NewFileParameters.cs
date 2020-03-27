// <copyright file="NewFileParameters.cs" company="Kohei Oizumi">
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
    /// The parameters for uploading a new file and message.
    /// </summary>
    public class NewFileParameters
    {
        /// <summary>
        /// Gets or sets the file information.
        /// <see cref="FileContent"/>.
        /// </summary>
        [JsonProperty("file", Required = Required.Always)]
        public FileContent File { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
