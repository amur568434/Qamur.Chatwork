// <copyright file="SkipText.cs" company="Kohei Oizumi">
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
    /// <summary>
    /// The skip reasons.
    /// Sets null to run the test.
    /// </summary>
    internal static class SkipText
    {
        /// <summary>
        /// The xUnit skip parameter.
        /// </summary>
        public const string SkipNull = null;

        /// <summary>
        /// The xUnit skip parameter.
        /// </summary>
        public const string SkipDefault = "Skip default.";

        /// <summary>
        /// The xUnit skip parameter.
        /// </summary>
        public const string SkipNotReady = "Not ready.";

        /// <summary>
        /// The xUnit skip parameter.
        /// </summary>
        public const string SkipAlreadyPassed = "Already passed.";

        /// <summary>
        /// The xUnit skip parameter.
        /// </summary>
        public const string SkipParameterCheck = "This test method is written only to check parameters in the code.";
    }
}
