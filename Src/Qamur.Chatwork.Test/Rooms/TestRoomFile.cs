// <copyright file="TestRoomFile.cs" company="Kohei Oizumi">
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
    /// [POST] /rooms/{room_id}/files.
    /// [GET] /rooms/{room_id}/files/{file_id}.
    /// </remarks>
    public class TestRoomFile : ClientTestBase
    {
        /// <summary>
        /// New file parameters.
        /// </summary>
        private readonly NewFileParameters textFileContent = new NewFileParameters
        {
            File = new FileContent
            {
                Content = "test text",
                Name = "test.txt",
            },
            Message = "upload test file",
        };

        /// <summary>
        /// Tests file.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestRoomFileLifecycle()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var newParameters = textFileContent;

            var newResponse = Client.PostRoomFile(roomId, newParameters);

            AssertPostFileResponse(newResponse);

            var fileId = newResponse.Data.FileId;
            var parameters = new FileParameters
            {
                CreateDownloadUrl = true,
            };

            var response = Client.GetRoomFile(roomId, fileId, parameters);

            AssertGetFileResponse(response, fileId);
        }

        /// <summary>
        /// Tests file.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticRoomFileLifecycle()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var newParameters = textFileContent;

            var newResponse = ChatworkClient.PostRoomFile(Token, roomId, newParameters);

            AssertPostFileResponse(newResponse);

            var fileId = newResponse.Data.FileId;
            var parameters = new FileParameters
            {
                CreateDownloadUrl = true,
            };

            var response = ChatworkClient.GetRoomFile(Token, roomId, fileId, parameters);

            AssertGetFileResponse(response, fileId);
        }

        /// <summary>
        /// Tests file asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestRoomFileLifecycleAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var newParameters = textFileContent;

            var newResponse = await Client.PostRoomFileAsync(roomId, newParameters)
                .ConfigureAwait(false);

            AssertPostFileResponse(newResponse);

            var fileId = newResponse.Data.FileId;
            var parameters = new FileParameters
            {
                CreateDownloadUrl = true,
            };

            var response = await Client.GetRoomFileAsync(roomId, fileId, parameters)
                .ConfigureAwait(false);

            AssertGetFileResponse(response, fileId);
        }

        /// <summary>
        /// Tests file asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticRoomFileLifecycleAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var newParameters = textFileContent;

            var newResponse = await ChatworkClient.PostRoomFileAsync(Token, roomId, newParameters)
                .ConfigureAwait(false);

            AssertPostFileResponse(newResponse);

            var fileId = newResponse.Data.FileId;
            var parameters = new FileParameters
            {
                CreateDownloadUrl = true,
            };

            var response = await ChatworkClient.GetRoomFileAsync(Token, roomId, fileId, parameters)
                .ConfigureAwait(false);

            AssertGetFileResponse(response, fileId);
        }

        /// <summary>
        /// Tests file asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestRoomFileLifecycleAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            TestPostRoomFileAsyncCallback(roomId, TestGetRoomFileAsyncCallback);

            // [POST] /rooms/{room_id}/files.
            void TestPostRoomFileAsyncCallback(long roomId, Action<long, long> next)
            {
                var parameters = textFileContent;

                Client.PostRoomFileAsync(
                    response =>
                    {
                        AssertPostFileResponse(response);
                        next.Invoke(roomId, response.Data.FileId);
                    },
                    roomId,
                    parameters);
            }

            // [GET] /rooms/{room_id}/files/{file_id}.
            void TestGetRoomFileAsyncCallback(long roomId, long fileId)
            {
                var parameters = new FileParameters
                {
                    CreateDownloadUrl = true,
                };

                Client.GetRoomFileAsync(
                    response => AssertGetFileResponse(response, fileId),
                    roomId,
                    fileId,
                    parameters);
            }
        }

        /// <summary>
        /// Tests file asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticRoomFileLifecycleAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            TestStaticPostRoomFileAsyncCallback(roomId, TestStaticGetRoomFileAsyncCallback);

            // [POST] /rooms/{room_id}/files.
            void TestStaticPostRoomFileAsyncCallback(long roomId, Action<long, long> next)
            {
                var parameters = textFileContent;

                ChatworkClient.PostRoomFileAsync(
                    Token,
                    response =>
                    {
                        AssertPostFileResponse(response);
                        next.Invoke(roomId, response.Data.FileId);
                    },
                    roomId,
                    parameters);
            }

            // [GET] /rooms/{room_id}/files/{file_id}.
            void TestStaticGetRoomFileAsyncCallback(long roomId, long fileId)
            {
                var parameters = new FileParameters
                {
                    CreateDownloadUrl = true,
                };

                ChatworkClient.GetRoomFileAsync(
                    Token,
                    response => AssertGetFileResponse(response, fileId),
                    roomId,
                    fileId,
                    parameters);
            }
        }

        /// <summary>
        /// Asserts "[POST] /rooms/{room_id}/files" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertPostFileResponse(ResponseData<TargetFileData> response)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.True(data.FileId > 0);
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}/files/{file_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="fileId">The file id.</param>
        private static void AssertGetFileResponse(ResponseData<FileData> response, long fileId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Equal(fileId, data.FileId);
        }
    }
}
