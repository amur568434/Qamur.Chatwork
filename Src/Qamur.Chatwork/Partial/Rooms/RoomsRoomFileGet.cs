// <copyright file="RoomsRoomFileGet.cs" company="Kohei Oizumi">
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
    using DataType = Qamur.Chatwork.Data.FileData;
    using ParametersType = Qamur.Chatwork.Parameters.FileParameters;

    /// <summary>
    /// [GET] /rooms/{room_id}/files/{file_id}.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Gets information about the specified file.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="fileId">The file id.</param>
        /// <param name="parameters">The file condition parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> GetRoomFile(string token, long roomId, long fileId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFile, roomId, fileId);
            return APICommunicator.Get<DataType, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Gets information about the specified file asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="fileId">The file id.</param>
        /// <param name="parameters">The file condition parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> GetRoomFileAsync(string token, long roomId, long fileId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFile, roomId, fileId);
            return await APICommunicator.CreateGetTask<DataType, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about the specified file asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="fileId">The file id.</param>
        /// <param name="parameters">The file condition parameters.</param>
        public static async void GetRoomFileAsync(
            string token,
            Action<ResponseData<DataType>> callback,
            long roomId,
            long fileId,
            ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFile, roomId, fileId);
            await APICommunicator.CreateGetTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about the specified file.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="fileId">The file id.</param>
        /// <param name="parameters">The file condition parameters.</param>
        /// <returns>Response data.</returns>
        public ResponseData<DataType> GetRoomFile(long roomId, long fileId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFile, roomId, fileId);
            return Communicator.Get<DataType, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Gets information about the specified file asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="fileId">The file id.</param>
        /// <param name="parameters">The file condition parameters.</param>
        /// <returns>Response data.</returns>
        public async Task<ResponseData<DataType>> GetRoomFileAsync(long roomId, long fileId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFile, roomId, fileId);
            return await Communicator.CreateGetTask<DataType, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about the specified file asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="fileId">The file id.</param>
        /// <param name="parameters">The file condition parameters.</param>
        public async void GetRoomFileAsync(Action<ResponseData<DataType>> callback, long roomId, long fileId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomFile, roomId, fileId);
            await Communicator.CreateGetTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
