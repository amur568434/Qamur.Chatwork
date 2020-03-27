// <copyright file="RoomsRoomMessagesReadPut.cs" company="Kohei Oizumi">
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
    using DataType = Qamur.Chatwork.Data.MessagesUnreadSummaryData;
    using ParametersType = Qamur.Chatwork.Parameters.TargetMessageParameters;

    /// <summary>
    /// [PUT] /rooms/{room_id}/messages/read.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Changes messages read status to read.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The messsages position parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> PutRoomMessagesRead(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessagesRead, roomId);
            return APICommunicator.Put<DataType, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Changes messages read status to read asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The messsages position parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> PutRoomMessagesReadAsync(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessagesRead, roomId);
            return await APICommunicator.CreatePostTask<DataType, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes messages read status to read asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The messsages position parameters.</param>
        public static async void PutRoomMessagesReadAsync(string token, Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessagesRead, roomId);
            await APICommunicator.CreatePostTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes messages read status to read.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The messsages position parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> PutRoomMessagesRead(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessagesRead, roomId);
            return Communicator.Put<DataType, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Changes messages read status to read asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The messsages position parameters.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> PutRoomMessagesReadAsync(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessagesRead, roomId);
            return await Communicator.CreatePostTask<DataType, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes messages read status to read asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The messsages position parameters.</param>
        public async void PutRoomMessagesReadAsync(Action<ResponseData<DataType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessagesRead, roomId);
            await Communicator.CreatePostTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
