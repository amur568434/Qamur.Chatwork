// <copyright file="IncomingRequestsRequestDelete.cs" company="Kohei Oizumi">
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
    using System.Globalization;
    using System.Threading.Tasks;
    using Qamur.Chatwork.Data;
    using APICommunicator = Qamur.Chatwork.Communicator.ChatworkCommunicator<Qamur.Chatwork.Communicator.APIV2Settings>;

    /// <summary>
    /// [DELETE] /incoming_requests/{request_id}.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Declines a contact approval request.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="requestId">The request id.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<object> DeleteIncomingRequest(string token, long requestId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.IncomingRequest, requestId);
            return APICommunicator.Delete<object>(token, path);
        }

        /// <summary>
        /// Declines a contact approval request asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="requestId">The request id.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<object>> DeleteIncomingRequestAsync(string token, long requestId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.IncomingRequest, requestId);
            return await APICommunicator.CreateDeleteTask<object>(token, path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Declines a contact approval request asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="requestId">The request id.</param>
        public static async void DeleteIncomingRequestAsync(string token, Action<ResponseData<object>> callback, long requestId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.IncomingRequest, requestId);
            await APICommunicator.CreateDeleteTask(token, callback, path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Declines a contact approval request.
        /// </summary>
        /// <param name="requestId">The request id.</param>
        /// <returns>THe response data.</returns>
        public ResponseData<object> DeleteIncomingRequest(long requestId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.IncomingRequest, requestId);
            return Communicator.Delete<object>(path);
        }

        /// <summary>
        /// Declines a contact approval request asynchronously.
        /// </summary>
        /// <param name="requestId">The request id.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<object>> DeleteIncomingRequestAsync(long requestId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.IncomingRequest, requestId);
            return await Communicator.CreateDeleteTask<object>(path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Declines a contact approval request asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="requestId">The request id.</param>
        public async void DeleteIncomingRequestAsync(Action<ResponseData<object>> callback, long requestId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.IncomingRequest, requestId);
            await Communicator.CreateDeleteTask(callback, path)
                .ConfigureAwait(false);
        }
    }
}
