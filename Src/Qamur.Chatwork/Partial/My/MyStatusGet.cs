// <copyright file="MyStatusGet.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork
{
    using System;
    using System.Threading.Tasks;
    using Qamur.Chatwork.Data;
    using APICommunicator = Qamur.Chatwork.Communicator.ChatworkCommunicator<Qamur.Chatwork.Communicator.APIV2Settings>;
    using DataType = Qamur.Chatwork.Data.MyStatusData;

    /// <summary>
    /// [GET] /my/status.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Gets the number of: unread messages, unread To messages, and unfinished tasks.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <returns>THe response data.</returns>
        public static ResponseData<DataType> GetMyStatus(string token)
        {
            return APICommunicator.Get<DataType>(token, Path.MyStatus);
        }

        /// <summary>
        /// Gets the number of: unread messages, unread To messages, and unfinished tasks asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <returns>THe response data.</returns>
        public static async Task<ResponseData<DataType>> GetMyStatusAsync(string token)
        {
            return await APICommunicator.CreateGetTask<DataType>(token, Path.MyStatus)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the number of: unread messages, unread To messages, and unfinished tasks asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        public static async void GetMyStatusAsync(string token, Action<ResponseData<DataType>> callback)
        {
            await APICommunicator.CreateGetTask(token, callback, Path.MyStatus)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the number of: unread messages, unread To messages, and unfinished tasks.
        /// </summary>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> GetMyStatus()
        {
            return Communicator.Get<DataType>(Path.MyStatus);
        }

        /// <summary>
        /// Gets the number of: unread messages, unread To messages, and unfinished tasks asynchronously.
        /// </summary>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> GetMyStatusAsync()
        {
            return await Communicator.CreateGetTask<DataType>(Path.MyStatus)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the number of: unread messages, unread To messages, and unfinished tasks asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        public async void GetMyStatusAsync(Action<ResponseData<DataType>> callback)
        {
            await Communicator.CreateGetTask(callback, Path.MyStatus)
                .ConfigureAwait(false);
        }
    }
}
