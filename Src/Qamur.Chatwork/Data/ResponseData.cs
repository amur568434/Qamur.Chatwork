// <copyright file="ResponseData.cs" company="Kohei Oizumi">
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
    /// <summary>
    /// Response data.
    /// </summary>
    /// <typeparam name="T">The success response data type.</typeparam>
    public class ResponseData<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the request succeeded or failed.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the response status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets success response data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets error response data.
        /// </summary>
        public ErrorData Error { get; set; }
    }
}
