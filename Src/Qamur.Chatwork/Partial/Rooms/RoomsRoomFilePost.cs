// <copyright file="RoomsRoomFilePost.cs" company="Kohei Oizumi">
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
    using DataType = Qamur.Chatwork.Data.TargetFileData;
    using ParametersType = Qamur.Chatwork.Parameters.NewFileParameters;

    /// <summary>
    /// [POST] /rooms/{room_id}/files.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Uploads a new file and message.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The uploading file parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> PostRoomFile(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFiles, roomId);
            return APICommunicator.PostMultipart<DataType, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Uploads a new file and message asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The uploading file parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> PostRoomFileAsync(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFiles, roomId);
            return await APICommunicator.CreatePostMultipartTask<DataType, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads a new file and message asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The uploading file parameters.</param>
        public static async void PostRoomFileAsync(string token, Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFiles, roomId);
            await APICommunicator.CreatePostMultipartTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads a new file and message.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The uploading file parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> PostRoomFile(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFiles, roomId);
            return Communicator.PostMultipart<DataType, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Uploads a new file and message asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The uploading file parameters.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> PostRoomFileAsync(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFiles, roomId);
            return await Communicator.CreatePostMultipartTask<DataType, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads a new file and message asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The uploading file parameters.</param>
        public async void PostRoomFileAsync(Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFiles, roomId);
            await Communicator.CreatePostMultipartTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
