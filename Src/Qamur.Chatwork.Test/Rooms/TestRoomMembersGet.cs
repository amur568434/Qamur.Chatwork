// <copyright file="TestRoomMembersGet.cs" company="Kohei Oizumi">
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
    using Qamur.Chatwork.Test;
    using Xunit;
    using static Qamur.Chatwork.Test.SkipText;

    /// <summary>
    /// Test class.
    /// </summary>
    /// <remarks>
    /// This test class runs the following path tests.
    /// [GET] /rooms/{room_id}/members.
    /// </remarks>
    public class TestRoomMembersGet : ClientTestBase
    {
        /// <summary>
        /// Tests [GET] /rooms/{room_id}/members.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestGetRoomMembers()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var response = Client.GetRoomMembers(roomId);
            AssertGetRoomMembersResponse(response, AccountId);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/members.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetRoomMembers()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var response = ChatworkClient.GetRoomMembers(Token, roomId);
            AssertGetRoomMembersResponse(response, AccountId);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/members asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestGetRoomMembersAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var response = await Client.GetRoomMembersAsync(roomId)
                .ConfigureAwait(false);

            AssertGetRoomMembersResponse(response, AccountId);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/members asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticGetRoomMembersAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var response = await ChatworkClient.GetRoomMembersAsync(Token, roomId)
                .ConfigureAwait(false);

            AssertGetRoomMembersResponse(response, AccountId);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/members asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestGetRoomMembersAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            Client.GetRoomMembersAsync(
                response => AssertGetRoomMembersResponse(response, AccountId),
                roomId);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/members asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetRoomMembersAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            ChatworkClient.GetRoomMembersAsync(
                Token,
                response => AssertGetRoomMembersResponse(response, AccountId),
                roomId);
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}/members" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="accountId">The member account id.</param>
        private static void AssertGetRoomMembersResponse(ResponseData<IReadOnlyCollection<MemberData>> response, long accountId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Contains(accountId, data.Select(x => x.AccountId));
        }
    }
}
