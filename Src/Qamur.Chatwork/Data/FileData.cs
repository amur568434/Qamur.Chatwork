// <copyright file="FileData.cs" company="Kohei Oizumi">
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
    /// File data.
    /// </summary>
    public class FileData
    {
        /// <summary>
        /// Gets or sets the file id.
        /// </summary>
        [JsonProperty("file_id")]
        public long FileId { get; set; }

        /// <summary>
        /// Gets or sets the account data.
        /// </summary>
        [JsonProperty("account")]
        public AccountData Account { get; set; }

        /// <summary>
        /// Gets or sets the message id.
        /// </summary>
        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        [JsonProperty("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the file size.
        /// </summary>
        [JsonProperty("filesize")]
        public long Filesize { get; set; }

        /// <summary>
        /// Gets or sets the file upload datetime.
        /// </summary>
        [JsonProperty("upload_time")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset UploadTime { get; set; }
    }
}
