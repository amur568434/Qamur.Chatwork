// <copyright file="RoomsRoomTaskStatusPut.cs" company="Kohei Oizumi">
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
    using DataType = Qamur.Chatwork.Data.TargetRoomTaskData;
    using ParametersType = Qamur.Chatwork.Parameters.UpdateRoomTaskStatusParameters;

    /// <summary>
    /// [PUT] /rooms/{room_id}/tasks/{task_id}/status.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Changes the specified task's status.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <param name="parameters">the updating task parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> PutRoomTaskStatus(string token, long roomId, long taskId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTaskStatus, roomId, taskId);
            return APICommunicator.Put<DataType, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Changes the specified task's status asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <param name="parameters">the updating task parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> PutRoomTaskStatusAsync(string token, long roomId, long taskId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTaskStatus, roomId, taskId);
            return await APICommunicator.CreatePutTask<DataType, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes the specified task's status asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <param name="parameters">the updating task parameters.</param>
        public static async void PutRoomTaskStatusAsync(string token, Action<ResponseData<DataType>> callback, long roomId, long taskId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTaskStatus, roomId, taskId);
            await APICommunicator.CreatePutTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes the specified task's status.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <param name="parameters">The updating task parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> PutRoomTaskStatus(long roomId, long taskId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTaskStatus, roomId, taskId);
            return Communicator.Put<DataType, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Changes the specified task's status asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <param name="parameters">the updating task parameters.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> PutRoomTaskStatusAsync(long roomId, long taskId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTaskStatus, roomId, taskId);
            return await Communicator.CreatePutTask<DataType, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes the specified task's status asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="taskId">The task id.</param>
        /// <param name="parameters">the updating task parameters.</param>
        public async void PutRoomTaskStatusAsync(Action<ResponseData<DataType>> callback, long roomId, long taskId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomTaskStatus, roomId, taskId);
            await Communicator.CreatePutTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
