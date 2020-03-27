// <copyright file="TestContactsGet.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Client.Test.Contacts
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
    /// [GET] /contacts.
    /// </remarks>
    public class TestContactsGet : ClientTestBase
    {
        /// <summary>
        /// Tests [GET] /contacts.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestGetContacts()
        {
            var response = Client.GetContacts();
            AssertGetContactsResponse(response);
        }

        /// <summary>
        /// Tests [GET] /contacts.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetContacts()
        {
            var response = ChatworkClient.GetContacts(Token);
            AssertGetContactsResponse(response);
        }

        /// <summary>
        /// Tests [GET] /contacts asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestGetContactsAsync()
        {
            var response = await Client.GetContactsAsync()
                .ConfigureAwait(false);

            AssertGetContactsResponse(response);
        }

        /// <summary>
        /// Tests [GET] /contacts asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticGetContactsAsync()
        {
            var response = await ChatworkClient.GetContactsAsync(Token)
                .ConfigureAwait(false);

            AssertGetContactsResponse(response);
        }

        /// <summary>
        /// Tests [GET] /contacts asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestGetContactsAsyncCallback()
        {
            Client.GetContactsAsync(AssertGetContactsResponse);
        }

        /// <summary>
        /// Tests [GET] /contacts asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticGetContactsAsyncCallback()
        {
            ChatworkClient.GetContactsAsync(Token, AssertGetContactsResponse);
        }

        /// <summary>
        /// Asserts "[GET] /contacts" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetContactsResponse(ResponseData<IReadOnlyCollection<ContactData>> response)
        {
            Assert.True(response.Success);
        }
    }
}
