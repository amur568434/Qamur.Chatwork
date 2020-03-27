// <copyright file="RoomsGet.cs" company="Kohei Oizumi">
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
    using System.Threading.Tasks;
    using Qamur.Chatwork.Data;
    using APICommunicator = Qamur.Chatwork.Communicator.ChatworkCommunicator<Qamur.Chatwork.Communicator.APIV2Settings>;
    using DataType = System.Collections.Generic.IReadOnlyCollection<Qamur.Chatwork.Data.RoomData>;

    /// <summary>
    /// [GET] /rooms.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Get's the list of all chats on owner's account.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> GetRooms(string token)
        {
            return APICommunicator.Get<DataType>(token, Path.Rooms);
        }

        /// <summary>
        /// Get's the list of all chats on owner's account asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> GetRoomsAsync(string token)
        {
            return await APICommunicator.CreateGetTask<DataType>(token, Path.Rooms)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get's the list of all chats on owner's account asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        public static async void GetRoomsAsync(string token, Action<ResponseData<DataType>> callback)
        {
            await APICommunicator.CreateGetTask(token, callback, Path.Rooms)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get's the list of all chats on owner's account.
        /// </summary>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> GetRooms()
        {
            return Communicator.Get<DataType>(Path.Rooms);
        }

        /// <summary>
        /// Get's the list of all chats on owner's account asynchronously.
        /// </summary>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> GetRoomsAsync()
        {
            return await Communicator.CreateGetTask<DataType>(Path.Rooms)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get's the list of all chats on owner's account asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        public async void GetRoomsAsync(Action<ResponseData<DataType>> callback)
        {
            await Communicator.CreateGetTask(callback, Path.Rooms)
                .ConfigureAwait(false);
        }
    }
}
