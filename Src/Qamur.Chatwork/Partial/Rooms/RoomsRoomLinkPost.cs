// <copyright file="RoomsRoomLinkPost.cs" company="Kohei Oizumi">
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
    using DataType = Qamur.Chatwork.Data.LinkData;
    using ParametersType = Qamur.Chatwork.Parameters.UpdateLinkParameters;

    /// <summary>
    /// [POST] /rooms/{room_id}/link.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Adds the room link information.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room link parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> PostRoomLink(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomLink, roomId);
            return APICommunicator.Post<DataType, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Adds the room link information asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room link parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> PostRoomLinkAsync(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomLink, roomId);
            return await APICommunicator.CreatePostTask<DataType, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the room link information asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room link parameters.</param>
        public static async void PostRoomLinkAsync(string token, Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomLink, roomId);
            await APICommunicator.CreatePostTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the room link information.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room link parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> PostRoomLink(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomLink, roomId);
            return Communicator.Post<DataType, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Adds the room link information asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room link parameters.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> PostRoomLinkAsync(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomLink, roomId);
            return await Communicator.CreatePostTask<DataType, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the room link information asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room link parameters.</param>
        public async void PostRoomLinkAsync(Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomLink, roomId);
            await Communicator.CreatePostTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
