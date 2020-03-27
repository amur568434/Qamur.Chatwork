// <copyright file="TestRoomLink.cs" company="Kohei Oizumi">
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
    using System;
    using System.Linq;
    using System.Threading.Tasks;
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
    /// [GET] /rooms/{room_id}/link.
    /// [POST] /rooms/{room_id}/link.
    /// [PUT] /rooms/{room_id}/link.
    /// [DELETE] /rooms/{room_id}/link.
    /// </remarks>
    public class TestRoomLink : ClientTestBase
    {
        /// <summary>
        /// New link parameters.
        /// </summary>
        private readonly UpdateLinkParameters newLinkParameters = new UpdateLinkParameters
        {
            Code = "23asda2",
            Description = "2223",
            NeedAcceptance = true,
        };

        /// <summary>
        /// Updating link parameters.
        /// </summary>
        private readonly UpdateLinkParameters updateLinkParameters = new UpdateLinkParameters
        {
            Code = "23asda2",
            Description = "2223",
            NeedAcceptance = true,
        };

        /// <summary>
        /// Tests room link.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestRoomsRoomLink()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            var link = TestGetRoomLink(roomId);
            var linkExists = link.Public || link.Url != null || !string.IsNullOrEmpty(link.Description);

            if (linkExists)
            {
                TestPutRoomLink(roomId);
                TestDeleteRoomLink(roomId);
                TestPostRoomLink(roomId);
            }
            else
            {
                TestPostRoomLink(roomId);
                TestPutRoomLink(roomId);
                TestDeleteRoomLink(roomId);
            }

            // [GET] /rooms/{room_id}/link.
            LinkData TestGetRoomLink(long roomId)
            {
                var response = Client.GetRoomLink(roomId);
                AssertGetRoomLinkResponse(response);
                return response.Data;
            }

            // [POST] /rooms/{room_id}/link.
            void TestPostRoomLink(long roomId)
            {
                var response = Client.PostRoomLink(roomId, newLinkParameters);
                AssertPostRoomLinkResponse(response);
            }

            // [PUT] /rooms/{room_id}/link.
            void TestPutRoomLink(long roomId)
            {
                var response = Client.PutRoomLink(roomId, updateLinkParameters);
                AssertPutRoomLinkResponse(response);
            }

            // [DELETE] /rooms/{room_id}/link.
            void TestDeleteRoomLink(long roomId)
            {
                var response = Client.DeleteRoomLink(roomId);
                AssertDeleteRoomLinkResponse(response);
            }
        }

        /// <summary>
        /// Tests room link.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticRoomsRoomLink()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            var link = TestStaticGetRoomLink(roomId);
            var linkExists = link.Public || link.Url != null || !string.IsNullOrEmpty(link.Description);

            if (linkExists)
            {
                TestStaticPutRoomLink(roomId);
                TestStaticDeleteRoomLink(roomId);
                TestStaticPostRoomLink(roomId);
            }
            else
            {
                TestStaticPostRoomLink(roomId);
                TestStaticPutRoomLink(roomId);
                TestStaticDeleteRoomLink(roomId);
            }

            // [GET] /rooms/{room_id}/link.
            LinkData TestStaticGetRoomLink(long roomId)
            {
                var response = ChatworkClient.GetRoomLink(Token, roomId);
                AssertGetRoomLinkResponse(response);
                return response.Data;
            }

            // [POST] /rooms/{room_id}/link.
            void TestStaticPostRoomLink(long roomId)
            {
                var response = ChatworkClient.PostRoomLink(Token, roomId, newLinkParameters);
                AssertPostRoomLinkResponse(response);
            }

            // [PUT] /rooms/{room_id}/link.
            void TestStaticPutRoomLink(long roomId)
            {
                var response = ChatworkClient.PutRoomLink(Token, roomId, updateLinkParameters);
                AssertPutRoomLinkResponse(response);
            }

            // [DELETE] /rooms/{room_id}/link.
            void TestStaticDeleteRoomLink(long roomId)
            {
                var response = ChatworkClient.DeleteRoomLink(Token, roomId);
                AssertDeleteRoomLinkResponse(response);
            }
        }

        /// <summary>
        /// Tests room link asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestRoomsRoomLinkAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            var link = await TestGetRoomLinkAsync(roomId)
                .ConfigureAwait(false);

            var linkExists = link.Public ||
                link.Url != null ||
                !string.IsNullOrEmpty(link.Description);

            if (linkExists)
            {
                await TestPutRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                await TestDeleteRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                await TestPostRoomLinkAsync(roomId)
                    .ConfigureAwait(false);
            }
            else
            {
                await TestPostRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                await TestPutRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                await TestDeleteRoomLinkAsync(roomId)
                    .ConfigureAwait(false);
            }

            // [GET] /rooms/{room_id}/link.
            async Task<LinkData> TestGetRoomLinkAsync(long roomId)
            {
                var response = await Client.GetRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                AssertGetRoomLinkResponse(response);
                return response.Data;
            }

            // [POST] /rooms/{room_id}/link.
            async Task TestPostRoomLinkAsync(long roomId)
            {
                var response = await Client.PostRoomLinkAsync(roomId, newLinkParameters)
                    .ConfigureAwait(false);

                AssertPostRoomLinkResponse(response);
            }

            // [PUT] /rooms/{room_id}/link.
            async Task TestPutRoomLinkAsync(long roomId)
            {
                var response = await Client.PutRoomLinkAsync(roomId, updateLinkParameters)
                    .ConfigureAwait(false);

                AssertPutRoomLinkResponse(response);
            }

            // [DELETE] /rooms/{room_id}/link.
            async Task TestDeleteRoomLinkAsync(long roomId)
            {
                var response = await Client.DeleteRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                AssertDeleteRoomLinkResponse(response);
            }
        }

        /// <summary>
        /// Tests room link asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticRoomsRoomLinkAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            var link = await TestStaticGetRoomLinkAsync(roomId)
                .ConfigureAwait(false);

            var linkExists = link.Public ||
                link.Url != null ||
                !string.IsNullOrEmpty(link.Description);

            if (linkExists)
            {
                await TestStaticPutRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                await TestStaticDeleteRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                await TestStaticPostRoomLinkAsync(roomId)
                    .ConfigureAwait(false);
            }
            else
            {
                await TestStaticPostRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                await TestStaticPutRoomLinkAsync(roomId)
                    .ConfigureAwait(false);

                await TestStaticDeleteRoomLinkAsync(roomId)
                    .ConfigureAwait(false);
            }

            // [GET] /rooms/{room_id}/link.
            async Task<LinkData> TestStaticGetRoomLinkAsync(long roomId)
            {
                var response = await ChatworkClient.GetRoomLinkAsync(Token, roomId)
                    .ConfigureAwait(false);

                AssertGetRoomLinkResponse(response);
                return response.Data;
            }

            // [POST] /rooms/{room_id}/link.
            async Task TestStaticPostRoomLinkAsync(long roomId)
            {
                var response = await ChatworkClient.PostRoomLinkAsync(Token, roomId, newLinkParameters)
                    .ConfigureAwait(false);

                AssertPostRoomLinkResponse(response);
            }

            // [PUT] /rooms/{room_id}/link.
            async Task TestStaticPutRoomLinkAsync(long roomId)
            {
                var response = await ChatworkClient.PutRoomLinkAsync(Token, roomId, updateLinkParameters)
                    .ConfigureAwait(false);

                AssertPutRoomLinkResponse(response);
            }

            // [DELETE] /rooms/{room_id}/link.
            async Task TestStaticDeleteRoomLinkAsync(long roomId)
            {
                var response = await ChatworkClient.DeleteRoomLinkAsync(Token, roomId)
                    .ConfigureAwait(false);

                AssertDeleteRoomLinkResponse(response);
            }
        }

        /// <summary>
        /// Tests room link asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestRoomsRoomLinkAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            TestGetRoomLinkAsyncCallback(
                roomId,
                (roomId, link) =>
                {
                    var linkExists = link.Public ||
                        link.Url != null ||
                        !string.IsNullOrEmpty(link.Description);

                    if (linkExists)
                    {
                        TestPutRoomLinkAsyncCallback(
                            roomId,
                            roomId =>
                            {
                                TestDeleteRoomLinkAsyncCallback(
                                    roomId,
                                    roomId =>
                                    {
                                        TestPostRoomLinkAsyncCallback(roomId, null);
                                    });
                            });
                    }
                    else
                    {
                        TestPostRoomLinkAsyncCallback(
                            roomId,
                            roomId =>
                            {
                                TestPutRoomLinkAsyncCallback(
                                    roomId,
                                    roomId =>
                                    {
                                        TestDeleteRoomLinkAsyncCallback(roomId, null);
                                    });
                            });
                    }
                });

            // [GET] /rooms/{room_id}/link.
            void TestGetRoomLinkAsyncCallback(long roomId, Action<long, LinkData> next)
            {
                Client.GetRoomLinkAsync(
                    response =>
                    {
                        AssertGetRoomLinkResponse(response);

                        if (next != null)
                        {
                            next.Invoke(roomId, response.Data);
                        }
                    },
                    roomId);
            }

            // [POST] /rooms/{room_id}/link.
            void TestPostRoomLinkAsyncCallback(long roomId, Action<long> next)
            {
                Client.PostRoomLinkAsync(
                    response =>
                    {
                        AssertPostRoomLinkResponse(response);

                        if (next != null)
                        {
                            next.Invoke(roomId);
                        }
                    },
                    roomId,
                    newLinkParameters);
            }

            // [PUT] /rooms/{room_id}/link.
            void TestPutRoomLinkAsyncCallback(long roomId, Action<long> next)
            {
                 Client.PutRoomLinkAsync(
                    response =>
                    {
                        AssertPutRoomLinkResponse(response);

                        if (next != null)
                        {
                            next.Invoke(roomId);
                        }
                    },
                    roomId,
                    updateLinkParameters);
            }

            // [DELETE] /rooms/{room_id}/link.
            void TestDeleteRoomLinkAsyncCallback(long roomId, Action<long> next)
            {
                Client.DeleteRoomLinkAsync(
                    response =>
                    {
                        AssertDeleteRoomLinkResponse(response);

                        if (next != null)
                        {
                            next.Invoke(roomId);
                        }
                    },
                    roomId);
            }
        }

        /// <summary>
        /// Tests room link asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticRoomsRoomLinkAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            TestStaticGetRoomLinkAsyncCallback(
                roomId,
                (roomId, link) =>
                {
                    var linkExists = link.Public ||
                        link.Url != null ||
                        !string.IsNullOrEmpty(link.Description);

                    if (linkExists)
                    {
                        TestStaticPutRoomLinkAsyncCallback(
                            roomId,
                            roomId =>
                            {
                                TestStaticDeleteRoomLinkAsyncCallback(
                                    roomId,
                                    roomId =>
                                    {
                                        TestStaticPostRoomLinkAsyncCallback(roomId, null);
                                    });
                            });
                    }
                    else
                    {
                        TestStaticPostRoomLinkAsyncCallback(
                            roomId,
                            roomId =>
                            {
                                TestStaticPutRoomLinkAsyncCallback(
                                    roomId,
                                    roomId =>
                                    {
                                        TestStaticDeleteRoomLinkAsyncCallback(roomId, null);
                                    });
                            });
                    }
                });

            // [GET] /rooms/{room_id}/link.
            void TestStaticGetRoomLinkAsyncCallback(long roomId, Action<long, LinkData> next)
            {
                ChatworkClient.GetRoomLinkAsync(
                    Token,
                    response =>
                    {
                        AssertGetRoomLinkResponse(response);

                        if (next != null)
                        {
                            next.Invoke(roomId, response.Data);
                        }
                    },
                    roomId);
            }

            // [POST] /rooms/{room_id}/link.
            void TestStaticPostRoomLinkAsyncCallback(long roomId, Action<long> next)
            {
                ChatworkClient.PostRoomLinkAsync(
                    Token,
                    response =>
                    {
                        AssertPostRoomLinkResponse(response);

                        if (next != null)
                        {
                            next.Invoke(roomId);
                        }
                    },
                    roomId,
                    newLinkParameters);
            }

            // [PUT] /rooms/{room_id}/link.
            void TestStaticPutRoomLinkAsyncCallback(long roomId, Action<long> next)
            {
                ChatworkClient.PutRoomLinkAsync(
                    Token,
                    response =>
                    {
                        AssertPutRoomLinkResponse(response);

                        if (next != null)
                        {
                            next.Invoke(roomId);
                        }
                    },
                    roomId,
                    updateLinkParameters);
            }

            // [DELETE] /rooms/{room_id}/link.
            void TestStaticDeleteRoomLinkAsyncCallback(long roomId, Action<long> next)
            {
                ChatworkClient.DeleteRoomLinkAsync(
                    Token,
                    response =>
                    {
                        AssertDeleteRoomLinkResponse(response);

                        if (next != null)
                        {
                            next.Invoke(roomId);
                        }
                    },
                    roomId);
            }
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}/link." response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetRoomLinkResponse(ResponseData<LinkData> response)
        {
            Assert.True(response.Success);
        }

        /// <summary>
        /// Asserts "[POST] /rooms/{room_id}/link." response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertPostRoomLinkResponse(ResponseData<LinkData> response)
        {
            Assert.True(response.Success);
        }

        /// <summary>
        /// Asserts "[PUT] /rooms/{room_id}/link." response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertPutRoomLinkResponse(ResponseData<LinkData> response)
        {
            Assert.True(response.Success);
        }

        /// <summary>
        /// Asserts "[DELETE] /rooms/{room_id}/link." response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertDeleteRoomLinkResponse(ResponseData<LinkStatusData> response)
        {
            Assert.True(response.Success);
        }
    }
}
