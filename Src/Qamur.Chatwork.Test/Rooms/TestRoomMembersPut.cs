// <copyright file="TestRoomMembersPut.cs" company="Kohei Oizumi">
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
    /// [PUT] /rooms/{room_id}/members.
    /// </remarks>
    public class TestRoomMembersPut : ClientTestBase
    {
        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/members.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestPutRoomMembers()
        {
            Assert.NotEmpty(RoomList);

            var roomId = RoomList.First();
            var parameters = new UpdateRoomMembersParameters
            {
                MembersAdminIds = new long[] { AccountId },
                MembersMemberIds = MemberList,
                MembersReadonlyIds = null,
            };

            var response = Client.PutRoomMembers(roomId, parameters);
            AssertPutRoomMembersResponse(response, AccountId);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/members.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticPutRoomMembers()
        {
            Assert.NotEmpty(RoomList);

            var roomId = RoomList.First();
            var parameters = new UpdateRoomMembersParameters
            {
                MembersAdminIds = new long[] { AccountId },
                MembersMemberIds = null,
                MembersReadonlyIds = MemberList,
            };

            var response = ChatworkClient.PutRoomMembers(Token, roomId, parameters);
            AssertPutRoomMembersResponse(response, AccountId);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/members asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestPutRoomMembersAsync()
        {
            Assert.NotEmpty(RoomList);

            var roomId = RoomList.First();
            var parameters = new UpdateRoomMembersParameters
            {
                MembersAdminIds = new long[] { AccountId },
                MembersMemberIds = MemberList,
                MembersReadonlyIds = null,
            };

            var response = await Client.PutRoomMembersAsync(roomId, parameters)
                .ConfigureAwait(false);

            AssertPutRoomMembersResponse(response, AccountId);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/members asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticPutRoomMembersAsync()
        {
            Assert.NotEmpty(RoomList);

            var roomId = RoomList.First();
            var parameters = new UpdateRoomMembersParameters
            {
                MembersAdminIds = new long[] { AccountId },
                MembersMemberIds = MemberList,
                MembersReadonlyIds = null,
            };

            var response = await ChatworkClient.PutRoomMembersAsync(Token, roomId, parameters)
                .ConfigureAwait(false);

            AssertPutRoomMembersResponse(response, AccountId);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/members asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestPutRoomMembersAsyncCallback()
        {
            Assert.NotEmpty(RoomList);

            var roomId = RoomList.First();
            var parameters = new UpdateRoomMembersParameters
            {
                MembersAdminIds = new long[] { AccountId },
                MembersMemberIds = MemberList,
                MembersReadonlyIds = null,
            };

            Client.PutRoomMembersAsync(
                response => AssertPutRoomMembersResponse(response, AccountId),
                roomId,
                parameters);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/members asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticPutRoomMembersAsyncCallback()
        {
            Assert.NotEmpty(RoomList);

            var roomId = RoomList.First();
            var parameters = new UpdateRoomMembersParameters
            {
                MembersAdminIds = new long[] { AccountId },
                MembersMemberIds = MemberList,
                MembersReadonlyIds = null,
            };

            ChatworkClient.PutRoomMembersAsync(
                Token,
                response => AssertPutRoomMembersResponse(response, AccountId),
                roomId,
                parameters);
        }

        /// <summary>
        /// Asserts "[PUT] /rooms/{room_id}/members" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="accountId">The member account id.</param>
        private static void AssertPutRoomMembersResponse(ResponseData<MembersSummaryData> response, long accountId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.NotEmpty(data.Admin);
            Assert.Contains(accountId, data.Admin);
        }
    }
}
