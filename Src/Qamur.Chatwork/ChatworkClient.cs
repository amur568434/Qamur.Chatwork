// <copyright file="ChatworkClient.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork
{
    using Qamur.Chatwork.Communicator;
    using APICommunicator = Qamur.Chatwork.Communicator.ChatworkCommunicator<Qamur.Chatwork.Communicator.APIV2Settings>;

    /// <summary>
    /// Chatwork API client.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatworkClient"/> class.
        /// </summary>
        /// <param name="token">The API token.</param>
        public ChatworkClient(string token)
        {
            Communicator = new ChatworkCommunicator<APIV2Settings>(token);
        }

        /// <summary>
        /// Gets the API communicator.
        /// </summary>
        private APICommunicator Communicator { get; }

        /// <summary>
        /// The API endpoint paths.
        /// </summary>
        private static class Path
        {
            // me.
            public const string Me = "/me";

            // my.
            public const string MyStatus = "/my/status";
            public const string MyTasks = "/my/tasks";

            // contacts.
            public const string Contacts = "/contacts";

            // rooms.
            public const string Rooms = "/rooms";
            public const string Room = "/rooms/{0}";
            public const string RoomMembers = "/rooms/{0}/members";
            public const string RoomMessages = "/rooms/{0}/messages";
            public const string RoomMessagesRead = "/rooms/{0}/messages/read";
            public const string RoomMessagesUnread = "/rooms/{0}/messages/unread";
            public const string RoomMessage = "/rooms/{0}/messages/{1}";
            public const string RoomTasks = "/rooms/{0}/tasks";
            public const string RoomTask = "/rooms/{0}/tasks/{1}";
            public const string RoomTaskStatus = "/rooms/{0}/tasks/{1}/status";
            public const string RoomFiles = "/rooms/{0}/files";
            public const string RoomFile = "/rooms/{0}/files/{1}";
            public const string RoomLink = "/rooms/{0}/link";

            // incoming_requests.
            public const string IncomingRequests = "/incoming_requests";
            public const string IncomingRequest = "/incoming_requests/{0}";
        }
    }
}
