// <copyright file="TestRoomFilesGet.cs" company="Kohei Oizumi">
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
    /// [GET] /rooms/{room_id}/files.
    /// </remarks>
    public class TestRoomFilesGet : ClientTestBase
    {
        /// <summary>
        /// Tests [GET] /rooms/{room_id}/files.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestGetRoomFiles()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new FilesParameters
            {
                AccountId = AccountId,
            };

            var response = Client.GetRoomFiles(roomId, parameters);
            AssertGetFilesResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/files.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetRoomFiles()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new FilesParameters
            {
                AccountId = AccountId,
            };

            var response = ChatworkClient.GetRoomFiles(Token, roomId, parameters);
            AssertGetFilesResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/files asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestGetRoomFilesAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new FilesParameters
            {
                AccountId = AccountId,
            };

            var response = await Client.GetRoomFilesAsync(roomId, parameters)
                .ConfigureAwait(false);

            AssertGetFilesResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/files asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticGetRoomFilesAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new FilesParameters
            {
                AccountId = AccountId,
            };

            var response = await ChatworkClient.GetRoomFilesAsync(Token, roomId, parameters)
                .ConfigureAwait(false);

            AssertGetFilesResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/files asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestGetRoomFilesAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new FilesParameters
            {
                AccountId = AccountId,
            };

            Client.GetRoomFilesAsync(
                AssertGetFilesResponse,
                roomId,
                parameters);
        }

        /// <summary>
        /// Tests [GET] /rooms/{room_id}/files asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetRoomFilesAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var parameters = new FilesParameters
            {
                AccountId = AccountId,
            };

            ChatworkClient.GetRoomFilesAsync(
                Token,
                AssertGetFilesResponse,
                roomId,
                parameters);
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}/files" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetFilesResponse(ResponseData<IReadOnlyCollection<FileData>> response)
        {
            Assert.True(response.Success);
            Assert.NotNull(response.Data);
        }
    }
}
