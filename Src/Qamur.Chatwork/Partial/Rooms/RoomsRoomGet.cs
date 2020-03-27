// <copyright file="RoomsRoomGet.cs" company="Kohei Oizumi">
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
    using DataType = Qamur.Chatwork.Data.RoomData;

    /// <summary>
    /// [GET] /rooms/{room_id}.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Gets chat name, icon, and type (my, direct, or group).
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> GetRoom(string token, long roomId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return APICommunicator.Get<DataType>(token, path);
        }

        /// <summary>
        /// Gets chat name, icon, and type (my, direct, or group) asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> GetRoomAsync(string token, long roomId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return await APICommunicator.CreateGetTask<DataType>(token, path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets chat name, icon, and type (my, direct, or group) asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        public static async void GetRoomAsync(string token, Action<ResponseData<DataType>> callback, long roomId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            await APICommunicator.CreateGetTask(token, callback, path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets chat name, icon, and type (my, direct, or group).
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> GetRoom(long roomId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return Communicator.Get<DataType>(path);
        }

        /// <summary>
        /// Gets chat name, icon, and type (my, direct, or group) asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> GetRoomAsync(long roomId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return await Communicator.CreateGetTask<DataType>(path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets chat name, icon, and type (my, direct, or group) asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        public async void GetRoomAsync(Action<ResponseData<DataType>> callback, long roomId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            await Communicator.CreateGetTask(callback, path)
                .ConfigureAwait(false);
        }
    }
}
