// <copyright file="TestRoomsGet.cs" company="Kohei Oizumi">
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
    using Qamur.Chatwork.Data;
    using Qamur.Chatwork.Test;
    using Xunit;
    using static Qamur.Chatwork.Test.SkipText;

    /// <summary>
    /// Test class.
    /// </summary>
    /// <remarks>
    /// This test class runs the following path tests.
    /// [GET] /rooms.
    /// </remarks>
    public class TestRoomsGet : ClientTestBase
    {
        /// <summary>
        /// Tests [GET] /rooms.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestGetRooms()
        {
            var response = Client.GetRooms();
            AssertGetRoomsResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetRooms()
        {
            var response = ChatworkClient.GetRooms(Token);
            AssertGetRoomsResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestGetRoomsAsync()
        {
            var response = await Client.GetRoomsAsync()
                .ConfigureAwait(false);

            AssertGetRoomsResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticGetRoomsAsync()
        {
            var response = await ChatworkClient.GetRoomsAsync(Token)
                .ConfigureAwait(false);

            AssertGetRoomsResponse(response);
        }

        /// <summary>
        /// Tests [GET] /rooms asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestGetRoomsAsyncCallback()
        {
            Client.GetRoomsAsync(AssertGetRoomsResponse);
        }

        /// <summary>
        /// Tests [GET] /rooms asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetRoomsAsyncCallback()
        {
            ChatworkClient.GetRoomsAsync(Token, AssertGetRoomsResponse);
        }

        /// <summary>
        /// Asserts "[GET] /rooms" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetRoomsResponse(ResponseData<IReadOnlyCollection<RoomData>> response)
        {
            Assert.True(response.Success);
            Assert.NotNull(response.Data);
        }
    }
}
