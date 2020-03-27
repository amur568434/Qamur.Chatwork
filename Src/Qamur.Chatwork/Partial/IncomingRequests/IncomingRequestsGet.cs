// <copyright file="IncomingRequestsGet.cs" company="Kohei Oizumi">
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
    using DataType = System.Collections.Generic.IReadOnlyCollection<Qamur.Chatwork.Data.IncomingRequestData>;

    /// <summary>
    /// [GET] /incoming_requests.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Get the list of owner's contact.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> GetIncomingRequests(string token)
        {
            return APICommunicator.Get<DataType>(token, Path.IncomingRequests);
        }

        /// <summary>
        /// Get the list of owner's contact asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> GetIncomingRequestsAsync(string token)
        {
            return await APICommunicator.CreateGetTask<DataType>(token, Path.IncomingRequests)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get the list of owner's contact asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        public static async void GetIncomingRequestsAsync(string token, Action<ResponseData<DataType>> callback)
        {
            await APICommunicator.CreateGetTask(token, callback, Path.IncomingRequests)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get the list of owner's contact.
        /// </summary>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> GetIncomingRequests()
        {
            return Communicator.Get<DataType>(Path.IncomingRequests);
        }

        /// <summary>
        /// Get the list of owner's contact asynchronously.
        /// </summary>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> GetIncomingRequestsAsync()
        {
            return await Communicator.CreateGetTask<DataType>(Path.IncomingRequests)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get the list of owner's contact asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        public async void GetIncomingRequestsAsync(Action<ResponseData<DataType>> callback)
        {
            await Communicator.CreateGetTask(callback, Path.IncomingRequests)
                .ConfigureAwait(false);
        }
    }
}
