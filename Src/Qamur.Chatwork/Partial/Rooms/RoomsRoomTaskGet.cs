﻿// <copyright file="RoomsRoomTaskGet.cs" company="Kohei Oizumi">
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
    using Datatype = Qamur.Chatwork.Data.RoomTaskData;

    /// <summary>
    /// [GET] /rooms/{room_id}/tasks/{task_id}.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Gets information about the specified task.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<Datatype> GetRoomTask(string token, long roomId, long taskId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTask, roomId, taskId);
            return APICommunicator.Get<Datatype>(token, path);
        }

        /// <summary>
        /// Gets information about the specified task asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<Datatype>> GetRoomTaskAsync(string token, long roomId, long taskId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTask, roomId, taskId);
            return await APICommunicator.CreateGetTask<Datatype>(token, path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about the specified task asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        public static async void GetRoomTaskAsync(string token, Action<ResponseData<Datatype>> callback, long roomId, long taskId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTask, roomId, taskId);
            await APICommunicator.CreateGetTask(token, callback, path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about the specified task.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <returns>The response data.</returns>
        public ResponseData<Datatype> GetRoomTask(long roomId, long taskId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTask, roomId, taskId);
            return Communicator.Get<Datatype>(path);
        }

        /// <summary>
        /// Gets information about the specified task asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<Datatype>> GetRoomTaskAsync(long roomId, long taskId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTask, roomId, taskId);
            return await Communicator.CreateGetTask<Datatype>(path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about the specified task asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        public async void GetRoomTaskAsync(Action<ResponseData<Datatype>> callback, long roomId, long taskId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTask, roomId, taskId);
            await Communicator.CreateGetTask(callback, path)
                .ConfigureAwait(false);
        }
    }
}
