// <copyright file="IChatworkTestSettings.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Test.Settings
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// The interface of chatwork client test settings.
    /// </summary>
    internal interface IChatworkTestSettings
    {
        /// <summary>
        /// Gets the API token.
        /// </summary>
        string Token { get; }

        /// <summary>
        /// Gets the owner's chat room id.
        /// </summary>
        long Room { get; }

        /// <summary>
        /// Gets the owner's account id.
        /// </summary>
        long AccountId { get; }

        /// <summary>
        /// Gets the chat room ids.
        /// </summary>
        IReadOnlyCollection<long> RoomList { get; }

        /// <summary>
        /// Gets the chat room member account ids.
        /// </summary>
        IReadOnlyCollection<long> MemberList { get; }
    }
}
