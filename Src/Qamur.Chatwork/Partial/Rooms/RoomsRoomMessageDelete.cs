// <copyright file="RoomsRoomMessageDelete.cs" company="Kohei Oizumi">
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

    /// <summary>
    /// [DELETE] /rooms/{room_id}/messages/{message_id}.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Deletes chat messages owner have posted.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> DeleteRoomMessage(string token, long roomId, string messageId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            return APICommunicator.Delete<DataType>(token, path);
        }

        /// <summary>
        /// Deletes chat messages owner have posted aynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> DeleteRoomMessageAsync(string token, long roomId, string messageId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            return await APICommunicator.CreateDeleteTask<DataType>(token, path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes chat messages owner have posted aynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        public static async void DeleteRoomMessageAsync(string token, Action<ResponseData<DataType>> callback, long roomId, string messageId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            await APICommunicator.CreateDeleteTask(token, callback, path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes chat messages owner have posted.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> DeleteRoomMessage(long roomId, string messageId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            return Communicator.Delete<DataType>(path);
        }

        /// <summary>
        /// Deletes chat messages owner have posted aynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> DeleteRoomMessageAsync(long roomId, string messageId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            return await Communicator.CreateDeleteTask<DataType>(path)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes chat messages owner have posted aynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="messageId">The message id.</param>
        public async void DeleteRoomMessageAsync(Action<ResponseData<DataType>> callback, long roomId, string messageId)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMessage, roomId, messageId);
            await Communicator.CreateDeleteTask(callback, path)
                .ConfigureAwait(false);
        }
    }
}
