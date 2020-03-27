// <copyright file="RoomsRoomMessagePut.cs" company="Kohei Oizumi">
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
    using DataType = Qamur.Chatwork.Data.TargetMessageData;
    using ParametersType = Qamur.Chatwork.Parameters.UpdateMessageParameters;

    /// <summary>
    /// [PUT] /rooms/{room_id}/messages/{message_id}.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Updates chat messages owner have posted.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <param name="parameters">The updating message parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> PutRoomMessage(string token, long roomId, string messageId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            return APICommunicator.Put<DataType, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Updates chat messages owner have posted asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <param name="parameters">The updating message parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> PutRoomMessageAsync(string token, long roomId, string messageId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            return await APICommunicator.CreatePutTask<DataType, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Updates chat messages owner have posted asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <param name="parameters">The updating message parameters.</param>
        public static async void PutRoomMessageAsync(string token, Action<ResponseData<DataType>> callback, long roomId, string messageId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            await APICommunicator.CreatePutTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Updates chat messages owner have posted.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <param name="parameters">The updating message parameters.</param>
        /// <returns>THe response data.</returns>
        public ResponseData<DataType> PutRoomMessage(long roomId, string messageId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            return Communicator.Put<DataType, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Updates chat messages owner have posted asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <param name="parameters">The updating message parameters.</param>
        /// <returns>THe response data.</returns>
        public async Task<ResponseData<DataType>> PutRoomMessageAsync(long roomId, string messageId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            return await Communicator.CreatePutTask<DataType, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Updates chat messages owner have posted asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <param name="parameters">The updating message parameters.</param>
        public async void PutRoomMessageAsync(Action<ResponseData<DataType>> callback, long roomId, string messageId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            await Communicator.CreatePutTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
