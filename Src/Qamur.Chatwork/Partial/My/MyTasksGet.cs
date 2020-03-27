// <copyright file="MyTasksGet.cs" company="Kohei Oizumi">
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
    using System;
    using System.Threading.Tasks;
    using Qamur.Chatwork.Data;
    using APICommunicator = Qamur.Chatwork.Communicator.ChatworkCommunicator<Qamur.Chatwork.Communicator.APIV2Settings>;
    using DataType = System.Collections.Generic.IReadOnlyCollection<Qamur.Chatwork.Data.MyTaskData>;
    using ParametersType = Qamur.Chatwork.Parameters.MyTasksParameters;

    /// <summary>
    /// [GET] /my/tasks.
    /// </summary>
    public partial class ChatworkClient
    {
        /// <summary>
        /// Gets the list of all unfinished tasks.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<DataType> GetMyTasks(string token, ParametersType parameters = null)
        {
            return APICommunicator.Get<DataType, ParametersType>(token, Path.MyTasks, parameters);
        }

        /// <summary>
        /// Gets the list of all unfinished tasks asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static async Task<ResponseData<DataType>> GetMyTasksAsync(string token, ParametersType parameters = null)
        {
            return await APICommunicator.CreateGetTask<DataType, ParametersType>(token, Path.MyTasks, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the list of all unfinished tasks asynchronously.
        /// </summary>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="parameters">The request parameters.</param>
        public static async void GetMyTasksAsync(string token, Action<ResponseData<DataType>> callback, ParametersType parameters = null)
        {
            await APICommunicator.CreateGetTask(token, callback, Path.MyTasks, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the list of all unfinished tasks.
        /// </summary>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<DataType> GetMyTasks(ParametersType parameters = null)
        {
            return Communicator.Get<DataType, ParametersType>(Path.MyTasks, parameters);
        }

        /// <summary>
        /// Gets the list of all unfinished tasks asynchronously.
        /// </summary>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public async Task<ResponseData<DataType>> GetMyTasksAsync(ParametersType parameters = null)
        {
            return await Communicator.CreateGetTask<DataType, ParametersType>(Path.MyTasks, parameters)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the list of all unfinished tasks asynchronously.
        /// </summary>
        /// <param name="callback">The callback action.</param>
        /// <param name="parameters">The request parameters.</param>
        public async void GetMyTasksAsync(Action<ResponseData<DataType>> callback, ParametersType parameters = null)
        {
            await Communicator.CreateGetTask(callback, Path.MyTasks, parameters)
                .ConfigureAwait(false);
        }
    }
}
