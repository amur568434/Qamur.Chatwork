// <copyright file="TestRoomTasks.cs" company="Kohei Oizumi">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
    /// [GET] /rooms/{room_id}/tasks.
    /// [POST] /rooms/{room_id}/tasks.
    /// [GET] /rooms/{room_id}/tasks/{task_id}.
    /// [PUT] /rooms/{room_id}/tasks/{task_id}/status.
    /// </remarks>
    public class TestRoomTasks : ClientTestBase
    {
        /// <summary>
        /// Tests room task.
        /// </summary>
        [Fact(Skip = SkipAlreadyPassed)]
        public void TestRoomTaskLifecycle()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var taskIdList = TestGetRoomTasks(roomId);
            var extendedTaskIdList = TestPostRoomTasks(roomId);
            var taskId = extendedTaskIdList.FirstOrDefault(x => !taskIdList.Contains(x));
            TestGetRoomTask(roomId, taskId);
            TestPutRoomTaskStatus(roomId, taskId);

            // [GET] /rooms/{room_id}/tasks.
            IReadOnlyCollection<long> TestGetRoomTasks(long roomId)
            {
                var parameters = new RoomTasksParameters
                {
                    AccountId = AccountId,
                    AssignedByAccontId = AccountId,
                    Status = TaskStatusValue.Open,
                };

                var response = Client.GetRoomTasks(roomId, parameters);
                AssertGetRoomTasksResponse(response);

                return response.Data
                    ?.Select(x => x.TaskId).ToArray()
                    ?? Array.Empty<long>();
            }

            // [POST] /rooms/{room_id}/tasks.
            IReadOnlyCollection<long> TestPostRoomTasks(long roomId)
            {
                var now = DateTime.Now;
                var parameters = new NewRoomTaskParameters
                {
                    Body = $"task test {now.Ticks}",
                    Limit = now + TimeSpan.FromMinutes(60),
                    LimitType = LimitTypeValue.Date,
                    ToIds = MemberList,
                };

                var response = Client.PostRoomTask(roomId, parameters);
                AssertPostRoomTasksResponse(response);
                return response.Data.TaskIds ?? Array.Empty<long>();
            }

            // [GET] /rooms/{room_id}/tasks/{task_id}.
            void TestGetRoomTask(long roomId, long taskId)
            {
                var response = Client.GetRoomTask(roomId, taskId);
                AssertGetRoomTaskResponse(response, taskId);
            }

            // [PUT] /rooms/{room_id}/tasks/{task_id}.
            void TestPutRoomTaskStatus(long roomId, long taskId)
            {
                var parameters = new UpdateRoomTaskStatusParameters
                {
                    Body = TaskStatusValue.Done,
                };

                var response = Client.PutRoomTaskStatus(roomId, taskId, parameters);
                AssertPutRoomTaskStatusResponse(response, taskId);
            }
        }

        /// <summary>
        /// Tests room task.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticRoomTaskLifecycle()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;
            var taskIdList = TestStaticGetRoomTasks(roomId);
            var extendedTaskIdList = TestStaticPostRoomTasks(roomId);
            var taskId = extendedTaskIdList.FirstOrDefault(x => !taskIdList.Contains(x));
            TestStaticGetRoomTask(roomId, taskId);
            TestStaticPutRoomTaskStatus(roomId, taskId);

            // [GET] /rooms/{room_id}/tasks.
            IReadOnlyCollection<long> TestStaticGetRoomTasks(long roomId)
            {
                var parameters = new RoomTasksParameters
                {
                    AccountId = AccountId,
                    AssignedByAccontId = AccountId,
                    Status = TaskStatusValue.Open,
                };

                var response = ChatworkClient.GetRoomTasks(Token, roomId, parameters);
                AssertGetRoomTasksResponse(response);

                return response.Data
                    ?.Select(x => x.TaskId).ToArray()
                    ?? Array.Empty<long>();
            }

            // [POST] /rooms/{room_id}/tasks.
            IReadOnlyCollection<long> TestStaticPostRoomTasks(long roomId)
            {
                var now = DateTime.Now;
                var parameters = new NewRoomTaskParameters
                {
                    Body = $"task test {now.Ticks}",
                    Limit = now + TimeSpan.FromMinutes(60),
                    LimitType = LimitTypeValue.Date,
                    ToIds = MemberList,
                };

                var response = ChatworkClient.PostRoomTask(Token, roomId, parameters);
                AssertPostRoomTasksResponse(response);
                return response.Data.TaskIds ?? Array.Empty<long>();
            }

            // [GET] /rooms/{room_id}/tasks/{task_id}.
            void TestStaticGetRoomTask(long roomId, long taskId)
            {
                var response = ChatworkClient.GetRoomTask(Token, roomId, taskId);
                AssertGetRoomTaskResponse(response, taskId);
            }

            // [PUT] /rooms/{room_id}/tasks/{task_id}.
            void TestStaticPutRoomTaskStatus(long roomId, long taskId)
            {
                var parameters = new UpdateRoomTaskStatusParameters
                {
                    Body = TaskStatusValue.Done,
                };

                var response = ChatworkClient.PutRoomTaskStatus(Token, roomId, taskId, parameters);
                AssertPutRoomTaskStatusResponse(response, taskId);
            }
        }

        /// <summary>
        /// Tests room task asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestRoomTaskLifecycleAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            var taskIdList = await TestGetRoomTasksAsync(roomId)
                .ConfigureAwait(false);

            var extendedTaskIdList = await TestPostRoomTasksAsync(roomId)
                .ConfigureAwait(false);

            var taskId = extendedTaskIdList.FirstOrDefault(x => !taskIdList.Contains(x));

            await TestGetRoomTaskAsync(roomId, taskId)
                .ConfigureAwait(false);

            await TestPutRoomTaskStatusAsync(roomId, taskId)
                .ConfigureAwait(false);

            // [GET] /rooms/{room_id}/tasks.
            async Task<IReadOnlyCollection<long>> TestGetRoomTasksAsync(long roomId)
            {
                var parameters = new RoomTasksParameters
                {
                    AccountId = AccountId,
                    AssignedByAccontId = AccountId,
                    Status = TaskStatusValue.Open,
                };

                var response = await Client.GetRoomTasksAsync(roomId, parameters)
                    .ConfigureAwait(false);

                AssertGetRoomTasksResponse(response);

                var taskIdList = response.Data
                    ?.Select(x => x.TaskId).ToArray()
                    ?? Array.Empty<long>();

                return taskIdList;
            }

            // [POST] /rooms/{room_id}/tasks.
            async Task<IReadOnlyCollection<long>> TestPostRoomTasksAsync(long roomId)
            {
                var now = DateTime.Now;
                var parameters = new NewRoomTaskParameters
                {
                    Body = $"task test {now.Ticks}",
                    Limit = now + TimeSpan.FromMinutes(60),
                    LimitType = LimitTypeValue.Date,
                    ToIds = MemberList,
                };

                var response = await Client.PostRoomTaskAsync(roomId, parameters)
                    .ConfigureAwait(false);

                AssertPostRoomTasksResponse(response);
                var taskIdList = response.Data.TaskIds ?? Array.Empty<long>();

                return taskIdList;
            }

            // [GET] /rooms/{room_id}/tasks/{task_id}.
            async Task TestGetRoomTaskAsync(long roomId, long taskId)
            {
                var response = await Client.GetRoomTaskAsync(roomId, taskId)
                    .ConfigureAwait(false);

                AssertGetRoomTaskResponse(response, taskId);
            }

            // [PUT] /rooms/{room_id}/tasks/{task_id}/status.
            async Task TestPutRoomTaskStatusAsync(long roomId, long taskId)
            {
                var parameters = new UpdateRoomTaskStatusParameters
                {
                    Body = TaskStatusValue.Done,
                };

                var response = await Client.PutRoomTaskStatusAsync(roomId, taskId, parameters)
                    .ConfigureAwait(false);

                AssertPutRoomTaskStatusResponse(response, taskId);
            }
        }

        /// <summary>
        /// Tests room task asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public async void TestStaticRoomTaskLifecycleAsync()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            var taskIdList = await TestStaticGetRoomTasksAsync(roomId)
                .ConfigureAwait(false);

            var extendedTaskIdList = await TestStaticPostRoomTasksAsync(roomId)
                .ConfigureAwait(false);

            var taskId = extendedTaskIdList.FirstOrDefault(x => !taskIdList.Contains(x));

            await TestStaticGetRoomTaskAsync(roomId, taskId)
                .ConfigureAwait(false);

            await TestStaticPutRoomTaskStatusAsync(roomId, taskId)
                .ConfigureAwait(false);

            // [GET] /rooms/{room_id}/tasks.
            async Task<IReadOnlyCollection<long>> TestStaticGetRoomTasksAsync(long roomId)
            {
                var parameters = new RoomTasksParameters
                {
                    AccountId = AccountId,
                    AssignedByAccontId = AccountId,
                    Status = TaskStatusValue.Open,
                };

                var response = await ChatworkClient.GetRoomTasksAsync(Token, roomId, parameters)
                    .ConfigureAwait(false);

                AssertGetRoomTasksResponse(response);

                var taskIdList = response.Data
                    ?.Select(x => x.TaskId).ToArray()
                    ?? Array.Empty<long>();

                return taskIdList;
            }

            // [POST] /rooms/{room_id}/tasks.
            async Task<IReadOnlyCollection<long>> TestStaticPostRoomTasksAsync(long roomId)
            {
                var now = DateTime.Now;
                var parameters = new NewRoomTaskParameters
                {
                    Body = $"task test {now.Ticks}",
                    Limit = now + TimeSpan.FromMinutes(60),
                    LimitType = LimitTypeValue.Date,
                    ToIds = MemberList,
                };

                var response = await ChatworkClient.PostRoomTaskAsync(Token, roomId, parameters)
                    .ConfigureAwait(false);

                AssertPostRoomTasksResponse(response);

                var taskIdList = response.Data.TaskIds ?? Array.Empty<long>();
                return taskIdList;
            }

            // [GET] /rooms/{room_id}/tasks/{task_id}.
            async Task TestStaticGetRoomTaskAsync(long roomId, long taskId)
            {
                var response = await ChatworkClient.GetRoomTaskAsync(Token, roomId, taskId)
                    .ConfigureAwait(false);

                AssertGetRoomTaskResponse(response, taskId);
            }

            // [PUT] /rooms/{room_id}/tasks/{task_id}/status.
            async Task TestStaticPutRoomTaskStatusAsync(long roomId, long taskId)
            {
                var parameters = new UpdateRoomTaskStatusParameters
                {
                    Body = TaskStatusValue.Done,
                };

                var response = await ChatworkClient.PutRoomTaskStatusAsync(Token, roomId, taskId, parameters)
                    .ConfigureAwait(false);

                AssertPutRoomTaskStatusResponse(response, taskId);
            }
        }

        /// <summary>
        /// Tests room task asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestRoomTaskLifecycleAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            TestGetRoomTasksAsyncCallback(
                roomId,
                taskIdList => TestPostRoomTasksAsyncCallback(
                    roomId,
                    extendedTaskIdList =>
                    {
                        var taskId = extendedTaskIdList.FirstOrDefault(x => !taskIdList.Contains(x));
                        TestGetRoomTaskAsyncCallback(roomId, taskId);
                        TestPutRoomTaskStatusAsyncCallback(roomId, taskId);
                    }));

            // [GET] /rooms/{room_id}/tasks.
            void TestGetRoomTasksAsyncCallback(long roomId, Action<IReadOnlyCollection<long>> next)
            {
                var parameters = new RoomTasksParameters
                {
                    AccountId = AccountId,
                    AssignedByAccontId = AccountId,
                    Status = TaskStatusValue.Open,
                };

                Client.GetRoomTasksAsync(
                    response =>
                    {
                        AssertGetRoomTasksResponse(response);

                        var taskIdList = response.Data
                            ?.Select(x => x.TaskId).ToArray()
                            ?? Array.Empty<long>();

                        next.Invoke(taskIdList);
                    },
                    roomId,
                    parameters);
            }

            // [POST] /rooms/{room_id}/tasks.
            void TestPostRoomTasksAsyncCallback(long roomId, Action<IReadOnlyCollection<long>> next)
            {
                var now = DateTime.Now;
                var parameters = new NewRoomTaskParameters
                {
                    Body = $"task test {now.Ticks}",
                    Limit = now + TimeSpan.FromMinutes(60),
                    LimitType = LimitTypeValue.Date,
                    ToIds = MemberList,
                };

                Client.PostRoomTaskAsync(
                    response =>
                    {
                        AssertPostRoomTasksResponse(response);
                        var taskIdList = response.Data.TaskIds ?? Array.Empty<long>();
                        next.Invoke(taskIdList);
                    },
                    roomId,
                    parameters);
            }

            // [GET] /rooms/{room_id}/tasks/{task_id}.
            void TestGetRoomTaskAsyncCallback(long roomId, long taskId)
            {
                Client.GetRoomTaskAsync(
                    response => AssertGetRoomTaskResponse(response, taskId),
                    roomId,
                    taskId);
            }

            // [PUT] /rooms/{room_id}/tasks/{task_id}/status.
            void TestPutRoomTaskStatusAsyncCallback(long roomId, long taskId)
            {
                var parameters = new UpdateRoomTaskStatusParameters
                {
                    Body = TaskStatusValue.Done,
                };

                Client.PutRoomTaskStatusAsync(
                    response => AssertPutRoomTaskStatusResponse(response, taskId),
                    roomId,
                    taskId,
                    parameters);
            }
        }

        /// <summary>
        /// Tests room task asynchronously.
        /// </summary>
        [Fact(Skip = SkipDefault)]
        public void TestStaticRoomTaskLifecycleAsyncCallback()
        {
            var roomId = RoomList != null && RoomList.Any() ? RoomList.First() : Room;

            TestStaticGetRoomTasksAsyncCallback(
                roomId,
                taskIdList => TestStaticPostRoomTasksAsyncCallback(
                    roomId,
                    extendedTaskIdList =>
                    {
                        var taskId = extendedTaskIdList.FirstOrDefault(x => !taskIdList.Contains(x));
                        TestStaticGetRoomTaskAsyncCallback(roomId, taskId);
                        TestStaticPutRoomTaskStatusAsyncCallback(roomId, taskId);
                    }));

            // [GET] /rooms/{room_id}/tasks.
            void TestStaticGetRoomTasksAsyncCallback(long roomId, Action<IReadOnlyCollection<long>> next)
            {
                var parameters = new RoomTasksParameters
                {
                    AccountId = AccountId,
                    AssignedByAccontId = AccountId,
                    Status = TaskStatusValue.Open,
                };

                ChatworkClient.GetRoomTasksAsync(
                    Token,
                    response =>
                    {
                        AssertGetRoomTasksResponse(response);

                        var taskIdList = response.Data
                            ?.Select(x => x.TaskId).ToArray()
                            ?? Array.Empty<long>();

                        next.Invoke(taskIdList);
                    },
                    roomId,
                    parameters);
            }

            // [POST] /rooms/{room_id}/tasks.
            void TestStaticPostRoomTasksAsyncCallback(long roomId, Action<IReadOnlyCollection<long>> next)
            {
                var now = DateTime.Now;
                var parameters = new NewRoomTaskParameters
                {
                    Body = $"task test {now.Ticks}",
                    Limit = now + TimeSpan.FromMinutes(60),
                    LimitType = LimitTypeValue.Date,
                    ToIds = MemberList,
                };

                ChatworkClient.PostRoomTaskAsync(
                    Token,
                    response =>
                    {
                        AssertPostRoomTasksResponse(response);
                        var taskIdList = response.Data.TaskIds ?? Array.Empty<long>();
                        next.Invoke(taskIdList);
                    },
                    roomId,
                    parameters);
            }

            // [GET] /rooms/{room_id}/tasks/{task_id}.
            void TestStaticGetRoomTaskAsyncCallback(long roomId, long taskId)
            {
                ChatworkClient.GetRoomTaskAsync(
                    Token,
                    response => AssertGetRoomTaskResponse(response, taskId),
                    roomId,
                    taskId);
            }

            // [PUT] /rooms/{room_id}/tasks/{task_id}/status.
            void TestStaticPutRoomTaskStatusAsyncCallback(long roomId, long taskId)
            {
                var parameters = new UpdateRoomTaskStatusParameters
                {
                    Body = TaskStatusValue.Done,
                };

                ChatworkClient.PutRoomTaskStatusAsync(
                    Token,
                    response => AssertPutRoomTaskStatusResponse(response, taskId),
                    roomId,
                    taskId,
                    parameters);
            }
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}/tasks" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertGetRoomTasksResponse(ResponseData<IReadOnlyCollection<RoomTaskData>> response)
        {
            Assert.True(response.Success);
        }

        /// <summary>
        /// Asserts "[POST] /rooms/{room_id}/tasks" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        private static void AssertPostRoomTasksResponse(ResponseData<TargetRoomTasksData> response)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.NotEmpty(data.TaskIds);
        }

        /// <summary>
        /// Asserts "[GET] /rooms/{room_id}/tasks/{task_id}" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="taskId">The task id.</param>
        private static void AssertGetRoomTaskResponse(ResponseData<RoomTaskData> response, long taskId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Equal(taskId, data.TaskId);
        }

        /// <summary>
        /// Asserts "[PUT] /rooms/{room_id}/tasks/{task_id}/status" response.
        /// </summary>
        /// <param name="response">The response data.</param>
        /// <param name="taskId">The task id.</param>
        private static void AssertPutRoomTaskStatusResponse(ResponseData<TargetRoomTaskData> response, long taskId)
        {
            Assert.True(response.Success);

            var data = response.Data;
            Assert.NotNull(data);
            Assert.Equal(taskId, data.TaskId);
        }
    }
}
