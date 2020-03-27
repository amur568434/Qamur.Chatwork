// <copyright file="TestMyStatusGet.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Client.Test.My
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
    /// [GET] /my/status.
    /// </remarks>
    public class TestMyStatusGet : ClientTestBase
    {
        /// <summary>
        /// Tests [GET] /my/status.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestGetMyStatus()
        {
            var response = Client.GetMyStatus();
            AssertGetMyStatusResponse(response);
        }

        /// <summary>
        /// Tests [GET] /my/status.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetMyStatus()
        {
            var response = ChatworkClient.GetMyStatus(Token);
            AssertGetMyStatusResponse(response);
        }

        /// <summary>
        /// Tests [GET] /my/status asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestGetMyStatusAsync()
        {
            var response = await Client.GetMyStatusAsync()
                .ConfigureAwait(false);

            AssertGetMyStatusResponse(response);
        }

        /// <summary>
        /// Tests [GET] /my/status asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticGetMyStatusAsync()
        {
            var response = await ChatworkClient.GetMyStatusAsync(Token)
                .ConfigureAwait(false);

            AssertGetMyStatusResponse(response);
        }

        /// <summary>
        /// Tests [GET] /my/status asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestGetMyStatusAsyncCallback()
        {
            Client.GetMyStatusAsync(AssertGetMyStatusResponse);
        }

        /// <summary>
        /// Tests [GET] /my/status asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetMyStatusAsyncCallback()
        {
            ChatworkClient.GetMyStatusAsync(Token, AssertGetMyStatusResponse);
        }

        /// <summary>
        /// Asserts "[GET] /my/status" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetMyStatusResponse(ResponseData<MyStatusData> response)
        {
            Assert.True(response.Success);
            Assert.NotNull(response.Data);
        }
    }
}
