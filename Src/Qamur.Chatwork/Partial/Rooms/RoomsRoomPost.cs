// <copyright file="RoomsRoomPost.cs" company="Kohei Oizumi">
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
    using DataType = Qamur.Chatwork.Data.TargetRoomData;
    using ParametersType = Qamur.Chatwork.Parameters.NewRoomParameters;

    /// <summary>
    /// [POST] /rooms.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Creates a new group chat.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="parameters">The new room parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> PostRoom(string token, ParametersType parameters)
        {
            return APICommunicator.Post<DataType, ParametersType>(token, Path.Rooms, parameters);
        }

        /// <summary>
        /// Creates a new group chat asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="parameters">The new room parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> PostRoomAsync(string token, ParametersType parameters)
        {
            return await APICommunicator.CreatePostTask<DataType, ParametersType>(token, Path.Rooms, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new group chat asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="parameters">The new room parameters.</param>
        public static async void PostRoomAsync(string token, Action<ResponseData<DataType>> callback, ParametersType parameters)
        {
            await APICommunicator.CreatePostTask(token, callback, Path.Rooms, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new group chat.
        /// </summary>
        /// <param name="parameters">The new room parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> PostRoom(ParametersType parameters)
        {
            return Communicator.Post<DataType, ParametersType>(Path.Rooms, parameters);
        }

        /// <summary>
        /// Creates a new group chat asynchronously.
        /// </summary>
        /// <param name="parameters">The new room parameters.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> PostRoomAsync(ParametersType parameters)
        {
            return await Communicator.CreatePostTask<DataType, ParametersType>(Path.Rooms, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new group chat asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="parameters">The new room parameters.</param>
        public async void PostRoomAsync(Action<ResponseData<DataType>> callback, ParametersType parameters)
        {
            await Communicator.CreatePostTask(callback, Path.Rooms, parameters)
                .ConfigureAwait(false);
        }
    }
}
