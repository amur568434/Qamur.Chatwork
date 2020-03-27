// <copyright file="TestMeGet.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Test.Profile
{
    using Qamur.Chatwork.Data;
    using Qamur.Chatwork.Test;
    using Xunit;
    using static Qamur.Chatwork.Test.SkipText;

    /// <summary>
    /// Test class.
    /// </summary>
    /// <remarks>
    /// This test class runs the following path tests.
    /// [GET] /me.
    /// </remarks>
    public class TestMeGet : ClientTestBase
    {
        /// <summary>
        /// Tests [GET] /me.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestGetMe()
        {
            var response = Client.GetMe();
            AssertGetMeResponse(response, Room, AccountId);
        }

        /// <summary>
        /// Tests [GET] /me.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetMe()
        {
            var response = ChatworkClient.GetMe(Token);
            AssertGetMeResponse(response, Room, AccountId);
        }

        /// <summary>
        /// Tests [GET] /me asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestGetMeAsync()
        {
            var response = await Client.GetMeAsync()
                .ConfigureAwait(false);

            AssertGetMeResponse(response, Room, AccountId);
        }

        /// <summary>
        /// Tests [GET] /me asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticGetMeAsync()
        {
            var response = await ChatworkClient.GetMeAsync(Token)
                .ConfigureAwait(false);

            AssertGetMeResponse(response, Room, AccountId);
        }

        /// <summary>
        /// Tests [GET] /me asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestGetMeAsyncCallback()
        {
            Client.GetMeAsync(
                response => AssertGetMeResponse(response, Room, AccountId));
        }

        /// <summary>
        /// Tests [GET] /me asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetMeAsyncCallback()
        {
            ChatworkClient.GetMeAsync(
                Token,
                response => AssertGetMeResponse(response, Room, AccountId));
        }

        /// <summary>
        /// Asserts "[GET] /me" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="roomId">The room id.</param>
        /// <param name="accountId">The account id.</param>
        private static void AssertGetMeResponse(ResponseData<ProfileData> response, long roomId, long accountId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Equal(roomId, data.RoomId);
            Assert.Equal(accountId, data.AccountId);
        }
    }
}
