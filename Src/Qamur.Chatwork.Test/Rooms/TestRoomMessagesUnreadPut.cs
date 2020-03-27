// <copyright file="TestRoomMessagesUnreadPut.cs" company="Kohei Oizumi">
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
    /// [PUT] /rooms/{room_id}/messages/unread.
    /// </remarks>
    public class TestRoomMessagesUnreadPut : ClientTestBase
    {
        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/messages/unread.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestPutRoomMessagesUnread()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var getMessagesParameters = new MessagesParameters { Force = true };
            var messagesResponse = ChatworkClient.GetRoomMessages(Token, roomId, getMessagesParameters);

            AssertGetRoomMessagesResponse(messagesResponse);

            if (messagesResponse.Data == null || !messagesResponse.Data.Any())
            {
                WarnSkip("TestPutRoomMessagesUnread");
                return;
            }

            var messages = messagesResponse.Data;
            var messageId = messages.FirstOrDefault(x => x.Body != "[deleted]").MessasgeId;

            if (string.IsNullOrEmpty(messageId))
            {
                WarnSkip("TestPutRoomMessagesUnread");
                return;
            }

            var parameters = new TargetMessageParameters { MessageId = messageId };
            var response = Client.PutRoomMessagesUnread(roomId, parameters);
            AssertPutRoomMessagesUnreadResponse(response);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/messages/unread.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticPutRoomMessagesUnread()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var getMessagesParameters = new MessagesParameters { Force = true };
            var messagesResponse = ChatworkClient.GetRoomMessages(Token, roomId, getMessagesParameters);

            AssertGetRoomMessagesResponse(messagesResponse);

            if (messagesResponse.Data == null || !messagesResponse.Data.Any())
            {
                WarnSkip("TestPutRoomMessagesUnread");
                return;
            }

            var messages = messagesResponse.Data;
            var messageId = messages.FirstOrDefault(x => x.Body != "[deleted]").MessasgeId;

            if (string.IsNullOrEmpty(messageId))
            {
                WarnSkip("TestPutRoomMessagesUnread");
                return;
            }

            var parameters = new TargetMessageParameters { MessageId = messageId };
            var response = ChatworkClient.PutRoomMessagesUnread(Token, roomId, parameters);
            AssertPutRoomMessagesUnreadResponse(response);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/messages/read.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestPutRoomMessagesUnreadAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var getMessagesParameters = new MessagesParameters { Force = true };
            var messagesResponse = await Client
                .GetRoomMessagesAsync(roomId, getMessagesParameters)
                .ConfigureAwait(false);

            AssertGetRoomMessagesResponse(messagesResponse);

            if (messagesResponse.Data == null || !messagesResponse.Data.Any())
            {
                WarnSkip("TestPutRoomMessagesUnreadAsync");
                return;
            }

            var messages = messagesResponse.Data;
            var messageId = messages.FirstOrDefault(x => x.Body != "[deleted]").MessasgeId;

            if (string.IsNullOrEmpty(messageId))
            {
                WarnSkip("TestPutRoomMessagesUnreadAsync");
                return;
            }

            var parameters = new TargetMessageParameters { MessageId = messageId };
            var response = await Client
                .PutRoomMessagesUnreadAsync(roomId, parameters)
                .ConfigureAwait(false);

            AssertPutRoomMessagesUnreadResponse(response);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/messages/read.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticPutRoomMessagesUnreadAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var getMessagesParameters = new MessagesParameters { Force = true };
            var messagesResponse = await ChatworkClient
                .GetRoomMessagesAsync(Token, roomId, getMessagesParameters)
                .ConfigureAwait(false);

            AssertGetRoomMessagesResponse(messagesResponse);

            if (messagesResponse.Data == null || !messagesResponse.Data.Any())
            {
                WarnSkip("TestStaticPutRoomMessagesUnreadAsync");
                return;
            }

            var messages = messagesResponse.Data;
            var messageId = messages.FirstOrDefault(x => x.Body != "[deleted]").MessasgeId;

            if (string.IsNullOrEmpty(messageId))
            {
                WarnSkip("TestStaticPutRoomMessagesUnreadAsync");
                return;
            }

            var parameters = new TargetMessageParameters { MessageId = messageId };
            var response = await ChatworkClient
                .PutRoomMessagesUnreadAsync(Token, roomId, parameters)
                .ConfigureAwait(false);

            AssertPutRoomMessagesUnreadResponse(response);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/messages/read.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestPutRoomMessagesUnreadAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var getMessagesParameters = new MessagesParameters { Force = true };
            Client.GetRoomMessagesAsync(
                messagesResponse =>
                {
                    AssertGetRoomMessagesResponse(messagesResponse);

                    if (messagesResponse.Data == null || !messagesResponse.Data.Any())
                    {
                        WarnSkip("TestPutRoomMessagesUnreadAsync");
                        return;
                    }

                    var messages = messagesResponse.Data;
                    var messageId = messages.FirstOrDefault(x => x.Body != "[deleted]").MessasgeId;

                    if (string.IsNullOrEmpty(messageId))
                    {
                        WarnSkip("TestPutRoomMessagesUnreadAsync");
                        return;
                    }

                    var parameters = new TargetMessageParameters { MessageId = messageId };
                    Client.PutRoomMessagesUnreadAsync(
                        AssertPutRoomMessagesUnreadResponse,
                        roomId,
                        parameters);
                },
                roomId,
                getMessagesParameters);
        }

        /// <summary>
        /// Tests [PUT] /rooms/{room_id}/messages/read.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticPutRoomMessagesUnreadAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var getMessagesParameters = new MessagesParameters { Force = true };
            ChatworkClient.GetRoomMessagesAsync(
                Token,
                messagesResponse =>
                {
                    AssertGetRoomMessagesResponse(messagesResponse);

                    if (messagesResponse.Data == null || !messagesResponse.Data.Any())
                    {
                        WarnSkip("TestStaticPutRoomMessagesUnreadAsync");
                        return;
                    }

                    var messages = messagesResponse.Data;
                    var messageId = messages.FirstOrDefault(x => x.Body != "[deleted]").MessasgeId;

                    if (string.IsNullOrEmpty(messageId))
                    {
                        WarnSkip("TestStaticPutRoomMessagesUnreadAsync");
                        return;
                    }

                    var parameters = new TargetMessageParameters { MessageId = messageId };
                    ChatworkClient.PutRoomMessagesUnreadAsync(
                        Token,
                        AssertPutRoomMessagesUnreadResponse,
                        roomId,
                        parameters);
                },
                roomId,
                getMessagesParameters);
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}/messages" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetRoomMessagesResponse(ResponseData<IReadOnlyCollection<MessageData>> response)
        {
            Assert.True(response.Success);
        }

        /// <summary>
        /// Asserts "[PUT] /rooms/{room_id}/messages/unread" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertPutRoomMessagesUnreadResponse(ResponseData<MessagesUnreadSummaryData> response)
        {
            if (response.Success)
            {
                return;
            }

            Assert.Equal(400, response.StatusCode);
            return;
        }
    }
}
