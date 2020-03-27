// <copyright file="ChatworkCommunicator.cs" company="Kohei Oizumi">
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

namespace Qamur.Chatwork.Communicator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Qamur.Chatwork.Data;
    using Qamur.Chatwork.ObjectValues;
    using Qamur.Chatwork.Parameters;
    using RestSharp;

    /// <summary>
    /// This class communicates with Chatwork API.
    /// </summary>
    /// <typeparam name="TSettings">The API connection settings class.</typeparam>
    internal class ChatworkCommunicator<TSettings>
        where TSettings : IConnectionSettings
    {
        /// <summary>
        /// The API setting data.
        /// </summary>
        private static readonly TSettings Settings = Internal.GetSettings<TSettings>();

        /// <summary>
        /// The API endpoint base url.
        /// </summary>
        private static readonly string EndpointBase = Settings.EndpointBase;

        /// <summary>
        /// The API token key.
        /// </summary>
        private static readonly string TokenKey = Settings.TokenKey;

        /// <summary>
        /// The request timeout (milliseconds).
        /// </summary>
        private static readonly int RequestTimeout = Settings.RequestTimeout;

        /// <summary>
        /// The maximum upload file size.
        /// </summary>
        private static readonly int MaxFileSize = Settings.MaxFileSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatworkCommunicator{TSettings}"/> class.
        /// </summary>
        /// <param name="token">The API token.</param>
        public ChatworkCommunicator(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Gets or sets the API Token.
        /// </summary>
        private string Token { get; set; }

        /* static GET */

        /// <summary>
        /// Sends a "GET" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> Get<TResult>(string token, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Request<TResult>(token, "GET", path, parameters);
        }

        /// <summary>
        /// Sends a "GET" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> Get<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return Request<TResult, TRequest>(token, "GET", path, parameters);
        }

        /// <summary>
        /// Creates a "GET" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreateGetTask<TResult>(string token, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask<TResult>(token, "GET", path, parameters);
        }

        /// <summary>
        /// Creates a "GET" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreateGetTask<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask<TResult, TRequest>(token, "GET", path, parameters);
        }

        /// <summary>
        /// Creates a "GET" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreateGetTask<TResult>(string token, Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask(token, callback, "GET", path, parameters);
        }

        /// <summary>
        /// Creates a "GET" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreateGetTask<TResult, TRequest>(string token, Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask(token, callback, "GET", path, parameters);
        }

        /* static POST */

        /// <summary>
        /// Sends a "POST" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> Post<TResult>(string token, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Request<TResult>(token, "POST", path, parameters);
        }

        /// <summary>
        /// Sends a "POST" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> Post<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return Request<TResult, TRequest>(token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreatePostTask<TResult>(string token, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask<TResult>(token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreatePostTask<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask<TResult, TRequest>(token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreatePostTask<TResult>(string token, Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask(token, callback, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreatePostTask<TResult, TRequest>(string token, Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask(token, callback, "POST", path, parameters);
        }

        /// <summary>
        /// Sends a "POST" multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> PostMultipart<TResult>(string token, string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return RequestMultipart<TResult>(token, "POST", path, parameters);
        }

        /// <summary>
        /// Sends a "POST" multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> PostMultipart<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return RequestMultipart<TResult, TRequest>(token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreatePostMultipartTask<TResult>(string token, string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return CreateRequestMultipartTask<TResult>(token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreatePostMultipartTask<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestMultipartTask<TResult, TRequest>(token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreatePostMultipartTask<TResult>(string token, Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return CreateRequestMultipartTask(token, callback, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreatePostMultipartTask<TResult, TRequest>(string token, Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestMultipartTask(token, callback, "POST", path, parameters);
        }

        /* static PUT */

        /// <summary>
        /// Sends a "PUT" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> Put<TResult>(string token, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Request<TResult>(token, "PUT", path, parameters);
        }

        /// <summary>
        /// Sends a "PUT" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> Put<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return Request<TResult, TRequest>(token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreatePutTask<TResult>(string token, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask<TResult>(token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreatePutTask<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask<TResult, TRequest>(token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreatePutTask<TResult>(string token, Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask(token, callback, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreatePutTask<TResult, TRequest>(string token, Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask(token, callback, "PUT", path, parameters);
        }

        /// <summary>
        /// Sends a "PUT" multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">the request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> PutMultipart<TResult>(string token, string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return RequestMultipart<TResult>(token, "PUT", path, parameters);
        }

        /// <summary>
        /// Sends a "PUT" multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">the request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> PutMultipart<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return RequestMultipart<TResult, TRequest>(token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreatePutMultipartTask<TResult>(string token, string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return CreateRequestMultipartTask<TResult>(token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreatePutMultipartTask<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestMultipartTask<TResult, TRequest>(token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreatePutMultipartTask<TResult>(string token, Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return CreateRequestMultipartTask(token, callback, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreatePutMultipartTask<TResult, TRequest>(string token, Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestMultipartTask(token, callback, "PUT", path, parameters);
        }

        /* static DELETE */

        /// <summary>
        /// Sends a "DELETE" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> Delete<TResult>(string token, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Request<TResult>(token, "DELETE", path, parameters);
        }

        /// <summary>
        /// Sends a "DELETE" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public static ResponseData<TResult> Delete<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return Request<TResult, TRequest>(token, "DELETE", path, parameters);
        }

        /// <summary>
        /// Creates a "DELETE" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreateDeleteTask<TResult>(string token, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask<TResult>(token, "DELETE", path, parameters);
        }

        /// <summary>
        /// Creates a "DELETE" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task<ResponseData<TResult>> CreateDeleteTask<TResult, TRequest>(string token, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask<TResult, TRequest>(token, "DELETE", path, parameters);
        }

        /// <summary>
        /// Creates a "DELETE" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreateDeleteTask<TResult>(string token, Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask(token, callback, "DELETE", path, parameters);
        }

        /// <summary>
        /// Creates a "DELETE" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public static Task CreateDeleteTask<TResult, TRequest>(string token, Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask(token, callback, "DELETE", path, parameters);
        }

        /* GET */

        /// <summary>
        /// Sends a "GET" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> Get<TResult>(string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Request<TResult>("GET", path, parameters);
        }

        /// <summary>
        /// Sends a "GET" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> Get<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return Request<TResult, TRequest>("GET", path, parameters);
        }

        /// <summary>
        /// Creates a "GET" request task`.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreateGetTask<TResult>(string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask<TResult>(Token, "GET", path, parameters);
        }

        /// <summary>
        /// Creates a "GET" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreateGetTask<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask<TResult, TRequest>(Token, "GET", path, parameters);
        }

        /// <summary>
        /// Creates a "GET" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreateGetTask<TResult>(Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask(Token, callback, "GET", path, parameters);
        }

        /// <summary>
        /// Creates a "GET" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreateGetTask<TResult, TRequest>(Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask(Token, callback, "GET", path, parameters);
        }

        /* POST */

        /// <summary>
        /// Sends a "POST" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> Post<TResult>(string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Request<TResult>("POST", path, parameters);
        }

        /// <summary>
        /// Sends a "POST" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> Post<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return Request<TResult, TRequest>("POST", path, parameters);
        }

        /// <summary>
        /// Sends a "POST" multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> PostMultipart<TResult>(string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return RequestMultipart<TResult>("POST", path, parameters);
        }

        /// <summary>
        /// Sends a "POST" multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> PostMultipart<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return RequestMultipart<TResult, TRequest>("POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreatePostTask<TResult>(string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask<TResult>(Token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreatePostTask<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask<TResult, TRequest>(Token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreatePostTask<TResult>(Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask(Token, callback, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreatePostTask<TResult, TRequest>(Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask(Token, callback, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreatePostMultipartTask<TResult>(string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return CreateRequestMultipartTask<TResult>(Token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreatePostMultipartTask<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestMultipartTask<TResult, TRequest>(Token, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreatePostMultipartTask<TResult>(Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return CreateRequestMultipartTask(Token, callback, "POST", path, parameters);
        }

        /// <summary>
        /// Creates a "POST" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreatePostMultipartTask<TResult, TRequest>(Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestMultipartTask(Token, callback, "POST", path, parameters);
        }

        /* PUT */

        /// <summary>
        /// Sends a "PUT" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> Put<TResult>(string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Request<TResult>("PUT", path, parameters);
        }

        /// <summary>
        /// Sends a "PUT" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> Put<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return Request<TResult, TRequest>("PUT", path, parameters);
        }

        /// <summary>
        /// Sends a "PUT" multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> PutMultipart<TResult>(string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return RequestMultipart<TResult>("PUT", path, parameters);
        }

        /// <summary>
        /// Sends a "PUT" multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> PutMultipart<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return RequestMultipart<TResult, TRequest>("PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreatePutTask<TResult>(string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask<TResult>(Token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreatePutTask<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask<TResult, TRequest>(Token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreatePutTask<TResult>(Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask(Token, callback, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreatePutTask<TResult, TRequest>(Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask(Token, callback, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreatePutMultipartTask<TResult>(string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return CreateRequestMultipartTask<TResult>(Token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreatePutMultipartTask<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestMultipartTask<TResult, TRequest>(Token, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreatePutMultipartTask<TResult>(Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<MultipartFormItem> parameters = null)
        {
            return CreateRequestMultipartTask(Token, callback, "PUT", path, parameters);
        }

        /// <summary>
        /// Creates a "PUT" multipart-form request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreatePutMultipartTask<TResult, TRequest>(Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestMultipartTask(Token, callback, "PUT", path, parameters);
        }

        /* DELETE */

        /// <summary>
        /// Sends a "DELETE" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> Delete<TResult>(string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Request<TResult>("DELETE", path, parameters);
        }

        /// <summary>
        /// Sends a "DELETE" request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        public ResponseData<TResult> Delete<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return Request<TResult, TRequest>("DELETE", path, parameters);
        }

        /// <summary>
        /// Creates a "DELETE" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreateDeleteTask<TResult>(string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask<TResult>(Token, "DELETE", path, parameters);
        }

        /// <summary>
        /// Creates a "DELETE" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task<ResponseData<TResult>> CreateDeleteTask<TResult, TRequest>(string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask<TResult, TRequest>(Token, "DELETE", path, parameters);
        }

        /// <summary>
        /// Creates a "DELETE" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreateDeleteTask<TResult>(Action<ResponseData<TResult>> callback, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return CreateRequestTask(Token, callback, "DELETE", path, parameters);
        }

        /// <summary>
        /// Creates a "DELETE" request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="callback">The callback action.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        public Task CreateDeleteTask<TResult, TRequest>(Action<ResponseData<TResult>> callback, string path, TRequest parameters = null)
            where TRequest : class
        {
            return CreateRequestTask(Token, callback, "DELETE", path, parameters);
        }

        /* static Request */

        /// <summary>
        /// Sends a single request.
        /// </summary>
        /// // <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        private static ResponseData<TResult> Request<TResult>(string token, string method, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            var urlEncoded = method == WebRequestMethods.Http.Post || method == WebRequestMethods.Http.Put;
            var paramsStrings = Internal.JoinParameters(parameters);
            var url = $"{EndpointBase}{path}";

            if (!urlEncoded && !string.IsNullOrEmpty(paramsStrings))
            {
                url = $"{url}?{paramsStrings}";
            }

            var request = WebRequest.Create(url);
            request.Method = method;
            request.Timeout = RequestTimeout;
            request.Headers.Set(TokenKey, token);

            if (urlEncoded && !string.IsNullOrEmpty(paramsStrings))
            {
                var body = Encoding.UTF8.GetBytes(paramsStrings);

                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = body.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(body, 0, body.Length);
                }
            }

            string GetResponseBody(HttpWebResponse webResponse)
            {
                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }

            string responseBody;
            int statusCode;

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                statusCode = (int)response.StatusCode;
                responseBody = GetResponseBody(response);
            }
            catch (WebException e)
            {
                if (e.Response is HttpWebResponse httpResponse)
                {
                    statusCode = (int)httpResponse.StatusCode;
                    responseBody = GetResponseBody(httpResponse);
                }
                else
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                    responseBody = e.Message;
                }
            }

            if (statusCode >= (int)HttpStatusCode.BadRequest)
            {
                return new ResponseData<TResult>
                {
                    Success = false,
                    StatusCode = statusCode,
                    Error = JsonConvert.DeserializeObject<ErrorData>(responseBody),
                };
            }

            return new ResponseData<TResult>
            {
                Success = true,
                StatusCode = statusCode,
                Data = JsonConvert.DeserializeObject<TResult>(responseBody),
            };
        }

        /// <summary>
        /// Sends a single request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        private static ResponseData<TResult> Request<TResult, TRequest>(string token, string method, string path, TRequest parameters)
            where TRequest : class
        {
            var strParams = Internal.ConvertParameters(parameters);
            return Request<TResult>(token, method, path, strParams);
        }

        /// <summary>
        /// Sends a multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        private static ResponseData<TResult> RequestMultipart<TResult>(string token, string method, string path, IReadOnlyCollection<MultipartFormItem> parameters)
        {
            if (parameters == null)
            {
                return null;
            }

            if (!Enum.TryParse(method, out Method methodVal))
            {
                return null;
            }

            if (methodVal != Method.POST && methodVal != Method.PUT)
            {
                return null;
            }

            var url = $"{EndpointBase}{path}";
            var request = new RestRequest
            {
                Method = methodVal,
                Resource = url,
                Timeout = RequestTimeout,
            };

            request.AddHeader(TokenKey, token);

            var multipart = false;

            foreach (var item in parameters)
            {
                if (item.Type == StreamType.Text && item.Value is string strVal)
                {
                    request.AddParameter(item.Name, strVal);
                    continue;
                }

                if (item.Type == StreamType.File && item.Value is FileContent fileContentInfo)
                {
                    var filename = fileContentInfo.Name;
                    var contentType = Internal.DetectMimeType(filename);

                    if (fileContentInfo.Content is Stream stream)
                    {
                        if (stream.Length > MaxFileSize)
                        {
                            return null;
                        }

                        var bytes = Internal.GetBytes(stream).ToArray();
                        if (bytes.Length > MaxFileSize)
                        {
                            return null;
                        }

                        request.AddFileBytes(item.Name, bytes, filename, contentType);
                        multipart = true;
                        continue;
                    }

                    if (fileContentInfo.Content is byte[] buff)
                    {
                        if (buff.Length > MaxFileSize)
                        {
                            return null;
                        }

                        request.AddFileBytes(item.Name, buff, filename, contentType);
                        multipart = true;
                        continue;
                    }

                    if (fileContentInfo.Content is string text)
                    {
                        var bytes = Encoding.ASCII.GetBytes(text);
                        if (bytes.Length > MaxFileSize)
                        {
                            return null;
                        }

                        request.AddFileBytes(item.Name, bytes, filename, contentType);
                        multipart = true;
                        continue;
                    }

                    continue;
                }
            }

            if (multipart)
            {
                request.AlwaysMultipartFormData = multipart;
            }

            var client = new RestClient()
            {
                BaseUrl = new Uri($"{EndpointBase}{path}"),
            };

            var response = client.Execute(request);
            var responseBody = response.Content;
            var statusCode = (int)response.StatusCode;

            if (statusCode >= (int)HttpStatusCode.BadRequest)
            {
                return new ResponseData<TResult>
                {
                    Success = false,
                    StatusCode = statusCode,
                    Error = JsonConvert.DeserializeObject<ErrorData>(responseBody),
                };
            }

            return new ResponseData<TResult>
            {
                Success = true,
                StatusCode = statusCode,
                Data = JsonConvert.DeserializeObject<TResult>(responseBody),
            };
        }

        /// <summary>
        /// Sends a multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        private static ResponseData<TResult> RequestMultipart<TResult, TRequest>(string token, string method, string path, TRequest parameters)
            where TRequest : class
        {
            var multipartParams = Internal.ConvertMultipartFormParameters(parameters);
            return RequestMultipart<TResult>(token, method, path, multipartParams);
        }

        /// <summary>
        /// Sends a single request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        private static Task<ResponseData<TResult>> CreateRequestTask<TResult>(string token, string method, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Task.Run(() => Request<TResult>(token, method, path, parameters));
        }

        /// <summary>
        /// Creates a single request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        private static Task<ResponseData<TResult>> CreateRequestTask<TResult, TRequest>(string token, string method, string path, TRequest parameters = null)
            where TRequest : class
        {
            return Task.Run(() => Request<TResult, TRequest>(token, method, path, parameters));
        }

        /// <summary>
        /// Creates a single request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        private static Task CreateRequestTask<TResult>(string token, Action<ResponseData<TResult>> callback, string method, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Task.Run(() =>
            {
                var result = Request<TResult>(token, method, path, parameters);
                if (callback != null)
                {
                    callback.Invoke(result);
                }
            });
        }

        /// <summary>
        /// Creates a single request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        private static Task CreateRequestTask<TResult, TRequest>(string token, Action<ResponseData<TResult>> callback, string method, string path, TRequest parameters = null)
            where TRequest : class
        {
            return Task.Run(() =>
            {
                var result = Request<TResult, TRequest>(token, method, path, parameters);
                if (callback != null)
                {
                    callback.Invoke(result);
                }
            });
        }

        /// <summary>
        /// Creates a multipart request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        private static Task<ResponseData<TResult>> CreateRequestMultipartTask<TResult>(string token, string method, string path, IReadOnlyCollection<MultipartFormItem> parameters)
        {
            return Task.Run(() => RequestMultipart<TResult>(token, method, path, parameters));
        }

        /// <summary>
        /// Creates a multipart request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        private static Task<ResponseData<TResult>> CreateRequestMultipartTask<TResult, TRequest>(string token, string method, string path, TRequest parameters)
            where TRequest : class
        {
            return Task.Run(() => RequestMultipart<TResult, TRequest>(token, method, path, parameters));
        }

        /// <summary>
        /// Creates a multipart request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        private static Task CreateRequestMultipartTask<TResult>(string token, Action<ResponseData<TResult>> callback, string method, string path, IReadOnlyCollection<MultipartFormItem> parameters)
        {
            return Task.Run(() =>
            {
                var result = RequestMultipart<TResult>(token, method, path, parameters);
                if (callback != null)
                {
                    callback.Invoke(result);
                }
            });
        }

        /// <summary>
        /// Creates a multipart request task.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="token">The API token.</param>
        /// <param name="callback">The callback action.</param>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The task.</returns>
        private static Task CreateRequestMultipartTask<TResult, TRequest>(string token, Action<ResponseData<TResult>> callback, string method, string path, TRequest parameters)
            where TRequest : class
        {
            return Task.Run(() =>
            {
                var result = RequestMultipart<TResult, TRequest>(token, method, path, parameters);
                if (callback != null)
                {
                    callback.Invoke(result);
                }
            });
        }

        /* Request */

        /// <summary>
        /// Sends a single request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        private ResponseData<TResult> Request<TResult>(string method, string path, IReadOnlyCollection<KeyValuePair<string, string>> parameters = null)
        {
            return Request<TResult>(Token, method, path, parameters);
        }

        /// <summary>
        /// Sends a single request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        private ResponseData<TResult> Request<TResult, TRequest>(string method, string path, TRequest parameters)
            where TRequest : class
        {
            return Request<TResult, TRequest>(Token, method, path, parameters);
        }

        /// <summary>
        /// Sends a multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        private ResponseData<TResult> RequestMultipart<TResult>(string method, string path, IReadOnlyCollection<MultipartFormItem> parameters)
        {
            return RequestMultipart<TResult>(Token, method, path, parameters);
        }

        /// <summary>
        /// Sends a multipart-form request.
        /// </summary>
        /// <typeparam name="TResult">The response data type.</typeparam>
        /// <typeparam name="TRequest">The request parameters data type.</typeparam>
        /// <param name="method">The request method.</param>
        /// <param name="path">The request path.</param>
        /// <param name="parameters">The request parameters.</param>
        /// <returns>The response data.</returns>
        private ResponseData<TResult> RequestMultipart<TResult, TRequest>(string method, string path, TRequest parameters)
            where TRequest : class
        {
            return RequestMultipart<TResult, TRequest>(Token, method, path, parameters);
        }
    }
}
