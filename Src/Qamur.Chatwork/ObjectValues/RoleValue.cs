// <copyright file="RoleValue.cs" company="Kohei Oizumi">
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
    /// The values of account role in the room.
    /// </summary>
    public enum RoleValue
    {
        /// <summary>
        /// The administrator member.
        /// </summary>
        [StringValue("admin")]
        Admin = 1,

        /// <summary>
        /// The member.
        /// </summary>
        [StringValue("member")]
        Member = 2,

        /// <summary>
        /// The readonly member.
        /// </summary>
        [StringValue("readnly")]
        Readonly = 3,
    }
}
