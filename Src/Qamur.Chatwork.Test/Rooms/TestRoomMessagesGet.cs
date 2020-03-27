// <copyright file="TestRoomMessagesGet.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Test.Rooms
{
    using System.Collections.Generic;
    using System.Linq;
    using Qamur.Chatwork.Data;
    using Qamur.Chatwork.Parameters;
    using Qamur.Chatwork.Test;
    using Xunit;
    using static Qamur.Chatwork.Test.SkipText;

    /// <summary>
    /// Test class.
    /// </summary>
    /// <remarks>
    /// This test class runs the following path tests.
    /// [GET] /rooms/{room_id}/messages.
    /// </remarks>
    public class TestRoomMessagesGet : ClientTestBase
    {
        /// <summary>
        /// Tests [GET] /rooms/{room_id}/messages.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestGetRoomMessages()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new MessagesParameters { Force = true };
            var response = Client.GetRoomMessages(roomId, parameters);
            AssertGetRoomMessagesResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/messages.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetRoomMembers()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new MessagesParameters { Force = true };
            var response = ChatworkClient.GetRoomMessages(Token, roomId, parameters);
            AssertGetRoomMessagesResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/messages asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestGetRoomMessagesAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new MessagesParameters { Force = true };
            var response = await Client
                .GetRoomMessagesAsync(roomId, parameters)
                .ConfigureAwait(false);

            AssertGetRoomMessagesResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/messages asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticGetRoomMessagesAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new MessagesParameters { Force = true };
            var response = await ChatworkClient
                .GetRoomMessagesAsync(Token, roomId, parameters)
                .ConfigureAwait(false);

            AssertGetRoomMessagesResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/messages asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestGetRoomMessagesAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new MessagesParameters { Force = true };
            Client.GetRoomMessagesAsync(
                AssertGetRoomMessagesResponse,
                roomId,
                parameters);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/messages asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetRoomMessagesAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new MessagesParameters { Force = true };
            ChatworkClient.GetRoomMessagesAsync(
                Token,
                AssertGetRoomMessagesResponse,
                roomId,
                parameters);
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}/messages" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetRoomMessagesResponse(ResponseData<IReadOnlyCollection<MessageData>> response)
        {
            Assert.True(response.Success);
        }
    }
}
