// <copyright file="RoomsRoomDelete.cs" company="Kohei Oizumi">
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
    using ParametersType = Qamur.Chatwork.Parameters.DeleteRoomParameters;

    /// <summary>
    /// [DELETE] /rooms/{room_id}.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Leaves/Deletes a group chat.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The action parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<object> DeleteRoom(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return APICommunicator.Delete<object, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Leaves/Deletes a group chat asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The action parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<object>> DeleteRoomAsync(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return await APICommunicator.CreateDeleteTask<object, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Leaves/Deletes a group chat asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The action parameters.</param>
        public static async void DeleteRoomAsync(string token, Action<ResponseData<object>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            await APICommunicator.CreateDeleteTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Leaves/Deletes a group chat.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The action parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<object> DeleteRoom(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return Communicator.Delete<object, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Leaves/Deletes a group chat asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The action parameters.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<object>> DeleteRoomAsync(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            return await Communicator.CreateDeleteTask<object, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Leaves/Deletes a group chat asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The action parameters.</param>
        public async void DeleteRoomAsync(Action<ResponseData<object>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.Room, roomId);
            await Communicator.CreateDeleteTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
