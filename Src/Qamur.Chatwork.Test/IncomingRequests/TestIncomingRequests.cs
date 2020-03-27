// <copyright file="TestIncomingRequests.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Client.Test.IncomingRequests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Qamur.Chatwork.Data;
    using Qamur.Chatwork.Test;
    using Xunit;
    using static Qamur.Chatwork.Test.SkipText;

    /// <summary>
    /// Test class.
    /// </summary>
    /// <remarks>
    /// This test class runs the following path tests.
    /// [GET] /incoming_requests.
    /// [PUT] /incoming_requests/{request_id}.
    /// [DELETE] /incoming_requests/{request_id}.
    /// </remarks>
    public class TestIncomingRequests : ClientTestBase
    {
        /// <summary>
        /// Tests incoming_requests.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestIncomingRequestsGetPutDelete()
        {
            var data = TestGetIncomingRequest();

            if (data == null || !data.Any())
            {
                WarnSkip("TestPutIncomingRequest");
                WarnSkip("TestDeleteIncomingRequest");
                return;
            }

            var requests = data.ToArray();

            if (requests.Length > 0)
            {
                var requestId = requests[0].RequestId;
                TestPutIncomingRequest(requestId);
            }
            else
            {
                WarnSkip("TestPutIncomingRequest");
            }

            if (requests.Length > 1)
            {
                var requestId = requests[1].RequestId;
                TestDeleteIncomingRequest(requestId);
            }
            else
            {
                WarnSkip("TestDeleteIncomingRequest");
            }

            // [GET] /incoming_requests.
            IReadOnlyCollection<IncomingRequestData> TestGetIncomingRequest()
            {
                var response = Client.GetIncomingRequests();
                AssertGetIncomingRequestsResponse(response);
                return response.Data;
            }

            // [PUT] /incoming_requests/{request_id}.
            void TestPutIncomingRequest(long requestId)
            {
                var response = Client.PutIncomingRequest(requestId);
                AssertPutIncomingRequestResponse(response);
            }

            // [DELETE] /incoming_requests/{request_id}.
            void TestDeleteIncomingRequest(long requestId)
            {
                var response = Client.DeleteIncomingRequest(requestId);
                AssertDeleteIncomingRequestResponse(response);
            }
        }

        /// <summary>
        /// Tests incoming_requests.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticIncomingRequestsGetPutDelete()
        {
            var data = TestStaticGetIncomingRequest();

            if (data == null || !data.Any())
            {
                WarnSkip("TestStaticPutIncomingRequest");
                WarnSkip("TestStaticDeleteIncomingRequest");
                return;
            }

            var requests = data.ToArray();

            if (requests.Length > 0)
            {
                var requestId = requests[0].RequestId;
                TestStaticPutIncomingRequest(requestId);
            }
            else
            {
                WarnSkip("TestStaticPutIncomingRequest");
            }

            if (requests.Length > 1)
            {
                var requestId = requests[1].RequestId;
                TestStaticDeleteIncomingRequest(requestId);
            }
            else
            {
                WarnSkip("TestStaticDeleteIncomingRequest");
            }

            // [GET] /incoming_requests.
            IReadOnlyCollection<IncomingRequestData> TestStaticGetIncomingRequest()
            {
                var response = ChatworkClient.GetIncomingRequests(Token);
                AssertGetIncomingRequestsResponse(response);
                return response.Data;
            }

            // [PUT] /incoming_requests/{request_id}.
            void TestStaticPutIncomingRequest(long requestId)
            {
                var response = ChatworkClient.PutIncomingRequest(Token, requestId);
                AssertPutIncomingRequestResponse(response);
            }

            // [DELETE] /incoming_requests/{request_id}.
            void TestStaticDeleteIncomingRequest(long requestId)
            {
                var response = ChatworkClient.DeleteIncomingRequest(Token, requestId);
                AssertDeleteIncomingRequestResponse(response);
            }
        }

        /// <summary>
        /// Tests incoming_requests asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestIncomingRequestsGetPutDeleteAsync()
        {
            var data = await TestGetIncomingRequestsAsync()
                .ConfigureAwait(false);

            if (data == null || !data.Any())
            {
                WarnSkip("TestPutIncomingRequestAsync");
                WarnSkip("TestDeleteIncomingRequestAsync");
                return;
            }

            var requests = data.ToArray();

            if (requests.Length > 0)
            {
                var requestId = requests[0].RequestId;
                await TestPutIncomingRequestAsync(requestId)
                    .ConfigureAwait(false);
            }
            else
            {
                WarnSkip("TestPutIncomingRequestAsync");
            }

            if (requests.Length > 1)
            {
                var requestId = requests[1].RequestId;
                await TestDeleteIncomingRequestAsync(requestId)
                    .ConfigureAwait(false);
            }
            else
            {
                WarnSkip("TestDeleteIncomingRequestAsync");
            }

            // [GET] /incoming_requests asynchronously.
            async Task<IReadOnlyCollection<IncomingRequestData>> TestGetIncomingRequestsAsync()
            {
                var response = await Client.GetIncomingRequestsAsync()
                    .ConfigureAwait(false);

                AssertGetIncomingRequestsResponse(response);
                return response.Data;
            }

            // [PUT] /incoming_requests/{request_id}.
            async Task TestPutIncomingRequestAsync(long requestId)
            {
                var response = await Client.PutIncomingRequestAsync(requestId)
                    .ConfigureAwait(false);

                AssertPutIncomingRequestResponse(response);
            }

            // [DELETE] /incoming_requests/{request_id}.
            async Task TestDeleteIncomingRequestAsync(long requestId)
            {
                var response = await Client.DeleteIncomingRequestAsync(requestId)
                    .ConfigureAwait(false);

                AssertDeleteIncomingRequestResponse(response);
            }
        }

        /// <summary>
        /// Tests incoming_requests asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticIncomingRequestsGetPutDeleteAsync()
        {
            var data = await TestStaticGetIncomingRequestsAsync()
                .ConfigureAwait(false);

            if (data == null || !data.Any())
            {
                WarnSkip("TestStaticPutIncomingRequestAsync");
                WarnSkip("TestStaticDeleteIncomingRequestAsync");
                return;
            }

            var requests = data.ToArray();

            if (requests.Length > 0)
            {
                var requestId = requests[0].RequestId;
                await TestStaticPutIncomingRequestAsync(requestId)
                    .ConfigureAwait(false);
            }
            else
            {
                WarnSkip("TestStaticPutIncomingRequestAsync");
            }

            if (requests.Length > 1)
            {
                var requestId = requests[1].RequestId;
                await TestStaticDeleteIncomingRequestAsync(requestId)
                    .ConfigureAwait(false);
            }
            else
            {
                WarnSkip("TestStaticDeleteIncomingRequestAsync");
            }

            // [GET] /incoming_requests asynchronously.
            async Task<IReadOnlyCollection<IncomingRequestData>> TestStaticGetIncomingRequestsAsync()
            {
                var response = await ChatworkClient.GetIncomingRequestsAsync(Token)
                    .ConfigureAwait(false);

                AssertGetIncomingRequestsResponse(response);
                return response.Data;
            }

            // [PUT] /incoming_requests/{request_id}.
            async Task TestStaticPutIncomingRequestAsync(long requestId)
            {
                var response = await ChatworkClient.PutIncomingRequestAsync(Token, requestId)
                    .ConfigureAwait(false);

                AssertPutIncomingRequestResponse(response);
            }

            // [DELETE] /incoming_requests/{request_id}.
            async Task TestStaticDeleteIncomingRequestAsync(long requestId)
            {
                var response = await ChatworkClient.DeleteIncomingRequestAsync(Token, requestId)
                    .ConfigureAwait(false);

                AssertDeleteIncomingRequestResponse(response);
            }
        }

        /// <summary>
        /// Tests incoming_requests asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestIncomingRequestsGetPutDeleteAsyncCallback()
        {
            TestGetIncomingRequestsAsyncCallback(data =>
            {
                if (data == null || !data.Any())
                {
                    WarnSkip("TestPutIncomingRequestAsync");
                    WarnSkip("TestDeleteIncomingRequestAsync");
                    return;
                }

                var requests = data.ToArray();

                if (requests.Length > 0)
                {
                    var requestId = requests[0].RequestId;
                    TestPutIncomingRequestAsyncCallback(requestId);
                }
                else
                {
                    WarnSkip("TestPutIncomingRequestAsync");
                }

                if (requests.Length > 1)
                {
                    var requestId = requests[1].RequestId;
                    TestDeleteIncomingRequestAsyncCallback(requestId);
                }
                else
                {
                    WarnSkip("TestDeleteIncomingRequestAsync");
                }
            });

            // [GET] /incoming_requests asynchronously.
            void TestGetIncomingRequestsAsyncCallback(Action<IReadOnlyCollection<IncomingRequestData>> next)
            {
                Client.GetIncomingRequestsAsync(
                    response =>
                    {
                        AssertGetIncomingRequestsResponse(response);
                        next.Invoke(response.Data);
                    });
            }

            // [PUT] /incoming_requests/{request_id}.
            void TestPutIncomingRequestAsyncCallback(long requestId)
            {
                Client.PutIncomingRequestAsync(
                    AssertPutIncomingRequestResponse,
                    requestId);
            }

            // [DELETE] /incoming_requests/{request_id}.
            void TestDeleteIncomingRequestAsyncCallback(long requestId)
            {
                Client.DeleteIncomingRequestAsync(
                    AssertDeleteIncomingRequestResponse,
                    requestId);
            }
        }

        /// <summary>
        /// Tests incoming_requests asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticIncomingRequestsGetPutDeleteAsyncCallback()
        {
            TestStaticGetIncomingRequestsAsyncCallback(data =>
            {
                if (data == null || !data.Any())
                {
                    WarnSkip("TestStaticPutIncomingRequestAsync");
                    WarnSkip("TestStaticDeleteIncomingRequestAsync");
                    return;
                }

                var requests = data.ToArray();

                if (requests.Length > 0)
                {
                    var requestId = requests[0].RequestId;
                    TestStaticPutIncomingRequestAsyncCallback(requestId);
                }
                else
                {
                    WarnSkip("TestStaticPutIncomingRequestAsync");
                }

                if (requests.Length > 1)
                {
                    var requestId = requests[1].RequestId;
                    TestStaticDeleteIncomingRequestAsyncCallback(requestId);
                }
                else
                {
                    WarnSkip("TestStaticDeleteIncomingRequestAsync");
                }
            });

            // [GET] /incoming_requests asynchronously.
            void TestStaticGetIncomingRequestsAsyncCallback(Action<IReadOnlyCollection<IncomingRequestData>> next)
            {
                ChatworkClient.GetIncomingRequestsAsync(
                    Token,
                    response =>
                    {
                        AssertGetIncomingRequestsResponse(response);
                        next.Invoke(response.Data);
                    });
            }

            // [PUT] /incoming_requests/{request_id}.
            void TestStaticPutIncomingRequestAsyncCallback(long requestId)
            {
                ChatworkClient.PutIncomingRequestAsync(
                    Token,
                    AssertPutIncomingRequestResponse,
                    requestId);
            }

            // [DELETE] /incoming_requests/{request_id}.
            void TestStaticDeleteIncomingRequestAsyncCallback(long requestId)
            {
                ChatworkClient.DeleteIncomingRequestAsync(
                    Token,
                    AssertDeleteIncomingRequestResponse,
                    requestId);
            }
        }

        /// <summary>
        /// Asserts "[GET] /incoming_requests" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetIncomingRequestsResponse(ResponseData<IReadOnlyCollection<IncomingRequestData>> response)
        {
            Assert.True(response.Success);
        }

        /// <summary>
        /// Asserts "[PUT] /incoming_requests/{request_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertPutIncomingRequestResponse(ResponseData<ContactData> response)
        {
            Assert.True(response.Success);
            Assert.NotNull(response.Data);
        }

        /// <summary>
        /// Asserts "[DELETE] /incoming_requests/{request_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertDeleteIncomingRequestResponse(ResponseData<object> response)
        {
            Assert.True(response.Success);
        }
    }
}
