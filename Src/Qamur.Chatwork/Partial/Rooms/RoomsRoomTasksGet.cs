// <copyright file="RoomsRoomTasksGet.cs" company="Kohei Oizumi">
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
    using DataType = System.Collections.Generic.IReadOnlyCollection<Qamur.Chatwork.Data.RoomTaskData>;
    using ParametersType = Qamur.Chatwork.Parameters.RoomTasksParameters;

    /// <summary>
    /// [GET] /rooms/{room_id}/tasks.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Gets the list of tasks associated with the specified chat.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The task's condition parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> GetRoomTasks(string token, long roomId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTasks, roomId);
            return APICommunicator.Get<DataType, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Gets the list of tasks associated with the specified chat asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The task's condition parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> GetRoomTasksAsync(string token, long roomId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTasks, roomId);
            return await APICommunicator.CreateGetTask<DataType, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the list of tasks associated with the specified chat asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The task's condition parameters.</param>
        public static async void GetRoomTasksAsync(string token, Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTasks, roomId);
            await APICommunicator.CreateGetTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the list of tasks associated with the specified chat.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The task's condition parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> GetRoomTasks(long roomId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTasks, roomId);
            return Communicator.Get<DataType, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Gets the list of tasks associated with the specified chat asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The task's condition parameters.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> GetRoomTasksAsync(long roomId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTasks, roomId);
            return await Communicator.CreateGetTask<DataType, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the list of tasks associated with the specified chat asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The task's condition parameters.</param>
        public async void GetRoomTasksAsync(Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters = null)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTasks, roomId);
            await Communicator.CreateGetTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
