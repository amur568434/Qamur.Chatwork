// <copyright file="TestRoom.cs" company="Kohei Oizumi">
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
    using System.Globalization;
    using System.Threading.Tasks;
    using Qamur.Chatwork.CustomAttribute;
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
    /// [POST] /rooms.
    /// [GET] /rooms/{room_id}.
    /// [PUT] /rooms/{room_id}.
    /// [DELETE] /rooms/{room_id}.
    /// </remarks>
    public class TestRoom : ClientTestBase
    {
        /// <summary>
        /// Tests room.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestRoomLifecycle()
        {
            const string roomName = "Room Lifecycle {0}";
            const string roomDescription = "Description of the room lifecycle {0}";
            var roomId = TestCreateRoom();
            TestGetRoom(roomId);
            TestPutRoom(roomId);
            TestDeleteRoom(roomId);

            // [POST] /rooms.
            long TestCreateRoom()
            {
                var identifier = "New";
                var parameters = new NewRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = IconPresetValue.Group,
                    Link = false,
                    LinkCode = "jlklqwes",
                    LinkNeedAcceptance = true,
                    MembersAdminIds = new[] { AccountId },
                    MembersMemberIds = MemberList,
                    MembersReadonlyIds = null,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                var response = Client.PostRoom(parameters);
                AssertPostRoomsResponse(response);
                return response.Data.RoomId;
            }

            // [GET] /rooms/{room_id}.
            void TestGetRoom(long roomId)
            {
                var response = Client.GetRoom(roomId);
                AssertGetRoomResponse(response, roomId);
            }

            // [PUT] /rooms/{room_id}.
            void TestPutRoom(long roomId)
            {
                var iconPresetList = Enum.GetValues(typeof(IconPresetValue));

                foreach (IconPresetValue iconPreset in iconPresetList)
                {
                    var identifier = string.Format(
                        CultureInfo.InvariantCulture,
                        "[{0}]",
                        StringValueAttribute.GetStringValue(iconPreset));

                    var parameters = new UpdateRoomParameters
                    {
                        Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                        IconPreset = iconPreset,
                        Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                    };

                    var response = Client.PutRoom(roomId, parameters);
                    AssertPutRoomResponse(response, roomId);
                }
            }

            // [DELETE] /rooms/{room_id}.
            void TestDeleteRoom(long roomId)
            {
                var parameters = new DeleteRoomParameters
                {
                    ActionType = ActionTypeValue.Delete,
                };

                var response = Client.DeleteRoom(roomId, parameters);
                AssertDeleteRoomResponse(response);
            }
        }

        /// <summary>
        /// Tests room.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticRoomLifecycle()
        {
            const string roomName = "Room Lifecycle {0}";
            const string roomDescription = "Description of the room lifecycle {0}";
            var roomId = TestStaticCreateRoom();
            TestStaticGetRoom(roomId);
            TestStaticPutRoom(roomId);
            TestStaticDeleteRoom(roomId);

            // [POST] /rooms.
            long TestStaticCreateRoom()
            {
                var identifier = "New";
                var parameters = new NewRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = IconPresetValue.Group,
                    Link = false,
                    LinkCode = "jlklqwes",
                    LinkNeedAcceptance = true,
                    MembersAdminIds = new[] { AccountId },
                    MembersMemberIds = null,
                    MembersReadonlyIds = null,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                var response = ChatworkClient.PostRoom(Token, parameters);
                AssertPostRoomsResponse(response);

                return response.Data.RoomId;
            }

            // [GET] /rooms/{room_id}.
            void TestStaticGetRoom(long roomId)
            {
                var response = ChatworkClient.GetRoom(Token, roomId);
                AssertGetRoomResponse(response, roomId);
            }

            // [PUT] /rooms/{room_id}.
            void TestStaticPutRoom(long roomId)
            {
                var iconPresetList = Enum.GetValues(typeof(IconPresetValue));

                foreach (IconPresetValue iconPreset in iconPresetList)
                {
                    var identifier = string.Format(
                        CultureInfo.InvariantCulture,
                        "[{0}]",
                        StringValueAttribute.GetStringValue(iconPreset));

                    var parameters = new UpdateRoomParameters
                    {
                        Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                        IconPreset = iconPreset,
                        Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                    };

                    var response = ChatworkClient.PutRoom(Token, roomId, parameters);
                    AssertPutRoomResponse(response, roomId);
                }
            }

            // [DELETE] /rooms/{room_id}.
            void TestStaticDeleteRoom(long roomId)
            {
                var parameters = new DeleteRoomParameters
                {
                    ActionType = ActionTypeValue.Delete,
                };

                var response = ChatworkClient.DeleteRoom(Token, roomId, parameters);
                AssertDeleteRoomResponse(response);
            }
        }

        /// <summary>
        /// Tests room asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestRoomLifecycleAsync()
        {
            const string roomName = "Room Lifecycle {0}";
            const string roomDescription = "Description of the room lifecycle {0}";

            var roomId = await TestCreateRoomAsync()
                .ConfigureAwait(false);

            await TestPutRoomAsync(roomId)
                .ConfigureAwait(false);

            await TestGetRoomAsync(roomId)
                .ConfigureAwait(false);

            await TestDeleteRoomAsync(roomId)
                .ConfigureAwait(false);

            // [POST] /rooms.
            async Task<long> TestCreateRoomAsync()
            {
                var identifier = "New";
                var parameters = new NewRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = IconPresetValue.Group,
                    Link = false,
                    LinkCode = "weqxdfas",
                    LinkNeedAcceptance = true,
                    MembersAdminIds = new[] { AccountId },
                    MembersMemberIds = null,
                    MembersReadonlyIds = MemberList,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                var response = await Client.PostRoomAsync(parameters)
                    .ConfigureAwait(false);

                AssertPostRoomsResponse(response);
                return response.Data.RoomId;
            }

            // [GET] /rooms/{room_id}.
            async Task TestGetRoomAsync(long roomId)
            {
                var response = await Client.GetRoomAsync(roomId)
                    .ConfigureAwait(false);

                AssertGetRoomResponse(response, roomId);
            }

            // [PUT] /rooms/{room_id}.
            async Task TestPutRoomAsync(long roomId)
            {
                var iconPreset = IconPresetValue.Business;
                var identifier = StringValueAttribute.GetStringValue(iconPreset);
                var parameters = new UpdateRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = iconPreset,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                var response = await Client.PutRoomAsync(roomId, parameters)
                    .ConfigureAwait(false);

                AssertPutRoomResponse(response, roomId);
            }

            // [DELETE] /rooms/{room_id}.
            async Task TestDeleteRoomAsync(long roomId)
            {
                var parameters = new DeleteRoomParameters
                {
                    ActionType = ActionTypeValue.Leave,
                };

                var response = await Client.DeleteRoomAsync(roomId, parameters)
                    .ConfigureAwait(false);

                AssertDeleteRoomResponse(response);
            }
        }

        /// <summary>
        /// Tests room asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticRoomLifecycleAsync()
        {
            const string roomName = "Room Lifecycle {0}";
            const string roomDescription = "Description of the room lifecycle {0}";

            var roomId = await TestStaticCreateRoomAsync()
                .ConfigureAwait(false);

            await TestStaticPutRoomAsync(roomId)
                .ConfigureAwait(false);

            await TestStaticGetRoomAsync(roomId)
                .ConfigureAwait(false);

            await TestStaticDeleteRoomAsync(roomId)
                .ConfigureAwait(false);

            // [POST] /rooms.
            async Task<long> TestStaticCreateRoomAsync()
            {
                var identifier = "New";
                var parameters = new NewRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = IconPresetValue.Group,
                    Link = false,
                    LinkCode = "weqxdfas",
                    LinkNeedAcceptance = true,
                    MembersAdminIds = new[] { AccountId },
                    MembersMemberIds = null,
                    MembersReadonlyIds = null,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                var response = await ChatworkClient.PostRoomAsync(Token, parameters)
                    .ConfigureAwait(false);

                AssertPostRoomsResponse(response);
                return response.Data.RoomId;
            }

            // [GET] /rooms/{room_id}.
            async Task TestStaticGetRoomAsync(long roomId)
            {
                var response = await ChatworkClient.GetRoomAsync(Token, roomId)
                    .ConfigureAwait(false);

                AssertGetRoomResponse(response, roomId);
            }

            // [PUT] /rooms/{room_id}.
            async Task TestStaticPutRoomAsync(long roomId)
            {
                var iconPreset = IconPresetValue.Business;
                var identifier = StringValueAttribute.GetStringValue(iconPreset);
                var parameters = new UpdateRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = iconPreset,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                var response = await ChatworkClient.PutRoomAsync(Token, roomId, parameters)
                    .ConfigureAwait(false);

                AssertPutRoomResponse(response, roomId);
            }

            // [DELETE] /rooms/{room_id}.
            async Task TestStaticDeleteRoomAsync(long roomId)
            {
                var parameters = new DeleteRoomParameters
                {
                    ActionType = ActionTypeValue.Leave,
                };

                var response = await ChatworkClient.DeleteRoomAsync(Token, roomId, parameters)
                    .ConfigureAwait(false);

                AssertDeleteRoomResponse(response);
            }
        }

        /// <summary>
        /// Tests room asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestRoomLifecycleAsyncCallback()
        {
            const string roomName = "Room Lifecycle {0}";
            const string roomDescription = "Description of the room lifecycle {0}";

            TestCreateRoomAsyncCallback(
                roomId => TestPutRoomAsyncCallback(
                    roomId,
                    roomId => TestGetRoomAsyncCallback(
                        roomId,
                        TestDeleteRoomAsyncCallback)));

            // [POST] /rooms.
            void TestCreateRoomAsyncCallback(Action<long> next)
            {
                var identifier = "New";
                var parameters = new NewRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = IconPresetValue.Group,
                    Link = false,
                    LinkCode = "weqxdfas",
                    LinkNeedAcceptance = true,
                    MembersAdminIds = new[] { AccountId },
                    MembersMemberIds = null,
                    MembersReadonlyIds = MemberList,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                Client.PostRoomAsync(
                    response =>
                    {
                        AssertPostRoomsResponse(response);
                        next.Invoke(response.Data.RoomId);
                    },
                    parameters);
            }

            // [GET] /rooms/{room_id}.
            void TestGetRoomAsyncCallback(long roomId, Action<long> next)
            {
                Client.GetRoomAsync(
                    response =>
                    {
                        AssertGetRoomResponse(response, roomId);
                        next.Invoke(roomId);
                    },
                    roomId);
            }

            // [PUT] /rooms/{room_id}.
            void TestPutRoomAsyncCallback(long roomId, Action<long> next)
            {
                var iconPreset = IconPresetValue.Business;
                var identifier = StringValueAttribute.GetStringValue(iconPreset);
                var parameters = new UpdateRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = iconPreset,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                Client.PutRoomAsync(
                    response =>
                    {
                        AssertPutRoomResponse(response, roomId);
                        next.Invoke(roomId);
                    },
                    roomId,
                    parameters);
            }

            // [DELETE] /rooms/{room_id}.
            void TestDeleteRoomAsyncCallback(long roomId)
            {
                var parameters = new DeleteRoomParameters
                {
                    ActionType = ActionTypeValue.Leave,
                };

                Client.DeleteRoomAsync(
                    response => AssertDeleteRoomResponse(response),
                    roomId,
                    parameters);
            }
        }

        /// <summary>
        /// Tests room asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticRoomLifecycleAsyncCallback()
        {
            const string roomName = "Room Lifecycle {0}";
            const string roomDescription = "Description of the room lifecycle {0}";

            TestStaticCreateRoomAsyncCallback(
                roomId => TestStaticPutRoomAsyncCallback(
                    roomId,
                    roomId => TestStaticGetRoomAsyncCallback(
                        roomId,
                        TestStaticDeleteRoomAsyncCallback)));

            // [POST] /rooms.
            void TestStaticCreateRoomAsyncCallback(Action<long> next)
            {
                var identifier = "New";
                var parameters = new NewRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = IconPresetValue.Group,
                    Link = false,
                    LinkCode = "weqxdfas",
                    LinkNeedAcceptance = true,
                    MembersAdminIds = new[] { AccountId },
                    MembersMemberIds = null,
                    MembersReadonlyIds = null,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                ChatworkClient.PostRoomAsync(
                    Token,
                    response =>
                    {
                        AssertPostRoomsResponse(response);
                        next.Invoke(response.Data.RoomId);
                    },
                    parameters);
            }

            // [GET] /rooms/{room_id}.
            void TestStaticGetRoomAsyncCallback(long roomId, Action<long> next)
            {
                ChatworkClient.GetRoomAsync(
                    Token,
                    response =>
                    {
                        AssertGetRoomResponse(response, roomId);
                        next.Invoke(roomId);
                    },
                    roomId);
            }

            // [PUT] /rooms/{room_id}.
            void TestStaticPutRoomAsyncCallback(long roomId, Action<long> next)
            {
                var iconPreset = IconPresetValue.Business;
                var identifier = StringValueAttribute.GetStringValue(iconPreset);
                var parameters = new UpdateRoomParameters
                {
                    Description = string.Format(CultureInfo.InvariantCulture, roomDescription, identifier),
                    IconPreset = iconPreset,
                    Name = string.Format(CultureInfo.InvariantCulture, roomName, identifier),
                };

                ChatworkClient.PutRoomAsync(
                    Token,
                    response =>
                    {
                        AssertPutRoomResponse(response, roomId);
                        next.Invoke(roomId);
                    },
                    roomId,
                    parameters);
            }

            // [DELETE] /rooms/{room_id}.
            void TestStaticDeleteRoomAsyncCallback(long roomId)
            {
                var parameters = new DeleteRoomParameters
                {
                    ActionType = ActionTypeValue.Leave,
                };

                ChatworkClient.DeleteRoomAsync(
                    Token,
                    response => AssertDeleteRoomResponse(response),
                    roomId,
                    parameters);
            }
        }

        /// <summary>
        /// Asserts "[POST] /rooms" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertPostRoomsResponse(ResponseData<TargetRoomData> response)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.True(data.RoomId > 0);
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="roomId">The chat room id.</param>
        private static void AssertGetRoomResponse(ResponseData<RoomData> response, long roomId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Equal(roomId, data.RoomId);
        }

        /// <summary>
        /// Asserts "[PUT] /rooms/{room_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="roomId">The room id.</param>
        private static void AssertPutRoomResponse(ResponseData<TargetRoomData> response, long roomId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Equal(roomId, data.RoomId);
        }

        /// <summary>
        /// Asserts "[DELETE] /rooms/{room_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertDeleteRoomResponse(ResponseData<object> response)
        {
            Assert.True(response.Success);
        }
    }
}
