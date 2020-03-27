// <copyright file="IconPresetValue.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.ObjectValues
{
    using Qamur.Chatwork.CustomAttribute;

    /// <summary>
    /// The room icon preset values.
    /// </summary>
    public enum IconPresetValue
    {
        /// <summary>
        /// group.
        /// </summary>
        [StringValue("group")]
        Group = 1,

        /// <summary>
        /// check.
        /// </summary>
        [StringValue("check")]
        Check = 2,

        /// <summary>
        /// document.
        /// </summary>
        [StringValue("document")]
        Document = 3,

        /// <summary>
        /// meeting.
        /// </summary>
        [StringValue("meeting")]
        Meeting = 4,

        /// <summary>
        /// event.
        /// </summary>
        [StringValue("event")]
        Event = 5,

        /// <summary>
        /// project.
        /// </summary>
        [StringValue("project")]
        Project = 6,

        /// <summary>
        /// business.
        /// </summary>
        [StringValue("business")]
        Business = 7,

        /// <summary>
        /// study.
        /// </summary>
        [StringValue("study")]
        Study = 8,

        /// <summary>
        /// security.
        /// </summary>
        [StringValue("security")]
        Security = 9,

        /// <summary>
        /// star.
        /// </summary>
        [StringValue("star")]
        Star = 10,

        /// <summary>
        /// idea.
        /// </summary>
        [StringValue("idea")]
        Idea = 11,

        /// <summary>
        /// heart.
        /// </summary>
        [StringValue("heart")]
        Heart = 12,
    }
}
