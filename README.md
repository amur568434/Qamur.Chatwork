# Qamur.Chatwork
Chatwork API client class library for .NET.

## Implementation
- Compatible with .Net Standard 2.0.
- This library supports Chatwork API version 2.
- The implementation is based on the following documents<br>
[Chatwork API Documentation - Endpoints (Japanese)](https://developer.chatwork.com/ja/endpoints.html)<br>
[Chatwork API Documentation (English)](https://download.chatwork.com/ChatWork_API_Documentation.pdf)<br>
_English documentation seems not to be maintained._

## Install

Search for and install **Qamur.Chatwork** on **nuget.org**.

## Usage

The example of handling requests and responses.

### Send a request

The target endpoint: [GET] /my/tasks

**Common part**
```
using Qamur.Chatwork;
using Qamur.Chatwork.Data;
using Qamur.Chatwork.ObjectValues;
using Qamur.Chatwork.Parameters;
    ⋮
var token = "your_chatwork_api_token";
    ⋮
```
---
**Usage 1.** Send a request and receive a response synchronously.

**Dynamic method**
```
var client = ChatworkClient(token);
    ⋮
var parameters = new MyTasksParameters { Status = TaskStatusValue.Open };
var response = client.GetMyTasks(parameters);
    ⋮ (see "Handling a response")
```
**Static method**
```
var parameters = new MyTasksParameters { Status = TaskStatusValue.Open };
var response = ChatworkClient.GetMyTasks(Token, parameters);
    ⋮ (see "Handling a response")
```
---
**Usage 2.** Send a request and receive a response asynchronously.

**Dynamic method**
```
var client = ChatworkClient(token);
    ⋮
var parameters = new MyTasksParameters { Status = TaskStatusValue.Open };
var response = await Client.GetMyTasksAsync(parameters)
    .ConfigureAwait(false);
    ⋮ (see "Handling a response")
```
**Static method**
```
var parameters = new MyTasksParameters { Status = TaskStatusValue.Open };
var response = await ChatworkClient.GetMyTasksAsync(Token, parameters)
    .ConfigureAwait(false);
    ⋮ (see "Handling a response")
```
---
**Usage 3.** Send a request and receive a response with a callback action asynchronously.

**Dynamic method**
```
var client = ChatworkClient(token);
    ⋮
var parameters = new MyTasksParameters { Status = TaskStatusValue.Open };
client.GetTasksAsync(
    response =>
    {
        ⋮ (see "Handling a response")
    },
    parameters);
```
**Static method**
```
var parameters = new MyTasksParameters { Status = TaskStatusValue.Open };
ChatworkClient.GetTasksAsync(
    token,
    response =>
    {
        ⋮ (see "Handling a response")
    },
    parameters);
```

### Handling a response

**When the request succeeds.**
- response.Success is true.
- response.StatusCode is usually 200.
- response.Error is null.
- The type of response.Data is System.Collections.Generic.**IReadOnlyCollection**&lt;Qamur.Chatwork.Data.**MyTaskData**&gt;.

```
using System.Linq;
    ⋮
if (response.Success)
{
    if (response.Data == null)
    {
        // No mytasks of the owner.
    }
    else if (response.Data.Any())
    {
        // Some mytasks of the owner.
    }
}
```

**When the request failed.**
- response.Success is false.
- response.Data is null.
- The type of response.Error is System.Collections.Generic.**IReadOnlyCollection**&lt;**string**&gt;.

```
using System.Linq;
    ⋮
if (!response.Success)
{
    if (response.Error == null)
    {
        // No error messages.
    }
    else of (response.Data.Any())
    {
        // Some error messages.
    }
}
```

## License
[Apache License, Version 2.0](./LICENSE)

## Author
[Kohei Oizumi](https://github.com/amur568434)
