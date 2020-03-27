// <copyright file="RoomsRoomPut.cs" company="Kohei Oizumi">
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
    using DataType = Qamur.Chatwork.Data.TargetRoomData;
    using ParametersType = Qamur.Chatwork.Parameters.UpdateRoomParameters;

    /// <summary>
    /// [PUT] /rooms/{room_id}.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Changes the title and icon type of the specified chat.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room updating data.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> PutRoom(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return APICommunicator.Put<DataType, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Changes the title and icon type of the specified chat asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room updating data.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> PutRoomAsync(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return await APICommunicator.CreatePutTask<DataType, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes the title and icon type of the specified chat asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room updating data.</param>
        public static async void PutRoomAsync(string token, Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            await APICommunicator.CreatePutTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes the title and icon type of the specified chat.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room updating data.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> PutRoom(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return Communicator.Put<DataType, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Changes the title and icon type of the specified chat asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room updating data.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> PutRoomAsync(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return await Communicator.CreatePutTask<DataType, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes the title and icon type of the specified chat asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The room updating data.</param>
        public async void PutRoomAsync(Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            await Communicator.CreatePutTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
