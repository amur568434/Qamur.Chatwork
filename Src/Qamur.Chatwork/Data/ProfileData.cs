// <copyright file="ProfileData.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Data
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Profile data.
    /// </summary>
    public class ProfileData
    {
        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        /// <summary>
        /// Gets or sets the owner's chat room id.
        /// </summary>
        [JsonProperty("room_id")]
        public long RoomId { get; set; }

        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the chatwork id.
        /// </summary>
        [JsonProperty("chatwork_id")]
        public string ChatworlId { get; set; }

        /// <summary>
        /// Gets or sets the organization id.
        /// </summary>
        [JsonProperty("organization_id")]
        public long OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets the organization name.
        /// </summary>
        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the introduction.
        /// </summary>
        [JsonProperty("introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// Gets or sets the e-mail address.
        /// </summary>
        [JsonProperty("mail")]
        public string Mail { get; set; }

        /// <summary>
        /// Gets or sets the organization phone number.
        /// </summary>
        [JsonProperty("tel_organization")]
        public string TelOrganization { get; set; }

        /// <summary>
        /// Gets or sets the extension phone number.
        /// </summary>
        [JsonProperty("tel_extension")]
        public string TelExtension { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone number.
        /// </summary>
        [JsonProperty("tel_mobile")]
        public string TelMobile { get; set; }

        /// <summary>
        /// Gets or sets the skype account.
        /// </summary>
        [JsonProperty("skype")]
        public string Skype { get; set; }

        /// <summary>
        /// Gets or sets the facebook account.
        /// </summary>
        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        /// <summary>
        /// Gets or sets the twitter account.
        /// </summary>
        [JsonProperty("twittter")]
        public string Twitter { get; set; }

        /// <summary>
        /// Gets or sets the avatar image url.
        /// </summary>
        [JsonProperty("avatar_image_url")]
        public Uri AvatarImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the login e-mail address.
        /// </summary>
        [JsonProperty("login_mail")]
        public string LoginMail { get; set; }
    }
}
