// <copyright file="ClientTestBase.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Test
{
    using System.Collections.Generic;
    using System.Globalization;
    using Qamur.Chatwork;
    using Qamur.Chatwork.Test.Settings;

    /// <summary>
    /// ChatworkClient test base class.
    /// </summary>
    public abstract class ClientTestBase
    {
        /// <summary>
        /// The text to warn about skipping.
        /// </summary>
        protected const string SkipWarningText = "{0} was skipped.";

        /// <summary>
        /// The test settings file path.
        /// </summary>
        private const string TestSettingsFilepath = "..\\..\\..\\test_settings.json";

        /// <summary>
        /// Gets the test settings.
        /// </summary>
        private readonly IChatworkTestSettings settings = ChatworkTestSettings.CreateFromJson(TestSettingsFilepath);

        /// <summary>
        /// The instance of <see cref="ChatworkClient"/>.
        /// </summary>
        private ChatworkClient client;

        /// <summary>
        /// Gets the instance of <see cref="ChatworkClient"/>.
        /// </summary>
        protected ChatworkClient Client => client ?? (client = new ChatworkClient(Token));

        /// <summary>
        /// Gets the API token.
        /// </summary>
        protected string Token => settings.Token;

        /// <summary>
        /// Gets the target chat room id.
        /// </summary>
        protected long Room => settings.Room;

        /// <summary>
        /// Gets the owner's account id.
        /// </summary>
        protected long AccountId => settings.AccountId;

        /// <summary>
        /// Gets the chat room ids.
        /// </summary>
        protected IReadOnlyCollection<long> RoomList => settings.RoomList;

        /// <summary>
        /// Gets the chat room member account ids.
        /// </summary>
        protected IReadOnlyCollection<long> MemberList => settings.MemberList;

        /// <summary>
        /// Notifies Warning.
        /// </summary>
        /// <param name="message">The warning message.</param>
        public static void Warn(string message)
        {
            // TODO
            System.Diagnostics.Debug.Print($"# warning: {message}");
        }

        /// <summary>
        /// Warns about skipping.
        /// </summary>
        /// <param name="skipTarget">The skip target.</param>
        public static void WarnSkip(string skipTarget)
        {
            Warn(string.Format(CultureInfo.InvariantCulture, SkipWarningText, skipTarget));
        }
    }
}
