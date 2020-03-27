// <copyright file="RoomsRoomMembersPut.cs" company="Kohei Oizumi">
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
    using DateType = Qamur.Chatwork.Data.MembersSummaryData;
    using ParametersType = Qamur.Chatwork.Parameters.UpdateRoomMembersParameters;

    /// <summary>
    /// [PUT] /rooms/{room_id}/members.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Changes associated members of group chat at once.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The members updating parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DateType> PutRoomMembers(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMembers, roomId);
            return APICommunicator.Put<DateType, ParametersType>(token, path, parameters);
        }

        /// <summary>
        /// Changes associated members of group chat at once asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The members updating parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DateType>> PutRoomMembersAsync(string token, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMembers, roomId);
            return await APICommunicator.CreatePutTask<DateType, ParametersType>(token, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes associated members of group chat at once asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The members updating parameters.</param>
        public static async void PutRoomMembersAsync(string token, Action<ResponseData<DateType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMembers, roomId);
            await APICommunicator.CreatePutTask(token, callback, path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes associated members of group chat at once.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The members updating parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DateType> PutRoomMembers(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMembers, roomId);
            return Communicator.Put<DateType, ParametersType>(path, parameters);
        }

        /// <summary>
        /// Changes associated members of group chat at once asynchronously.
        /// </summary>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The members updating parameters.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DateType>> PutRoomMembersAsync(long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMembers, roomId);
            return await Communicator.CreatePutTask<DateType, ParametersType>(path, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Changes associated members of group chat at once asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="roomId">The chat room id.</param>
        /// <param name="parameters">The members updating parameters.</param>
        public async void PutRoomMembersAsync(Action<ResponseData<DateType>> callback, long roomId, ParametersType parameters)
        {
            var path = string.Format(CultureInfo.InvariantCulture, Path.RoomMembers, roomId);
            await Communicator.CreatePutTask(callback, path, parameters)
                .ConfigureAwait(false);
        }
    }
}
