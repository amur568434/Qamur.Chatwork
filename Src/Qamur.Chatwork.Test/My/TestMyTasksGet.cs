// <copyright file="TestMyTasksGet.cs" company="Kohei Oizumi">
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
    using System.Collections.Generic;
    using Qamur.Chatwork.Data;
    using Qamur.Chatwork.ObjectValues;
    using Qamur.Chatwork.Parameters;
    using Qamur.Chatwork.Test;
    using Xunit;
    using static Qamur.Chatwork.Test.SkipText;

    /// <summary>
    /// Test class.
    /// </summary>
    /// <remarks>
    /// This test class runs the following path tests.
    /// [GET] /my/tasks.
    /// </remarks>
    public class TestMyTasksGet : ClientTestBase
    {
        /// <summary>
        /// Tests [GET] /my/tasks.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestGetMyTasks()
        {
            var parameters = new MyTasksParameters
            {
                Status = TaskStatusValue.Open,
            };

            var response = Client.GetMyTasks(parameters);
            AssertGetMyTasksResponse(response);
        }

        /// <summary>
        /// Tests [GET] /my/tasks.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestStaticGetMyTasks()
        {
            var parameters = new MyTasksParameters
            {
                Status = TaskStatusValue.Done,
            };

            var response = ChatworkClient.GetMyTasks(Token, parameters);
            AssertGetMyTasksResponse(response);
        }

        /// <summary>
        /// Tests [GET] /my/tasks asyncchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestGetMyTasksAsync()
        {
            var parameters = new MyTasksParameters
            {
                Status = TaskStatusValue.Open,
            };

            var response = await Client.GetMyTasksAsync(parameters)
                .ConfigureAwait(false);

            AssertGetMyTasksResponse(response);
        }

        /// <summary>
        /// Tests [GET] /my/tasks asyncchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticGetMyTasksAsync()
        {
            var parameters = new MyTasksParameters
            {
                Status = TaskStatusValue.Done,
            };

            var response = await ChatworkClient.GetMyTasksAsync(Token, parameters)
                .ConfigureAwait(false);

            AssertGetMyTasksResponse(response);
        }

        /// <summary>
        /// Tests [GET] /my/tasks asyncchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestGetMyTasksAsyncCallback()
        {
            var parameters = new MyTasksParameters
            {
                Status = TaskStatusValue.Open,
            };

            Client.GetMyTasksAsync(
                AssertGetMyTasksResponse,
                parameters);
        }

        /// <summary>
        /// Tests [GET] /my/tasks asyncchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetMyTasksAsyncCallback()
        {
            var parameters = new MyTasksParameters
            {
                Status = TaskStatusValue.Done,
            };

            ChatworkClient.GetMyTasksAsync(
                Token,
                AssertGetMyTasksResponse,
                parameters);
        }

        /// <summary>
        /// Asserts "[GET] /my/tasks" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetMyTasksResponse(ResponseData<IReadOnlyCollection<MyTaskData>> response)
        {
            Assert.True(response.Success);
        }
    }
}
