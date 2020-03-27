// <copyright file="TestRoomMessage.cs" company="Kohei Oizumi">
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
    /// [POST] /rooms/{room_id}/messages.
    /// [GET] /rooms/{room_id}/messages/{message_id}.
    /// [PUT] /rooms/{room_id}/messages/{message_id}.
    /// [DELETE] /rooms/{room_id}/messages/{message_id}.
    /// </remarks>
    public class TestRoomMessage : ClientTestBase
    {
        /// <summary>
        /// Tests message.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestMessageLifecycle()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var messageId = TestPostRoomMessage(roomId);
            TestGetRoomMessage(roomId, messageId);
            TestPutRoomMessage(roomId, messageId);
            TestDeleteRoomMessage(roomId, messageId);

            // [POST] /rooms/{room_id}/messages.
            string TestPostRoomMessage(long roomId)
            {
                var parameters = new NewMessageParameters
                {
                    Body = "new test message.",
                    SelfUnread = true,
                };

                var response = Client.PostRoomMessage(roomId, parameters);
                AssertPostRoomMessageResponse(response);

                return response.Data.MessageId;
            }

            // [GET] /rooms/{room_id}/messages/{message_id}.
            void TestGetRoomMessage(long roomId, string messageId)
            {
                var response = Client.GetRoomMessage(roomId, messageId);
                AssertGetRoomMessageResponse(response, messageId);
            }

            // [PUT] /rooms/{room_id}/messages/{message_id}.
            void TestPutRoomMessage(long roomId, string messageId)
            {
                var parameters = new UpdateMessageParameters
                {
                    Body = "update test message.",
                };

                var response = Client.PutRoomMessage(roomId, messageId, parameters);
                AssertPutRoomMessageResponse(response, messageId);
            }

            // [DELETE] /rooms/{room_id}/messages/{message_id}.
            void TestDeleteRoomMessage(long roomId, string messageId)
            {
                var response = Client.DeleteRoomMessage(roomId, messageId);
                AssertDeleteRoomMessageResponse(response, messageId);
            }
        }

        /// <summary>
        /// Tests message.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticMessageLifecycle()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var messageId = TestStaticPostRoomMessage(roomId);
            TestStaticGetRoomMessage(roomId, messageId);
            TestStaticPutRoomMessage(roomId, messageId);
            TestStaticDeleteRoomMessage(roomId, messageId);

            // [POST] /rooms/{room_id}/messages.
            string TestStaticPostRoomMessage(long roomId)
            {
                var parameters = new NewMessageParameters
                {
                    Body = "new test message.",
                    SelfUnread = true,
                };

                var response = ChatworkClient.PostRoomMessage(Token, roomId, parameters);
                AssertPostRoomMessageResponse(response);

                return response.Data.MessageId;
            }

            // [GET] /rooms/{room_id}/messages/{message_id}.
            void TestStaticGetRoomMessage(long roomId, string messageId)
            {
                var response = ChatworkClient.GetRoomMessage(Token, roomId, messageId);
                AssertGetRoomMessageResponse(response, messageId);
            }

            // [PUT] /rooms/{room_id}/messages/{message_id}.
            void TestStaticPutRoomMessage(long roomId, string messageId)
            {
                var parameters = new UpdateMessageParameters
                {
                    Body = "update test message.",
                };

                var response = ChatworkClient.PutRoomMessage(Token, roomId, messageId, parameters);
                AssertPutRoomMessageResponse(response, messageId);
            }

            // [DELETE] /rooms/{room_id}/messages/{message_id}.
            void TestStaticDeleteRoomMessage(long roomId, string messageId)
            {
                var response = ChatworkClient.DeleteRoomMessage(Token, roomId, messageId);
                AssertDeleteRoomMessageResponse(response, messageId);
            }
        }

        /// <summary>
        /// Tests message asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestMessageLifecycleAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            var messageId = await TestPostRoomMessageAsync(roomId)
                .ConfigureAwait(false);

            await TestGetRoomMessageAsync(roomId, messageId)
                .ConfigureAwait(false);

            await TestPutRoomMessageAsync(roomId, messageId)
                .ConfigureAwait(false);

            await TestDeleteRoomMessageAsync(roomId, messageId)
                .ConfigureAwait(false);

            // [POST] /rooms/{room_id}/messages.
            async Task<string> TestPostRoomMessageAsync(long roomId)
            {
                var parameters = new NewMessageParameters
                {
                    Body = "new test message.",
                    SelfUnread = true,
                };

                var response = await Client.PostRoomMessageAsync(roomId, parameters)
                    .ConfigureAwait(false);

                AssertPostRoomMessageResponse(response);
                return response.Data.MessageId;
            }

            // [GET] /rooms/{room_id}/messages/{message_id}.
            async Task TestGetRoomMessageAsync(long roomId, string messageId)
            {
                var response = await Client.GetRoomMessageAsync(roomId, messageId)
                    .ConfigureAwait(false);

                AssertGetRoomMessageResponse(response, messageId);
            }

            // [PUT] /rooms/{room_id}/messages/{message_id}.
            async Task TestPutRoomMessageAsync(long roomId, string messageId)
            {
                var parameters = new UpdateMessageParameters
                {
                    Body = "update test message.",
                };

                var response = await Client.PutRoomMessageAsync(roomId, messageId, parameters)
                    .ConfigureAwait(false);

                AssertPutRoomMessageResponse(response, messageId);
            }

            // [DELETE] /rooms/{room_id}/messages/{message_id}.
            async Task TestDeleteRoomMessageAsync(long roomId, string messageId)
            {
                var response = await Client.DeleteRoomMessageAsync(roomId, messageId)
                    .ConfigureAwait(false);

                AssertDeleteRoomMessageResponse(response, messageId);
            }
        }

        /// <summary>
        /// Tests message asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticMessageLifecycleAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            var messageId = await TestStaticPostRoomMessageAsync(roomId)
                .ConfigureAwait(false);

            await TestStaticGetRoomMessageAsync(roomId, messageId)
                .ConfigureAwait(false);

            await TestStaticPutRoomMessageAsync(roomId, messageId)
                .ConfigureAwait(false);

            await TestStaticDeleteRoomMessageAsync(roomId, messageId)
                .ConfigureAwait(false);

            // [POST] /rooms/{room_id}/messages.
            async Task<string> TestStaticPostRoomMessageAsync(long roomId)
            {
                var parameters = new NewMessageParameters
                {
                    Body = "new test message.",
                    SelfUnread = true,
                };

                var response = await ChatworkClient.PostRoomMessageAsync(Token, roomId, parameters)
                    .ConfigureAwait(false);

                AssertPostRoomMessageResponse(response);
                return response.Data.MessageId;
            }

            // [GET] /rooms/{room_id}/messages/{message_id}.
            async Task TestStaticGetRoomMessageAsync(long roomId, string messageId)
            {
                var response = await ChatworkClient.GetRoomMessageAsync(Token, roomId, messageId)
                    .ConfigureAwait(false);

                AssertGetRoomMessageResponse(response, messageId);
            }

            // [PUT] /rooms/{room_id}/messages/{message_id}.
            async Task TestStaticPutRoomMessageAsync(long roomId, string messageId)
            {
                var parameters = new UpdateMessageParameters
                {
                    Body = "update test message.",
                };

                var response = await ChatworkClient.PutRoomMessageAsync(Token, roomId, messageId, parameters)
                    .ConfigureAwait(false);

                AssertPutRoomMessageResponse(response, messageId);
            }

            // [DELETE] /rooms/{room_id}/messages/{message_id}.
            async Task TestStaticDeleteRoomMessageAsync(long roomId, string messageId)
            {
                var response = await ChatworkClient.DeleteRoomMessageAsync(Token, roomId, messageId)
                    .ConfigureAwait(false);

                AssertDeleteRoomMessageResponse(response, messageId);
            }
        }

        /// <summary>
        /// Tests message asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestMessageLifecycleAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            TestPostRoomMessageAsyncCallback(
                roomId,
                (roomId, messageId) => TestGetRoomMessageAsyncCallback(
                    roomId,
                    messageId,
                    (roomId, messageId) => TestPutRoomMessageAsyncCallback(
                        roomId,
                        messageId,
                        TestDeleteRoomMessageAsyncCallback)));

            // [POST] /rooms/{room_id}/messages.
            void TestPostRoomMessageAsyncCallback(long roomId, Action<long, string> next)
            {
                var parameters = new NewMessageParameters
                {
                    Body = "new test message.",
                    SelfUnread = true,
                };

                Client.PostRoomMessageAsync(
                    response =>
                    {
                        AssertPostRoomMessageResponse(response);
                        next.Invoke(roomId, response.Data.MessageId);
                    },
                    roomId,
                    parameters);
            }

            // [GET] /rooms/{room_id}/messages/{message_id}.
            void TestGetRoomMessageAsyncCallback(long roomId, string messageId, Action<long, string> next)
            {
                Client.GetRoomMessageAsync(
                    response =>
                    {
                        AssertGetRoomMessageResponse(response, messageId);
                        next.Invoke(roomId, messageId);
                    },
                    roomId,
                    messageId);
            }

            // [PUT] /rooms/{room_id}/messages/{message_id}.
            void TestPutRoomMessageAsyncCallback(long roomId, string messageId, Action<long, string> next)
            {
                var parameters = new UpdateMessageParameters
                {
                    Body = "update test message.",
                };

                Client.PutRoomMessageAsync(
                    response =>
                    {
                        AssertPutRoomMessageResponse(response, messageId);
                        next.Invoke(roomId, messageId);
                    },
                    roomId,
                    messageId,
                    parameters);
            }

            // [DELETE] /rooms/{room_id}/messages/{message_id}.
            void TestDeleteRoomMessageAsyncCallback(long roomId, string messageId)
            {
                Client.DeleteRoomMessageAsync(
                    response => AssertDeleteRoomMessageResponse(response, messageId),
                    roomId,
                    messageId);
            }
        }

        /// <summary>
        /// Tests message asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticMessageLifecycleAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            TestStaticPostRoomMessageAsyncCallback(
                roomId,
                (roomId, messageId) => TestStaticGetRoomMessageAsyncCallback(
                    roomId,
                    messageId,
                    (roomId, messageId) => TestStaticPutRoomMessageAsyncCallback(
                        roomId,
                        messageId,
                        TestStaticDeleteRoomMessageAsyncCallback)));

            // [POST] /rooms/{room_id}/messages.
            void TestStaticPostRoomMessageAsyncCallback(long roomId, Action<long, string> next)
            {
                var parameters = new NewMessageParameters
                {
                    Body = "new test message.",
                    SelfUnread = true,
                };

                ChatworkClient.PostRoomMessageAsync(
                    Token,
                    response =>
                    {
                        AssertPostRoomMessageResponse(response);
                        next.Invoke(roomId, response.Data.MessageId);
                    },
                    roomId,
                    parameters);
            }

            // [GET] /rooms/{room_id}/messages/{message_id}.
            void TestStaticGetRoomMessageAsyncCallback(long roomId, string messageId, Action<long, string> next)
            {
                ChatworkClient.GetRoomMessageAsync(
                    Token,
                    response =>
                    {
                        AssertGetRoomMessageResponse(response, messageId);
                        next.Invoke(roomId, messageId);
                    },
                    roomId,
                    messageId);
            }

            // [PUT] /rooms/{room_id}/messages/{message_id}.
            void TestStaticPutRoomMessageAsyncCallback(long roomId, string messageId, Action<long, string> next)
            {
                var parameters = new UpdateMessageParameters
                {
                    Body = "update test message.",
                };

                ChatworkClient.PutRoomMessageAsync(
                    Token,
                    response =>
                    {
                        AssertPutRoomMessageResponse(response, messageId);
                        next.Invoke(roomId, messageId);
                    },
                    roomId,
                    messageId,
                    parameters);
            }

            // [DELETE] /rooms/{room_id}/messages/{message_id}.
            void TestStaticDeleteRoomMessageAsyncCallback(long roomId, string messageId)
            {
                ChatworkClient.DeleteRoomMessageAsync(
                    Token,
                    response => AssertDeleteRoomMessageResponse(response, messageId),
                    roomId,
                    messageId);
            }
        }

        /// <summary>
        /// Asserts "[POST] /rooms/{room_id}/messages" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertPostRoomMessageResponse(ResponseData<TargetMessageData> response)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.NotEmpty(response.Data.MessageId);
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}/messages/{message_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="messageId">The messasge id.</param>
        private static void AssertGetRoomMessageResponse(ResponseData<MessageData> response, string messageId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Equal(messageId, data.MessasgeId);
        }

        /// <summary>
        /// Asserts "[PUT] /rooms/{room_id}/messages/{message_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="messageId">The messasge id.</param>
        private static void AssertPutRoomMessageResponse(ResponseData<TargetMessageData> response, string messageId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Equal(messageId, data.MessageId);
        }

        /// <summary>
        /// Asserts "[DELETE] /rooms/{room_id}/messages/{message_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="messageId">The messaage id.</param>
        private static void AssertDeleteRoomMessageResponse(ResponseData<TargetMessageData> response, string messageId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Equal(messageId, data.MessageId);
        }
    }
}
